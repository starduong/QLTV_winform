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

namespace AppLibrary
{
    public partial class FormDocGia : DevExpress.XtraEditors.XtraForm
    {
        public FormDocGia()
        {
            InitializeComponent();
        }

        private bool isAdding = false;
        private Stack<UndoAction> undoStack = new Stack<UndoAction>();

        private void FormDocGia_Load(object sender, EventArgs e)
        {
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.ta_DocGia.Connection.ConnectionString = Program.connstr;
            this.ta_DocGia.Fill(this.ds_QLTV.DOCGIA);
            dOCGIAGridControl.DataSource = bds_DocGia;
            gridView1.OptionsBehavior.Editable = false;

            // Gán sự kiện khi thay đổi dòng
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);

            // Thiết lập cột mã độc giả chỉ đọc
            colMADG.OptionsColumn.AllowEdit = false;
            colMADG.OptionsColumn.ReadOnly = true;
            mADGTextEdit.ReadOnly = true;

            // Khóa các control nhập liệu ban đầu
            SetInputControlsReadOnly(true);

            // Xóa dữ liệu các control
            ClearInputFields();

            // Định dạng hiển thị giới tính
            gridView1.CustomColumnDisplayText += (s, ev) =>
            {
                if (ev.Column.FieldName == "GIOITINH")
                {
                    if (ev.Value != null && ev.Value != DBNull.Value)
                    {
                        ev.DisplayText = (Convert.ToBoolean(ev.Value)) ? "Nam" : "Nữ";
                    }
                }
            };

            // Thiết lập trạng thái các nút
            btnThem.Enabled = true;
            btnGhi.Enabled = false;
            btnXoa.Enabled = false;
            btnRefresh.Enabled = true;
            btnPhucHoi.Enabled = false;

            isAdding = false;
        }

        private void ClearInputFields()
        {
            mADGTextEdit.Text = "";
            hODGTextEdit.Text = "";
            tENDGTextEdit.Text = "";
            dIACHITextEdit.Text = "";
            dIENTHOAITextEdit.Text = "";
            eMAILDGTextEdit.Text = "";
            sOCMNDTextEdit.Text = "";
            nGAYLAMTHEDateEdit.DateTime = DateTime.Now;
            nGAYHETHANDateEdit.DateTime = DateTime.Now.AddYears(1);
            nGAYSINHDateEdit.DateTime = DateTime.Now;
            gIOITINHRadioButton.Checked = false;
            radioButtonNu.Checked = false;
            hOATDONGRadioButton.Checked = true;
        }

        private void SetInputControlsReadOnly(bool isReadOnly)
        {
            hODGTextEdit.ReadOnly = isReadOnly;
            tENDGTextEdit.ReadOnly = isReadOnly;
            dIACHITextEdit.ReadOnly = isReadOnly;
            dIENTHOAITextEdit.ReadOnly = isReadOnly;
            eMAILDGTextEdit.ReadOnly = isReadOnly;
            sOCMNDTextEdit.ReadOnly = isReadOnly;
            nGAYLAMTHEDateEdit.Properties.ReadOnly = isReadOnly;
            nGAYHETHANDateEdit.Properties.ReadOnly = isReadOnly;
            nGAYSINHDateEdit.Properties.ReadOnly = isReadOnly;
            gIOITINHRadioButton.Enabled = !isReadOnly;
            radioButtonNu.Enabled = !isReadOnly;
            hOATDONGRadioButton.Enabled = !isReadOnly;
            radioButtonKhoa.Enabled = !isReadOnly;
        }

