using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;

namespace AppLibrary
{
    public partial class FormTacGia : DevExpress.XtraEditors.XtraForm
    {
        #region *** VAR - CLASS *************************************************
        private int vitri = 0; // Vị trí dòng đang chọn trên grid
        private bool isAddMode = false; // Cờ đánh dấu đang ở chế độ THÊM mới
        private Dictionary<int, DataRow> editedRows = new Dictionary<int, DataRow>(); // Lưu các dòng đã chỉnh sửa (chưa Ghi)

        // Stack cho Undo và Redo
        private Stack<LogAction> undoStack = new Stack<LogAction>();
        private Stack<LogAction> redoStack = new Stack<LogAction>();

        // Hằng số tên bảng và cột PK
        private const string TABLE_NAME = "TACGIA";
        private const string PK_COLUMN_NAME = "MATACGIA";

        bool isNhanVien = (Program.mGroup == "NHANVIEN"); // Chỉ NHANVIEN mới có quyền chỉnh sửa
        #endregion

        #region *** INIT FROM *****************************************
        public FormTacGia()
        {
            InitializeComponent();
        }

        private void FormTacGia_Load(object sender, EventArgs e)
        {   // Tạm thời tắt kiểm tra ràng buộc khóa ngoại khi Fill
            qLTVDataSet.EnforceConstraints = false;
            // Load dữ liệu từ Database lên DataSet
            this.tACGIATableAdapter.Connection.ConnectionString = Program.connstr;
            this.tACGIATableAdapter.Fill(this.qLTVDataSet.TACGIA);

            this.dAUSACHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dAUSACHTableAdapter.Fill(this.qLTVDataSet.DAUSACH);

            this.tACGIA_SACHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.tACGIA_SACHTableAdapter.Fill(this.qLTVDataSet.TACGIA_SACH);

            // Cấu hình giao diện GridView
            gvTacGia.OptionsDetail.EnableMasterViewMode = false; // Không hiển thị view chi tiết
            gvTacGia.OptionsView.ShowGroupPanel = false;      // Ẩn panel gom nhóm
            gvTacGia.OptionsFind.AlwaysVisible = true;          // Hiện ô tìm kiếm
            gvTacGia.OptionsFind.FindNullPrompt = "Nhập thông tin tìm kiếm..."; // Placeholder ô tìm kiếm

            // --- Phân quyền ---
            btnThem.Enabled = btnGhi.Enabled = btnXoa.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnIn.Enabled = isNhanVien;
            contextMenuStrip1.Enabled = isNhanVien;    // Cho phép menu chuột phải (nếu có)
            pnInputTacGia.Visible = isNhanVien;        // Cho phép nhập liệu vào panel input
            if (isNhanVien)
            {
                // Cập nhật trạng thái ban đầu của các nút
                UpdateButtonStates();
                btnRefresh.Enabled = btnGhi.Enabled = false;
                // Nếu không có dữ liệu, ẩn panel nhập liệu ban đầu
                if (bdsTacGia.Count == 0) pnInputTacGia.Visible = false;
            }


            // Gắn sự kiện TextChanged cho tất cả các TextEdit trong panel Input
            foreach (Control control in pnInputTacGia.Controls)
            {
                if (control is TextEdit textEdit)
                {
                    textEdit.TextChanged += AnyTextBox_TextChanged;
                }
            }
            // ----------------------------------------------------------------------------------------
            // Cấu hình cho Grid Tác Giả Sách (DataGridView)
            this.tACGIA_SACHDataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.tACGIA_SACHDataGridView_EditingControlShowing);
            btnGhiTGS.Enabled = false; // Nút Ghi TGS ban đầu vô hiệu hóa
            btnXoaTGS.Enabled = (bdsTacGia_Sach.Count >= 0); // Nút Xóa TGS chỉ bật khi có dữ liệu

            // Sự kiện để bật nút Ghi TGS khi có thay đổi
            tACGIA_SACHDataGridView.CellValueChanged += tACGIA_SACHDataGridView_CellValueChanged;
            tACGIA_SACHDataGridView.CurrentCellDirtyStateChanged += tACGIA_SACHDataGridView_CurrentCellDirtyStateChanged;
            bdsTacGia_Sach.ListChanged += bdsTacGia_Sach_ListChanged;
        }

        // Cập nhật trạng thái enable/disable của các nút trên thanh barManager
        private void UpdateButtonStates()
        {
            bool hasData = bdsTacGia.Count > 0;
            // isAddMode = true: Trong chế độ thêm mới
            btnThem.Enabled = !isAddMode;
            btnXoa.Enabled = !isAddMode && hasData;
            // edited row - Nếu có dòng chỉnh sửa
            btnGhi.Enabled = isAddMode || editedRows.Count > 0;
            // undoStack.Count > 0: có thao tác để phục hồi
            // redoStack.Count > 0: có thao tác để làm lại
            btnUndo.Enabled = isAddMode || undoStack.Count > 0;
            btnRedo.Enabled = redoStack.Count > 0;
            btnRefresh.Enabled = !isAddMode && editedRows.Count > 0;
            btnIn.Enabled = !isAddMode;
            btnThoat.Enabled = !isAddMode;
        }

        // Sự kiện xảy ra khi text trong bất kỳ TextEdit nào trên pnInputTacGia thay đổi
        private void AnyTextBox_TextChanged(object sender, EventArgs e)
        {   // Nếu đang ở chế độ thêm, hoặc không có dòng hiện tại, hoặc bindingsource rỗng -> bỏ qua
            if (isAddMode || bdsTacGia.Current == null || bdsTacGia.Count == 0) return;
            int currentPos = bdsTacGia.Position; // Lấy vị trí dòng hiện tại
            var currentRow = ((DataRowView)bdsTacGia.Current).Row; // Lấy DataRow tương ứng với dòng hiện tại đang chọn
            // Nếu dòng này chưa được đánh dấu là đã sửa, thêm nó vào dictionary editedRows
            if (!editedRows.ContainsKey(currentPos))
            {   // Chỉ thêm vào nếu nó chưa bị sửa hoặc trạng thái là Unchanged/Modified
                if (currentRow.RowState == DataRowState.Unchanged || currentRow.RowState == DataRowState.Modified)
                {
                    editedRows[currentPos] = currentRow;
                }
            }
            // Bật nút Ghi và Refresh để cho phép lưu hoặc hủy thay đổi
            btnGhi.Enabled = isNhanVien;
            btnRefresh.Enabled = !isAddMode;
            if (bdsTacGia.Position == 0)
            {
                btnRefresh.Enabled = false;
            }
        }
        #endregion

