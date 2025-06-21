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
using DevExpress.XtraRichEdit.API.Native;

namespace AppLibrary
{
    public partial class FormTheLoai : DevExpress.XtraEditors.XtraForm
    {
        #region VAR - CLASS *****************
        private int vitri = 0;
        private bool isAddMode = false;
        private Dictionary<int, DataRow> editedRows = new Dictionary<int, DataRow>();

        // Stack cho Undo và Redo
        private Stack<LogAction> undoStack = new Stack<LogAction>();
        private Stack<LogAction> redoStack = new Stack<LogAction>();

        // Hằng số tên bảng và cột PK
        private const string TABLE_NAME = "THELOAI";
        private const string PK_COLUMN_NAME = "MATL";

        bool isNhanVien = (Program.mGroup == "NHANVIEN"); // Chỉ NHANVIEN mới có quyền chỉnh sửa
        #endregion

        #region INIT FORM ***************
        public FormTheLoai()
        {
            InitializeComponent();
        }

        private void FormTheLoai_Load(object sender, EventArgs e)
        {

            qLTVDataSet.EnforceConstraints = false;
            this.tableAdapterTHELOAI.Connection.ConnectionString = Program.connstr;
            this.tableAdapterTHELOAI.Fill(this.qLTVDataSet.THELOAI);
            this.tableAdapterDAUSACH.Connection.ConnectionString = Program.connstr;
            this.tableAdapterDAUSACH.Fill(this.qLTVDataSet.DAUSACH);

            gvTHELOAI.OptionsView.ShowGroupPanel = false;
            gvTHELOAI.OptionsFind.AlwaysVisible = true;
            gvTHELOAI.OptionsFind.FindNullPrompt = "Nhập thông tin tìm kiếm...";

            // --- Phân quyền ---
            btnThem.Enabled = btnGhi.Enabled = btnXoa.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnIn.Enabled = isNhanVien;
            pnINPUTTL.Visible = isNhanVien;        // Cho phép nhập liệu vào panel input
            if (isNhanVien)
            {
                // Cập nhật trạng thái ban đầu của các nút
                UpdateButtonStates();
                btnRefresh.Enabled = btnGhi.Enabled = false;
                // Nếu không có dữ liệu, ẩn panel nhập liệu ban đầu
                if (bdsTHELOAI.Count == 0) pnINPUTTL.Visible = false;
            }

            // Gắn sự kiện TextChanged cho tất cả các TextEdit trong panel Input
            foreach (Control control in pnINPUTTL.Controls)
            {
                if (control is TextEdit textEdit)
                {
                    textEdit.TextChanged += AnyTextBox_TextChanged;
                }
            }
        }

        private void FormTHELOAI_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Validate();
                bdsTHELOAI.EndEdit(); // Kết thúc mọi chỉnh sửa
            }
            catch (Exception ex)
            {
                // Báo lỗi nếu không thể hoàn tất chỉnh sửa
                MessageBox.Show("Dữ liệu chưa hợp lệ hoặc lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Không cho phép đóng form
            }
        }


