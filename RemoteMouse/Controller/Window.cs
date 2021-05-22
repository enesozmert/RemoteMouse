using System;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using RemoteMouse.Data.TCP;

namespace RemoteMouse.Controller
{
    public class Window
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();


        public static Size GetSize()
        {
            Size size = new Size
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height
            };
            return size;
        }
        public static Tuple<double, double> OranSize()
        {
            double width = (double)Math.Abs((double)Math.Abs(Get.TCPSetWindowSize.Width - Set.TCPGetWindowSize.Width) / Get.TCPSetWindowSize.Width);
            double height = (double)Math.Abs((double)Math.Abs(Get.TCPSetWindowSize.Height - Set.TCPGetWindowSize.Height) / Get.TCPSetWindowSize.Height);
            return Tuple.Create(width,height);
        }
    }
}
