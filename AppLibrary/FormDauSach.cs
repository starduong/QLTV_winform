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
using static DevExpress.XtraEditors.Mask.MaskSettings;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.IO;
using DevExpress.XtraRichEdit.Import.Doc;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace AppLibrary
{
    public partial class FormDauSach : DevExpress.XtraEditors.XtraForm
    {
        #region *** VAR - CLASS ************************************************************************
        private int vitri = 0;
        private bool isAddMode = false;
        // editedRows lưu trữ các dòng đã chỉnh sửa ->Undo nhiều dòng cùng lúc
        private Dictionary<int, DataRow> editedRows = new Dictionary<int, DataRow>();

        // Lưu các dòng có thể xóa
        private HashSet<int> deletableRowHandles = new HashSet<int>();
        // Lưu các dòng đã chỉnh sửa để tô màu
        private HashSet<int> modifiedRows = new HashSet<int>();

        // Stack cho Undo và Redo
        private Stack<LogAction> undoStack = new Stack<LogAction>();
        private Stack<LogAction> redoStack = new Stack<LogAction>();

        private const string TABLE_NAME = "DAUSACH";
        private const string PK_COLUMN_NAME = "ISBN";
        // Phân quyền hiển thị UI
        bool isNhanVien = (Program.mGroup == "NHANVIEN");
        #endregion

        #region *** INIT FROM **************************************************************************
        public FormDauSach()
        {
            InitializeComponent();
        }

        private void FormDauSach_Load(object sender, EventArgs e)
        {
            qLTVDataSet.EnforceConstraints = false;
            this.tACGIATableAdapter.Connection.ConnectionString = Program.connstr;
            this.tACGIATableAdapter.Fill(this.qLTVDataSet.TACGIA);
            this.tableAdapterTACGIA_SACH.Connection.ConnectionString = Program.connstr;
            this.tableAdapterTACGIA_SACH.Fill(this.qLTVDataSet.TACGIA_SACH);
            this.tableAdapterCTNGANTU.Connection.ConnectionString = Program.connstr;
            this.tableAdapterCTNGANTU.Fill(this.qLTVDataSet.CHITIETNGANTU);
            this.tableAdapterTHELOAI.Connection.ConnectionString = Program.connstr;
            this.tableAdapterTHELOAI.Fill(this.qLTVDataSet.DSTHELOAI);
            this.tableAdapterNGONNGU.Connection.ConnectionString = Program.connstr;
            this.tableAdapterNGONNGU.Fill(this.qLTVDataSet.DSNGONNGU);
            this.tableAdapterDAUSACH.Connection.ConnectionString = Program.connstr;
            this.tableAdapterDAUSACH.Fill(this.qLTVDataSet.DAUSACH);
            this.tableAdapterSACH.Connection.ConnectionString = Program.connstr;
            this.tableAdapterSACH.Fill(this.qLTVDataSet.SACH);
            this.tINHTRANG_SACHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.tINHTRANG_SACHTableAdapter.Fill(this.qLTVDataSet.TINHTRANG_SACH);
            this.cHOMUON_SACHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cHOMUON_SACHTableAdapter.Fill(this.qLTVDataSet.CHOMUON_SACH);

            // Cấu hình giao diện GridView
            dteNGAYXB.Properties.MaxValue = DateTime.Today;
            gridViewDAUSACH.OptionsDetail.EnableMasterViewMode = false; // Không hiển thị view chi tiết
            gridViewDAUSACH.OptionsView.ShowGroupPanel = false;
            gridViewDAUSACH.OptionsFind.AlwaysVisible = true;  // Hiện ô tìm kiếm
            gridViewDAUSACH.OptionsFind.FindNullPrompt = "Nhập thông tin tìm kiếm..."; // Placeholder ô tìm kiếm

            // Ẩn các mục không cần thiết cho người dùng không phải nhân viên
            btnTHEM.Enabled = btnGHI.Enabled = btnXOA.Enabled = btnUNDO.Enabled = btnREDO.Enabled = btnTACGIA_SACH.Enabled = isNhanVien;
            this.contextMenuStripSACH.Enabled = this.contextMenuStripTACGIA.Enabled = this.pncINPUT.Visible = isNhanVien;
            this.gcThongTinDauSach.Width = !isNhanVien ? this.picDauSach.Width : this.gcThongTinDauSach.Width;
            if (isNhanVien)
            {
                UpdateButtonStates();
                btnGHI.Enabled = btnREFRESH.Enabled = false;
                if (bdsDAUSACH.Count == 0) { pncINPUT.Visible = false; }
                //--- cấu hình grid view SACH --------//
                btnGhiSach.Enabled = false;
                btnXoaSach.Enabled = (bdsSACH.Count > 0);

                //--- cấu hình grid view TACGIA_SACH --------//
                btnGHI_TGS.Enabled = false;
                btnXOA_TGS.Enabled = (bdsTACGIA_SACH.Count > 0);
            }
            gvSACH.Dock = DockStyle.Fill;
            gvTACGIA_SACH.Dock = DockStyle.Fill;
            gvTACGIA_SACH.ReadOnly = gvSACH.ReadOnly = !isNhanVien;       
        }

        private void FormDauSach_Shown(object sender, EventArgs e)
        {
            // === GỌI HÀM KIỂM TRA SAU KHI DỮ LIỆU ĐÃ ĐƯỢC TẢI ===
            KiemTraVaToMauDauSachMoCoi();
        }

        private void FormDauSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Validate();
                bdsSACH.EndEdit(); // Kết thúc mọi chỉnh sửa
                bdsDAUSACH.EndEdit();
                bdsTACGIA_SACH.EndEdit();
            }
            catch (Exception ex)
            {
                // Báo lỗi nếu không thể hoàn tất chỉnh sửa
                MessageBox.Show("Dữ liệu chưa hợp lệ hoặc lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Không cho phép đóng form
            }
        }

        public void UpdateButtonStates()
        {
            // === 1. Kiểm tra trạng thái dữ liệu ===
            bool hasUnsavedChanges = false;
            bool hasData = bdsDAUSACH.Count > 0;

            // 1.1 Dữ liệu đã chỉnh sửa và chuyển dòng (đã lưu trong editedRows)
            if (modifiedRows.Count > 0)
            {
                hasUnsavedChanges = true;
            }
            // 1.2 Dòng hiện tại đang chỉnh sửa nhưng chưa chuyển dòng
            else if (bdsDAUSACH.Current is DataRowView currentRowView &&
                     currentRowView.Row.RowState == DataRowState.Modified)
            {
                hasUnsavedChanges = true;
            }

            // === 2. Cập nhật trạng thái các nút chức năng ===
            btnTHEM.Enabled = isNhanVien && !isAddMode;
            btnGHI.Enabled = isNhanVien && (isAddMode || hasUnsavedChanges);
            btnUNDO.Enabled = isNhanVien && (isAddMode || undoStack.Count > 0);
            btnREDO.Enabled = isNhanVien && !isAddMode && redoStack.Count > 0;
            btnREFRESH.Enabled = !isAddMode && (hasUnsavedChanges || (bdsDAUSACH.Position != 0));
            btnTACGIA_SACH.Enabled = !isAddMode;
            btnTHOAT.Enabled = !isAddMode;

            // === 3. Cập nhật nút XÓA ===
            bool canDeleteCurrentRow = false;
            // Kiểm tra dòng đang được chọn có nằm trong danh sách cho phép xóa không
            if (hasData && gridViewDAUSACH.FocusedRowHandle >= 0)
            {
                canDeleteCurrentRow = deletableRowHandles.Contains(gridViewDAUSACH.FocusedRowHandle);
            }

            // Nút XÓA: chỉ bật khi có dữ liệu, là nhân viên, không ở chế độ thêm,
            // không có dữ liệu chưa lưu và dòng hiện tại được phép xóa
            btnXOA.Enabled = isNhanVien && hasData && !isAddMode && !hasUnsavedChanges && canDeleteCurrentRow;
        }


        // Xử lý sự kiện khi thay đổi các ô input
        private void AnyTextBox_TextChanged(object sender, EventArgs e)
        {   // Nếu đang ở chế độ thêm, hoặc không có dòng hiện tại, hoặc bindingsource rỗng -> bỏ qua
            if (isAddMode || bdsDAUSACH.Current == null || bdsDAUSACH.Count == 0) return;
            int currentPos = bdsDAUSACH.Position;
            var currentRow = ((DataRowView)bdsDAUSACH.Current).Row;
            // Nếu dòng này chưa được đánh dấu là đã sửa, thêm nó vào dictionary editedRows
            if (!editedRows.ContainsKey(currentPos))
            {   // Chỉ thêm vào nếu nó chưa bị sửa hoặc trạng thái là Unchanged/Modified
                if (currentRow.RowState == DataRowState.Unchanged || currentRow.RowState == DataRowState.Modified)
                {
                    editedRows[currentPos] = currentRow;
                }
            }
            // === Bật nút GHI và REFRESH ngay lập tức khi có thay đổi ===
            // Điều này xử lý trường hợp người dùng đang chỉnh sửa dòng hiện tại.
            btnGHI.Enabled = isNhanVien;
            btnREFRESH.Enabled = true;
        }

        // Xử lý sự kiện khi người dùng thay đổi giá trị trong ComboBox cbNgonNgu
        private void cbNgonNgu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaNgonNgu.Text = cbNgonNgu.SelectedValue?.ToString() ?? string.Empty;
            }
            catch { }
        }

        // Xử lý sự kiện khi người dùng thay đổi giá trị trong ComboBox cbTheLoai
        private void cbTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaTheLoai.Text = cbTheLoai.SelectedValue?.ToString() ?? string.Empty;
            }
            catch { }
        }

        private void gridViewDAUSACH_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // e.PrevFocusedRowHandle là vị trí của dòng vừa mất focus.
            if (e.PrevFocusedRowHandle >= 0)
            {
                // Lấy DataRow của dòng vừa rời đi
                DataRow prevRow = gridViewDAUSACH.GetDataRow(e.PrevFocusedRowHandle);

                // Kiểm tra xem dòng đó có thực sự bị thay đổi không (trạng thái là 'Modified')
                // Đây là điểm mấu chốt: chỉ khi dữ liệu đã thay đổi và BindingSource đã cập nhật thì RowState mới là Modified.
                if (prevRow != null && prevRow.RowState == DataRowState.Modified)
                {
                    modifiedRows.Add(e.PrevFocusedRowHandle);
                    // Yêu cầu vẽ lại dòng vừa rời đi để tô màu nó
                    gridViewDAUSACH.RefreshRow(e.PrevFocusedRowHandle);
                }
            }

            // CẬP NHẬT TRẠNG THÁI CÁC NÚT DỰA TRÊN `editedRows`
            UpdateButtonStates();

            HienThiAnhTheoTenFile();
        }
        #endregion

        #region *** XỬ LÝ HIỆN THỊ VÀ LƯU ẢNH **********************************************************
        private void HienThiAnhTheoTenFile()
        {
            //if (string.IsNullOrWhiteSpace(txtHinhAnh.Text))
            //    return;

            string thuMucAnh = @"C:\Users\Duong\Documents\C#\SolutionAppLibrary\AppLibrary\Resources\";
            string duongDanAnh = Path.Combine(thuMucAnh, txtHinhAnh.Text);

            try
            {
                picDauSach.Image = Image.FromFile(duongDanAnh);
            }
            catch
            {
                picDauSach.Image = Image.FromFile(Path.Combine(thuMucAnh, "images-is-empty.jpg"));
            }
        }


        // Xử lý sự kiện khi người dùng nhấp vào TextBox txtHinhAnh
        // -> Mở hộp thoại chọn tệp
        // -> Lấy đường dẫn tệp đã chọn và gán tên file vào TextBox txtHinhAnh
        // -> Hiển thị ảnh trong PictureEdit picDauSach
        private string duongDanGocHinhAnh = string.Empty;
        private void txtHinhAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All files (*.*)|*.*";
            openFileDialog.Title = "Chọn ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn đầy đủ của tệp đã chọn
                duongDanGocHinhAnh = openFileDialog.FileName;

                // Lấy chỉ tên tệp (không bao gồm đường dẫn)
                string fileName = System.IO.Path.GetFileName(duongDanGocHinhAnh);

                // Gán tên tệp vào TextBox txtHinhAnh
                txtHinhAnh.Text = fileName;

                // (Tùy chọn) Hiển thị ảnh vừa chọn trong PictureEdit picDauSach
                try
                {
                    picDauSach.Image = System.Drawing.Image.FromFile(duongDanGocHinhAnh);
                }
                catch (System.IO.FileNotFoundException ex)
                {   // Xử lý lỗi nếu không tìm thấy tệp (ví dụ: hiển thị ảnh mặc định)
                    XtraMessageBox.Show($"Không tìm thấy tệp: {duongDanGocHinhAnh}" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {   // Xử lý các lỗi khác khi tải ảnh
                    XtraMessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private string LuuAnhVaoResources(string duongDanGoc)
        {
            try
            {
                // Thư mục đích cố định (bạn có thể cho nó là cấu hình nếu cần)
                string thuMucDich = @"C:\Users\Duong\Documents\C#\SolutionAppLibrary\AppLibrary\Resources";

                // Kiểm tra thư mục tồn tại, nếu chưa thì tạo
                if (!Directory.Exists(thuMucDich))
                {
                    Directory.CreateDirectory(thuMucDich);
                }

                // Lấy tên tệp từ đường dẫn gốc
                string tenFile = txtHinhAnh.Text.Trim();

                // Tạo đường dẫn đích
                string duongDanDich = Path.Combine(thuMucDich, tenFile);

                // Nếu file chưa tồn tại ở đích thì mới copy
                if (!File.Exists(duongDanDich))
                {
                    File.Copy(duongDanGoc, duongDanDich);
                }

                // Trả về tên file để lưu vào CSDL hoặc textbox
                return tenFile;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi lưu ảnh vào Resources: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion

        #region *** XỬ LÝ HỖ TRỢ UI CHO NÚT XÓA *********************************************************
        // Thêm hàm này vào class FormDauSach
        private bool KiemTraTonTaiSachHoacTacGia(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
            {
                return false;
            }
            if (Program.KetNoi() == 0) return false;
            string query = @"
            SELECT 1
            WHERE EXISTS (
                SELECT 1 FROM SACH WHERE ISBN = @ISBN
            ) OR EXISTS (
                SELECT 1 FROM TACGIA_SACH WHERE ISBN = @ISBN
            );";

            using (SqlCommand command = new SqlCommand(query, Program.conn))
            {
                command.Parameters.AddWithValue("@ISBN", isbn);
                try
                {
                    // ExecuteScalar sẽ trả về object đầu tiên của dòng đầu tiên,
                    // hoặc null nếu không có kết quả nào.
                    object result = command.ExecuteScalar();
                    // Nếu result không phải là null (tức là câu lệnh SELECT 1 đã chạy thành công),
                    // nghĩa là ISBN tồn tại.
                    return (result != null);
                }
                catch (Exception ex)
                {
                    // Ghi log hoặc hiển thị lỗi nếu cần thiết
                    XtraMessageBox.Show("Lỗi khi kiểm tra dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true; // Mặc định trả về true để tránh xóa nhầm
                }
                finally
                {
                    Program.conn.Close(); // Đóng kết nối sau khi thực hiện xong
                }
            }
        }

        private void KiemTraVaToMauDauSachMoCoi()
        {
            // Xóa danh sách cũ
            deletableRowHandles.Clear();
            List<string> orphanISBNs = new List<string>();

            // 1. THU THẬP DỮ LIỆU
            for (int i = 0; i < gridViewDAUSACH.DataRowCount; i++)
            {
                // Nhớ Trim() để loại bỏ khoảng trắng
                string isbn = gridViewDAUSACH.GetRowCellValue(i, "ISBN")?.ToString().Trim();
                if (!string.IsNullOrEmpty(isbn))
                {
                    if (!KiemTraTonTaiSachHoacTacGia(isbn))
                    {
                        if (isNhanVien)
                        {
                            deletableRowHandles.Add(i);
                        }
                        else
                        {
                            orphanISBNs.Add(isbn);
                        }
                    }
                }
            }

            // 2. XỬ LÝ GIAO DIỆN DỰA TRÊN QUYỀN
            if (isNhanVien)
            {
                // Dành cho NHANVIEN: Tô màu
                // Xóa bộ lọc cũ trên BindingSource (nếu có) để nhân viên thấy tất cả
                bdsDAUSACH.Filter = null;
                gridViewDAUSACH.RefreshData(); // Kích hoạt RowStyle
            }
            else
            {
                // Dành cho người dùng khác: Lọc trực tiếp trên BindingSource
                if (orphanISBNs.Count > 0)
                {
                    // Tạo chuỗi filter (đã được xác nhận là đúng)
                    var quotedISBNs = orphanISBNs.Select(isbn => $"'{EscapeFilterString(isbn)}'");
                    string filterString = $"ISBN NOT IN ({string.Join(", ", quotedISBNs)})";

                    // === THAY ĐỔI QUAN TRỌNG NHẤT ===
                    // Áp dụng bộ lọc cho BINDING SOURCE, không phải GridView
                    try
                    {
                        bdsDAUSACH.Filter = filterString;
                    }
                    catch (Exception ex)
                    {
                        // Bắt lỗi nếu cú pháp filter sai
                        XtraMessageBox.Show("Lỗi khi áp dụng bộ lọc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Nếu không có gì để lọc, xóa bộ lọc trên BindingSource
                    bdsDAUSACH.Filter = null;
                }
            }
        }

        private string EscapeFilterString(string str)
        {
            // Dấu nháy đơn ' là ký tự đặc biệt trong chuỗi filter, cần được nhân đôi  
            return str.Replace("'", "''");
        }
        #endregion

        #region *** XỬ LÝ CÁC NÚT CHỨC NĂNG ***************************************************************
        private void btnTHEM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsDAUSACH.Position; // Lưu vị trí hiện tại
            bdsDAUSACH.AddNew();
            setUIForAddMode(true); // Chuyển sang chế độ thêm mới
        }

        private void btnXOA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsSACH.Count > 0)
            {
                XtraMessageBox.Show("Đầu sách đang đại diện cho một số sách, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsDAUSACH.Current == null)
            {
                XtraMessageBox.Show("Vui lòng chọn đầu sách cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (bdsTACGIA_SACH.Count > 0)
            {
                XtraMessageBox.Show("Đầu sách đang đại diện cho một số tác giả, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vitri = bdsDAUSACH.Position; // Lưu vị trí dòng sẽ xóa
            LogAction action = null;    // Khai báo action để lưu thông tin undo
            object deletedPrimaryKey = null; // Lưu khóa chính của dòng bị xóa
            try
            {   // Lấy dòng hiện tại từ BindingSource
                var currentRow = ((DataRowView)bdsDAUSACH.Current).Row;
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
                bdsDAUSACH.RemoveCurrent();
                // Ghi thay đổi xuống Database (quan trọng: làm điều này trong try-catch)
                this.tableAdapterDAUSACH.Update(this.qLTVDataSet.DAUSACH);

                // **XÓA THÀNH CÔNG -> PUSH VÀO UNDO STACK**
                undoStack.Push(action);
                redoStack.Clear();  // Xóa redo stack khi có hành động mới
                //XtraMessageBox.Show("Xóa đầu sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // **XÓA THẤT BẠI**
                XtraMessageBox.Show("Lỗi xóa đầu sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tableAdapterDAUSACH.Fill(this.qLTVDataSet.DAUSACH);
                // Cố gắng đặt lại vị trí con trỏ
                int foundPos = bdsDAUSACH.Find(PK_COLUMN_NAME, deletedPrimaryKey);
                if (foundPos >= 0) bdsDAUSACH.Position = foundPos;
                else bdsDAUSACH.Position = vitri; // Về vị trí cũ nếu không tìm thấy
                return;
            }
            finally
            {
                UpdateButtonStates();
                ResetOriginalUI();
            }
        }

        private void btnGHI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 1. Kiểm tra dữ liệu nhập hợp lệ
            if (!checkValidInput()) return;

            // 2. Xác thực và kết thúc chỉnh sửa trên BindingSource
            try
            {
                this.Validate(); // Đảm bảo các control đã validate
                bdsDAUSACH.EndEdit(); // Lưu các thay đổi từ control vào DataRowView hiện tại
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi kết thúc chỉnh sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dòng hiện tại (sau khi EndEdit)
            var currentView = bdsDAUSACH.Current as DataRowView;
            if (currentView == null)
            {
                XtraMessageBox.Show("Không có dòng dữ liệu hợp lệ để ghi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var currentRow = currentView.Row;
            // **CHUẨN HÓA TÊN ĐẦU SÁCH**
            if (currentRow["TENSACH"] != null && !string.IsNullOrEmpty(currentRow["TENSACH"].ToString()))
            {
                currentRow["TENSACH"] = ChuanHoaTenDauSach(currentRow["TENSACH"].ToString());
            }
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
                        XtraMessageBox.Show("Thêm đầu sách thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Cần xử lý hủy bỏ dòng mới thêm trên UI nếu insert lỗi
                        bdsDAUSACH.CancelEdit();
                        if (bdsDAUSACH.Current != null && ((DataRowView)bdsDAUSACH.Current).IsNew)
                        {
                            bdsDAUSACH.RemoveCurrent();
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
                        Positions = new List<int> { bdsDAUSACH.Position } // Lưu vị trí dòng mới
                    };
                    undoStack.Push(action);
                    redoStack.Clear();
                    if (!string.IsNullOrEmpty(duongDanGocHinhAnh))
                    {
                        string tenAnh = LuuAnhVaoResources(duongDanGocHinhAnh);
                        if (tenAnh != null)
                        {
                            txtHinhAnh.Text = tenAnh; // Đảm bảo TextBox lưu tên đúng sau khi copy
                        }
                        else
                        {
                            XtraMessageBox.Show("Lỗi khi lưu ảnh vào Resources.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    ReloadData();
                    // Đặt vị trí về dòng mới thêm (Tìm lại bằng ID để chắc chắn)
                    bdsDAUSACH.Position = bdsDAUSACH.Find(PK_COLUMN_NAME, newPkValue);
                    XtraMessageBox.Show($"Thêm đầu sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    // **CHUẨN HÓA TÊN ĐẦU SÁCH CHO TẤT CẢ DÒNG ĐÃ SỬA**
                    foreach (var row in changedRows)
                    {
                        if (row["TENSACH"] != null && !string.IsNullOrEmpty(row["TENSACH"].ToString()))
                        {
                            row["TENSACH"] = ChuanHoaTenDauSach(row["TENSACH"].ToString());
                        }
                    }

                    // Thu thập dữ liệu gốc và hiện tại cho các dòng đã thay đổi
                    foreach (DataRow row in changedRows)
                    {
                        var currentData = new Dictionary<string, object>();
                        var originalData = new Dictionary<string, object>();
                        int position = bdsDAUSACH.Find(PK_COLUMN_NAME, row[PK_COLUMN_NAME]); // Tìm vị trí thực tế của dòng

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
                    int rowsAffected = this.tableAdapterDAUSACH.Update(this.qLTVDataSet.DAUSACH);

                    if (rowsAffected > 0) // Kiểm tra xem có dòng nào được cập nhật thành công không
                    {
                        // **UPDATE THÀNH CÔNG -> Push LogAction**
                        undoStack.Push(action);
                        redoStack.Clear();
                        XtraMessageBox.Show($"Cập nhật {rowsAffected} đầu sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (rowsAffected == 0 && changedRows.Count > 0)
                    {
                        // Có dòng đánh dấu sửa đổi nhưng không có dòng nào được Update (có thể do lỗi hoặc concurrency)
                        XtraMessageBox.Show("Không có đầu sách nào được cập nhật. Có thể dữ liệu đã bị thay đổi bởi người khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Cân nhắc ReloadData() để lấy dữ liệu mới nhất
                        ReloadData();
                    }
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
                    bdsDAUSACH.CancelEdit(); // Hủy các thay đổi trên control
                    if (bdsDAUSACH.Current != null && ((DataRowView)bdsDAUSACH.Current).IsNew)
                    {
                        bdsDAUSACH.RemoveCurrent(); // Xóa dòng mới khỏi BindingSource
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
        private void btnUNDO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                    //XtraMessageBox.Show("Hoàn tác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                                    int foundPos = bdsDAUSACH.Find(action.PrimaryKeyColumnName, pkToFind);
                                    if (foundPos >= 0) targetPosition = foundPos;
                                }
                            }
                            // Đảm bảo vị trí hợp lệ
                            targetPosition = Math.Max(0, Math.Min(targetPosition, bdsDAUSACH.Count - 1));
                            if (bdsDAUSACH.Count > 0) bdsDAUSACH.Position = targetPosition;
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

        private void btnREDO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                    //XtraMessageBox.Show("Làm lại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                                    int foundPos = bdsDAUSACH.Find(action.PrimaryKeyColumnName, pkToFind);
                                    if (foundPos >= 0) targetPosition = foundPos;
                                }
                            }
                            // Đảm bảo vị trí hợp lệ
                            targetPosition = Math.Max(0, Math.Min(targetPosition, bdsDAUSACH.Count - 1));
                            if (bdsDAUSACH.Count > 0) bdsDAUSACH.Position = targetPosition;
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

        private void btnREFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (modifiedRows.Count > 0)
            {
                if (XtraMessageBox.Show("Bạn có muốn hủy bỏ các thay đổi chưa lưu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.tableAdapterDAUSACH.Connection.ConnectionString = Program.connstr;
                    this.tableAdapterDAUSACH.Fill(this.qLTVDataSet.DAUSACH);
                }
            }
            ResetOriginalUI();
            UpdateButtonStates();
            btnGHI.Enabled = btnREFRESH.Enabled = false;
            if (bdsDAUSACH.Count >= 0)
            {
                bdsDAUSACH.Position = 0;
                btnREFRESH.Enabled = false;
                return;
            }
        }

        private void btnTHOAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   // Kiểm tra nếu có thay đổi chưa lưu trước khi thoát
            if (modifiedRows.Count > 0)
            {
                if (XtraMessageBox.Show("Bạn có thay đổi chưa lưu. Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                { return; }
            }
            this.Close();
        }
        #endregion

        #region *** HÀM HỖ TRỢ NÚT CHỨC NĂNG ***********************************************************
        // Hàm hủy thao tác Thêm đang thực hiện
        private void CancelAddAction()
        {
            if (!isAddMode) return; // Chỉ hủy khi đang ở mode Add
            bdsDAUSACH.CancelEdit();
            if (bdsDAUSACH.Current != null && ((DataRowView)bdsDAUSACH.Current).IsNew)
            {   // Đảm bảo dòng hiện tại là dòng mới và xóa nó đi
                bdsDAUSACH.RemoveCurrent();
            }
            if (vitri >= 0 && vitri < bdsDAUSACH.Count)
            {   // Quay về vị trí trước khi nhấn Thêm
                bdsDAUSACH.Position = vitri;
            }
            ResetOriginalUI(); // cancel
        }

        private void setUIForAddMode(bool isAdd)
        {
            isAddMode = isAdd;
            gcDAUSACH.Enabled = !isAddMode; // Kích hoạt GridControl nếu không ở chế độ thêm mới
            UpdateButtonStates(); // Cập nhật trạng thái nút
            txtTENSACH.Focus();
            txtISBN.Enabled = isAdd;
            btnREFRESH.Enabled = !isAdd;
            this.contextMenuStripSACH.Enabled = this.contextMenuStripTACGIA.Enabled = !isAdd;
            HienThiAnhTheoTenFile();
        }
        private void ResetOriginalUI()
        {
            isAddMode = false;      // Tắt chế độ Thêm
            editedRows.Clear();     // Xóa danh sách dòng đang sửa
            modifiedRows.Clear(); // Xóa danh sách màu đã chỉnh sửa
            gcDAUSACH.Enabled = !isAddMode; // Kích hoạt GridControl nếu không ở chế độ thêm mới
            KiemTraVaToMauDauSachMoCoi();
            // Vẽ lại toàn bộ Grid để xóa hết các highlight màu vàng
            gridViewDAUSACH.RefreshData();
            txtISBN.Enabled = false; // Tắt chỉnh sửa ISBN khi không ở chế độ thêm mới
            this.contextMenuStripSACH.Enabled = this.contextMenuStripTACGIA.Enabled = isNhanVien;
        }
        // Hàm tải lại dữ liệu cho các BindingSource chính
        private void ReloadData()
        {
            try
            {    // Lưu lại vị trí và ID hiện tại để cố gắng khôi phục sau khi tải lại
                int currentPosition = bdsDAUSACH.Position;
                object currentId = null;
                if (currentPosition >= 0 && bdsDAUSACH.Current != null)
                {
                    currentId = ((DataRowView)bdsDAUSACH.Current)[PK_COLUMN_NAME];
                }

                // Tải lại dữ liệu cho các bảng liên quan
                this.tableAdapterCTNGANTU.Fill(this.qLTVDataSet.CHITIETNGANTU);
                this.tableAdapterTHELOAI.Fill(this.qLTVDataSet.DSTHELOAI);
                this.tableAdapterNGONNGU.Fill(this.qLTVDataSet.DSNGONNGU);
                this.tableAdapterDAUSACH.Fill(this.qLTVDataSet.DAUSACH);
                this.tableAdapterSACH.Fill(this.qLTVDataSet.SACH);

                // Cố gắng khôi phục vị trí
                if (currentId != null)
                {
                    int newPosition = bdsDAUSACH.Find(PK_COLUMN_NAME, currentId);
                    if (newPosition >= 0)
                    {
                        bdsDAUSACH.Position = newPosition;
                    }
                    else if (bdsDAUSACH.Count > 0)
                    {   // Nếu không tìm thấy ID cũ (ví dụ: bị xóa), về vị trí gần nhất
                        bdsDAUSACH.Position = Math.Max(0, Math.Min(currentPosition, bdsDAUSACH.Count - 1));
                    }
                }
                else if (bdsDAUSACH.Count > 0)
                {   // Nếu không có ID cũ, về vị trí đầu tiên
                    bdsDAUSACH.Position = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string ChuanHoaTenDauSach(string tenDauSach)
        {
            // Kiểm tra trường hợp null hoặc rỗng
            if (string.IsNullOrEmpty(tenDauSach))
            {
                return string.Empty;
            }

            // Xóa khoảng trắng đầu/cuối và thay nhiều khoảng trắng bằng một khoảng trắng
            string result = System.Text.RegularExpressions.Regex.Replace(tenDauSach.Trim(), @"\s+", " ");

            return result;
        }

        //Kiểm tra dữ liệu đầu vào
        private bool checkValidInput()
        {
            // Kiểm tra Tên sách
            if (string.IsNullOrWhiteSpace(txtTENSACH.Text.Trim()))
            {
                XtraMessageBox.Show("Tên sách không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTENSACH.Focus();
                return false;
            }

            // Kiểm tra Nhà xuất bản
            if (string.IsNullOrWhiteSpace(txtNHAXB.Text.Trim()))
            {
                XtraMessageBox.Show("Nhà xuất bản không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNHAXB.Focus();
                return false;
            }

            // Kiểm tra ISBN
            string iSBN = txtISBN.Text.Trim();

            if (string.IsNullOrWhiteSpace(iSBN))
            {
                XtraMessageBox.Show("ISBN không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtISBN.Focus();
                return false;
            }
            else if (iSBN.Contains(" "))
            {
                XtraMessageBox.Show("ISBN không được chứa dấu cách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtISBN.Focus();
                return false;
            }
            else if (!Regex.IsMatch(iSBN, @"^\d{10}(\d{3})?$")) // 10 hoặc 13 số
            {
                XtraMessageBox.Show("ISBN phải gồm 10 hoặc 13 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtISBN.Focus();
                return false;
            }

            // Kiểm tra trùng lặp chỉ khi thêm hoặc sửa
            if (Program.KetNoi() == 0) return false;

            try
            {
                string query;

                if (isAddMode)
                {
                    query = "SELECT COUNT(*) FROM DAUSACH WHERE ISBN = @iSBN";
                }
                else
                {
                    query = "SELECT COUNT(*) FROM DAUSACH WHERE (ISBN = @iSBN) AND ISBN != @iSBNCurrent";
                }

                using (SqlCommand cmd = new SqlCommand(query, Program.conn))
                {
                    cmd.Parameters.AddWithValue("@iSBN", iSBN);

                    if (!isAddMode)
                    {
                        var currentRow = ((DataRowView)bdsDAUSACH.Current).Row;
                        string iSBNCurrent = currentRow["ISBN"].ToString();
                        cmd.Parameters.AddWithValue("@iSBNCurrent", iSBNCurrent);
                    }

                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        XtraMessageBox.Show("ISBN đầu sách đã tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi kiểm tra dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra Ngày xuất bản
            if (dteNGAYXB.EditValue == null || dteNGAYXB.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("Ngày xuất bản không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dteNGAYXB.Focus();
                return false;
            }

            if (!DateTime.TryParse(dteNGAYXB.EditValue.ToString(), out DateTime ngayXB))
            {
                XtraMessageBox.Show("Giá trị ngày xuất bản không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dteNGAYXB.Focus();
                return false;
            }

            // Kiểm tra Lần xuất bản
            if (string.IsNullOrWhiteSpace(speLANXB.Text))
            {
                XtraMessageBox.Show("Lần xuất bản không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                speLANXB.Focus();
                return false;
            }

            // Kiểm tra Số trang
            if (string.IsNullOrWhiteSpace(speSOTRANG.Text))
            {
                XtraMessageBox.Show("Số trang không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                speSOTRANG.Focus();
                return false;
            }

            // 🆕 Kiểm tra Ngôn Ngữ
            if (cbNgonNgu.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Vui lòng chọn Ngôn ngữ cho sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbNgonNgu.Focus();
                return false;
            }

            // 🆕 Kiểm tra Thể Loại
            if (cbTheLoai.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Vui lòng chọn Thể loại cho sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTheLoai.Focus();
                return false;
            }

            // 🆕 Kiểm tra Khổ Sách (cho phép nhập tay)
            if (string.IsNullOrWhiteSpace(cbKHOSACH.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn hoặc nhập Khổ sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbKHOSACH.Focus();
                return false;
            }

            // Kiểm tra Giá
            if (speGIA.Value <= 0)
            {
                XtraMessageBox.Show("Giá sách phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                speGIA.Focus();
                return false;
            }

            // Kiểm tra Hình ảnh (nếu bắt buộc nhập hình)
            if (string.IsNullOrWhiteSpace(txtHinhAnh.Text.Trim()))
            {
                XtraMessageBox.Show("Đường dẫn hình ảnh không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHinhAnh.Focus();
                return false;
            }

            // Kiểm tra Nội dung
            if (string.IsNullOrWhiteSpace(txtNOIDUNG.Text.Trim()))
            {
                XtraMessageBox.Show("Nội dung sách không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNOIDUNG.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region *** HÀM HỖ TRỢ THỰC THI SQL *************************************************************
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

        #region *** BỔ SUNG XỬ LÝ SỰ KIỆN CHO GRIDVIEW DAUSACH *****************************************
        private void gridViewDAUSACH_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            // Bỏ qua nếu là dòng không hợp lệ (ví dụ: dòng Thêm mới)
            if (e.RowHandle < 0) return;

            GridView view = sender as GridView;
            if (view == null) return;

            // Lấy DataRow tương ứng với dòng đang được vẽ
            DataRow row = view.GetDataRow(e.RowHandle);

            // Nếu không lấy được DataRow (có thể xảy ra với một số dòng đặc biệt) -> bỏ qua
            if (row == null) return;

            // Kiểm tra xem DataRow này có nằm trong danh sách các dòng đã chỉnh sửa không
            if (isNhanVien && modifiedRows.Contains(e.RowHandle))
            {
                // Nếu có, thay đổi màu nền của dòng
                e.Appearance.BackColor = Color.LightGoldenrodYellow;
                e.Appearance.BackColor2 = Color.LightYellow;
                e.HighPriority = true; // Đảm bảo style này được ưu tiên áp dụng
            }
            // Kiểm tra xem dòng này có phải là "mồ côi" (có thể xóa) không
            if (isNhanVien && deletableRowHandles.Contains(e.RowHandle))
            {
                e.Appearance.BackColor = Color.LightGray;
                e.Appearance.ForeColor = Color.DimGray;
                e.HighPriority = true; // Ưu tiên style này nếu không có style nào khác
            }
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            // Chỉ xử lý nếu control là gcDAUSACH
            if (e.SelectedControl != gcDAUSACH) return;

            // Tính toán vị trí chuột trên GridView
            GridHitInfo hitInfo = gridViewDAUSACH.CalcHitInfo(e.ControlMousePosition);
            if (hitInfo == null || !hitInfo.InRow || hitInfo.RowHandle < 0) return;

            // Lấy DataRow tương ứng với dòng
            DataRow row = gridViewDAUSACH.GetDataRow(hitInfo.RowHandle);
            if (row == null) return;

            // Tạo tooltip dựa trên trạng thái dòng
            ToolTipControlInfo toolTipInfo = GetToolTipInfo(hitInfo.RowHandle);
            if (toolTipInfo != null)
            {
                e.Info = toolTipInfo;
            }
        }

        private ToolTipControlInfo GetToolTipInfo(int rowHandle)
        {
            // Trường hợp dòng đã chỉnh sửa (chưa lưu)
            if (modifiedRows.Contains(rowHandle))
            {
                return new ToolTipControlInfo($"EditedRow_{rowHandle}", "Dòng này đã được chỉnh sửa và chưa được lưu.")
                {
                    IconType = ToolTipIconType.Warning,
                    Title = "Thay đổi chưa lưu"
                };
            }

            // Trường hợp dòng có thể xóa (đầu sách mồ côi)
            if (deletableRowHandles.Contains(rowHandle))
            {
                return new ToolTipControlInfo($"DeletableRow_{rowHandle}", "Đầu sách này chưa có bản sao và chưa được gán tác giả. Có thể xóa.")
                {
                    IconType = ToolTipIconType.Information,
                    Title = "Thông tin xóa"
                };
            }

            // Không cần tooltip
            return null;
        }

        #endregion

        #region *** PHẦN GRID VIEW SÁCH ****************************************************************
        private void gvSACH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // === THÊM ĐIỀU KIỆN KIỂM TRA NÀY VÀO ===
            // Bỏ qua nếu đang định dạng cho header của cột hoặc header của dòng
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            // Lấy tên cột đang được định dạng
            // Dòng này bây giờ đã an toàn để thực thi
            string columnName = gvSACH.Columns[e.ColumnIndex].Name;

            // === Xử lý cho cột CHOMUON ===
            if (columnName == "CHOMUON") // Sử dụng tên cột bạn đã đặt
            {
                // Kiểm tra giá trị của ô (giá trị gốc từ database)
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    try
                    {
                        // Ép kiểu giá trị về boolean
                        bool isChoMuon = Convert.ToBoolean(e.Value);

                        // Thay đổi giá trị hiển thị
                        if (isChoMuon)
                        {
                            e.Value = "Đã cho mượn";
                            // (Tùy chọn) Tô màu để nhấn mạnh
                            e.CellStyle.ForeColor = Color.Red;
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        }
                        else
                        {
                            e.Value = "Chưa cho mượn";
                            e.CellStyle.ForeColor = Color.Green;
                        }

                        // Đánh dấu là đã định dạng để tránh định dạng mặc định
                        e.FormattingApplied = true;
                    }
                    catch (FormatException)
                    {
                        // Xử lý trường hợp giá trị không thể chuyển đổi sang boolean
                        e.Value = "Không xác định";
                    }
                }
            }
        }
        //____________ BUTTON THÊM SÁCH ______________________________________________________________
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            if (bdsDAUSACH.Current == null)
            {
                XtraMessageBox.Show("Chưa chọn đầu sách để thêm sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bdsSACH.AddNew();

            DataRowView newRow = bdsSACH.Current as DataRowView;
            if (newRow != null)
            {
                newRow.BeginEdit(); // Bắt đầu chế độ sửa đổi cho dòng

                newRow["TINHTRANG"] = true;
                newRow["CHOMUON"] = false;

                newRow.EndEdit(); // Kết thúc sửa đổi, commit giá trị

                // === THÊM DÒNG NÀY VÀO ===
                // Buộc BindingSource thông báo cho các control được liên kết
                bdsSACH.EndEdit();
            }
        }
        //____________ BUTTON LƯU SÁCH ______________________________________________________________
        private void btnGhiSach_Click(object sender, EventArgs e)
        {
            try
            {   // Kết thúc chỉnh sửa trên BindingSource TGS
                this.Validate();
                bdsSACH.EndEdit();
                if (loiDangChinhSuaSACH)
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lỗi chỉnh sửa trước khi ghi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!KiemTraHopLeDuLieuSach(out string errorMessage))
                {
                    XtraMessageBox.Show(errorMessage, "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.tableAdapterSACH.Update(this.qLTVDataSet.SACH);
                XtraMessageBox.Show("Ghi sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KiemTraVaToMauDauSachMoCoi();
                btnGhiSach.Enabled = false;
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 2627 || sqlEx.Number == 2601) // Lỗi Primary Key/Unique Constraint
            {
                XtraMessageBox.Show("Lỗi: Không thể thêm/sửa liên kết. Có thể sách này đã được gán cho sách.\n" + sqlEx.Message, "Lỗi Trùng Khóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Bắt các lỗi khác
                XtraMessageBox.Show("Lỗi ghi dữ liệu Sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Reload lại để hủy thay đổi trên UI
                ReloadTacGiaSachData();
            }
        }
        //____________ BUTTON XÓA SÁCH ______________________________________________________________
        private void btnXoaSach_Click(object sender, EventArgs e)
        {

            if (bdsSACH.Current == null)
            {
                XtraMessageBox.Show("Vui lòng chọn sách cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataRowView currentRow = (DataRowView)bdsSACH.Current;
            if (currentRow == null)
                return;

            // Lấy giá trị dạng string "true"/"false"
            string tinhTrangStr = currentRow["TINHTRANG"]?.ToString()?.Trim().ToLower();
            string choMuonStr = currentRow["CHOMUON"]?.ToString()?.Trim().ToLower();

            if (string.IsNullOrEmpty(tinhTrangStr) || string.IsNullOrEmpty(choMuonStr))
            {
                XtraMessageBox.Show("Vui lòng đảm bảo đã chọn Tình trạng và Trạng thái cho mượn.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse chuỗi "true"/"false" sang bool
            bool tinhTrang = bool.TryParse(tinhTrangStr, out bool t) && t;
            bool choMuon = bool.TryParse(choMuonStr, out bool c) && c;

            // Kiểm tra điều kiện xóa
            if (tinhTrang) // true = còn mượn được
            {
                XtraMessageBox.Show("Chỉ có thể xóa sách đã được thanh lý (Tình trạng = false).", "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (choMuon) // true = đã cho mượn
            {
                XtraMessageBox.Show("Không thể xóa sách đang được mượn.", "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận xóa
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa sách này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bdsSACH.RemoveCurrent();
                    this.tableAdapterSACH.Update(qLTVDataSet.SACH);
                    //XtraMessageBox.Show("Xóa sách thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KiemTraVaToMauDauSachMoCoi();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi khi xóa sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ReloadTacGiaSachData();
                }
            }
        }


        //________________ HÀM KIỂM TRA DỮ LIỆU SÁCH TRÊN GV________________________
        private bool KiemTraHopLeDuLieuSach(out string errorMessage)
        {
            errorMessage = "";
            HashSet<string> masachSet = new HashSet<string>();

            for (int i = 0; i < gvSACH.Rows.Count; i++)
            {
                DataGridViewRow row = gvSACH.Rows[i];
                if (row.IsNewRow)
                {
                    continue;
                }

                string masach = row.Cells["MASACH"].Value?.ToString().Trim();
                object tinhTrang = row.Cells["TINHTRANG"].Value;
                object choMuon = row.Cells["CHOMUON"].Value;
                object nganTu = row.Cells["NGANTU"].Value;

                // Kiểm tra MASACH trống
                if (string.IsNullOrEmpty(masach))
                {
                    errorMessage = $"Dòng {i + 1}: Mã sách không được để trống.";
                    return false;
                }
                // Kiểm tra MASACH trùng
                if (!masachSet.Add(masach))
                {
                    errorMessage = $"Dòng {i + 1}: Mã sách bị trùng ở hàng khác.";
                    return false;
                }
                // ✅ Kiểm tra MASACH trùng trong database – chỉ với dòng AddNew
                DataRowView drv = (DataRowView)row.DataBoundItem;
                if (drv != null && drv.Row.RowState == DataRowState.Added)
                {
                    if (KiemTraMaSachTrungTrongDatabase(masach))
                    {
                        errorMessage = $"Dòng {i + 1}: Mã sách '{masach}' đã tồn tại trong cơ sở dữ liệu.";
                        return false;
                    }
                }
                // Check riêng CHOMUON, TINHTRANG, NGANTU: không null, không rỗng, không DBNull
                if (tinhTrang == null || tinhTrang == DBNull.Value || string.IsNullOrWhiteSpace(tinhTrang.ToString()))
                {
                    errorMessage = $"Dòng {i + 1}: Vui lòng chọn tình trạng của sách.";
                    return false;
                }
                if (choMuon == null || choMuon == DBNull.Value || string.IsNullOrWhiteSpace(choMuon.ToString()))
                {
                    errorMessage = $"Dòng {i + 1}: Vui lòng xác nhận sách đã cho mượn chưa.";
                    return false;
                }
                if (nganTu == null || nganTu == DBNull.Value || string.IsNullOrWhiteSpace(nganTu.ToString()))
                {
                    errorMessage = $"Dòng {i + 1}: Vui lòng chọn ngăn tủ của sách.";
                    return false;
                }

            }
            return true;
        }

        //_____________ HÀM KIỂM TRA MÃ SÁCH TRÙNG TRONG DATABASE ______________________
        private bool KiemTraMaSachTrungTrongDatabase(string maSach)
        {
            if (Program.KetNoi() == 0) return false; // Không kết nối được CSDL
            string query = "SELECT COUNT(*) FROM SACH WHERE MASACH = @MASACH";
            using (SqlCommand cmd = new SqlCommand(query, Program.conn))
            {
                cmd.Parameters.AddWithValue("@MASACH", maSach);
                int count = (int)cmd.ExecuteScalar();
                Program.conn.Close(); // Đóng kết nối sau khi thực hiện xong
                return count > 0;
            }
        }
        //_____________ HÀM TẢI LẠI DỮ LIỆU SÁCH ______________________
        private void ReloadTacGiaSachData()
        {
            try
            {
                int currentTgsPos = bdsSACH.Position;
                this.tableAdapterSACH.Connection.ConnectionString = Program.connstr;
                this.tableAdapterSACH.Fill(this.qLTVDataSet.SACH);
                // Khôi phục vị trí (nếu còn hợp lệ)
                if (currentTgsPos >= 0 && currentTgsPos < bdsSACH.Count)
                {
                    bdsSACH.Position = currentTgsPos;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi tải lại dữ liệu sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //_____________ XỬ LÝ SỰ KIỆN  GV______________________
        private bool loiDangChinhSuaSACH = false;
        private void gvSACH_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Kiểm tra cột đang chỉnh sửa là MASACH
            if (gvSACH.Columns[e.ColumnIndex].Name == "MASACH")
            {
                string newValue = e.FormattedValue.ToString().Trim();

                if (string.IsNullOrEmpty(newValue))
                {
                    gvSACH.Rows[e.RowIndex].ErrorText = "Mã sách không được để trống.";
                    e.Cancel = true;
                    loiDangChinhSuaSACH = true; // Đánh dấu có lỗi
                    return;
                }

                // Duyệt qua tất cả các dòng khác để kiểm tra trùng mã
                for (int i = 0; i < gvSACH.Rows.Count; i++)
                {
                    if (i == e.RowIndex || gvSACH.Rows[i].IsNewRow)
                        continue;

                    string existingValue = gvSACH.Rows[i].Cells["MASACH"].Value?.ToString().Trim();

                    if (string.Equals(existingValue, newValue, StringComparison.OrdinalIgnoreCase))
                    {
                        gvSACH.Rows[e.RowIndex].ErrorText = $"Mã sách '{newValue}' đã tồn tại ở dòng {i + 1}.";
                        e.Cancel = true;
                        loiDangChinhSuaSACH = true; // Đánh dấu có lỗi
                        return;
                    }
                }

                // Xóa thông báo lỗi nếu hợp lệ
                gvSACH.Rows[e.RowIndex].ErrorText = string.Empty;
                loiDangChinhSuaSACH = false; // Không có lỗi
            }
        }

        private void gvSACH_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnGhiSach.Enabled = true;
        }
        private void gvSACH_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gvSACH.IsCurrentCellDirty)
            {
                gvSACH.CommitEdit(DataGridViewDataErrorContexts.Commit);
                //// Lấy thông tin dòng và cột hiện tại
                //int rowIndex = gvSACH.CurrentCell.RowIndex;
                //int colIndex = gvSACH.CurrentCell.ColumnIndex;

                //// Lấy giá trị sau commit
                //object newValue = gvSACH.Rows[rowIndex].Cells[colIndex].Value;

                //// In ra giá trị để kiểm tra (có thể dùng Debug.WriteLine, hoặc MessageBox)
                //string columnName = gvSACH.Columns[colIndex].Name;
            }
        }
        //_____________ XỬ LÝ SỰ KIỆN BINDINGSOURCE ______________________
        private void bdsSACH_ListChanged(object sender, ListChangedEventArgs e)
        {
            bool hasData = bdsSACH.Count > 0;
            btnXoaSach.Enabled = hasData;
            btnGhiSach.Enabled = hasData;
        }
        #endregion

        #region *** PHẦN GRID VIEW TÁC GIẢ_SÁCH ********************************************************
        private void btnTG_SACH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool on = (btnTG_SACH.Caption == "Cập nhật sách");
            gvSACH.Visible = on;
            gvTACGIA_SACH.Visible = !on;
            gcTABLESACH.Text = on ? "QUẢN LÝ SÁCH" : "QUẢN LÝ TÁC GIẢ";
            btnTG_SACH.Caption = on ? "Cập nhật tác giả" : "Cập nhật sách";

        }
        //____________ BUTTON THÊM SÁCH ______________________________________________________________
        private void btnTHEM_TGS_Click(object sender, EventArgs e)
        {
            if (bdsDAUSACH.Current == null)
            {
                XtraMessageBox.Show("Chưa chọn đầu sách để thêm tác giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bdsTACGIA_SACH.AddNew();
        }

        //______________ BUTTON LƯU TÁC GIẢ SÁCH ______________________________________________________________
        private void btnGHI_TGS_Click(object sender, EventArgs e)
        {
            try
            {   // Kết thúc chỉnh sửa trên BindingSource TGS
                this.Validate();
                bdsTACGIA_SACH.EndEdit();
                if (!KiemTraHopLeDuLieuTacGiaSach(out string errorMessage))
                {
                    XtraMessageBox.Show(errorMessage, "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Dùng TableAdapter để cập nhật thay đổi xuống DB
                this.tableAdapterTACGIA_SACH.Update(this.qLTVDataSet.TACGIA_SACH);
                XtraMessageBox.Show("Ghi tác giả sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KiemTraVaToMauDauSachMoCoi();
                btnGHI_TGS.Enabled = false;
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 2627 || sqlEx.Number == 2601) // Lỗi Primary Key/Unique Constraint
            {
                XtraMessageBox.Show("Lỗi: Không thể thêm/sửa liên kết. Có thể tác giả này đã được gán cho sách.\n" + sqlEx.Message, "Lỗi Trùng Khóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Bắt các lỗi khác
                XtraMessageBox.Show("Lỗi ghi dữ liệu Tác giả sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Reload lại để hủy thay đổi trên UI
                ReloadTacGiaSachData();
            }

        }
        //______________ BUTTON XÓA TÁC GIẢ SÁCH ______________________________________________________________
        private void btnXOA_TGS_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong grid TGS không
            if (bdsTACGIA_SACH.Current == null)
            {
                XtraMessageBox.Show("Vui lòng chọn dòng liên kết cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Xác nhận xóa
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa tác giả này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Xóa dòng hiện tại khỏi BindingSource
                    bdsTACGIA_SACH.RemoveCurrent();
                    // Cập nhật thay đổi (xóa) xuống Database
                    this.tableAdapterTACGIA_SACH.Update(qLTVDataSet.TACGIA_SACH);
                    //XtraMessageBox.Show("Xóa tác giả thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KiemTraVaToMauDauSachMoCoi();
                    // Nút Ghi TGS có thể bị bật do ListChanged, nên tắt nó đi nếu xóa thành công
                    btnGHI_TGS.Enabled = false;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi khi xóa liên kết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Nếu lỗi, tải lại dữ liệu TGS để phục hồi dòng vừa xóa trên UI
                    ReloadTacGiaSachData();
                }
            }

        }

        //________________ HÀM KIỂM TRA DỮ LIỆU TÁC GIẢ SÁCH TRÊN GV________________________
        private bool KiemTraHopLeDuLieuTacGiaSach(out string errorMessage)
        {
            errorMessage = "";
            for (int i = 0; i < gvTACGIA_SACH.Rows.Count; i++)
            {
                DataGridViewRow row = gvTACGIA_SACH.Rows[i];
                if (row.IsNewRow)
                {
                    continue;
                }

                object maTG = row.Cells["MATACGIA"].Value;


                if (maTG == null || maTG == DBNull.Value || string.IsNullOrWhiteSpace(maTG.ToString()))
                {
                    errorMessage = $"Dòng {i + 1}: Vui lòng chọn tác giả của sách.";
                    return false;
                }

            }
            return true;
        }
        //______________ XỬ LÝ SỰ KIỆN GV ______________________
        private void gvTACGIA_SACH_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnGHI_TGS.Enabled = true;
        }

        private void gvTACGIA_SACH_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Commit thay đổi ngay khi người dùng rời ô (đặc biệt hữu ích cho CheckBox, ComboBox)
            if (gvTACGIA_SACH.IsCurrentCellDirty)
            {
                gvTACGIA_SACH.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        // Dùng để lọc ComboBox MATACGIA, không cho chọn cùng tác giả cho 1 đầu sách
        private void gvTACGIA_SACH_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Chỉ xử lý khi đang sửa cột MATACGIA và control là ComboBox
            if (gvTACGIA_SACH.CurrentCell.ColumnIndex == gvTACGIA_SACH.Columns["MATACGIA"].Index
                && e.Control is System.Windows.Forms.ComboBox comboBox)
            {
                // Luôn xóa DataSource cũ và đặt lại DropDownStyle
                comboBox.DataSource = null;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList; // Quan trọng: Bắt buộc chọn từ list

                // Lấy danh sách MATACGIA đã được sử dụng cho ĐẦU SÁCH HIỆN TẠI (ở grid chính)
                // ngoại trừ dòng đang được chỉnh sửa
                var usedMATACGIA = new HashSet<string>();
                if (bdsDAUSACH.Current != null)
                {
                    object currentMaTacGia = ((DataRowView)bdsDAUSACH.Current)[PK_COLUMN_NAME];

                    foreach (DataGridViewRow row in gvTACGIA_SACH.Rows)
                    {
                        // Bỏ qua dòng mới (chưa commit) và dòng đang sửa
                        if (row.IsNewRow || row.Index == gvTACGIA_SACH.CurrentCell.RowIndex)
                            continue;

                        // Lấy DataRowView của dòng trong gV TACGIA_SACH
                        var rowView = row.DataBoundItem as DataRowView;
                        // Đảm bảo dòng này thuộc về DAUSACH đang chọn và chưa bị xóa logic
                        if (rowView != null && rowView.Row.RowState != DataRowState.Detached && rowView["ISBN"] != DBNull.Value && rowView["ISBN"].Equals(currentMaTacGia))
                        {
                            var isbnValue = row.Cells["MATACGIA"].Value;
                            if (isbnValue != null && isbnValue != DBNull.Value)
                                usedMATACGIA.Add(isbnValue.ToString());
                        }
                    }
                }
                else
                {
                    // Nếu không có DAUSACH nào được chọn, không nên cho phép thêm/sửa TGS
                    // Nhưng để phòng ngừa, không lọc gì cả nếu không có tác giả
                }


                // Tạo danh sách các TACGIA (từ bdsTACGIA) CHƯA có trong usedMATACGIA
                List<DataRowView> availableItems = new List<DataRowView>();
                foreach (DataRowView drv in bdsTACGIA)
                {
                    // Kiểm tra xem drv có hợp lệ không (phòng trường hợp dataset lỗi)
                    if (drv != null && drv.Row.RowState != DataRowState.Detached && drv["MATACGIA"] != DBNull.Value)
                    {
                        string maTG = drv["MATACGIA"].ToString();
                        if (!usedMATACGIA.Contains(maTG))
                        {
                            availableItems.Add(drv);
                        }
                    }
                }

                // Gán danh sách sách khả dụng làm DataSource cho ComboBox
                comboBox.DisplayMember = "HOTENTG"; // Hiển thị tên sách
                comboBox.ValueMember = "MATACGIA";      // Giá trị lấy về là ISBN
                comboBox.DataSource = availableItems; // Gán danh sách đã lọc
            }
        }
        //______________ XỬ LÝ SỰ KIỆN BINDINGSOURCE ______________________
        private void bdsTACGIA_SACH_ListChanged(object sender, ListChangedEventArgs e)
        {
            bool hasData = bdsTACGIA_SACH.Count > 0;
            btnGHI_TGS.Enabled = hasData;
            btnXOA_TGS.Enabled = hasData;
        }
        #endregion

    }
}