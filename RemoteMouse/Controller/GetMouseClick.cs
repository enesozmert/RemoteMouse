using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace RemoteMouse.Controller
{
    public static class GetMouseClick
    {
        [DllImport("user32.dll")]
        private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 dwData, IntPtr dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(UInt16 virtualKeyCode);

        private const UInt16 VK_MBUTTON = 0x04;//middle mouse button

        private const UInt16 VK_LBUTTON = 0x01;//left mouse button

        private const UInt16 VK_RBUTTON = 0x02;//right mouse button
        public static short GetRightButtonState()
        {
            return GetAsyncKeyState(VK_RBUTTON);
        }

        public static short GetLeftButtonState()

        {
            return GetAsyncKeyState(VK_LBUTTON);
        }
    }
}
