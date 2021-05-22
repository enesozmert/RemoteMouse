using RemoteMouse.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace RemoteMouse.Business
{
    public class MainManager
    {
        private string _message;
        public Size TCPGetWindowSize;
        GetMousePosition getMousePosition = new GetMousePosition();
        public MainManager()
        {

        }
        public string Get()
        {
            Thread.Sleep(100);
            TCPGetWindowSize = Window.GetSize();
            _message = Convert.ToString(getMousePosition.GetCursorPosition().X) + "," + Convert.ToString(getMousePosition.GetCursorPosition().Y) + "," + Convert.ToString(GetMouseClick.GetLeftButtonState()) + "," + Convert.ToString(GetMouseClick.GetRightButtonState());
            return _message;
        }
        public short KeyboardKeyUpDown()
        {
            return KeyboardClick.GetAsyncKeyState(17);
        }
    }
}
