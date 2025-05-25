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
    public partial class FormNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }
        private bool isAdding = false;
        private Stack<UndoAction> undoStack = new Stack<UndoAction>();
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.tam_NhanVien.Connection.ConnectionString = Program.connstr;
            this.ta_NhanVien.Fill(this.ds_QLTV.NHANVIEN);
            nHANVIENGridControl.DataSource = bds_NhanVien;
            gridView1.OptionsBehavior.Editable = false;

            // Gán sự kiện đổi dòng
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);

            // Các cột mã nhân viên không cho chỉnh sửa
            colMANV.OptionsColumn.AllowEdit = false;
            colMANV.OptionsColumn.ReadOnly = true;
            textEditMANV.ReadOnly = true;

            // Khóa tất cả các TextBox ban đầu
            SetInputControlsReadOnly(true);

            // Clear dữ liệu
            ClearInputFields();

            // Không chọn dòng nào khi mới mở form
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


            // Trạng thái nút
            btnThem.Enabled = true;
            btnGhi.Enabled = false;
            btnXoa.Enabled = false;
            btnRefresh.Enabled = true;
            btnPhucHoi.Enabled = false;

            isAdding = false;
        }

        // Các hàm hỗ trợ
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

        private void SetInputControlsReadOnly(bool isReadOnly)
        {
            textEditHO.ReadOnly = isReadOnly;
            textEditTEN.ReadOnly = isReadOnly;
            textEditDIACHI.ReadOnly = isReadOnly;
            textEditDIENTHOAI.ReadOnly = isReadOnly;
            textEditEMAIL.ReadOnly = isReadOnly;
            gIOITINHCheckEditNAM.ReadOnly = isReadOnly;
            checkEditNu.ReadOnly = isReadOnly;
        }

        private class UndoAction
        {
            public string ActionType { get; set; } // INSERT, DELETE, UPDATE
            public List<Dictionary<string, object>> DataList { get; set; } = new List<Dictionary<string, object>>();
        }





        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (bds_NhanVien.Current != null)
            {
                DataRowView row = (DataRowView)bds_NhanVien.Current;
                textEditMANV.Text = row["MANV"].ToString();
                textEditHO.Text = row["HONV"].ToString();
                textEditTEN.Text = row["TENNV"].ToString();
                textEditDIACHI.Text = row["DIACHI"].ToString();
                textEditDIENTHOAI.Text = row["DIENTHOAI"].ToString();
                textEditEMAIL.Text = row["EMAIL"].ToString();
                // Hiển thị giới tính lên RadioButton
                if (row["GIOITINH"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(row["GIOITINH"]))
                    {
                        gIOITINHCheckEditNAM.Checked = true;
                        checkEditNu.Checked = false;
                    }
                    else
                    {
                        gIOITINHCheckEditNAM.Checked = false;
                        checkEditNu.Checked = true;
                    }
                }
                else
                {
                    gIOITINHCheckEditNAM.Checked = false;
                    checkEditNu.Checked = false;
                }
                btnGhi.Enabled = true;
                textEditHO.ReadOnly = false;
                textEditTEN.ReadOnly = false;
                textEditDIACHI.ReadOnly = false;
                textEditDIENTHOAI.ReadOnly = false;
                textEditEMAIL.ReadOnly = false;
                gIOITINHCheckEditNAM.ReadOnly = false;
                checkEditNu.ReadOnly = false;

            }
            else
            {
                // Xóa các điều khiển khi không có dòng nào được chọn
                textEditMANV.Text = "";
                textEditHO.Text = "";
                textEditTEN.Text = "";
                textEditDIACHI.Text = "";
                textEditDIENTHOAI.Text = "";
                textEditEMAIL.Text = "";
                gIOITINHCheckEditNAM.Checked = false;
                checkEditNu.Checked = false;
                textEditHO.ReadOnly = true;
                textEditTEN.ReadOnly = true;
                textEditDIACHI.ReadOnly = true;
                textEditDIENTHOAI.ReadOnly = true;
                textEditEMAIL.ReadOnly = true;
                gIOITINHCheckEditNAM.ReadOnly = true;
                checkEditNu.ReadOnly = true;
            }
            if (textEditMANV.Text == Program.UserName || isAdding)
            {
                btnXoa.Enabled = false;
            }
            else
            {
                btnXoa.Enabled = true;
            }

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

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // 1. Đánh dấu đang trong trạng thái Thêm
                isAdding = true;

                // 2. Thêm dòng mới vào BindingSource
                bds_NhanVien.AddNew();

                // 3. Gán mã nhân viên mới
                int nextManv = LayMaNvTiepTheo();
                DataRowView newRow = (DataRowView)bds_NhanVien.Current;
                newRow["MANV"] = nextManv;
                textEditMANV.Text = nextManv.ToString();

                // 4. Clear các field còn lại
                textEditHO.Text = "";
                textEditTEN.Text = "";
                textEditDIACHI.Text = "";
                textEditDIENTHOAI.Text = "";
                textEditEMAIL.Text = "";
                gIOITINHCheckEditNAM.Checked = false;
                checkEditNu.Checked = false;

                // 5. Enable nhập liệu
                SetInputControlsReadOnly(false);

                // 6. Disable GridControl (không cho chọn dòng khác)
                nHANVIENGridControl.Enabled = false;

                // 7. Cập nhật trạng thái nút
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnRefresh.Enabled = false;
                btnGhi.Enabled = true;
                btnPhucHoi.Enabled = true;
                gridView1.FocusedRowHandle = gridView1.RowCount - 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kiểm tra định dạng email
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

        // Kiểm tra định dạng số điện thoại (10 chữ số, bắt đầu bằng số 0)
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^0\d{9}$");
        }
        // Regex: Không cho phép chứa chữ số
        private bool KhongChuaSo(string input)
        {
            return !System.Text.RegularExpressions.Regex.IsMatch(input, @"\d");
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textEditHO.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Họ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!KhongChuaSo(textEditHO.Text))
                {
                    MessageBox.Show("Họ không được chứa số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textEditTEN.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!KhongChuaSo(textEditTEN.Text))
                {
                    MessageBox.Show("Tên không được chứa số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textEditDIACHI.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Địa chỉ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(textEditEMAIL.Text) && !IsValidEmail(textEditEMAIL.Text))
                {
                    MessageBox.Show("Email không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(textEditDIENTHOAI.Text) && !IsValidPhoneNumber(textEditDIENTHOAI.Text))
                {
                    MessageBox.Show("Số điện thoại không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (gIOITINHCheckEditNAM.Checked == checkEditNu.Checked)
                {
                    MessageBox.Show("Vui lòng chọn giới tính Nam hoặc Nữ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- THỰC HIỆN GHI ---
                DataRowView currentRow = (DataRowView)bds_NhanVien.Current;
                int currentRowHandle = gridView1.FocusedRowHandle;

                if (isAdding)
                {
                    // Nếu đang thêm mới (đã push Undo INSERT trước đó), cập nhật lại dữ liệu vào UndoStack
                    var newData = new Dictionary<string, object>
                    {
                        ["MANV"] = currentRow["MANV"],
                        ["HONV"] = textEditHO.Text.Trim(),
                        ["TENNV"] = textEditTEN.Text.Trim(),
                        ["DIACHI"] = textEditDIACHI.Text.Trim(),
                        ["DIENTHOAI"] = textEditDIENTHOAI.Text.Trim(),
                        ["EMAIL"] = textEditEMAIL.Text.Trim(),
                        ["GIOITINH"] = gIOITINHCheckEditNAM.Checked
                    };
                    var undoAction = new UndoAction
                    {
                        ActionType = "INSERT",
                        DataList = new List<Dictionary<string, object>> { newData }
                    };

                    undoStack.Push(undoAction);
                    gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                }
                else
                {
                    // Nếu đang sửa, lưu lại trạng thái cũ vào UndoStack
                    var updateAction = new UndoAction { ActionType = "UPDATE" };

                    foreach (DataRow row in ds_QLTV.NHANVIEN.Rows)
                    {
                        if (row.RowState == DataRowState.Modified)
                        {
                            var oldData = new Dictionary<string, object>();
                            foreach (DataColumn col in ds_QLTV.NHANVIEN.Columns)
                            {
                                oldData[col.ColumnName] = row[col, DataRowVersion.Original]; // Lưu dữ liệu gốc
                            }
                            updateAction.DataList.Add(oldData);
                        }
                    }

                    if (updateAction.DataList.Count > 0)
                        undoStack.Push(updateAction);
                }



                bds_NhanVien.EndEdit();
                ta_NhanVien.Update(ds_QLTV.NHANVIEN);

                // Reload lại dữ liệu từ Database
                ds_QLTV.NHANVIEN.Clear();
                ta_NhanVien.Fill(ds_QLTV.NHANVIEN);
                if (currentRowHandle >= 0 && currentRowHandle < gridView1.RowCount)
                {
                    gridView1.FocusedRowHandle = currentRowHandle;
                }
                // --- Reset trạng thái ---
                isAdding = false;
                nHANVIENGridControl.Enabled = true;

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



        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Reload dữ liệu từ cơ sở dữ liệu
                ds_QLTV.NHANVIEN.Clear();
                ta_NhanVien.Fill(ds_QLTV.NHANVIEN);
                nHANVIENGridControl.Enabled = true;

                // Xóa các điều khiển
                textEditMANV.Text = "";
                textEditHO.Text = "";
                textEditTEN.Text = "";
                textEditDIACHI.Text = "";
                textEditDIENTHOAI.Text = "";
                textEditEMAIL.Text = "";
                gIOITINHCheckEditNAM.Checked = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
                btnRefresh.Enabled = true;
                btnGhi.Enabled = false;
                btnPhucHoi.Enabled = true;
                textEditMANV.ReadOnly = true;
                textEditHO.ReadOnly = true;
                textEditTEN.ReadOnly = true;
                textEditDIACHI.ReadOnly = true;
                textEditDIENTHOAI.ReadOnly = true;
                textEditEMAIL.ReadOnly = true;
                gIOITINHCheckEditNAM.ReadOnly = true;
                checkEditNu.ReadOnly = true;
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
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView current = (DataRowView)bds_NhanVien.Current;
            int maNV = Convert.ToInt32(current["MANV"]);

            try
            {
                SqlCommand cmdCheckPMH = new SqlCommand("dbo.sp_KiemTra_NV_PMH", Program.conn);
                cmdCheckPMH.CommandType = CommandType.StoredProcedure;
                cmdCheckPMH.Parameters.AddWithValue("@MaNV", maNV);

                SqlParameter returnPMH = new SqlParameter();
                returnPMH.Direction = ParameterDirection.ReturnValue;
                cmdCheckPMH.Parameters.Add(returnPMH);

                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();

                cmdCheckPMH.ExecuteNonQuery();

                int resultPMH = Convert.ToInt32(returnPMH.Value);
                if (resultPMH == 1)
                {
                    MessageBox.Show("Nhân viên này đang liên quan đến bảng PHIEUMUON!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra bảng PHIEUMUON: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                SqlCommand cmdCheckCTPM = new SqlCommand("dbo.sp_KiemTra_NV_CTPMH", Program.conn);
                cmdCheckCTPM.CommandType = CommandType.StoredProcedure;
                cmdCheckCTPM.Parameters.AddWithValue("@MaNV", maNV);

                SqlParameter returnCTPM = new SqlParameter();
                returnCTPM.Direction = ParameterDirection.ReturnValue;
                cmdCheckCTPM.Parameters.Add(returnCTPM);

                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();

                cmdCheckCTPM.ExecuteNonQuery();

                int resultCTPM = Convert.ToInt32(returnCTPM.Value);
                if (resultCTPM == 1)
                {
                    MessageBox.Show("Nhân viên này đang liên quan đến bảng CHITIETPHIEUMUON!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra bảng CHITIETPHIEUMUON: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Hỏi xác nhận
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var data = new Dictionary<string, object>();
                    foreach (DataColumn column in current.Row.Table.Columns)
                    {
                        data[column.ColumnName] = current.Row[column];
                    }

                    undoStack.Push(new UndoAction
                    {
                        ActionType = "DELETE",
                        DataList = new List<Dictionary<string, object>> { data }
                    });

                    bds_NhanVien.RemoveCurrent();
                    ta_NhanVien.Update(ds_QLTV.NHANVIEN);

                    ds_QLTV.NHANVIEN.Clear();
                    ta_NhanVien.Fill(ds_QLTV.NHANVIEN);

                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    MessageBox.Show("Hủy thao tác thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isAdding = false;
                    return;
                }
                if (undoStack.Count == 0)
                {
                    MessageBox.Show("Không có thao tác nào để phục hồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                // Lấy hành động mới nhất
                UndoAction action = undoStack.Pop();

                switch (action.ActionType)
                {
                    case "INSERT":
                        // Undo INSERT => XÓA
                        foreach (var data in action.DataList)
                        {
                            Program.ExecuteSqlNonQuery($"DELETE FROM NHANVIEN WHERE MANV = {data["MANV"]}");
                        }
                        break;

                    case "DELETE":
                        foreach (var data in action.DataList)
                        {
                            Program.ExecuteSqlNonQuery($@"
                                SET IDENTITY_INSERT NHANVIEN ON;
                                INSERT INTO NHANVIEN (MANV, HONV, TENNV, GIOITINH, DIACHI, DIENTHOAI, EMAIL)
                                VALUES ({data["MANV"]}, N'{data["HONV"]}', N'{data["TENNV"]}',
                                        '{(Convert.ToBoolean(data["GIOITINH"]) ? 1 : 0)}',
                                        N'{data["DIACHI"]}', '{data["DIENTHOAI"]}', '{data["EMAIL"]}');
                                SET IDENTITY_INSERT NHANVIEN OFF;
                            ");
                        }
                        break;


                    case "UPDATE":
                        // Undo UPDATE => cập nhật lại dữ liệu cũ
                        foreach (var data in action.DataList)
                        {
                            Program.ExecuteSqlNonQuery($@"
                            UPDATE NHANVIEN SET
                            HONV = N'{data["HONV"]}',
                            TENNV = N'{data["TENNV"]}',
                            GIOITINH = '{(Convert.ToBoolean(data["GIOITINH"]) ? 1 : 0)}',
                            DIACHI = N'{data["DIACHI"]}',
                            DIENTHOAI = '{data["DIENTHOAI"]}',
                            EMAIL = '{data["EMAIL"]}'
                            WHERE MANV = {data["MANV"]}");
                        }
                        break;
                }

                // Sau khi Undo, load lại dữ liệu
                ds_QLTV.NHANVIEN.Clear();
                ta_NhanVien.Fill(ds_QLTV.NHANVIEN);

                btnPhucHoi.Enabled = undoStack.Count > 0;

                MessageBox.Show("Phục hồi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phục hồi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void gIOITINHCheckEditNAM_CheckedChanged(object sender, EventArgs e)
        {
            if (gIOITINHCheckEditNAM.Checked)
            {
                checkEditNu.CheckedChanged -= checkEditNu_CheckedChanged; // tạm bỏ event
                checkEditNu.Checked = false;
                checkEditNu.CheckedChanged += checkEditNu_CheckedChanged; // gán lại event
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

    }
}