        private class UndoAction
        {
            public string ActionType { get; set; } // INSERT, DELETE, UPDATE
            public List<Dictionary<string, object>> DataList { get; set; } = new List<Dictionary<string, object>>();
            public int FocusedRowHandle { get; set; } = -1; // Thêm thuộc tính này để lưu vị trí dòng được chọn
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (bds_DocGia.Current != null)
            {
                DataRowView row = (DataRowView)bds_DocGia.Current;
                mADGTextEdit.Text = row["MADG"].ToString();
                hODGTextEdit.Text = row["HODG"].ToString();
                tENDGTextEdit.Text = row["TENDG"].ToString();
                dIACHITextEdit.Text = row["DIACHI"].ToString();
                dIENTHOAITextEdit.Text = row["DIENTHOAI"].ToString();
                eMAILDGTextEdit.Text = row["EMAILDG"].ToString();
                sOCMNDTextEdit.Text = row["SOCMND"].ToString();

                if (row["NGAYLAMTHE"] != DBNull.Value)
                    nGAYLAMTHEDateEdit.DateTime = Convert.ToDateTime(row["NGAYLAMTHE"]);

                if (row["NGAYHETHAN"] != DBNull.Value)
                    nGAYHETHANDateEdit.DateTime = Convert.ToDateTime(row["NGAYHETHAN"]);

                if (row["NGAYSINH"] != DBNull.Value)
                    nGAYSINHDateEdit.DateTime = Convert.ToDateTime(row["NGAYSINH"]);

                // Hiển thị giới tính
                if (row["GIOITINH"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(row["GIOITINH"]))
                    {
                        gIOITINHRadioButton.Checked = true;
                        radioButtonNu.Checked = false;
                    }
                    else
                    {
                        gIOITINHRadioButton.Checked = false;
                        radioButtonNu.Checked = true;
                    }
                }
                else
                {
                    gIOITINHRadioButton.Checked = false;
                    radioButtonNu.Checked = false;
                }

                // Hiển thị trạng thái hoạt động
                if (row["HOATDONG"] != DBNull.Value)
                {
                    hOATDONGRadioButton.Checked = Convert.ToBoolean(row["HOATDONG"]);
                    radioButtonKhoa.Checked = !hOATDONGRadioButton.Checked;
                }
                else
                {
                    hOATDONGRadioButton.Checked = true;
                    radioButtonKhoa.Checked = false;
                }

                // Mở khóa các control nhập liệu
                SetInputControlsReadOnly(false);
                btnGhi.Enabled = true;
            }
            else
            {
                ClearInputFields();
                SetInputControlsReadOnly(true);
            }

            btnXoa.Enabled = (bds_DocGia.Current != null);
        }

