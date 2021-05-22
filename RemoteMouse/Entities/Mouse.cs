using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteMouse.Entities
{
    public sealed class Mouse:IDisposable
    {
        public int MousePosX { get; set; }
        public int MousePosY { get; set; }
        public string IsMouseLeftClik{ get; set; }
        public string IsMouseRightClik { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
