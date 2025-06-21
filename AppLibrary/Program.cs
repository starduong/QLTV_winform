using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Data.SqlClient;
using System.Data;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;

namespace AppLibrary
{
    static class Program
    {

        // Biến toàn cục dùng để kết nối với SQL Server
        public static SqlConnection conn = new SqlConnection();
        public static string connstr;
        public static SqlDataReader myReader;
        public static readonly string ServerName = "DESKTOP-GA0VKO6\\SQL2022"; // Tên server SQL
        //public static readonly string ServerName = "DESKTOP-8MGRMNI"; // Tên server SQL
        public static readonly string DatabaseName = "QLTV"; // Tên database cần làm việc
        public static string UserName = "";
        //public static string LoginName = "THAO"; // Tên đăng nhập vào SQL Server
        public static string LoginName = "DG"; // Tên đăng nhập vào SQL Server
        public static string LoginPassword = "123456"; // Mật khẩu đăng nhập

        public static String mGroup = "DOCGIA";
        public static String mHoten = "";

        public static IOverlaySplashScreenHandle handle = null;

        /// <summary>
        /// Phương thức kết nối đến SQL Server
        /// </summary>
        /// <returns>1 nếu kết nối thành công, 0 nếu thất bại</returns>
        public static int KetNoi()
        {
            /* *****************************************************************************
             * Đóng kết nối nếu đang mở, rồi tiến hành mở kết nối lại
             * -> Giúp tránh trường hợp vừa kết nối đến lại bị đóng đột ngột ngay sau đó.
             * Vì mỗi lần kết nối có khoảng thời gian nhất định xong sẽ tự động đóng kết nối
            ******************************************************************************/
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
            try
            {
                // Thiết lập chuỗi kết nối
                connstr = $"Data Source={ServerName};Initial Catalog={DatabaseName};User ID={LoginName};Password={LoginPassword}";
                conn.ConnectionString = connstr;
                conn.Open(); // Mở kết nối
                return 1;
            }
            catch (Exception e)
            {
                // Hiển thị thông báo lỗi nếu kết nối thất bại
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + e.Message + "\nVui lòng kiểm tra tên đăng nhập và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Thực hiện câu lệnh SQL và trả về một SqlDataReader (chỉ đọc dữ liệu, không chỉnh sửa)
        /// </summary>
        /// <param name="sqlQuery">Câu lệnh SQL</param>
        /// <returns>SqlDataReader chứa dữ liệu hoặc null nếu có lỗi</returns>
        public static SqlDataReader ExecuteSqlDataReader(string sqlQuery)
        {
            SqlDataReader sqlReader;
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn)
            {
                CommandType = CommandType.Text
            };

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            try
            {
                sqlReader = sqlCommand.ExecuteReader(); // Thực thi câu lệnh SQL
                return sqlReader;
            }
            catch (SqlException ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi thực hiện lệnh SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Thực hiện câu lệnh SQL và trả về một DataTable (dùng cho các thao tác thêm, xóa, sửa, xem dữ liệu)
        /// </summary>
        /// <param name="sqlQuery">Câu lệnh SQL</param>
        /// <returns>DataTable chứa dữ liệu</returns>
        public static DataTable ExecuteSqlDataTable(string sqlQuery)
        {
            DataTable dataTable = new DataTable();

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, conn);
            sqlDataAdapter.Fill(dataTable); // Đổ dữ liệu vào DataTable

            conn.Close();
            return dataTable;
        }

        /// <summary>
        /// Thực thi câu lệnh SQL không trả về dữ liệu (thường dùng cho INSERT, UPDATE, DELETE)
        /// </summary>
        /// <param name="sqlQuery">Câu lệnh SQL</param>
        /// <returns>0 nếu thành công, mã lỗi nếu thất bại</returns>
        public static int ExecuteSqlNonQuery(string sqlQuery)
        {
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn)
            {
                CommandType = CommandType.Text,
                CommandTimeout = 600 // Thời gian chờ tối đa là 10 phút
            };

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            try
            {
                sqlCommand.ExecuteNonQuery(); // Thực thi câu lệnh
                conn.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi thực thi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return ex.State;
            }
        }

        public static Form CurrentMainForm; // Lưu tham chiếu FormMain hiện tại
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CurrentMainForm = new FormMain();
            CurrentMainForm.Show(); // Hiển thị FormMain ban đầu
            Application.Run(); // Chạy ứng dụng mà không chỉ định form chính
        }
    }
}
