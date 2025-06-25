using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace AppLibrary
{
    public partial class FormDocGia2 : DevExpress.XtraEditors.XtraForm
    {
        #region *** VAR - CLASS *************************************************
        private int vitri = 0; // Vị trí dòng đang chọn trên grid
        private bool isAddMode = false; // Cờ đánh dấu đang ở chế độ THÊM mới
        private Dictionary<int, DataRow> editedRows = new Dictionary<int, DataRow>(); // Lưu các dòng đã chỉnh sửa (chưa Ghi)

        // Stack cho Undo và Redo
        private Stack<LogAction> undoStack = new Stack<LogAction>();
        private Stack<LogAction> redoStack = new Stack<LogAction>();

        // Hằng số tên bảng và cột PK
        private const string TABLE_NAME = "DOCGIA";
        private const string PK_COLUMN_NAME = "MADG";

        bool isNhanVien = (Program.mGroup == "NHANVIEN"); // Chỉ NHANVIEN mới có quyền chỉnh sửa
        #endregion

        #region *** CONSTRUCTOR - LOAD ******************************************
        public FormDocGia2()
        {
            InitializeComponent();
        }

        private void FormDocGia2_Load(object sender, EventArgs e)
        {
            qLTVDataSet.EnforceConstraints = false;
            this.dOCGIATableAdapter.Connection.ConnectionString = Program.connstr;
            this.dOCGIATableAdapter.Fill(this.qLTVDataSet.DOCGIA);
            this.hOATDONGTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hOATDONGTableAdapter.Fill(this.qLTVDataSet.HOATDONG);
            this.gIOITINHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIOITINHTableAdapter.Fill(this.qLTVDataSet.GIOITINH);
            this.pHIEUMUONTableAdapter.Connection.ConnectionString = Program.connstr;
            this.pHIEUMUONTableAdapter.Fill(this.qLTVDataSet.PHIEUMUON);

            // Cấu hình giao diện GridView
            gvDOCGIA.OptionsView.ShowGroupPanel = false;      // Ẩn panel gom nhóm
            gvDOCGIA.OptionsFind.AlwaysVisible = true;          // Hiện ô tìm kiếm
            gvDOCGIA.OptionsFind.FindNullPrompt = "Nhập thông tin tìm kiếm..."; // Placeholder ô tìm kiếm

            // --- Phân quyền ---
            btnThem.Enabled = btnGhi.Enabled = btnXoa.Enabled = btnUndo.Enabled = btnRedo.Enabled = isNhanVien;
            pnINPUT.Visible = isNhanVien;        // Cho phép nhập liệu vào panel input
            if (isNhanVien)
            {
                // Cập nhật trạng thái ban đầu của các nút
                UpdateButtonStates();
                btnRefresh.Enabled = btnGhi.Enabled = false;
                // Nếu không có dữ liệu, ẩn panel nhập liệu ban đầu
                if (dOCGIABindingSource.Count == 0) pnINPUT.Visible = false;
            }


            // Gắn sự kiện TextChanged cho tất cả các TextEdit trong panel Input
            foreach (Control control in pnINPUT.Controls)
            {
                if (control is TextEdit textEdit)
                {
                    textEdit.TextChanged += AnyTextBox_TextChanged;
                }
            }
        }

        private void UpdateButtonStates()
        {
            bool hasData = dOCGIABindingSource.Count > 0;
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
            btnThoat.Enabled = !isAddMode;
        }

        private void AnyTextBox_TextChanged(object sender, EventArgs e)
        {   // Nếu đang ở chế độ thêm, hoặc không có dòng hiện tại, hoặc bindingsource rỗng -> bỏ qua
            if (isAddMode || dOCGIABindingSource.Current == null || dOCGIABindingSource.Count == 0) return;
            int currentPos = dOCGIABindingSource.Position; // Lấy vị trí dòng hiện tại
            var currentRow = ((DataRowView)dOCGIABindingSource.Current).Row; // Lấy DataRow tương ứng với dòng hiện tại đang chọn
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
            if (dOCGIABindingSource.Position == 0)
            {
                btnRefresh.Enabled = false;
            }
        }
        #endregion

        #region *** SỰ KIỆN NÚT CHỨC NĂNG *****************************************
        // ***** ✅ Sự kiện nút THÊM *****
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = dOCGIABindingSource.Position;
            isAddMode = true;
            dOCGIABindingSource.AddNew();
            setUIForAddMode(false, "Mã độc giả tự động thêm");
        }

        // **** ✅ Sự kiện nút XÓA *****
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Kiểm tra có dòng được chọn không
            if (dOCGIABindingSource.Current == null)
            {
                XtraMessageBox.Show("Vui lòng chọn độc giả cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Kiểm tra ràng buộc: Không cho xóa nếu độc giả này đang có sách liên kết
            if (pHIEUMUONBindingSource.Count > 0)
            {
                XtraMessageBox.Show("độc giả đã tồn tại phiếu mượn, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // ✅ Kiểm tra cột HOATDONG có bằng 1 không (đang hoạt động)
            var currentRowView = (DataRowView)dOCGIABindingSource.Current;
            if (currentRowView != null && currentRowView["HOATDONG"] != DBNull.Value)
            {
                bool hoatDong = Convert.ToBoolean(currentRowView["HOATDONG"]);
                if (hoatDong)
                {
                    XtraMessageBox.Show("Không thể xóa độc giả đang hoạt động!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            vitri = dOCGIABindingSource.Position;
            LogAction action = null;
            object deletedPrimaryKey = null;
            try
            {
                var currentRow = ((DataRowView)dOCGIABindingSource.Current).Row;
                deletedPrimaryKey = currentRow[PK_COLUMN_NAME];

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
                dOCGIABindingSource.RemoveCurrent();
                // Ghi thay đổi xuống Database (quan trọng: làm điều này trong try-catch)
                this.dOCGIATableAdapter.Update(this.qLTVDataSet.DOCGIA);

                // **XÓA THÀNH CÔNG -> PUSH VÀO UNDO STACK**
                undoStack.Push(action);
                redoStack.Clear();  // Xóa redo stack khi có hành động mới
                XtraMessageBox.Show("Xóa độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // **XÓA THẤT BẠI**
                XtraMessageBox.Show("Lỗi xóa độc giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Nếu có lỗi xảy ra, phục hồi lại bảng DOCGIA từ DataSet để đảm bảo khớp dữ liệu
                this.dOCGIATableAdapter.Fill(this.qLTVDataSet.DOCGIA);
                // Cố gắng đặt lại vị trí con trỏ
                int foundPos = dOCGIABindingSource.Find(PK_COLUMN_NAME, deletedPrimaryKey);
                if (foundPos >= 0) dOCGIABindingSource.Position = foundPos;
                else dOCGIABindingSource.Position = vitri; // Về vị trí cũ nếu không tìm thấy
                                                           // Không push action vào undoStack vì thao tác thất bại
                return;
            }
            finally
            {   // cập nhật trạng thái các Button
                UpdateButtonStates();
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
                dOCGIABindingSource.EndEdit(); // Lưu các thay đổi từ control vào DataRowView hiện tại
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi kết thúc chỉnh sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dòng hiện tại (sau khi EndEdit)
            var currentView = dOCGIABindingSource.Current as DataRowView;
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
                    currentRow["HODG"] = ChuanHoaHoTen(currentRow["HODG"] as string);
                    currentRow["TENDG"] = ChuanHoaHoTen(currentRow["TENDG"] as string);

                    // Lấy mã độc giả mới (nếu là tự động tăng)
                    int newId = GetNextAuthorId();
                    if (newId <= 0)
                    {
                        XtraMessageBox.Show("Không thể tạo mã độc giả mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        XtraMessageBox.Show("Thêm độc giả thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Cần xử lý hủy bỏ dòng mới thêm trên UI nếu insert lỗi
                        dOCGIABindingSource.CancelEdit();
                        if (dOCGIABindingSource.Current != null && ((DataRowView)dOCGIABindingSource.Current).IsNew)
                        {
                            dOCGIABindingSource.RemoveCurrent();
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
                        Positions = new List<int> { dOCGIABindingSource.Position } // Lưu vị trí dòng mới
                    };
                    undoStack.Push(action);
                    redoStack.Clear();
                    ReloadData();
                    // Đặt vị trí về dòng mới thêm (Tìm lại bằng ID để chắc chắn)
                    dOCGIABindingSource.Position = dOCGIABindingSource.Find(PK_COLUMN_NAME, newId);
                    XtraMessageBox.Show($"Thêm độc giả với ID-{newId} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                               !Equals(row["HODG", DataRowVersion.Current], row["HODG", DataRowVersion.Original]) &&
                               !Equals(row["TENDG", DataRowVersion.Current], row["TENDG", DataRowVersion.Original]))
                            {
                                row["HODG"] = ChuanHoaHoTen(row["HODG"] as string);
                                row["TENDG"] = ChuanHoaHoTen(row["TENDG"] as string);
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
                        int position = dOCGIABindingSource.Find(PK_COLUMN_NAME, row[PK_COLUMN_NAME]); // Tìm vị trí thực tế của dòng

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
                    int rowsAffected = this.dOCGIATableAdapter.Update(this.qLTVDataSet.DOCGIA);

                    if (rowsAffected > 0) // Kiểm tra xem có dòng nào được cập nhật thành công không
                    {
                        // **UPDATE THÀNH CÔNG -> Push LogAction**
                        undoStack.Push(action);
                        redoStack.Clear();
                        XtraMessageBox.Show($"Cập nhật {rowsAffected} độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // AcceptChanges cho các dòng đã sửa để cập nhật trạng thái thành Unchanged
                        // TableAdapter.Update thường đã làm điều này, nhưng gọi lại để chắc chắn
                        this.qLTVDataSet.DOCGIA.AcceptChanges();
                    }
                    else if (rowsAffected == 0 && changedRows.Count > 0)
                    {
                        // Có dòng đánh dấu sửa đổi nhưng không có dòng nào được Update (có thể do lỗi hoặc concurrency)
                        XtraMessageBox.Show("Không có độc giả nào được cập nhật. Có thể dữ liệu đã bị thay đổi bởi người khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    dOCGIABindingSource.CancelEdit(); // Hủy các thay đổi trên control
                    if (dOCGIABindingSource.Current != null && ((DataRowView)dOCGIABindingSource.Current).IsNew)
                    {
                        dOCGIABindingSource.RemoveCurrent(); // Xóa dòng mới khỏi BindingSource
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
                                    int foundPos = dOCGIABindingSource.Find(action.PrimaryKeyColumnName, pkToFind);
                                    if (foundPos >= 0) targetPosition = foundPos;
                                }
                            }
                            // Đảm bảo vị trí hợp lệ
                            targetPosition = Math.Max(0, Math.Min(targetPosition, dOCGIABindingSource.Count - 1));
                            if (dOCGIABindingSource.Count > 0) dOCGIABindingSource.Position = targetPosition;
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
                                    int foundPos = dOCGIABindingSource.Find(action.PrimaryKeyColumnName, pkToFind);
                                    if (foundPos >= 0) targetPosition = foundPos;
                                }
                            }
                            // Đảm bảo vị trí hợp lệ
                            targetPosition = Math.Max(0, Math.Min(targetPosition, dOCGIABindingSource.Count - 1));
                            if (dOCGIABindingSource.Count > 0) dOCGIABindingSource.Position = targetPosition;
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
            if (!isNhanVien && dOCGIABindingSource.Count >= 0)
            {
                dOCGIABindingSource.Position = 0;
                return;
            }

            if (editedRows.Count > 0)
            {
                if (XtraMessageBox.Show("Bạn có muốn hủy bỏ các thay đổi chưa lưu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.dOCGIATableAdapter.Connection.ConnectionString = Program.connstr;
                    this.dOCGIATableAdapter.Fill(this.qLTVDataSet.DOCGIA);
                }
            }
            ResetOriginalUI();
            UpdateButtonStates();
            btnGhi.Enabled = btnRefresh.Enabled = false;
        }

        // **** Sự kiện nút THOÁT *****
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Kiểm tra nếu có thay đổi chưa lưu trước khi thoát
            if (editedRows.Count > 0)
            {
                if (XtraMessageBox.Show("Bạn có thay đổi chưa lưu. Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            this.Close();
        }
        #endregion

        #region *** HÀM HỖ TRỢ NÚT CHỨC NĂNG ********************************************
        // Hàm hủy thao tác Thêm đang thực hiện
        private void CancelAddAction()
        {
            if (!isAddMode) return; // Chỉ hủy khi đang ở mode Add
            dOCGIABindingSource.CancelEdit();
            if (dOCGIABindingSource.Current != null && ((DataRowView)dOCGIABindingSource.Current).IsNew)
            {   // Đảm bảo dòng hiện tại là dòng mới và xóa nó đi
                dOCGIABindingSource.RemoveCurrent();
            }
            if (vitri >= 0 && vitri < dOCGIABindingSource.Count)
            {   // Quay về vị trí trước khi nhấn Thêm
                dOCGIABindingSource.Position = vitri;
            }
            ResetOriginalUI(); // cancel
        }

        // Hàm tải lại dữ liệu cho các BindingSource chính
        private void ReloadData()
        {
            try
            {    // Lưu lại vị trí và ID hiện tại để cố gắng khôi phục sau khi tải lại
                int currentPosition = dOCGIABindingSource.Position;
                object currentId = null;
                if (currentPosition >= 0 && dOCGIABindingSource.Current != null)
                {
                    currentId = ((DataRowView)dOCGIABindingSource.Current)[PK_COLUMN_NAME];
                }

                // Tải lại dữ liệu cho các bảng liên quan
                this.dOCGIATableAdapter.Fill(this.qLTVDataSet.DOCGIA);
                this.pHIEUMUONTableAdapter.Fill(this.qLTVDataSet.PHIEUMUON);

                // Cố gắng khôi phục vị trí
                if (currentId != null)
                {
                    int newPosition = dOCGIABindingSource.Find(PK_COLUMN_NAME, currentId);
                    if (newPosition >= 0)
                    {
                        dOCGIABindingSource.Position = newPosition;
                    }
                    else if (dOCGIABindingSource.Count > 0)
                    {   // Nếu không tìm thấy ID cũ (ví dụ: bị xóa), về vị trí gần nhất
                        dOCGIABindingSource.Position = Math.Max(0, Math.Min(currentPosition, dOCGIABindingSource.Count - 1));
                    }
                }
                else if (dOCGIABindingSource.Count > 0)
                {   // Nếu không có ID cũ, về vị trí đầu tiên
                    dOCGIABindingSource.Position = 0;
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
                XtraMessageBox.Show("Lỗi lấy mã độc giả tiếp theo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nextId = -1;
            }
            finally
            {
                if (Program.conn.State == ConnectionState.Open) Program.conn.Close();
            }
            return nextId;
        }

        private void setUIForAddMode(bool maDOCGIAVisible, string maDOCGIALabel)
        {
            gcDOCGIA.Enabled = !isAddMode;
            mADGTextEdit.Visible = maDOCGIAVisible;
            lblMA.Text = maDOCGIALabel;
            hODGTextEdit.Focus();
            nGAYLAMTHEDateEdit.Enabled = maDOCGIAVisible;
            nGAYHETHANDateEdit.Enabled = maDOCGIAVisible;
            hOATDONGCheckEdit.Enabled = maDOCGIAVisible;
            btnRefresh.Enabled = !isAddMode;
            if (isAddMode)
            {
                DateTime now = DateTime.Now;
                nGAYLAMTHEDateEdit.EditValue = now;
                nGAYHETHANDateEdit.EditValue = now.AddDays(30);
                hOATDONGCheckEdit.EditValue = true; // Mặc định hoạt động
                hOATDONGCheckEdit.IsOn = true; // Đặt trạng thái bật
            }
            UpdateButtonStates();
        }

        private void ResetOriginalUI()
        {
            isAddMode = false;
            editedRows.Clear();
            setUIForAddMode(true, "MÃ:");
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
            if (string.IsNullOrWhiteSpace(hODGTextEdit.Text.Trim()))
            {
                XtraMessageBox.Show("Họ không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hODGTextEdit.Focus();
                return false;
            }
            else if (!Regex.IsMatch(hODGTextEdit.Text.Trim(), @"^(?=.*[a-zA-ZÀ-ỹ])[a-zA-ZÀ-ỹ\s]+$"))
            {
                XtraMessageBox.Show("Họ tên chỉ được chứa chữ cái và phải có ít nhất một từ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hODGTextEdit.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tENDGTextEdit.Text.Trim()))
            {
                XtraMessageBox.Show("Tên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tENDGTextEdit.Focus();
                return false;
            }
            else if (!Regex.IsMatch(tENDGTextEdit.Text.Trim(), @"^(?=.*[a-zA-ZÀ-ỹ])[a-zA-ZÀ-ỹ\s]+$"))
            {
                XtraMessageBox.Show("Tên chỉ được chứa chữ cái và phải có ít nhất một từ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tENDGTextEdit.Focus();
                return false;
            }
            //email
            if (string.IsNullOrWhiteSpace(eMAILDGTextEdit.Text.Trim()))
            {
                XtraMessageBox.Show("Email không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                eMAILDGTextEdit.Focus();
                return false;
            }
            else if (!Regex.IsMatch(eMAILDGTextEdit.Text.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                XtraMessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                eMAILDGTextEdit.Focus();
                return false;
            }
            //số CMND
            if (string.IsNullOrWhiteSpace(sOCMNDTextEdit.Text.Trim()))
            {
                XtraMessageBox.Show("CMND không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sOCMNDTextEdit.Focus();
                return false;
            }
            else if (!Regex.IsMatch(sOCMNDTextEdit.Text.Trim(), @"^\d{9,12}$"))
            {
                XtraMessageBox.Show("CMND phải là số và có từ 9 đến 12 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sOCMNDTextEdit.Focus();
                return false;
            }
            // Ngày sinh
            if (nGAYSINHDateEdit.EditValue == null || !(nGAYSINHDateEdit.EditValue is DateTime))
            {
                XtraMessageBox.Show("Ngày sinh không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nGAYSINHDateEdit.Focus();
                return false;
            }
            // số điện thoại
            if (string.IsNullOrWhiteSpace(dIENTHOAITextEdit.Text.Trim()))
            {
                XtraMessageBox.Show("Điện thoại không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dIENTHOAITextEdit.Focus();
                return false;
            }
            else if (!Regex.IsMatch(dIENTHOAITextEdit.Text.Trim(), @"^\d{10,12}$"))
            {
                XtraMessageBox.Show("Số điện thoại phải là số và có từ 10 đến 12 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dIENTHOAITextEdit.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(dIACHITextEdit.Text.Trim()))
            {
                XtraMessageBox.Show("Địa chỉ không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dIACHITextEdit.Focus();
                return false;
            }
            // ngày đăng ký
            if (nGAYLAMTHEDateEdit.EditValue == null || !(nGAYLAMTHEDateEdit.EditValue is DateTime))
            {
                XtraMessageBox.Show("Ngày đăng ký không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nGAYLAMTHEDateEdit.Focus();
                return false;
            }
            //ngày hết hạn
            if (nGAYHETHANDateEdit.EditValue == null || !(nGAYHETHANDateEdit.EditValue is DateTime))
            {
                XtraMessageBox.Show("Ngày hết hạn không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nGAYHETHANDateEdit.Focus();
                return false;
            }
            // Kiểm tra ngày hết hạn phải lớn hơn ngày hiện tại nếu không phải chế độ thêm
            if (!isAddMode)
            {
                DateTime ngayHetHan = (DateTime)nGAYHETHANDateEdit.EditValue;
                if (ngayHetHan <= DateTime.Now.Date)
                {
                    XtraMessageBox.Show("Ngày hết hạn phải lớn hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nGAYHETHANDateEdit.Focus();
                    return false;
                }
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
                                           && PK_COLUMN_NAME.Equals("MADOCGIA", StringComparison.OrdinalIgnoreCase); // Cụ thể cho bảng DOCGIA

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

        private void rbNAM_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbNAM.Checked) rbNU.Checked = true;
        }

        private void rbNU_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbNU.Checked) rbNAM.Checked = true;
        }
    }
}