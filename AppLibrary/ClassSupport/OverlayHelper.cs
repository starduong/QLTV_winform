using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLibrary.ClassSupport
{
    public static class OverlayHelper
    {
        public static OverlayWindowOptions options = new OverlayWindowOptions(
            backColor: Color.Black, //Màu nền của overlay là màu đen
            opacity: 0.5,           // Độ trong suốt của overlay là 50%
            fadeIn: false,          // Không có hiệu ứng làm mờ khi xuất hiện
            fadeOut: false          // Không có hiệu ứng làm mờ khi biến mất        
        );

        public static IOverlaySplashScreenHandle ShowOverlay(Control control)
        {
            return SplashScreenManager.ShowOverlayForm(control, options);
        }

        public static void CloseOverlay(IOverlaySplashScreenHandle handle)
        {
            SplashScreenManager.CloseOverlayForm(handle);
        }
    }

}
