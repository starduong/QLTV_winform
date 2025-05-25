using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    public static class AccountEvents
    {
        public static event EventHandler TaiKhoanDuocTao;
        public static event EventHandler TaiKhoanBiXoa;

        public static void RaiseTaiKhoanDuocTao()
        {
            TaiKhoanDuocTao?.Invoke(null, EventArgs.Empty);
        }

        public static void RaiseTaiKhoanBiXoa()
        {
            TaiKhoanBiXoa?.Invoke(null, EventArgs.Empty);
        }
    }

}
