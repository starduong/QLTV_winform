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
            // Khóa chỉnh sửa trên gridView1
            gridView1.OptionsBehavior.Editable = false;
            
            // Gán sự kiện FocusedRowChanged cho gridView1
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            colMANV.OptionsColumn.AllowEdit = false;
            colMANV.OptionsColumn.ReadOnly = true;
            textEditMANV.ReadOnly = true;
        }
        private class UndoAction
        {
            public string ActionType { get; set; } // INSERT, DELETE, UPDATE
            public Dictionary<string, object> Data { get; set; }
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


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            isAdding = false;
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
                    bool gioiTinh = Convert.ToBoolean(row["GIOITINH"]);
                    radioButtonNAM.Checked = gioiTinh;
                    radioButtonNU.Checked = !gioiTinh;
                }
                else
                {
                    radioButtonNAM.Checked = false;
                    radioButtonNU.Checked = false;
                }

                btnGhi.Enabled = true;
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
                radioButtonNAM.Checked = false;
                radioButtonNU.Checked = false;
            }
        }
       

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 1. Thêm bản ghi mới vào BindingSource
            bds_NhanVien.AddNew();

            int nextManv = LayMaNvTiepTheo();

            // Cập nhật lại MANV cho dòng mới (dù không lưu vào DB – để hiển thị trên GridControl)
            DataRowView newRow = (DataRowView)bds_NhanVien.Current;
            newRow["MANV"] = nextManv;
            textEditMANV.Text = nextManv.ToString();
            textEditHO.Text = "";
            textEditTEN.Text = "";
            textEditDIACHI.Text = "";
            textEditDIENTHOAI.Text = "";
            textEditEMAIL.Text = "";
            radioButtonNAM.Checked = false;
            radioButtonNU.Checked = false;
            // Push hành động insert (chưa có dữ liệu, sẽ cập nhật khi ghi)
            undoStack.Push(new UndoAction
            {
                ActionType = "INSERT",
                Data = new Dictionary<string, object>()
            });

            // 5. Vô hiệu hóa các nút không cần thiết
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnRefresh.Enabled = false;
            btnGhi.Enabled = true;
            btnPhucHoi.Enabled = true;
            // 6. Tập trung vào TextEdit để người dùng nhập dữ liệu
            textEditHO.Focus();
            isAdding = true;
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

        private void btnGhi_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textEditHO.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Họ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (
                    string.IsNullOrWhiteSpace(textEditTEN.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên v!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (
                    string.IsNullOrWhiteSpace(textEditDIACHI.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Địa chỉ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!radioButtonNAM.Checked && !radioButtonNU.Checked)
                {
                    MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                DataRowView currentRow = (DataRowView)bds_NhanVien.Current;

                if (!isAdding)
                {
                    var oldData = new Dictionary<string, object>();
                    foreach (DataColumn column in currentRow.Row.Table.Columns)
                    {
                        oldData[column.ColumnName] = currentRow.Row[column];
                    }
                    undoStack.Push(new UndoAction
                    {
                        ActionType = "UPDATE",
                        Data = oldData
                    });
                }
                else if (undoStack.Count > 0 && undoStack.Peek().ActionType == "INSERT")
                {
                    UndoAction action = undoStack.Pop();
                    var newData = new Dictionary<string, object>();
                    newData["MANV"] = textEditMANV.Text;
                    newData["HONV"] = textEditHO.Text;
                    newData["TENNV"] = textEditTEN.Text;
                    newData["DIACHI"] = textEditDIACHI.Text;
                    newData["DIENTHOAI"] = textEditDIENTHOAI.Text;
                    newData["EMAIL"] = textEditEMAIL.Text;
                    newData["GIOITINH"] = radioButtonNAM.Checked;
                    action.Data = newData;
                    undoStack.Push(action);
                }

                currentRow["HONV"] = textEditHO.Text;
                currentRow["TENNV"] = textEditTEN.Text;
                currentRow["GIOITINH"] = radioButtonNAM.Checked ? 1 : 0;
                currentRow["DIACHI"] = textEditDIACHI.Text;
                currentRow["EMAIL"] = textEditEMAIL.Text;
                currentRow["DIENTHOAI"] = textEditDIENTHOAI.Text;

                bds_NhanVien.EndEdit();
                ta_NhanVien.Update(ds_QLTV.NHANVIEN);
                ds_QLTV.NHANVIEN.Clear();
                ta_NhanVien.Fill(ds_QLTV.NHANVIEN);

                MessageBox.Show(isAdding ? "Đã thêm nhân viên mới!" : "Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnRefresh.Enabled = true;
                btnGhi.Enabled = false;
                isAdding = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nHANVIENGridControl_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Reload dữ liệu từ cơ sở dữ liệu
                ds_QLTV.NHANVIEN.Clear();
                ta_NhanVien.Fill(ds_QLTV.NHANVIEN);

                // Xóa các điều khiển
                textEditMANV.Text = "";
                textEditHO.Text = "";
                textEditTEN.Text = "";
                textEditDIACHI.Text = "";
                textEditDIENTHOAI.Text = "";
                textEditEMAIL.Text = "";
                radioButtonNAM.Checked = false;
                radioButtonNU.Checked = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnRefresh.Enabled = true;
                btnGhi.Enabled = true;
                btnPhucHoi.Enabled = true;
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
                        Data = data
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
        }


        private void btnPhucHoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (undoStack.Count == 0)
            {
                MessageBox.Show("Không có thao tác nào để phục hồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UndoAction action = undoStack.Pop();
            var data = action.Data;

            switch (action.ActionType)
            {
                case "INSERT":
                    if (data == null || data.Count == 0)
                    {
                        // Người dùng đã nhấn Thêm nhưng chưa ghi -> chỉ cần refresh
                        btnRefresh_ItemClick(sender, e);
                        return;
                    }
                    else
                    {
                        // Đã ghi rồi, cần xóa dòng vừa ghi
                        Program.ExecuteSqlNonQuery($"DELETE FROM NHANVIEN WHERE MANV = {data["MANV"]}");
                    }
                    break;

                case "DELETE":
                    Program.ExecuteSqlNonQuery($@"
                        INSERT INTO NHANVIEN (HONV, TENNV, GIOITINH, DIACHI, DIENTHOAI, EMAIL)
                        VALUES (
                            N'{data["HONV"]}',
                            N'{data["TENNV"]}',
                            '{(Convert.ToBoolean(data["GIOITINH"]) ? 1 : 0)}',
                            N'{data["DIACHI"]}',
                            '{data["DIENTHOAI"]}',
                            '{data["EMAIL"]}'
                        )");
                    break;

                case "UPDATE":
                    Program.ExecuteSqlNonQuery($@"
                        UPDATE NHANVIEN SET
                            HONV = N'{data["HONV"]}',
                            TENNV = N'{data["TENNV"]}',
                            GIOITINH = '{(Convert.ToBoolean(data["GIOITINH"]) ? 1 : 0)}',
                            DIACHI = N'{data["DIACHI"]}',
                            DIENTHOAI = '{data["DIENTHOAI"]}',
                            EMAIL = '{data["EMAIL"]}'
                        WHERE MANV = {data["MANV"]}");
                    break;
            }

            ds_QLTV.NHANVIEN.Clear();
            ta_NhanVien.Fill(ds_QLTV.NHANVIEN);

        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }

        }
    }
}