using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RemoteMouse.Controller
{
    public class MouseClick
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint cInputs, INPUT input, int size);

        private bool _isClicked = false;
        public void ClickMouseLeftPoint()
        {
            DoClickMouse(0x2); // Left mouse button down
            _isClicked = true;
            IsClicked(_isClicked);
            DoClickMouse(0x4); // Left mouse button up
            _isClicked = false;
            IsClicked(_isClicked);
        }
        public void ClickMouseRightPoint()
        {
            DoClickMouse(0x8); // Left mouse button down
            _isClicked = true;
            IsClicked(_isClicked);
            DoClickMouse(0x10); // Left mouse button up
            _isClicked = false;
            IsClicked(_isClicked);
        }
        public bool IsClicked(bool key=false)
        {
            return key;
        }

         void DoClickMouse(int mouseButton)
        {
            var input = new INPUT()
            {
                dwType = 0, // Mouse input
                mi = new MOUSEINPUT() { dwFlags = mouseButton }
            };

            if (SendInput(1, input, Marshal.SizeOf(input)) == 0)
            {
                throw new Exception();
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            int dx;
            int dy;
            int mouseData;
            public int dwFlags;
            int time;
            IntPtr dwExtraInfo;
        }
        struct INPUT
        {
            public uint dwType;
            public MOUSEINPUT mi;
        }
    }
}
