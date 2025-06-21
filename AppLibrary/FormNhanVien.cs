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
using DevExpress.XtraBars;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace AppLibrary
{
    public partial class FormNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private bool isAdding = false;
        private Stack<UndoAction> undoStack = new Stack<UndoAction>();
        private bool isUpdating = false;
        private Color modifiedRowColor = Color.LightYellow;
        private Dictionary<int, Dictionary<string, object>> pendingUpdates = new Dictionary<int, Dictionary<string, object>>();


        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.tam_NhanVien.Connection.ConnectionString = Program.connstr;
            LoadAllNhanVien(); // Load tất cả nhân viên ngay từ đầu

            ConfigureGridViewColumns();

            // Hiển thị giới tính và trạng thái
            gridView1.CustomColumnDisplayText += (s, ev) =>
            {
                if (ev.Column.FieldName == "GIOITINH")
                {
                    ev.DisplayText = (ev.Value != DBNull.Value && Convert.ToBoolean(ev.Value)) ? "Nam" : "Nữ";
                }
                else if (ev.Column.FieldName == "TRANGTHAIXOA")
                {
                    ev.DisplayText = (ev.Value != DBNull.Value && Convert.ToBoolean(ev.Value)) ? "Đã nghỉ" : "Còn làm";
                }
            };

            // Theo dõi thay đổi trên các dòng
            gridView1.RowCellStyle += GridView1_RowCellStyle;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;

            // Chọn dòng đầu tiên nếu có
            if (gridView1.RowCount > 0)
            {
                gridView1.FocusedRowHandle = 0;
                DisplayCurrentRowData((DataRowView)bds_NhanVien.Current);
            }

            UpdateButtonStates();
        }

        private void LoadAllNhanVien()
        {
            try
            {
                string query = "SELECT * FROM NHANVIEN";
                DataTable dt = Program.ExecuteSqlDataTable(query);
                nHANVIENGridControl.DataSource = dt;
                bds_NhanVien.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (pendingUpdates.ContainsKey(e.RowHandle))
            {
                e.Appearance.BackColor = modifiedRowColor;
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(textEditHO.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textEditHO.Focus();
                return false;
            }
            if (!KhongChuaSo(textEditHO.Text))
            {
                MessageBox.Show("Họ không được chứa số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textEditHO.Focus();
                return false;
            }
            if (textEditHO.Text.Length > 50)
            {
                MessageBox.Show("Họ không được vượt quá 50 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textEditHO.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textEditTEN.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textEditTEN.Focus();
                return false;
            }
            if (!KhongChuaSo(textEditTEN.Text))
            {
                MessageBox.Show("Tên không được chứa số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textEditTEN.Focus();
                return false;
            }
            if (textEditTEN.Text.Length > 50)
            {
                MessageBox.Show("Tên không được vượt quá 10 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textEditTEN.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textEditDIACHI.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Địa chỉ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textEditDIACHI.Focus();
                return false;
            }
            if (textEditDIACHI.Text.Length > 100)
            {
                MessageBox.Show("Địa chỉ không được vượt quá 100 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textEditDIACHI.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(textEditEMAIL.Text))
            {
                if (!IsValidEmail(textEditEMAIL.Text))
                {
                    MessageBox.Show("Email không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textEditEMAIL.Focus();
                    return false;
                }
                if (textEditEMAIL.Text.Length > 50)
                {
                    MessageBox.Show("Email không được vượt quá 50 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textEditEMAIL.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(textEditDIENTHOAI.Text))
            {
                if (!IsValidPhoneNumber(textEditDIENTHOAI.Text))
                {
                    MessageBox.Show("Số điện thoại phải gồm 10 số và bắt đầu bằng 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textEditDIENTHOAI.Focus();
                    return false;
                }
                if (textEditDIENTHOAI.Text.Length > 15)
                {
                    MessageBox.Show("Số điện thoại không được vượt quá 15 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textEditDIENTHOAI.Focus();
                    return false;
                }
            }

            if (gIOITINHCheckEditNAM.Checked == checkEditNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính Nam hoặc Nữ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Nâng cấp gridView1_FocusedRowChanged
        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (isAdding || bds_NhanVien.Count == 0 || e.FocusedRowHandle < 0) return;

            // Nếu dòng trước đó có sửa
            if (isUpdating && pendingUpdates.ContainsKey(e.PrevFocusedRowHandle))
            {
                if (!ValidateData())
                {
                    gridView1.FocusedRowHandle = e.PrevFocusedRowHandle;
                    return;
                }

                // Cập nhật dữ liệu mới nhất
                var updatedRow = new Dictionary<string, object>
                {
                    ["MANV"] = int.Parse(textEditMANV.Text),
                    ["HONV"] = textEditHO.Text.Trim(),
                    ["TENNV"] = textEditTEN.Text.Trim(),
                    ["DIACHI"] = textEditDIACHI.Text.Trim(),
                    ["DIENTHOAI"] = textEditDIENTHOAI.Text.Trim(),
                    ["EMAIL"] = textEditEMAIL.Text.Trim(),
                    ["GIOITINH"] = gIOITINHCheckEditNAM.Checked,
                    ["TRANGTHAIXOA"] = radioButtonNGHI.Checked
                };

                pendingUpdates[e.PrevFocusedRowHandle] = updatedRow;
                gridView1.RefreshRow(e.PrevFocusedRowHandle);
            }

            // Load dòng mới
            DisplayCurrentRowData((DataRowView)bds_NhanVien[e.FocusedRowHandle]);
            UpdateButtonStates((DataRowView)bds_NhanVien[e.FocusedRowHandle]);
            isUpdating = false;
        }



        private void DisplayCurrentRowData(DataRowView row)
        {
            try
            {
                // Tạm ngừng các sự kiện để tránh trigger không cần thiết
                SuspendEvents();

                textEditMANV.Text = row["MANV"].ToString();
                textEditHO.Text = row["HONV"].ToString();
                textEditTEN.Text = row["TENNV"].ToString();
                textEditDIACHI.Text = row["DIACHI"].ToString();
                textEditDIENTHOAI.Text = row["DIENTHOAI"].ToString();
                textEditEMAIL.Text = row["EMAIL"].ToString();

                // Xử lý giới tính
                if (row["GIOITINH"] != DBNull.Value)
                {
                    bool isNam = Convert.ToBoolean(row["GIOITINH"]);
                    gIOITINHCheckEditNAM.Checked = isNam;
                    checkEditNu.Checked = !isNam;
                }
                else
                {
                    gIOITINHCheckEditNAM.Checked = false;
                    checkEditNu.Checked = false;
                }

                // Xử lý trạng thái
                bool isDaNghi = row["TRANGTHAIXOA"] != DBNull.Value && Convert.ToBoolean(row["TRANGTHAIXOA"]);
                tRANGTHAIXOARadioButton.Checked = !isDaNghi;
                radioButtonNGHI.Checked = isDaNghi;
            }
            finally
            {
                // Kích hoạt lại các sự kiện
                ResumeEvents();
            }
        }

        private void UpdateButtonStates(DataRowView row)
        {
            bool isDaNghi = row["TRANGTHAIXOA"] != DBNull.Value && Convert.ToBoolean(row["TRANGTHAIXOA"]);
            bool isCurrentUser = textEditMANV.Text == Program.UserName;

            btnThem.Enabled = !isDaNghi;
            btnGhi.Enabled = false; // Mặc định disable, chỉ enable khi có thay đổi
            btnXoa.Enabled = !isDaNghi && !isCurrentUser;
            btnRefresh.Enabled = true;
            btnPhucHoi.Enabled = undoStack.Count > 0;

            // Cập nhật trạng thái các control nhập liệu
            if (isDaNghi)
            {
                LockAllInputControls();
            }
            else
            {
                UnlockForEditing();
                textEditMANV.ReadOnly = true; // Không cho sửa mã NV
            }
        }

        private void SuspendEvents()
        {
            // Tạm ngừng các sự kiện thay đổi giá trị
            textEditHO.EditValueChanged -= textEdit_EditValueChanged;
            textEditTEN.EditValueChanged -= textEdit_EditValueChanged;
            textEditDIACHI.EditValueChanged -= textEdit_EditValueChanged;
            textEditDIENTHOAI.EditValueChanged -= textEdit_EditValueChanged;
            textEditEMAIL.EditValueChanged -= textEdit_EditValueChanged;
            gIOITINHCheckEditNAM.CheckedChanged -= gIOITINHCheckEditNAM_CheckedChanged;
            checkEditNu.CheckedChanged -= checkEditNu_CheckedChanged;
        }

        private void ResumeEvents()
        {
            // Kích hoạt lại các sự kiện thay đổi giá trị
            textEditHO.EditValueChanged += textEdit_EditValueChanged;
            textEditTEN.EditValueChanged += textEdit_EditValueChanged;
            textEditDIACHI.EditValueChanged += textEdit_EditValueChanged;
            textEditDIENTHOAI.EditValueChanged += textEdit_EditValueChanged;
            textEditEMAIL.EditValueChanged += textEdit_EditValueChanged;
            gIOITINHCheckEditNAM.CheckedChanged += gIOITINHCheckEditNAM_CheckedChanged;
            checkEditNu.CheckedChanged += checkEditNu_CheckedChanged;
        }

        private void ConfigureGridViewColumns()
        {
            // Cột giới tính
            colGIOITINH.ColumnEdit = new RepositoryItemTextEdit();
            colGIOITINH.OptionsColumn.AllowEdit = false;

            // Cột trạng thái
            colTRANGTHAIXOA.ColumnEdit = new RepositoryItemTextEdit();
            colTRANGTHAIXOA.OptionsColumn.AllowEdit = false;

            // Đặt độ rộng cột phù hợp
            colGIOITINH.Width = 80;
            colTRANGTHAIXOA.Width = 100;
        }

        private void ClearInputFields()
        {
            textEditMANV.Text = "";
            textEditHO.Text = "";
            textEditTEN.Text = "";
            textEditDIACHI.Text = "";
            textEditDIENTHOAI.Text = "";
            textEditEMAIL.Text = "";
            gIOITINHCheckEditNAM.Checked = false;
            checkEditNu.Checked = false;
        }

        
        private class UndoAction
        {
            public string ActionType { get; set; } // INSERT, DELETE, UPDATE
            public List<Dictionary<string, object>> DataList { get; set; } = new List<Dictionary<string, object>>();
            public int FocusedRowHandle { get; set; } = -1;
        }

        

       

        private void UpdateButtonStates(bool allowEdit = true)
        {
            btnThem.Enabled = allowEdit;
            btnGhi.Enabled = false;
            btnXoa.Enabled = false;

            if (!allowEdit)
            {
                btnThem.Enabled = false;
            }
        }

        private void LockAllInputControls()
        {
            foreach (Control ctrl in panelControl1.Controls)
            {
                if (ctrl is TextEdit txt) txt.ReadOnly = true;
                if (ctrl is CheckEdit chk) chk.Enabled = false;
                if (ctrl is RadioButton rdo) rdo.Enabled = false;
            }
        }

        private void UnlockAllInputControls()
        {
            foreach (Control ctrl in panelControl1.Controls)
            {
                if (ctrl is TextEdit txt) txt.ReadOnly = false;
                if (ctrl is CheckEdit chk) chk.Enabled = true;
                if (ctrl is RadioButton rdo) rdo.Enabled = true;
            }
            textEditMANV.ReadOnly = true;
        }

        private void UnlockForEditing()
        {
            foreach (Control ctrl in panelControl1.Controls)
            {
                if (ctrl is TextEdit txt) txt.ReadOnly = false;
                if (ctrl is CheckEdit chk) chk.Enabled = true;
                if (ctrl is RadioButton rdo) rdo.Enabled = true;
            }
            textEditMANV.ReadOnly = true;
        }

        private int LayMaNvTiepTheo()
        {
            int nextManv = 0;
            string sql = "SELECT IDENT_CURRENT('NHANVIEN') + IDENT_INCR('NHANVIEN')";

            using (SqlCommand cmd = new SqlCommand(sql, Program.conn))
            {
                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();

                object result = cmd.ExecuteScalar();
                nextManv = Convert.ToInt32(result);
            }

            return nextManv;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^0\d{9}$");
        }

        private bool KhongChuaSo(string input)
        {
            return !System.Text.RegularExpressions.Regex.IsMatch(input, @"\d");
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                isAdding = true;
                bds_NhanVien.AddNew();

                int nextManv = LayMaNvTiepTheo();
                DataRowView newRow = (DataRowView)bds_NhanVien.Current;
                newRow["MANV"] = nextManv;
                textEditMANV.Text = nextManv.ToString();

                // Clear các field và thiết lập giá trị mặc định
                ClearInputFields();
                tRANGTHAIXOARadioButton.Checked = true;
                radioButtonNGHI.Checked = false;

                // Mở khóa các control nhập liệu
                UnlockAllInputControls();
                nHANVIENGridControl.Enabled = false;

                // Cập nhật trạng thái nút
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnRefresh.Enabled = false;
                btnGhi.Enabled = true;
                btnPhucHoi.Enabled = true;
                tRANGTHAIXOARadioButton.Visible = false;
                radioButtonNGHI.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isAdding && !ValidateData()) return;

            if (Program.conn.State != ConnectionState.Open)
                Program.conn.Open();

            using (SqlTransaction transaction = Program.conn.BeginTransaction())
            {
                try
                {
                    // TH1: đang thêm mới
                    if (isAdding)
                    {
                        bds_NhanVien.EndEdit();
                        ta_NhanVien.Transaction = transaction;
                        ta_NhanVien.Update(ds_QLTV.NHANVIEN);

                        // Lưu vào undo
                        var newData = new Dictionary<string, object>
                        {
                            ["MANV"] = textEditMANV.Text,
                            ["HONV"] = textEditHO.Text.Trim(),
                            ["TENNV"] = textEditTEN.Text.Trim(),
                            ["DIACHI"] = textEditDIACHI.Text.Trim(),
                            ["DIENTHOAI"] = textEditDIENTHOAI.Text.Trim(),
                            ["EMAIL"] = textEditEMAIL.Text.Trim(),
                            ["GIOITINH"] = gIOITINHCheckEditNAM.Checked,
                            ["TRANGTHAIXOA"] = false
                        };

                        undoStack.Push(new UndoAction
                        {
                            ActionType = "INSERT",
                            FocusedRowHandle = gridView1.FocusedRowHandle,
                            DataList = new List<Dictionary<string, object>> { newData }
                        });
                        btnPhucHoi.Enabled = true;
                    }
                    else
                    {
                        // TH2: ghi các dòng đã chỉnh sửa
                        foreach (var update in pendingUpdates.Values)
                        {
                            int manv = (int)update["MANV"];

                            // Lấy dữ liệu gốc để undo
                            DataRow oldRow = ds_QLTV.NHANVIEN.Rows
                                .Cast<DataRow>()
                                .FirstOrDefault(r => r.RowState != DataRowState.Deleted && Convert.ToInt32(r["MANV"]) == manv);

                            if (oldRow != null)
                            {
                                var oldData = new Dictionary<string, object>
                                {
                                    ["MANV"] = oldRow["MANV"],
                                    ["HONV"] = oldRow["HONV"],
                                    ["TENNV"] = oldRow["TENNV"],
                                    ["DIACHI"] = oldRow["DIACHI"],
                                    ["DIENTHOAI"] = oldRow["DIENTHOAI"],
                                    ["EMAIL"] = oldRow["EMAIL"],
                                    ["GIOITINH"] = oldRow["GIOITINH"],
                                    ["TRANGTHAIXOA"] = oldRow["TRANGTHAIXOA"]
                                };

                                undoStack.Push(new UndoAction
                                {
                                    ActionType = "UPDATE",
                                    FocusedRowHandle = gridView1.LocateByValue("MANV", manv),
                                    DataList = new List<Dictionary<string, object>> { oldData }
                                });
                            }

                            // Ghi thủ công bằng câu lệnh SQL
                            string updateQuery = $@"
                        UPDATE NHANVIEN SET
                            HONV = N'{update["HONV"]}',
                            TENNV = N'{update["TENNV"]}',
                            DIACHI = N'{update["DIACHI"]}',
                            DIENTHOAI = '{update["DIENTHOAI"]}',
                            EMAIL = '{update["EMAIL"]}',
                            GIOITINH = {(Convert.ToBoolean(update["GIOITINH"]) ? 1 : 0)},
                            TRANGTHAIXOA = {(Convert.ToBoolean(update["TRANGTHAIXOA"]) ? 1 : 0)}
                        WHERE MANV = {manv}";

                            // Gọi hàm thực thi có transaction
                            SqlCommand cmd = new SqlCommand(updateQuery, Program.conn, transaction);
                            cmd.ExecuteNonQuery();
                        }

                        btnPhucHoi.Enabled = undoStack.Count > 0;
                    }

                    transaction.Commit();

                    // Reset trạng thái
                    isAdding = false;
                    isUpdating = false;
                    pendingUpdates.Clear();

                    // Làm mới dữ liệu
                    ds_QLTV.NHANVIEN.Clear();
                    ta_NhanVien.Fill(ds_QLTV.NHANVIEN);

                    // UI
                    LockAllInputControls();
                    nHANVIENGridControl.Enabled = true;
                    btnThem.Enabled = true;
                    btnXoa.Enabled = (textEditMANV.Text != Program.UserName);
                    btnGhi.Enabled = false;
                    btnRefresh.Enabled = true;
                    tRANGTHAIXOARadioButton.Visible = true;
                    radioButtonNGHI.Visible = true;

                    MessageBox.Show("Ghi dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi ghi dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (isAdding)
                    {
                        bds_NhanVien.CancelEdit();
                        isAdding = false;
                        LockAllInputControls();
                        nHANVIENGridControl.Enabled = true;
                    }
                }
            }
        }


        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Reload dữ liệu từ cơ sở dữ liệu
                ds_QLTV.NHANVIEN.Clear();
                ta_NhanVien.Fill(ds_QLTV.NHANVIEN);
                nHANVIENGridControl.Enabled = true;

                // Xóa các điều khiển
                ClearInputFields();

                // Cập nhật trạng thái nút
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
                btnRefresh.Enabled = true;
                btnGhi.Enabled = false;
                btnPhucHoi.Enabled = false;
                LockAllInputControls();

                // Chọn lại dòng đầu tiên (nếu có)
                if (bds_NhanVien.Count > 0)
                {
                    gridView1.FocusedRowHandle = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bds_NhanVien.Current == null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để cho nghỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView current = (DataRowView)bds_NhanVien.Current;
            int maNV = Convert.ToInt32(current["MANV"]);
            int currentRowHandle = gridView1.FocusedRowHandle;

                try
                {
                    // Lưu dữ liệu để phục hồi
                    var data = new Dictionary<string, object>();
                    foreach (DataColumn column in current.Row.Table.Columns)
                    {
                        data[column.ColumnName] = current.Row[column];
                    }

                    undoStack.Push(new UndoAction
                    {
                        ActionType = "UPDATE",
                        DataList = new List<Dictionary<string, object>> { data },
                        FocusedRowHandle = currentRowHandle
                    });

                    // Cập nhật trạng thái xóa (cho nghỉ)
                    current["TRANGTHAIXOA"] = true;
                    bds_NhanVien.EndEdit();
                    ta_NhanVien.Update(ds_QLTV.NHANVIEN);

                    // Làm mới dữ liệu
                    ds_QLTV.NHANVIEN.Clear();
                    ta_NhanVien.Fill(ds_QLTV.NHANVIEN);

                    MessageBox.Show("Đã chuyển nhân viên sang trạng thái đã nghỉ việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật trạng thái nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            btnPhucHoi.Enabled = true;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (isAdding)
                {
                    if (bds_NhanVien.Current != null)
                    {
                        bds_NhanVien.RemoveCurrent();
                    }

                    nHANVIENGridControl.Enabled = true;

                    btnThem.Enabled = true;
                    btnXoa.Enabled = true;
                    btnRefresh.Enabled = true;
                    btnGhi.Enabled = false;
                    btnPhucHoi.Enabled = undoStack.Count > 0;
                    tRANGTHAIXOARadioButton.Visible = true;
                    radioButtonNGHI.Visible = true;
                    MessageBox.Show("Hủy thao tác thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isAdding = false;
                    return;
                }
                if (undoStack.Count == 0)
                {
                    MessageBox.Show("Không có thao tác nào để phục hồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                UndoAction action = undoStack.Pop();
                if (Program.conn.State != ConnectionState.Open)
                {
                    Program.conn.Open();
                }
                using (SqlTransaction transaction = Program.conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var data in action.DataList)
                        {
                            if (action.ActionType == "INSERT")
                            {
                                // Xóa bản ghi đã thêm
                                Program.ExecuteSqlNonQuery($"DELETE FROM NHANVIEN WHERE MANV = {data["MANV"]}");
                            }
                            else if (action.ActionType == "UPDATE")
                            {
                                // Khôi phục dữ liệu cũ
                                Program.ExecuteSqlNonQuery($@"
                        UPDATE NHANVIEN SET
                        HONV = N'{data["HONV"]}',
                        TENNV = N'{data["TENNV"]}',
                        GIOITINH = {(Convert.ToBoolean(data["GIOITINH"]) ? 1 : 0)},
                        DIACHI = N'{data["DIACHI"]}',
                        DIENTHOAI = '{data["DIENTHOAI"]}',
                        EMAIL = '{data["EMAIL"]}',
                        TRANGTHAIXOA = {(Convert.ToBoolean(data["TRANGTHAIXOA"]) ? 1 : 0)}
                        WHERE MANV = {data["MANV"]}");
                            }
                        }
                        transaction.Commit();

                        // Làm mới dữ liệu
                        LoadAllNhanVien();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phục hồi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!isAdding && bds_NhanVien.Current != null)
            {
                isUpdating = true;
                int rowHandle = gridView1.FocusedRowHandle;

                if (!pendingUpdates.ContainsKey(rowHandle))
                {
                    // Đánh dấu là dòng có chỉnh sửa
                    var editedRow = new Dictionary<string, object>
                    {
                        ["MANV"] = int.Parse(textEditMANV.Text),
                        ["HONV"] = textEditHO.Text.Trim(),
                        ["TENNV"] = textEditTEN.Text.Trim(),
                        ["DIACHI"] = textEditDIACHI.Text.Trim(),
                        ["DIENTHOAI"] = textEditDIENTHOAI.Text.Trim(),
                        ["EMAIL"] = textEditEMAIL.Text.Trim(),
                        ["GIOITINH"] = gIOITINHCheckEditNAM.Checked,
                        ["TRANGTHAIXOA"] = radioButtonNGHI.Checked
                    };

                    pendingUpdates[rowHandle] = editedRow;
                    gridView1.RefreshRow(rowHandle); // Cập nhật màu
                }
            }
        }


        private void gIOITINHCheckEditNAM_CheckedChanged(object sender, EventArgs e)
        {
            if (gIOITINHCheckEditNAM.Checked)
            {
                checkEditNu.CheckedChanged -= checkEditNu_CheckedChanged;
                checkEditNu.Checked = false;
                checkEditNu.CheckedChanged += checkEditNu_CheckedChanged;
            }
        }

        private void checkEditNu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditNu.Checked)
            {
                gIOITINHCheckEditNAM.CheckedChanged -= gIOITINHCheckEditNAM_CheckedChanged;
                gIOITINHCheckEditNAM.Checked = false;
                gIOITINHCheckEditNAM.CheckedChanged += gIOITINHCheckEditNAM_CheckedChanged;
            }
        }

        private void tRANGTHAIXOARadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (tRANGTHAIXOARadioButton.Checked)
            {
                radioButtonNGHI.Checked = false;
            }
        }

        private void radioButtonNGHI_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNGHI.Checked)
            {
                tRANGTHAIXOARadioButton.Checked = false;
            }
        }
    }
}