        #region *** SỰ KIỆN NÚT CHỨC NĂNG *****************************************
        // ***** ✅ Sự kiện nút THÊM *****
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsTacGia.Position; // Lưu lại vị trí hiện tại trước khi thêm
            isAddMode = true;           // Bật chế độ Thêm

            bdsTacGia.AddNew();         // Thêm một dòng mới vào BindingSource (và DataTable)

            setUIForAddMode(false, "Mã tác giả tự động thêm");
        }

        // **** ✅ Sự kiện nút XÓA *****
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   // Kiểm tra ràng buộc: Không cho xóa nếu Tác giả này đang có sách liên kết
            if (bdsTacGia_Sach.Count > 0)
            {
                XtraMessageBox.Show("Tác giả đang tồn tại trong các đầu sách, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra có dòng được chọn không
            if (bdsTacGia.Current == null)
            {
                XtraMessageBox.Show("Vui lòng chọn tác giả cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Xác nhận xóa
            if (XtraMessageBox.Show("Bạn có thực sự muốn xóa tác giả này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                vitri = bdsTacGia.Position; // Lưu vị trí dòng sẽ xóa
                LogAction action = null;    // Khai báo action để lưu thông tin undo
                object deletedPrimaryKey = null; // Lưu khóa chính của dòng bị xóa
                try
                {   // Lấy dòng hiện tại từ BindingSource
                    var currentRow = ((DataRowView)bdsTacGia.Current).Row;
                    deletedPrimaryKey = currentRow[PK_COLUMN_NAME]; // Lấy khóa chính

                    // **CHUẨN BỊ DỮ LIỆU CHO UNDO (LogAction)**
                    action = new LogAction
                    {
                        Type = LogAction.ActionType.Delete,
                        TableName = TABLE_NAME,
                        PrimaryKeyColumnName = PK_COLUMN_NAME,
                        Positions = new List<int> { vitri }
                        // Lưu lại toàn bộ dữ liệu của dòng SẮP BỊ XÓA vào DataList để có thể khôi phục (INSERT lại) khi Undo
                    };
                    var originalData = new Dictionary<string, object>();
                    foreach (DataColumn col in currentRow.Table.Columns)
                    {
                        originalData[col.ColumnName] = currentRow[col]; // Lấy giá trị hiện tại
                    }
                    action.DataList.Add(originalData);

                    // **THỰC HIỆN XÓA TRÊN BINDINGSOURCE VÀ DATABASE**
                    bdsTacGia.RemoveCurrent();
                    // Ghi thay đổi xuống Database (quan trọng: làm điều này trong try-catch)
                    this.tACGIATableAdapter.Update(this.qLTVDataSet.TACGIA);

                    // **XÓA THÀNH CÔNG -> PUSH VÀO UNDO STACK**
                    undoStack.Push(action);
                    redoStack.Clear();  // Xóa redo stack khi có hành động mới
                    XtraMessageBox.Show("Xóa tác giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // **XÓA THẤT BẠI**
                    XtraMessageBox.Show("Lỗi xóa tác giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Nếu có lỗi xảy ra, phục hồi lại bảng TACGIA từ DataSet để đảm bảo khớp dữ liệu
                    this.tACGIATableAdapter.Fill(this.qLTVDataSet.TACGIA);
                    // Cố gắng đặt lại vị trí con trỏ
                    int foundPos = bdsTacGia.Find(PK_COLUMN_NAME, deletedPrimaryKey);
                    if (foundPos >= 0) bdsTacGia.Position = foundPos;
                    else bdsTacGia.Position = vitri; // Về vị trí cũ nếu không tìm thấy
                    // Không push action vào undoStack vì thao tác thất bại
                    return;
                }
                finally
                {   // cập nhật trạng thái các Button
                    UpdateButtonStates();
                }
            }
        }

        // **** ✅ Sự kiện nút GHI *****
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 1. Kiểm tra dữ liệu nhập hợp lệ
            if (!checkValidInput()) return;

            // 2. Xác thực và kết thúc chỉnh sửa trên BindingSource
            try
            {
                this.Validate(); // Đảm bảo các control đã validate
                bdsTacGia.EndEdit(); // Lưu các thay đổi từ control vào DataRowView hiện tại
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi kết thúc chỉnh sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dòng hiện tại (sau khi EndEdit)
            var currentView = bdsTacGia.Current as DataRowView;
            if (currentView == null)
            {
                XtraMessageBox.Show("Không có dòng dữ liệu hợp lệ để ghi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var currentRow = currentView.Row;

            // 3. Xử lý theo chế độ (Thêm mới hoặc Chỉnh sửa)
            try
            {
                // --------------------- CHẾ ĐỘ THÊM MỚI ---------------------
                if (isAddMode)
                {
                    // Chuẩn hóa họ tên trước khi lưu
                    currentRow["HOTENTG"] = ChuanHoaHoTen(currentRow["HOTENTG"] as string);

                    // Lấy mã tác giả mới (nếu là tự động tăng)
                    int newId = GetNextAuthorId();
                    if (newId <= 0)
                    {
                        XtraMessageBox.Show("Không thể tạo mã tác giả mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Chuẩn bị dữ liệu để lưu vào LogAction (dữ liệu ĐÃ LƯU thành công)
                    var savedData = new Dictionary<string, object>();
                    foreach (DataColumn col in currentRow.Table.Columns)
                    {
                        savedData[col.ColumnName] = (col.ColumnName == PK_COLUMN_NAME) ? newId : currentRow[col];
                    }

                    // **THỰC HIỆN INSERT VÀO DATABASE**
                    // Gọi hàm thực thi INSERT trực tiếp (không cần tạo SQL trước)
                    if (!ExecuteInsert(TABLE_NAME, savedData))
                    {
                        // Nếu Insert thất bại, hiển thị lỗi và thoát
                        XtraMessageBox.Show("Thêm tác giả thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Cần xử lý hủy bỏ dòng mới thêm trên UI nếu insert lỗi
                        bdsTacGia.CancelEdit();
                        if (bdsTacGia.Current != null && ((DataRowView)bdsTacGia.Current).IsNew)
                        {
                            bdsTacGia.RemoveCurrent();
                        }
                        return;
                    }

                    // **INSERT THÀNH CÔNG -> Tạo và Push LogAction**
                    var action = new LogAction
                    {
                        Type = LogAction.ActionType.Add,
                        TableName = TABLE_NAME,
                        PrimaryKeyColumnName = PK_COLUMN_NAME,
                        DataList = new List<Dictionary<string, object>> { savedData }, // Lưu dữ liệu đã insert thành công
                        Positions = new List<int> { bdsTacGia.Position } // Lưu vị trí dòng mới
                    };
                    undoStack.Push(action);
                    redoStack.Clear();
                    ReloadData();
                    // Đặt vị trí về dòng mới thêm (Tìm lại bằng ID để chắc chắn)
                    bdsTacGia.Position = bdsTacGia.Find(PK_COLUMN_NAME, newId);
                    XtraMessageBox.Show($"Thêm tác giả với ID-{newId} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // --------------------- CHẾ ĐỘ CHỈNH SỬA ---------------------
                else if (editedRows.Count > 0)
                {
                    // **CHUẨN BỊ DỮ LIỆU CHO UNDO (LogAction)**
                    var action = new LogAction
                    {
                        Type = LogAction.ActionType.Edit,
                        TableName = TABLE_NAME,
                        PrimaryKeyColumnName = PK_COLUMN_NAME,
                    };

                    // Lấy danh sách các dòng đã sửa thực sự từ DataTable
                    List<DataRow> changedRows = new List<DataRow>();
                    foreach (var row in editedRows.Values)
                    {   // Chỉ xử lý những dòng thực sự đã thay đổi (Modified)
                        if (row.RowState == DataRowState.Modified)
                        {
                            // Chuẩn hóa họ tên nếu cột này bị thay đổi
                            if (row.HasVersion(DataRowVersion.Original) &&
                               !Equals(row["HOTENTG", DataRowVersion.Current], row["HOTENTG", DataRowVersion.Original]))
                            {
                                row["HOTENTG"] = ChuanHoaHoTen(row["HOTENTG"] as string);
                            }
                            changedRows.Add(row);
                        }
                    }

                    if (changedRows.Count == 0)
                    {   // Không có dòng nào thực sự thay đổi sau EndEdit
                        XtraMessageBox.Show("Không có thay đổi nào để ghi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        editedRows.Clear(); // Xóa danh sách theo dõi
                        ResetOriginalUI(); // Reset UI
                        return;
                    }

                    // Thu thập dữ liệu gốc và hiện tại cho các dòng đã thay đổi
                    foreach (DataRow row in changedRows)
                    {
                        var currentData = new Dictionary<string, object>();
                        var originalData = new Dictionary<string, object>();
                        int position = bdsTacGia.Find(PK_COLUMN_NAME, row[PK_COLUMN_NAME]); // Tìm vị trí thực tế của dòng

                        foreach (DataColumn col in row.Table.Columns)
                        {
                            // Lấy dữ liệu hiện tại (sau khi EndEdit)
                            currentData[col.ColumnName] = row[col, DataRowVersion.Current];
                            // Lấy dữ liệu gốc (trước khi sửa)
                            if (row.HasVersion(DataRowVersion.Original))
                            {
                                /*
                                   DataRowVersion.Original: Giá trị ban đầu của dòng khi được tải từ database
                                   DataRowVersion.Current: Giá trị hiện tại sau khi người dùng chỉnh sửa
                                   DataRowVersion.Proposed: Giá trị được đề xuất(trong lúc sửa, trước khi gọi EndEdit())
                                   DataRowVersion.Default: Phiên bản mặc định dựa vào trạng thái dòng(đang thêm/ sửa / gốc)
                                */
                                originalData[col.ColumnName] = row[col, DataRowVersion.Original];
                            }
                            else
                            {
                                // Trường hợp hiếm gặp: dòng không có bản gốc? Lấy bản hiện tại làm gốc.
                                originalData[col.ColumnName] = row[col, DataRowVersion.Current];
                            }
                        }
                        action.DataList.Add(currentData);      // Dữ liệu mới (sau khi sửa)
                        action.OriginalDataList.Add(originalData); // Dữ liệu cũ (trước khi sửa)
                        if (position >= 0) action.Positions.Add(position); // Thêm vị trí nếu tìm thấy
                    }


                    // **THỰC HIỆN UPDATE XUỐNG DATABASE (Dùng TableAdapter)**
                    // TableAdapter.Update sẽ tự động tìm các dòng Modified và gửi lệnh UPDATE
                    int rowsAffected = this.tACGIATableAdapter.Update(this.qLTVDataSet.TACGIA);

                    if (rowsAffected > 0) // Kiểm tra xem có dòng nào được cập nhật thành công không
                    {
                        // **UPDATE THÀNH CÔNG -> Push LogAction**
                        undoStack.Push(action);
                        redoStack.Clear();
                        XtraMessageBox.Show($"Cập nhật {rowsAffected} tác giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // AcceptChanges cho các dòng đã sửa để cập nhật trạng thái thành Unchanged
                        // TableAdapter.Update thường đã làm điều này, nhưng gọi lại để chắc chắn
                        this.qLTVDataSet.TACGIA.AcceptChanges();
                    }
                    else if (rowsAffected == 0 && changedRows.Count > 0)
                    {
                        // Có dòng đánh dấu sửa đổi nhưng không có dòng nào được Update (có thể do lỗi hoặc concurrency)
                        XtraMessageBox.Show("Không có tác giả nào được cập nhật. Có thể dữ liệu đã bị thay đổi bởi người khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Cân nhắc ReloadData() để lấy dữ liệu mới nhất
                        ReloadData();
                    }
                    // Nếu rowsAffected < 0 là lỗi, nhưng Update thường ném Exception
                }
                // 4. Reset UI sau khi Ghi thành công
                ResetOriginalUI();

            }
            catch (Exception ex)
            {
                // 5. Xử lý lỗi nếu có
                XtraMessageBox.Show("Lỗi ghi dữ liệu: " + ex.Message + (ex.InnerException != null ? "\nInner Exception: " + ex.InnerException.Message : ""), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Nếu đang Thêm mới mà lỗi -> hủy dòng mới thêm trên UI
                if (isAddMode)
                {
                    bdsTacGia.CancelEdit(); // Hủy các thay đổi trên control
                    if (bdsTacGia.Current != null && ((DataRowView)bdsTacGia.Current).IsNew)
                    {
                        bdsTacGia.RemoveCurrent(); // Xóa dòng mới khỏi BindingSource
                    }
                    isAddMode = false; // Thoát chế độ thêm
                    ResetOriginalUI(); // Reset giao diện
                }
                else
                {   // Nếu đang sửa mà lỗi -> Reload lại data để loại bỏ thay đổi trên UI
                    ReloadData();
                }
                return;
            }
            finally
            {
                // 6. Dọn dẹp và cập nhật trạng thái nút
                editedRows.Clear();   // Xóa danh sách các dòng đã sửa (dù thành công hay lỗi)
                UpdateButtonStates(); // Cập nhật trạng thái các nút
            }
        }

        // **** ✅ Sự kiện nút UNDO *****
        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {    // Nếu đang ở mode Add mà nhấn Undo -> Coi như Cancel Add
            if (isAddMode || undoStack.Count == 0)
            {
                CancelAddAction();
                ResetOriginalUI();
                UpdateButtonStates();
                return;
            }
            bool success = false; // Cờ đánh dấu thành công
            LogAction action = undoStack.Pop(); // Lấy hành động gần nhất từ stack undo
            try
            {
                // Thực hiện hành động ngược lại dựa vào loại action
                switch (action.Type)
                {
                    case LogAction.ActionType.Add: // Undo Add -> Delete
                        List<object> pksToDelete = action.GetPrimaryKeys(); // Lấy PK từ DataList (dữ liệu đã thêm)
                        if (pksToDelete.Count > 0)
                        {
                            success = ExecuteDelete(action.TableName, action.PrimaryKeyColumnName, pksToDelete[0]);
                        }
                        break;

                    case LogAction.ActionType.Edit: // Undo Edit -> Update về giá trị gốc
                        success = true;
                        List<object> pksToUpdateUndo = action.GetPrimaryKeys(); // Lấy PK từ DataList (dữ liệu sau khi sửa)
                        if (pksToUpdateUndo.Count != action.OriginalDataList.Count)
                        {   // ismatch in count of primary keys and data list.");
                            success = false;
                        }
                        else
                        {
                            for (int i = 0; i < pksToUpdateUndo.Count; i++)
                            {   // Cập nhật về giá trị gốc (OriginalDataList) dựa vào PK
                                if (!ExecuteUpdate(action.TableName, action.PrimaryKeyColumnName, pksToUpdateUndo[i], action.OriginalDataList[i]))
                                {   // Nếu thất bại nếu 1 dòng lỗi -> STOP
                                    success = false;
                                    break;
                                }
                            }
                        }
                        break;

                    case LogAction.ActionType.Delete: // Undo Delete -> Insert lại dữ liệu gốc
                        success = true;
                        if (action.DataList.Count > 0)
                        {   // DataList của Delete action chứa dữ liệu gốc
                            for (int i = 0; i < action.DataList.Count; i++)
                            {
                                if (!ExecuteInsert(action.TableName, action.DataList[i]))
                                {
                                    success = false;
                                    break;
                                }
                            }
                        }
                        else { success = false; } // Không có dữ liệu để insert lại
                        break;

                }

                // Xử lý sau khi thực thi hành động ngược
                if (success)
                {
                    redoStack.Push(action); // Đưa hành động vào redo stack nếu thành công
                    ReloadData();          // Tải lại dữ liệu để cập nhật Grid
                    XtraMessageBox.Show("Hoàn tác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // UNDO VỊ TRÍ CON TRỎ
                    try
                    {
                        if (action.Positions.Count > 0)
                        {
                            int targetPosition = action.Positions[0];
                            if (action.Type == LogAction.ActionType.Delete)
                            {   // // TÌM VỊ TRÍ BẰNG FK
                                object pkToFind = action.GetPrimaryKeys().FirstOrDefault();
                                if (pkToFind != null)
                                {
                                    int foundPos = bdsTacGia.Find(action.PrimaryKeyColumnName, pkToFind);
                                    if (foundPos >= 0) targetPosition = foundPos;
                                }
                            }
                            // Đảm bảo vị trí hợp lệ
                            targetPosition = Math.Max(0, Math.Min(targetPosition, bdsTacGia.Count - 1));
                            if (bdsTacGia.Count > 0) bdsTacGia.Position = targetPosition;
                        }
                    }
                    catch (Exception)
                    {
                        //Console.WriteLine("Error restoring position after Undo: " + posEx.Message);
                    }

                }
                else
                {   // Nếu thất bại, không push vào redoStack, hiển thị lỗi
                    undoStack.Push(action); // Đẩy lại vào Undo Stack để thử lại? (Cẩn thận vòng lặp vô hạn)
                    XtraMessageBox.Show("Hoàn tác thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {   // Đẩy lại action vào stack nếu có lỗi nghiêm trọng xảy ra
                if (action != null) undoStack.Push(action);
                XtraMessageBox.Show("Lỗi khi hoàn tác: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {   // RESET UI và cập nhật trạng thái nút
                ResetOriginalUI();
                UpdateButtonStates();
            }
        }

        // **** ✅ Sự kiện nút REDO *****
        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (redoStack.Count == 0) return; // Không có gì để redo
            bool success = false;
            LogAction action = redoStack.Pop(); // Lấy hành động từ stack redo
            try
            {   // Thực hiện lại hành động gốc
                switch (action.Type)
                {
                    case LogAction.ActionType.Add: // Redo Add -> Insert lại dữ liệu đã thêm
                        success = true;
                        if (action.DataList.Count > 0)
                        {
                            for (int i = 0; i < action.DataList.Count; i++)
                            {
                                if (!ExecuteInsert(action.TableName, action.DataList[i]))
                                {
                                    success = false;
                                    break;
                                }
                            }
                        }
                        else { success = false; }
                        break;

                    case LogAction.ActionType.Edit: // Redo Edit -> Update lại giá trị đã sửa
                        success = true;
                        List<object> pksToUpdateRedo = action.GetPrimaryKeys(); // Lấy PK từ DataList (dữ liệu sau sửa)
                        if (pksToUpdateRedo.Count != action.DataList.Count)
                        {   //Redo Edit Error: Mismatch between PKs and current data count
                            success = false;
                        }
                        else
                        {
                            for (int i = 0; i < pksToUpdateRedo.Count; i++)
                            {   // Cập nhật về giá trị mới (DataList) dựa vào PK
                                if (!ExecuteUpdate(action.TableName, action.PrimaryKeyColumnName, pksToUpdateRedo[i], action.DataList[i]))
                                {
                                    success = false;
                                    break;
                                }
                            }
                        }
                        break;

                    case LogAction.ActionType.Delete: // Redo Delete -> Delete lại dữ liệu
                        List<object> pksToDeleteRedo = action.GetPrimaryKeys(); // Lấy PK từ DataList (dữ liệu gốc trước khi xóa)
                        if (pksToDeleteRedo.Count > 0)
                        {
                            success = ExecuteDelete(action.TableName, action.PrimaryKeyColumnName, pksToDeleteRedo[0]); // Giả sử chỉ 1 dòng
                        }
                        break;
                }

                // Xử lý sau khi thực thi lại hành động
                if (success)
                {
                    undoStack.Push(action); // Đưa hành động trở lại undo stack
                    ReloadData();          // Tải lại dữ liệu
                    XtraMessageBox.Show("Làm lại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // KHÔI PHỤC VỊ TRÍ CON TRỎ
                    try
                    {
                        if (action.Positions.Count > 0)
                        {
                            int targetPosition = action.Positions[0];
                            if (action.Type == LogAction.ActionType.Add || action.Type == LogAction.ActionType.Edit)
                            {
                                // TÌM VỊ TRÍ BẰNG FK
                                object pkToFind = action.GetPrimaryKeys().LastOrDefault();
                                if (pkToFind != null)
                                {
                                    int foundPos = bdsTacGia.Find(action.PrimaryKeyColumnName, pkToFind);
                                    if (foundPos >= 0) targetPosition = foundPos;
                                }
                            }
                            // Đảm bảo vị trí hợp lệ
                            targetPosition = Math.Max(0, Math.Min(targetPosition, bdsTacGia.Count - 1));
                            if (bdsTacGia.Count > 0) bdsTacGia.Position = targetPosition;
                        }
                    }
                    catch (Exception)
                    {
                        //Console.WriteLine("Error restoring position after Redo: " + posEx.Message);
                    }
                }
                else
                {   // Nếu thất bại, đẩy lại redo stack và báo lỗi
                    redoStack.Push(action); // Đẩy lại để thử lại?
                    XtraMessageBox.Show("Làm lại thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {   // Đẩy lại action vào redoStack nếu có lỗi nghiêm trọng
                if (action != null) redoStack.Push(action);
                XtraMessageBox.Show("Lỗi khi làm lại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ResetOriginalUI();
                UpdateButtonStates();
            }
        }

        // **** ✅ Sự kiện nút REFRESH *****
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!isNhanVien && bdsTacGia.Count >= 0)
            {
                if (XtraMessageBox.Show("Bạn có muốn làm mới không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bdsTacGia.Position = 0;
                    return;
                }
            }

            if (editedRows.Count > 0)
            {
                if (XtraMessageBox.Show("Bạn có muốn hủy bỏ các thay đổi chưa lưu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.tACGIATableAdapter.Connection.ConnectionString = Program.connstr;
                    this.tACGIATableAdapter.Fill(this.qLTVDataSet.TACGIA);
                }
            }
            ResetOriginalUI();
            UpdateButtonStates();
            btnGhi.Enabled = btnRefresh.Enabled = false;
        }

        // **** Sự kiện nút THOÁT *****
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   // Kiểm tra nếu có thay đổi chưa lưu trước khi thoát
            if (editedRows.Count > 0)
            {
                if (XtraMessageBox.Show("Bạn có thay đổi chưa lưu. Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            this.Close();
        }

        // **** Sự kiện nút IN *****
        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   // TODO: Thêm code xử lý in danh sách tác giả (sử dụng XtraReport)
            XtraMessageBox.Show("Chức năng In đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region *** HÀM HỖ TRỢ NÚT CHỨC NĂNG ********************************************
        // Hàm hủy thao tác Thêm đang thực hiện
        private void CancelAddAction()
        {
            if (!isAddMode) return; // Chỉ hủy khi đang ở mode Add
            bdsTacGia.CancelEdit();
            if (bdsTacGia.Current != null && ((DataRowView)bdsTacGia.Current).IsNew)
            {   // Đảm bảo dòng hiện tại là dòng mới và xóa nó đi
                bdsTacGia.RemoveCurrent();
            }
            if (vitri >= 0 && vitri < bdsTacGia.Count)
            {   // Quay về vị trí trước khi nhấn Thêm
                bdsTacGia.Position = vitri;
            }
            ResetOriginalUI(); // cancel
        }

        // Hàm tải lại dữ liệu cho các BindingSource chính
        private void ReloadData()
        {
            try
            {    // Lưu lại vị trí và ID hiện tại để cố gắng khôi phục sau khi tải lại
                int currentPosition = bdsTacGia.Position;
                object currentId = null;
                if (currentPosition >= 0 && bdsTacGia.Current != null)
                {
                    currentId = ((DataRowView)bdsTacGia.Current)[PK_COLUMN_NAME];
                }

                // Tải lại dữ liệu cho các bảng liên quan
                this.tACGIATableAdapter.Fill(this.qLTVDataSet.TACGIA);
                this.dAUSACHTableAdapter.Fill(this.qLTVDataSet.DAUSACH);
                this.tACGIA_SACHTableAdapter.Fill(this.qLTVDataSet.TACGIA_SACH);

                // Cố gắng khôi phục vị trí
                if (currentId != null)
                {
                    int newPosition = bdsTacGia.Find(PK_COLUMN_NAME, currentId);
                    if (newPosition >= 0)
                    {
                        bdsTacGia.Position = newPosition;
                    }
                    else if (bdsTacGia.Count > 0)
                    {   // Nếu không tìm thấy ID cũ (ví dụ: bị xóa), về vị trí gần nhất
                        bdsTacGia.Position = Math.Max(0, Math.Min(currentPosition, bdsTacGia.Count - 1));
                    }
                }
                else if (bdsTacGia.Count > 0)
                {   // Nếu không có ID cũ, về vị trí đầu tiên
                    bdsTacGia.Position = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm lấy ID tự động tăng tiếp theo (nếu cần)
        private int GetNextAuthorId()
        {
            // Hàm này vẫn giữ nguyên logic cũ để lấy MAX + 1
            if (Program.KetNoi() == 0) return -1;
            int nextId = -1;
            try
            {
                using (var cmd = new SqlCommand($"SELECT ISNULL(MAX([{PK_COLUMN_NAME}]), 0) + 1 FROM [{TABLE_NAME}]", Program.conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        nextId = Convert.ToInt32(result);
                    }
                    else
                    {
                        nextId = 1; // Nếu bảng trống, bắt đầu từ 1
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi lấy mã tác giả tiếp theo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nextId = -1;
            }
            finally
            {
                if (Program.conn.State == ConnectionState.Open) Program.conn.Close();
            }
            return nextId;
        }

        private void setUIForAddMode(bool maTacGiaVisible, string maTacGiaLabel)
        {
            gcBangTacGiaSach.Enabled = !isAddMode;
            txtMaTacGia.Visible = maTacGiaVisible;
            lblMaTacGia.Text = maTacGiaLabel;
            txtHoTen.Focus();
            btnRefresh.Enabled = !isAddMode;
            UpdateButtonStates();
        }
        private void ResetOriginalUI()
        {
            isAddMode = false;      // Tắt chế độ Thêm
            editedRows.Clear();     // Xóa danh sách dòng đang sửa
            setUIForAddMode(true, "Mã tác giả");
        }

        // Hàm chuẩn hóa họ tên (viết hoa chữ cái đầu)
        private string ChuanHoaHoTen(string hoTen)
        {
            // Logic chuẩn hóa giữ nguyên
            if (string.IsNullOrWhiteSpace(hoTen)) return "";
            hoTen = hoTen.Trim();
            while (hoTen.Contains("  ")) hoTen = hoTen.Replace("  ", " ");
            hoTen = hoTen.ToLower();
            string[] words = hoTen.Split(' ');
            StringBuilder result = new StringBuilder();
            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    result.Append(char.ToUpper(word[0])).Append(word.Substring(1)).Append(" ");
                }
            }
            return result.ToString().TrimEnd();
        }

        // Hàm kiểm tra dữ liệu nhập có hợp lệ không
        private bool checkValidInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text.Trim()))
            {
                XtraMessageBox.Show("Họ tên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }
            else if (!Regex.IsMatch(txtHoTen.Text.Trim(), @"^(?=.*[a-zA-ZÀ-ỹ])[a-zA-ZÀ-ỹ\s]+$"))
            {
                XtraMessageBox.Show("Họ tên chỉ được chứa chữ cái và phải có ít nhất một từ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoDT.Text.Trim()))
            {
                XtraMessageBox.Show("Điện thoại không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDT.Focus();
                return false;
            }
            else if (!Regex.IsMatch(txtSoDT.Text.Trim(), @"^\d{10,12}$"))
            {
                XtraMessageBox.Show("Số điện thoại phải là số và có từ 10 đến 12 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDT.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text.Trim()))
            {
                XtraMessageBox.Show("Địa chỉ không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region *** HÀM THỰC THI SQL (INSERT, UPDATE, DELETE) ********************************************
        // Hàm thực thi INSERT (dùng cho Undo Delete, Redo Add)
        private bool ExecuteInsert(string tableName, Dictionary<string, object> data)
        {
            if (string.IsNullOrEmpty(tableName) || data == null || data.Count == 0) return false;

            // Xây dựng câu lệnh INSERT động
            StringBuilder sqlColumns = new StringBuilder();
            StringBuilder sqlValues = new StringBuilder();
            var parameters = new Dictionary<string, object>();

            bool first = true;
            foreach (var kvp in data)
            {
                if (!first)
                {
                    sqlColumns.Append(", ");
                    sqlValues.Append(", ");
                }
                sqlColumns.Append($"[{kvp.Key}]"); // Tên cột
                sqlValues.Append($"@{kvp.Key}");   // Tham số
                parameters.Add($"@{kvp.Key}", kvp.Value ?? DBNull.Value); // Giá trị tham số
                first = false;
            }

            string sql = $"INSERT INTO [{tableName}] ({sqlColumns}) VALUES ({sqlValues})";

            // Kiểm tra xem có cần bật IDENTITY_INSERT không
            // (Chỉ cần khi Undo Delete mà PK là identity và ta cung cấp giá trị PK)
            bool requiresIdentityInsert = data.ContainsKey(PK_COLUMN_NAME)
                                           && PK_COLUMN_NAME.Equals("MATACGIA", StringComparison.OrdinalIgnoreCase); // Cụ thể cho bảng TACGIA

            if (requiresIdentityInsert)
            {
                sql = $"SET IDENTITY_INSERT [{tableName}] ON; {sql}; SET IDENTITY_INSERT [{tableName}] OFF;";
            }


            // Thực thi lệnh và trả về true nếu thành công (số dòng bị ảnh hưởng > 0)
            return ExecuteSqlCommand(sql, parameters) > 0;
        }

        // Hàm thực thi UPDATE (dùng cho Undo Edit, Redo Edit)
        private bool ExecuteUpdate(string tableName, string pkColumnName, object pkValue, Dictionary<string, object> updateData)
        {
            if (string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(pkColumnName) || pkValue == null || updateData == null || updateData.Count == 0) return false;

            // Xây dựng phần SET của câu lệnh UPDATE
            StringBuilder sqlSet = new StringBuilder();
            var parameters = new Dictionary<string, object>();
            bool first = true;

            foreach (var kvp in updateData)
            {
                // Bỏ qua cột khóa chính trong phần SET
                if (kvp.Key.Equals(pkColumnName, StringComparison.OrdinalIgnoreCase)) continue;

                if (!first)
                {
                    sqlSet.Append(", ");
                }
                sqlSet.Append($"[{kvp.Key}] = @{kvp.Key}"); // VD: [HOTENTG] = @HOTENTG
                parameters.Add($"@{kvp.Key}", kvp.Value ?? DBNull.Value);
                first = false;
            }

            // Nếu không có cột nào để SET (chỉ có PK trong data?), thì không update
            if (first) return false;

            // Thêm điều kiện WHERE
            string sql = $"UPDATE [{tableName}] SET {sqlSet} WHERE [{pkColumnName}] = @{pkColumnName}_PK";
            parameters.Add($"@{pkColumnName}_PK", pkValue); // Tham số cho khóa chính

            return ExecuteSqlCommand(sql, parameters) > 0;
        }

        // Hàm thực thi DELETE (dùng cho Undo Add, Redo Delete)
        private bool ExecuteDelete(string tableName, string pkColumnName, object pkValue)
        {
            if (string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(pkColumnName) || pkValue == null) return false;

            string sql = $"DELETE FROM [{tableName}] WHERE [{pkColumnName}] = @{pkColumnName}_PK";
            var parameters = new Dictionary<string, object> { { $"@{pkColumnName}_PK", pkValue } };

            return ExecuteSqlCommand(sql, parameters) > 0;
        }

        // Hàm thực thi SQL chung (INSERT, UPDATE, DELETE)
        // Trả về số dòng bị ảnh hưởng, hoặc -1 nếu lỗi
        private int ExecuteSqlCommand(string sql, Dictionary<string, object> parameters)
        {
            int rowsAffected = -1; // Giá trị trả về mặc định nếu lỗi
                                   // Đảm bảo connection string là mới nhất (nếu cần)
            if (Program.conn.State == ConnectionState.Closed)
            {
                Program.conn.ConnectionString = Program.connstr;
            }

            if (Program.KetNoi() == 0) return -1; // Không kết nối được CSDL

            SqlTransaction transaction = null;
            try
            {
                transaction = Program.conn.BeginTransaction(); // Bắt đầu transaction
                using (var cmd = new SqlCommand(sql, Program.conn, transaction)) // Gán transaction cho command
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            // Dùng AddWithValue tiện lợi nhưng cần cẩn thận kiểu dữ liệu
                            // Để chặt chẽ hơn có thể dùng cmd.Parameters.Add("@ParamName", SqlDbType.VarChar).Value = ...
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value); // Xử lý null
                        }
                    }
                    rowsAffected = cmd.ExecuteNonQuery(); // Thực thi lệnh
                }
                transaction.Commit(); // Commit nếu không có lỗi
                Console.WriteLine($"Executed SQL: {rowsAffected} rows affected. SQL: {sql}"); // Log thành công
            }
            catch (SqlException sqlEx)
            {
                try { transaction?.Rollback(); } catch { /* Bỏ qua lỗi rollback */ }
                // Hiển thị lỗi SQL cụ thể hơn
                string errorMsg = $"SQL Error Number: {sqlEx.Number}\nMessage: {sqlEx.Message}\nSQL: {sql}";
                Console.WriteLine(errorMsg); // Log lỗi
                XtraMessageBox.Show(errorMsg, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rowsAffected = -1; // Đánh dấu lỗi
            }
            catch (Exception ex)
            {
                try { transaction?.Rollback(); } catch { /* Bỏ qua lỗi rollback */ }
                Console.WriteLine($"General Error Executing SQL: {ex.Message}\nSQL: {sql}"); // Log lỗi
                XtraMessageBox.Show("Lỗi thực thi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rowsAffected = -1; // Đánh dấu lỗi
            }
            finally
            {
                if (Program.conn.State == ConnectionState.Open)
                    Program.conn.Close(); // Luôn đóng kết nối
            }
            return rowsAffected;
        }
        #endregion


        #region *** PHẦN XỬ LÝ GRID VIEW TÁC GIẢ - SÁCH ***************************************
        // Các sự kiện này chủ yếu để bật nút Ghi TGS khi có thay đổi
        private void tACGIA_SACHDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không phải header
                btnGhiTGS.Enabled = true;
        }

        private void tACGIA_SACHDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Commit thay đổi ngay khi người dùng rời ô (đặc biệt hữu ích cho CheckBox, ComboBox)
            if (tACGIA_SACHDataGridView.IsCurrentCellDirty)
            {
                tACGIA_SACHDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void bdsTacGia_Sach_ListChanged(object sender, ListChangedEventArgs e)
        {
            // Cập nhật trạng thái nút Xóa TGS dựa vào số lượng dòng
            btnXoaTGS.Enabled = (bdsTacGia_Sach.Count != 0);

            // Bật nút Ghi TGS nếu có sự thay đổi trong danh sách (thêm, sửa, xóa item)
            // Cần kiểm tra ListChangedType cụ thể hơn nếu muốn chính xác tuyệt đối
            if (e.ListChangedType == ListChangedType.ItemAdded ||
                e.ListChangedType == ListChangedType.ItemChanged ||
                e.ListChangedType == ListChangedType.ItemDeleted ||
                 e.ListChangedType == ListChangedType.Reset) // Reset cũng có thể làm thay đổi cần ghi
            {
                // Có thể thêm kiểm tra trạng thái RowState của các dòng nếu cần
                btnGhiTGS.Enabled = true;
            }
        }

        // **** Sự kiện nút THÊM TGS (Tác Giả Sách) *****
        private void btnThemTGS_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn tác giả ở grid chính chưa
            if (bdsTacGia.Current == null)
            {
                XtraMessageBox.Show("Vui lòng chọn một tác giả trước khi thêm sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã tác giả hiện tại
            object currentMaTacGia = ((DataRowView)bdsTacGia.Current)[PK_COLUMN_NAME];

            // Thêm dòng mới vào BindingSource của TGS
            DataRowView newRow = (DataRowView)bdsTacGia_Sach.AddNew();
            // Tự động gán mã tác giả cho dòng mới
            newRow["MATACGIA"] = currentMaTacGia;

            // Bật nút Ghi TGS sau khi thêm
            btnGhiTGS.Enabled = true;
            // Có thể focus vào ô ISBN để người dùng chọn sách
            tACGIA_SACHDataGridView.Focus();
            // Tự động di chuyển đến cột ISBN của dòng mới (nếu grid không trống)
            if (tACGIA_SACHDataGridView.Rows.Count > 1 && tACGIA_SACHDataGridView.Columns.Contains("ISBN"))
            { // Count > 1 vì có dòng mới
                int newRowIndex = tACGIA_SACHDataGridView.Rows.GetLastRow(DataGridViewElementStates.None); // Lấy index dòng cuối (dòng mới)
                int isbnColIndex = tACGIA_SACHDataGridView.Columns["ISBN"].Index;
                if (newRowIndex >= 0 && isbnColIndex >= 0)
                {
                    tACGIA_SACHDataGridView.CurrentCell = tACGIA_SACHDataGridView[isbnColIndex, newRowIndex];
                    tACGIA_SACHDataGridView.BeginEdit(true); // Bắt đầu chỉnh sửa ô ISBN
                }
            }


        }

        // **** Sự kiện nút GHI TGS (Tác Giả Sách) *****
        private void btnGhiTGS_Click(object sender, EventArgs e)
        {
            try
            {
                // Kết thúc chỉnh sửa trên BindingSource TGS
                this.Validate(); // Validate form nếu cần
                bdsTacGia_Sach.EndEdit();

                // Kiểm tra tính duy nhất của ISBN cho cùng một MATACGIA trước khi lưu (nếu cần thiết)
                // Việc này phức tạp hơn và thường nên để Database Constraint xử lý

                // Dùng TableAdapter để cập nhật thay đổi xuống DB
                this.tACGIA_SACHTableAdapter.Update(this.qLTVDataSet.TACGIA_SACH);

                XtraMessageBox.Show("Ghi liên kết Tác giả - Sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGhiTGS.Enabled = false; // Tắt nút Ghi sau khi thành công
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 2627 || sqlEx.Number == 2601) // Lỗi Primary Key/Unique Constraint
            {
                XtraMessageBox.Show("Lỗi: Không thể thêm/sửa liên kết. Có thể sách này đã được gán cho tác giả.\n" + sqlEx.Message, "Lỗi Trùng Khóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Cần reload lại để hủy thay đổi trên UI
                ReloadTacGiaSachData();
            }
            catch (Exception ex)
            {
                // Bắt các lỗi khác
                XtraMessageBox.Show("Lỗi ghi dữ liệu Tác giả - Sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Reload lại để hủy thay đổi trên UI
                ReloadTacGiaSachData();
            }
        }

        // **** Sự kiện nút XÓA TGS (Tác Giả Sách) *****
        private void btnXoaTGS_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong grid TGS không
            if (bdsTacGia_Sach.Current == null)
            {
                XtraMessageBox.Show("Vui lòng chọn dòng liên kết cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận xóa
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa liên kết tác giả - sách này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Xóa dòng hiện tại khỏi BindingSource
                    bdsTacGia_Sach.RemoveCurrent();
                    // Cập nhật thay đổi (xóa) xuống Database
                    this.tACGIA_SACHTableAdapter.Update(qLTVDataSet.TACGIA_SACH);
                    XtraMessageBox.Show("Xóa liên kết thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Nút Ghi TGS có thể bị bật do ListChanged, nên tắt nó đi nếu xóa thành công
                    btnGhiTGS.Enabled = false;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi khi xóa liên kết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Nếu lỗi, tải lại dữ liệu TGS để phục hồi dòng vừa xóa trên UI
                    ReloadTacGiaSachData();
                }
            }
        }

        // Hàm tải lại dữ liệu chỉ cho bảng TACGIA_SACH
        private void ReloadTacGiaSachData()
        {
            try
            {
                // Lưu vị trí hiện tại của TGS nếu cần
                int currentTgsPos = bdsTacGia_Sach.Position;

                // Fill lại adapter TGS
                this.tACGIA_SACHTableAdapter.Fill(this.qLTVDataSet.TACGIA_SACH);

                // Khôi phục vị trí (nếu còn hợp lệ)
                if (currentTgsPos >= 0 && currentTgsPos < bdsTacGia_Sach.Count)
                {
                    bdsTacGia_Sach.Position = currentTgsPos;
                }
                Console.WriteLine("TacGia_Sach data reloaded.");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi tải lại dữ liệu Tác giả-Sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi bắt đầu chỉnh sửa ô trong DataGridView TGS
        // Dùng để lọc ComboBox ISBN, không cho chọn sách đã có của tác giả đó
        private void tACGIA_SACHDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Chỉ xử lý khi đang sửa cột ISBN và control là ComboBox
            if (tACGIA_SACHDataGridView.CurrentCell.ColumnIndex == tACGIA_SACHDataGridView.Columns["ISBN"].Index
                && e.Control is System.Windows.Forms.ComboBox comboBox)
            {
                // Luôn xóa DataSource cũ và đặt lại DropDownStyle
                comboBox.DataSource = null;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList; // Quan trọng: Bắt buộc chọn từ list

                // Lấy danh sách ISBN đã được sử dụng cho TÁC GIẢ HIỆN TẠI (ở grid chính)
                // ngoại trừ dòng đang được chỉnh sửa
                var usedISBNs = new HashSet<string>();
                if (bdsTacGia.Current != null)
                {
                    object currentMaTacGia = ((DataRowView)bdsTacGia.Current)[PK_COLUMN_NAME];

                    foreach (DataGridViewRow row in tACGIA_SACHDataGridView.Rows)
                    {
                        // Bỏ qua dòng mới (chưa commit) và dòng đang sửa
                        if (row.IsNewRow || row.Index == tACGIA_SACHDataGridView.CurrentCell.RowIndex)
                            continue;

                        // Lấy DataRowView của dòng trong grid TGS
                        var rowView = row.DataBoundItem as DataRowView;
                        // Đảm bảo dòng này thuộc về tác giả đang chọn và chưa bị xóa logic
                        if (rowView != null && rowView.Row.RowState != DataRowState.Detached && rowView["MATACGIA"] != DBNull.Value && rowView["MATACGIA"].Equals(currentMaTacGia))
                        {
                            var isbnValue = row.Cells["ISBN"].Value;
                            if (isbnValue != null && isbnValue != DBNull.Value)
                                usedISBNs.Add(isbnValue.ToString());
                        }
                    }
                }
                else
                {
                    // Nếu không có tác giả nào được chọn, không nên cho phép thêm/sửa TGS
                    // Nhưng để phòng ngừa, không lọc gì cả nếu không có tác giả
                }


                // Tạo danh sách các đầu sách (từ bdsDauSach) CHƯA có trong usedISBNs
                List<DataRowView> availableItems = new List<DataRowView>();
                foreach (DataRowView drv in bdsDauSach)
                {
                    // Kiểm tra xem drv có hợp lệ không (phòng trường hợp dataset lỗi)
                    if (drv != null && drv.Row.RowState != DataRowState.Detached && drv["ISBN"] != DBNull.Value)
                    {
                        string isbn = drv["ISBN"].ToString();
                        if (!usedISBNs.Contains(isbn))
                        {
                            availableItems.Add(drv);
                        }
                    }
                }

                // Gán danh sách sách khả dụng làm DataSource cho ComboBox
                comboBox.DisplayMember = "TENSACH"; // Hiển thị tên sách
                comboBox.ValueMember = "ISBN";      // Giá trị lấy về là ISBN
                comboBox.DataSource = availableItems; // Gán danh sách đã lọc
            }
        }
        #endregion
    }
}
