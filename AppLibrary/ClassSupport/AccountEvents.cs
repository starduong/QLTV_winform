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

        public static void RaiseTaiKhoanDuocTao()
        {
            TaiKhoanDuocTao?.Invoke(null, EventArgs.Empty);
        }
    }

}
