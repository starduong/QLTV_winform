using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    // Lớp lưu trữ thông tin thao tác Undo/Redo
    public class LogAction
    {
        public enum ActionType { Add, Edit, Delete }
        public ActionType Type { get; set; }

        // Danh sách dữ liệu HIỆN TẠI (sau khi thực hiện Add hoặc Edit)
        // Hoặc dữ liệu GỐC (trước khi thực hiện Delete - để có thể khôi phục)
        public List<Dictionary<string, object>> DataList { get; set; }

        // Danh sách dữ liệu GỐC (chỉ dùng cho thao tác Edit, lưu trạng thái trước khi sửa)
        public List<Dictionary<string, object>> OriginalDataList { get; set; }

        // Danh sách vị trí trên UI (ví dụ: index của dòng trong grid)
        public List<int> Positions { get; set; }

        // Tên bảng và tên cột khóa chính để biết thao tác trên đối tượng nào
        public string TableName { get; set; }
        public string PrimaryKeyColumnName { get; set; }

        public LogAction()
        {
            DataList = new List<Dictionary<string, object>>();
            OriginalDataList = new List<Dictionary<string, object>>(); // Khởi tạo cho Edit
            Positions = new List<int>();
        }

        // Helper để lấy giá trị khóa chính (thuận tiện hơn)
        public List<object> GetPrimaryKeys()
        {
            var keys = new List<object>();
            // Đối với Edit và Add, PK nằm trong DataList (sau khi thao tác)
            // Đối với Delete, PK nằm trong DataList (là dữ liệu gốc đã lưu trước khi xóa)
            var listToUse = DataList; // Mặc định dùng DataList

            if (listToUse != null && listToUse.Count > 0 && !string.IsNullOrEmpty(PrimaryKeyColumnName))
            {
                foreach (var data in listToUse)
                {
                    if (data.TryGetValue(PrimaryKeyColumnName, out object key) && key != null && key != DBNull.Value)
                    {
                        keys.Add(key);
                    }
                }
            }
            return keys;
        }
        // Helper lấy PK từ OriginalDataList (dùng cho Undo Edit)
        public List<object> GetOriginalPrimaryKeys()
        {
            var keys = new List<object>();
            if (Type != ActionType.Edit || OriginalDataList == null || OriginalDataList.Count == 0 || string.IsNullOrEmpty(PrimaryKeyColumnName))
            {
                return keys; // Chỉ hợp lệ cho Edit và có dữ liệu gốc
            }

            foreach (var data in OriginalDataList)
            {
                if (data.TryGetValue(PrimaryKeyColumnName, out object key) && key != null && key != DBNull.Value)
                {
                    keys.Add(key);
                }
            }
            return keys;
        }
    }
}
