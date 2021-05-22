using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RemoteMouse.Controller
{
    public sealed class MouseMove:IDisposable
    {

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        public void Dispose(bool v)
        {
            Dispose(v);
            //GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            //Dispose();
            GC.SuppressFinalize(this);
            GC.RemoveMemoryPressure(1);
        }

        public MouseMove(int x = 0, int y = 0)
        {
            SetCursorPos(x, y);
        }
    }
}
