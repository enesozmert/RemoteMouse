using RemoteMouse.Controller;
using RemoteMouse.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteMouse.Business
{
    public class BaseManager
    {
        private Mouse mouse = new Mouse();
        public BaseManager()
        {

        }
        public void Set(string mesaj)
        {
            mouse.MousePosX = Convert.ToInt32(mesaj.Split(",")[0]);
            mouse.MousePosY = Convert.ToInt32(mesaj.Split(",")[1]);
            mouse.IsMouseLeftClik = Convert.ToString(mesaj.Split(",")[2]);
            mouse.IsMouseRightClik = Convert.ToString(mesaj.Split(",")[3]);
            if (mouse.IsMouseLeftClik != "0")
            {
                MouseClick mouseClick = new MouseClick();
                mouseClick.ClickMouseLeftPoint();
            }
            if (mouse.IsMouseRightClik != "0")
            {
                MouseClick mouseClick = new MouseClick();
                mouseClick.ClickMouseRightPoint();
            }
            GetMousePosition getMousePosition = new GetMousePosition();
            Console.WriteLine((int)Math.Abs(mouse.MousePosX - getMousePosition.GetCursorPosition().X) + "," + (int)Math.Abs(mouse.MousePosY - getMousePosition.GetCursorPosition().Y));
            Console.WriteLine("Gelen mesaj: " + (int)Math.Abs(mouse.MousePosX - getMousePosition.GetCursorPosition().X) + "," + (int)Math.Abs(mouse.MousePosY - getMousePosition.GetCursorPosition().Y) + "," + mouse.IsMouseLeftClik);
            using (var mousemove = new MouseMove((int)Math.Abs(mouse.MousePosX + Window.OranSize().Item1), (int)Math.Abs(mouse.MousePosY + Window.OranSize().Item2)))
            {

            }
        }
        public Mouse GetMouse()
        {
            return mouse;
        }
    }
}