        private void UpdateButtonStates()
        {
            bool hasData = bdsTHELOAI.Count > 0;
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

        private void AnyTextBox_TextChanged(object sender, EventArgs e)
        {   // Nếu đang ở chế độ thêm, hoặc không có dòng hiện tại, hoặc bindingsource rỗng -> bỏ qua
            if (isAddMode || bdsTHELOAI.Current == null || bdsTHELOAI.Count == 0) return;
            int currentPos = bdsTHELOAI.Position;
            var currentRow = ((DataRowView)bdsTHELOAI.Current).Row;
            // Nếu dòng này chưa được đánh dấu là đã sửa, thêm nó vào dictionary editedRows
            if (!editedRows.ContainsKey(currentPos))
            {
                if (currentRow.RowState == DataRowState.Unchanged || currentRow.RowState == DataRowState.Modified)
                {
                    editedRows[currentPos] = currentRow;
                }
            }
            // Bật nút Ghi và Refresh để cho phép lưu hoặc hủy thay đổi
            btnGhi.Enabled = isNhanVien;
            btnRefresh.Enabled = !isAddMode;
            if (bdsTHELOAI.Position == 0)
            {
                btnRefresh.Enabled = false;
            }
        }
        #endregion

        #region BUTTON CLICK ***********************
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsTHELOAI.Position;
            setUIForAddMode(true);
            bdsTHELOAI.AddNew();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsDAUSACH_TL.Count > 0)
            {
                XtraMessageBox.Show("Thể loại đang thuộc một số thể loại, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsTHELOAI.Current == null)
            {
                XtraMessageBox.Show("Vui lòng chọn thể loại cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Xác nhận xóa
            if (XtraMessageBox.Show("Bạn có thực sự muốn xóa thể loại này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                vitri = bdsTHELOAI.Position; // Lưu vị trí dòng sẽ xóa
                LogAction action = null;    // Khai báo action để lưu thông tin undo
                object deletedPrimaryKey = null; // Lưu khóa chính của dòng bị xóa
                try
                {
                    var currentRow = ((DataRowView)bdsTHELOAI.Current).Row;
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
                    bdsTHELOAI.RemoveCurrent();
                    this.tableAdapterTHELOAI.Update(this.qLTVDataSet.THELOAI);

                    // **XÓA THÀNH CÔNG -> PUSH VÀO UNDO STACK**
                    undoStack.Push(action);
                    redoStack.Clear();  // Xóa redo stack khi có hành động mới
                    XtraMessageBox.Show("Xóa thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {   // **XÓA THẤT BẠI**
                    XtraMessageBox.Show("Lỗi xóa thể loại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.tableAdapterTHELOAI.Fill(this.qLTVDataSet.THELOAI);
                    // Cố gắng đặt lại vị trí con trỏ
                    int foundPos = bdsTHELOAI.Find(PK_COLUMN_NAME, deletedPrimaryKey);
                    if (foundPos >= 0) bdsTHELOAI.Position = foundPos;
                    else bdsTHELOAI.Position = vitri; // Về vị trí cũ nếu không tìm thấy
                    return;
                }
                finally
                {
                    UpdateButtonStates();
                }
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 1. Kiểm tra dữ liệu nhập hợp lệ
            if (!checkValidInput()) return;

            // 2. Xác thực và kết thúc chỉnh sửa trên BindingSource
            try
            {
                this.Validate();
                bdsTHELOAI.EndEdit(); // Lưu các thay đổi từ control vào DataRowView hiện tại
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi kết thúc chỉnh sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dòng hiện tại (sau khi EndEdit)
            var currentView = bdsTHELOAI.Current as DataRowView;
            if (currentView == null)
            {
                XtraMessageBox.Show("Không có dòng dữ liệu hợp lệ để ghi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var currentRow = currentView.Row;
            object newPkValue = currentRow[PK_COLUMN_NAME];
            // 3. Xử lý theo chế độ (Thêm mới hoặc Chỉnh sửa)
            try
            {
                // --------------------- CHẾ ĐỘ THÊM MỚI ---------------------
                if (isAddMode)
                {
                    // Chuẩn bị dữ liệu để lưu vào LogAction (dữ liệu ĐÃ LƯU thành công)
                    var savedData = new Dictionary<string, object>();
                    foreach (DataColumn col in currentRow.Table.Columns)
                    {
                        savedData[col.ColumnName] = currentRow[col];
                    }

                    // **THỰC HIỆN INSERT VÀO DATABASE**
                    // Gọi hàm thực thi INSERT trực tiếp (không cần tạo SQL trước)
                    if (!ExecuteInsert(TABLE_NAME, savedData))
                    {
                        // Nếu Insert thất bại, hiển thị lỗi và thoát
                        XtraMessageBox.Show("Thêm thể loại thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Cần xử lý hủy bỏ dòng mới thêm trên UI nếu insert lỗi
                        bdsTHELOAI.CancelEdit();
                        if (bdsTHELOAI.Current != null && ((DataRowView)bdsTHELOAI.Current).IsNew)
                        {
                            bdsTHELOAI.RemoveCurrent();
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
                        Positions = new List<int> { bdsTHELOAI.Position } // Lưu vị trí dòng mới
                    };
                    undoStack.Push(action);
                    redoStack.Clear();
                    ReloadData();
                    // Đặt vị trí về dòng mới thêm (Tìm lại bằng ID để chắc chắn)
                    bdsTHELOAI.Position = bdsTHELOAI.Find(PK_COLUMN_NAME, newPkValue);
                    XtraMessageBox.Show($"Thêm thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        int position = bdsTHELOAI.Find(PK_COLUMN_NAME, row[PK_COLUMN_NAME]); // Tìm vị trí thực tế của dòng

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
                    int rowsAffected = this.tableAdapterTHELOAI.Update(this.qLTVDataSet.THELOAI);

                    if (rowsAffected > 0) // Kiểm tra xem có dòng nào được cập nhật thành công không
                    {
                        // **UPDATE THÀNH CÔNG -> Push LogAction**
                        undoStack.Push(action);
                        redoStack.Clear();
                        XtraMessageBox.Show($"Cập nhật {rowsAffected} thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (rowsAffected == 0 && changedRows.Count > 0)
                    {
                        // Có dòng đánh dấu sửa đổi nhưng không có dòng nào được Update (có thể do lỗi hoặc concurrency)
                        XtraMessageBox.Show("Không có thể loại nào được cập nhật. Có thể dữ liệu đã bị thay đổi bởi người khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    bdsTHELOAI.CancelEdit(); // Hủy các thay đổi trên control
                    if (bdsTHELOAI.Current != null && ((DataRowView)bdsTHELOAI.Current).IsNew)
                    {
                        bdsTHELOAI.RemoveCurrent(); // Xóa dòng mới khỏi BindingSource
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
                // 6. Dọn dẹp List theo dõi thay đổi và cập nhật trạng thái nút
                editedRows.Clear();
                UpdateButtonStates();
            }
        }
        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Nếu đang ở mode Add mà nhấn Undo -> Coi như Cancel Add
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
                                    int foundPos = bdsTHELOAI.Find(action.PrimaryKeyColumnName, pkToFind);
                                    if (foundPos >= 0) targetPosition = foundPos;
                                }
                            }
                            // Đảm bảo vị trí hợp lệ
                            targetPosition = Math.Max(0, Math.Min(targetPosition, bdsTHELOAI.Count - 1));
                            if (bdsTHELOAI.Count > 0) bdsTHELOAI.Position = targetPosition;
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
                                    int foundPos = bdsTHELOAI.Find(action.PrimaryKeyColumnName, pkToFind);
                                    if (foundPos >= 0) targetPosition = foundPos;
                                }
                            }
                            // Đảm bảo vị trí hợp lệ
                            targetPosition = Math.Max(0, Math.Min(targetPosition, bdsTHELOAI.Count - 1));
                            if (bdsTHELOAI.Count > 0) bdsTHELOAI.Position = targetPosition;
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

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!isNhanVien && bdsTHELOAI.Count >= 0)
            {
                bdsTHELOAI.Position = 0;
                return;
            }
            if (editedRows.Count > 0)
            {
                if (XtraMessageBox.Show("Bạn có muốn hủy bỏ các thay đổi chưa lưu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.tableAdapterTHELOAI.Connection.ConnectionString = Program.connstr;
                    this.tableAdapterTHELOAI.Fill(this.qLTVDataSet.THELOAI);
                }
            }
            ResetOriginalUI();
            UpdateButtonStates();
            btnGhi.Enabled = btnRefresh.Enabled = false;

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!isNhanVien)
            {
                this.Close();
                return;
            }
            // Kiểm tra nếu có thay đổi chưa lưu trước khi thoát
            if (editedRows.Count > 0)
            {
                if (XtraMessageBox.Show("Bạn có thay đổi chưa lưu. Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                { return; }
            }
            this.Close();
        }
        #endregion

        #region FUNCTIONS HỖ TRỢ TRONG BTN CLICK *****************
        // Hàm hủy thao tác Thêm đang thực hiện
        private void CancelAddAction()
        {
            if (!isAddMode) return; // Chỉ hủy khi đang ở mode Add
            bdsTHELOAI.CancelEdit();
            if (bdsTHELOAI.Current != null && ((DataRowView)bdsTHELOAI.Current).IsNew)
            {   // Đảm bảo dòng hiện tại là dòng mới và xóa nó đi
                bdsTHELOAI.RemoveCurrent();
            }
            if (vitri >= 0 && vitri < bdsTHELOAI.Count)
            {   // Quay về vị trí trước khi nhấn Thêm
                bdsTHELOAI.Position = vitri;
            }
            ResetOriginalUI(); // cancel
        }

        private void setUIForAddMode(bool isAdd)
        {
            isAddMode = isAdd;
            gcTHELOAI.Enabled = !isAddMode; // Kích hoạt GridControl nếu không ở chế độ thêm mới
            UpdateButtonStates(); // Cập nhật trạng thái nút
            txtMATL.Focus();
        }
        private void ResetOriginalUI()
        {
            isAddMode = false;      // Tắt chế độ Thêm
            editedRows.Clear();     // Xóa danh sách dòng đang sửa
            gcTHELOAI.Enabled = !isAddMode; // Kích hoạt GridControl nếu không ở chế độ thêm mới
        }
        // Hàm tải lại dữ liệu cho các BindingSource chính
        private void ReloadData()
        {
            try
            {    // Lưu lại vị trí và ID hiện tại để cố gắng khôi phục sau khi tải lại
                int currentPosition = bdsTHELOAI.Position;
                object currentId = null;
                if (currentPosition >= 0 && bdsTHELOAI.Current != null)
                {
                    currentId = ((DataRowView)bdsTHELOAI.Current)[PK_COLUMN_NAME];
                }

                // Tải lại dữ liệu cho các bảng liên quan
                this.tableAdapterTHELOAI.Fill(this.qLTVDataSet.THELOAI);
                this.tableAdapterDAUSACH.Fill(this.qLTVDataSet.DAUSACH);

                // Cố gắng khôi phục vị trí
                if (currentId != null)
                {
                    int newPosition = bdsTHELOAI.Find(PK_COLUMN_NAME, currentId);
                    if (newPosition >= 0)
                    {
                        bdsTHELOAI.Position = newPosition;
                    }
                    else if (bdsTHELOAI.Count > 0)
                    {   // Nếu không tìm thấy ID cũ (ví dụ: bị xóa), về vị trí gần nhất
                        bdsTHELOAI.Position = Math.Max(0, Math.Min(currentPosition, bdsTHELOAI.Count - 1));
                    }
                }
                else if (bdsTHELOAI.Count > 0)
                {   // Nếu không có ID cũ, về vị trí đầu tiên
                    bdsTHELOAI.Position = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool checkValidInput()
        {
            string maTL = txtMATL.Text.Trim();
            string tenTL = txtTHELOAI.Text.Trim();

            if (string.IsNullOrWhiteSpace(maTL))
            {
                XtraMessageBox.Show("Mã thể loại không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMATL.Focus();
                return false;
            }

            if (maTL.Length > 10)
            {
                XtraMessageBox.Show("Mã thể loại không được vượt quá 10 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMATL.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tenTL))
            {
                XtraMessageBox.Show("Tên thể loại không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTHELOAI.Focus();
                return false;
            }

            if (tenTL.Length > 255)
            {
                XtraMessageBox.Show("Tên thể loại không được vượt quá 255 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTHELOAI.Focus();
                return false;
            }
            // Kiểm tra trùng lặp chỉ khi thêm hoặc sửa
            if (Program.KetNoi() == 0) return false;

            try
            {
                string query;

                if (isAddMode)
                {
                    query = "SELECT COUNT(*) FROM THELOAI WHERE MATL = @maTL OR THELOAI = @tenTL";
                }
                else
                {
                    query = "SELECT COUNT(*) FROM THELOAI WHERE (MATL = @maTL OR THELOAI = @tenTL) AND MATL != @maTLCu";
                }

                using (SqlCommand cmd = new SqlCommand(query, Program.conn))
                {
                    cmd.Parameters.AddWithValue("@maTL", maTL);
                    cmd.Parameters.AddWithValue("@tenTL", tenTL);

                    if (!isAddMode)
                    {
                        var currentRow = ((DataRowView)bdsTHELOAI.Current).Row;
                        string maTLCurrent = currentRow["MATL"].ToString();
                        cmd.Parameters.AddWithValue("@maTLCu", maTLCurrent);
                    }

                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        XtraMessageBox.Show("Mã thể loại hoặc Tên thể loại đã tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi kiểm tra dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }
        #endregion

        #region FUNCTION EXECUTE SQL (INSERT, UPDATE, DELETE) *****************
        // Hàm thực thi INSERT (dùng cho Undo Delete, Redo Add)
        private bool ExecuteInsert(string tableName, Dictionary<string, object> data)
        {
            if (string.IsNullOrEmpty(tableName) || data == null || data.Count == 0) return false;
            // Xây dựng câu lệnh INSERT
            StringBuilder sqlColumns = new StringBuilder();
            StringBuilder sqlValues = new StringBuilder();
            var parameters = new Dictionary<string, object>();
            /*
            sqlColumns ➔ [ID], [HoTen]
            sqlValues ➔ @ID, @HoTen
            parameters ➔ { @ID = 100, @HoTen = "HO VAN DUONG" }
            */
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
                if (!first)
                {
                    sqlSet.Append(", ");
                }
                sqlSet.Append($"[{kvp.Key}] = @{kvp.Key}"); // VD: [HOTEN] = @HOTEN
                parameters.Add($"@{kvp.Key}", kvp.Value ?? DBNull.Value); //DBNull = Null trong Database
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
            if (Program.conn.State == ConnectionState.Closed)
            {   // Đảm bảo connection string là mới nhất (nếu cần)
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
            }
            catch (SqlException sqlEx)
            {
                try { transaction?.Rollback(); } catch { /* Bỏ qua lỗi rollback */ }
                // Hiển thị lỗi SQL cụ thể hơn
                string errorMsg = $"SQL Error Number: {sqlEx.Number}\nMessage: {sqlEx.Message}\nSQL: {sql}";
                XtraMessageBox.Show(errorMsg, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rowsAffected = -1; // Đánh dấu lỗi
            }
            catch (Exception ex)
            {
                try { transaction?.Rollback(); } catch { /* Bỏ qua lỗi rollback */ }
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
    }
}