        private int LayMaDGTiepTheo()
        {
            int nextMadg = 0;
            string sql = "SELECT IDENT_CURRENT('DOCGIA') + IDENT_INCR('DOCGIA')";

            using (SqlCommand cmd = new SqlCommand(sql, Program.conn))
            {
                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();

                object result = cmd.ExecuteScalar();
                nextMadg = Convert.ToInt32(result);
            }

            return nextMadg;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                isAdding = true;
                bds_DocGia.AddNew();

                int nextMadg = LayMaDGTiepTheo();
                DataRowView newRow = (DataRowView)bds_DocGia.Current;
                newRow["MADG"] = nextMadg;
                mADGTextEdit.Text = nextMadg.ToString();

                // Thiết lập giá trị mặc định
                ClearInputFields();
                nGAYLAMTHEDateEdit.DateTime = DateTime.Now;
                nGAYHETHANDateEdit.DateTime = DateTime.Now.AddYears(1);
                hOATDONGRadioButton.Checked = true;

                SetInputControlsReadOnly(false);
                dOCGIAGridControl.Enabled = false;

                // Cập nhật trạng thái các nút
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnRefresh.Enabled = false;
                btnGhi.Enabled = true;
                btnPhucHoi.Enabled = true;
                gridView1.FocusedRowHandle = gridView1.RowCount - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm độc giả mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private bool IsValidCMND(string cmnd)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(cmnd, @"^\d{9}$|^\d{12}$");
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Kiểm tra hợp lệ
                if (string.IsNullOrWhiteSpace(hODGTextEdit.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Họ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!KhongChuaSo(hODGTextEdit.Text))
                {
                    MessageBox.Show("Họ không được chứa số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tENDGTextEdit.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!KhongChuaSo(tENDGTextEdit.Text))
                {
                    MessageBox.Show("Tên không được chứa số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(dIACHITextEdit.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Địa chỉ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(eMAILDGTextEdit.Text) && !IsValidEmail(eMAILDGTextEdit.Text))
                {
                    MessageBox.Show("Email không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(dIENTHOAITextEdit.Text) && !IsValidPhoneNumber(dIENTHOAITextEdit.Text))
                {
                    MessageBox.Show("Số điện thoại không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(sOCMNDTextEdit.Text) || !IsValidCMND(sOCMNDTextEdit.Text))
                {
                    MessageBox.Show("Số CMND phải có 9 hoặc 12 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (gIOITINHRadioButton.Checked == radioButtonNu.Checked)
                {
                    MessageBox.Show("Vui lòng chọn giới tính Nam hoặc Nữ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (nGAYHETHANDateEdit.DateTime <= nGAYLAMTHEDateEdit.DateTime)
                {
                    MessageBox.Show("Ngày hết hạn phải sau ngày làm thẻ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- THỰC HIỆN GHI DỮ LIỆU ---
                DataRowView currentRow = (DataRowView)bds_DocGia.Current;
                int currentRowHandle = gridView1.FocusedRowHandle;

                if (isAdding)
                {
                    var newData = new Dictionary<string, object>
                    {
                        // ... (phần tạo dữ liệu giữ nguyên)
                    };

                    var undoAction = new UndoAction
                    {
                        ActionType = "INSERT",
                        DataList = new List<Dictionary<string, object>> { newData },
                        FocusedRowHandle = currentRowHandle // Lưu vị trí dòng hiện tại
                    };

                    undoStack.Push(undoAction);
                    gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                }
                else
                {
                    var updateAction = new UndoAction
                    {
                        ActionType = "UPDATE",
                        FocusedRowHandle = currentRowHandle // Lưu vị trí dòng hiện tại
                    };

                    foreach (DataRow row in ds_QLTV.DOCGIA.Rows)
                    {
                        if (row.RowState == DataRowState.Modified)
                        {
                            var oldData = new Dictionary<string, object>();
                            foreach (DataColumn col in ds_QLTV.DOCGIA.Columns)
                            {
                                oldData[col.ColumnName] = row[col, DataRowVersion.Original];
                            }
                            updateAction.DataList.Add(oldData);
                        }
                    }

                    if (updateAction.DataList.Count > 0)
                        undoStack.Push(updateAction);
                }

                // Lưu thay đổi
                bds_DocGia.EndEdit();
                ta_DocGia.Update(ds_QLTV.DOCGIA);

                // Tải lại dữ liệu
                ds_QLTV.DOCGIA.Clear();
                ta_DocGia.Fill(ds_QLTV.DOCGIA);

                if (currentRowHandle >= 0 && currentRowHandle < gridView1.RowCount)
                {
                    gridView1.FocusedRowHandle = currentRowHandle;
                }

                // Đặt lại trạng thái
                isAdding = false;
                dOCGIAGridControl.Enabled = true;

                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnRefresh.Enabled = true;
                btnGhi.Enabled = false;
                btnPhucHoi.Enabled = undoStack.Count > 0;

                MessageBox.Show("Ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bds_DocGia.Current == null)
            {
                MessageBox.Show("Vui lòng chọn một độc giả để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView current = (DataRowView)bds_DocGia.Current;
            int currentRowHandle = gridView1.FocusedRowHandle;
            int maDG = Convert.ToInt32(current["MADG"]);

            try
            {
                // Kiểm tra độc giả có liên quan đến phiếu mượn không
                SqlCommand cmdCheckPM = new SqlCommand("SELECT COUNT(*) FROM PHIEUMUON WHERE MADG = @MaDG", Program.conn);
                cmdCheckPM.Parameters.AddWithValue("@MaDG", maDG);

                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();

                int countPM = Convert.ToInt32(cmdCheckPM.ExecuteScalar());
                if (countPM > 0)
                {
                    MessageBox.Show("Không thể xóa độc giả này vì có liên quan đến phiếu mượn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra bảng PHIEUMUON: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xác nhận xóa
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa độc giả này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
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
                        ActionType = "DELETE",
                        DataList = new List<Dictionary<string, object>> { data },
                        FocusedRowHandle = currentRowHandle
                    });

                    // Xóa bản ghi
                    bds_DocGia.RemoveCurrent();
                    ta_DocGia.Update(ds_QLTV.DOCGIA);

                    // Tải lại dữ liệu
                    ds_QLTV.DOCGIA.Clear();
                    ta_DocGia.Fill(ds_QLTV.DOCGIA);

                    MessageBox.Show("Xóa độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa độc giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            btnPhucHoi.Enabled = true;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (isAdding)
                {
                    if (bds_DocGia.Current != null)
                    {
                        bds_DocGia.RemoveCurrent();
                    }

                    dOCGIAGridControl.Enabled = true;

                    btnThem.Enabled = true;
                    btnXoa.Enabled = true;
                    btnRefresh.Enabled = true;
                    btnGhi.Enabled = false;
                    btnPhucHoi.Enabled = undoStack.Count > 0;

                    MessageBox.Show("Hủy thao tác thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isAdding = false;
                    return;
                }

                if (undoStack.Count == 0)
                {
                    MessageBox.Show("Không có thao tác nào để phục hồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Lấy hành động gần nhất
                UndoAction action = undoStack.Pop();
                int savedRowHandle = action.FocusedRowHandle;
                switch (action.ActionType)
                {
                    case "INSERT":
                        // Phục hồi INSERT => XÓA
                        foreach (var data in action.DataList)
                        {
                            Program.ExecuteSqlNonQuery($"DELETE FROM DOCGIA WHERE MADG = {data["MADG"]}");
                        }
                        break;

                    case "DELETE":
                        // Phục hồi DELETE => THÊM LẠI
                        foreach (var data in action.DataList)
                        {
                            Program.ExecuteSqlNonQuery($@"
                                SET IDENTITY_INSERT DOCGIA ON;
                                INSERT INTO DOCGIA (MADG, HODG, TENDG, GIOITINH, DIACHI, DIENTHOAI, EMAILDG, 
                                                   SOCMND, NGAYSINH, NGAYLAMTHE, NGAYHETHAN, HOATDONG)
                                VALUES ({data["MADG"]}, N'{data["HODG"]}', N'{data["TENDG"]}',
                                        '{(Convert.ToBoolean(data["GIOITINH"]) ? 1 : 0)}',
                                        N'{data["DIACHI"]}', '{data["DIENTHOAI"]}', '{data["EMAILDG"]}',
                                        '{data["SOCMND"]}', '{Convert.ToDateTime(data["NGAYSINH"]).ToString("yyyy-MM-dd")}',
                                        '{Convert.ToDateTime(data["NGAYLAMTHE"]).ToString("yyyy-MM-dd")}',
                                        '{Convert.ToDateTime(data["NGAYHETHAN"]).ToString("yyyy-MM-dd")}',
                                        '{(Convert.ToBoolean(data["HOATDONG"]) ? 1 : 0)}');
                                SET IDENTITY_INSERT DOCGIA OFF;
                            ");
                        }
                        break;

                    case "UPDATE":
                        // Phục hồi UPDATE => khôi phục dữ liệu cũ
                        foreach (var data in action.DataList)
                        {
                            Program.ExecuteSqlNonQuery($@"
                                UPDATE DOCGIA SET
                                HODG = N'{data["HODG"]}',
                                TENDG = N'{data["TENDG"]}',
                                GIOITINH = '{(Convert.ToBoolean(data["GIOITINH"]) ? 1 : 0)}',
                                DIACHI = N'{data["DIACHI"]}',
                                DIENTHOAI = '{data["DIENTHOAI"]}',
                                EMAILDG = '{data["EMAILDG"]}',
                                SOCMND = '{data["SOCMND"]}',
                                NGAYSINH = '{Convert.ToDateTime(data["NGAYSINH"]).ToString("yyyy-MM-dd")}',
                                NGAYLAMTHE = '{Convert.ToDateTime(data["NGAYLAMTHE"]).ToString("yyyy-MM-dd")}',
                                NGAYHETHAN = '{Convert.ToDateTime(data["NGAYHETHAN"]).ToString("yyyy-MM-dd")}',
                                HOATDONG = '{(Convert.ToBoolean(data["HOATDONG"]) ? 1 : 0)}'
                                WHERE MADG = {data["MADG"]}");
                        }
                        break;
                }

                // Tải lại dữ liệu sau khi phục hồi
                ds_QLTV.DOCGIA.Clear();
                ta_DocGia.Fill(ds_QLTV.DOCGIA);
                if (savedRowHandle >= 0 && savedRowHandle < gridView1.RowCount)
                {
                    gridView1.FocusedRowHandle = savedRowHandle;
                }
                btnPhucHoi.Enabled = undoStack.Count > 0;
                MessageBox.Show("Phục hồi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phục hồi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Tải lại dữ liệu từ CSDL
                ds_QLTV.DOCGIA.Clear();
                ta_DocGia.Fill(ds_QLTV.DOCGIA);
                dOCGIAGridControl.Enabled = true;

                // Xóa dữ liệu các control
                ClearInputFields();

                // Cập nhật trạng thái các nút
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
                btnRefresh.Enabled = true;
                btnGhi.Enabled = false;
                btnPhucHoi.Enabled = undoStack.Count > 0;

                // Chọn dòng đầu tiên nếu có
                if (bds_DocGia.Count > 0)
                {
                    gridView1.FocusedRowHandle = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gIOITINHRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (gIOITINHRadioButton.Checked)
            {
                radioButtonNu.Checked = false;
            }
        }

        private void radioButtonNu_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNu.Checked)
            {
                gIOITINHRadioButton.Checked = false;
            }
        }

        private void hOATDONGRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (hOATDONGRadioButton.Checked)
            {
                radioButtonKhoa.Checked = false;
                radioButtonVHH.Checked = false;
            }
        }

        private void radioButtonKhoa_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonKhoa.Checked)
            {
                hOATDONGRadioButton.Checked = false;
                radioButtonVHH.Checked = false;
            }
        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void radioButtonVHH_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonVHH.Checked)
            {
                hOATDONGRadioButton.Checked=false;
                radioButtonKhoa.Checked=false;
            }
        }
    }
}