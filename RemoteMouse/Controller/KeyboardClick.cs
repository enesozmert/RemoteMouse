using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RemoteMouse.Controller
{
    public class KeyboardClick
    {
        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern short GetAsyncKeyState(int Tus);

    }
}
