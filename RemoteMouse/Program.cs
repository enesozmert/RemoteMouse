using RemoteMouse.Controller;
using RemoteMouse.Data.TCP;
using RemoteMouse.Entities;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace RemoteMouse
{
    class Program
    {
        public static Size OranSize;
        static void Main(string[] args)
        {
            string consoleResult = Console.ReadLine();

            MouseClick mouseClick = new MouseClick();

            if (consoleResult == "Base")
            {
                using (var _get = new Get())
                {
                    _get.Data();
                }
            }
            else if (consoleResult == "Main")
            {
                string oku = Console.ReadLine();
                using (var _set = new Set(oku))
                {
                    try
                    {
                        while (true)
                        {
                            
                            using (var mouse = new Mouse())
                            {
                                _set.Data();
                            }
                            if (GetMouseClick.GetRightButtonState() != 0)
                            {
                                Console.SetWindowPosition(0, 1);
                            }
                            else
                            {
                                Console.SetWindowPosition(0, 0);
                            }
                            if (GetMouseClick.GetLeftButtonState() != 0)
                            {
                                Console.WindowTop = Console.WindowTop + 1;
                                //Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop + 1);
                            }
                            else
                            {
                                Console.WindowTop = Console.WindowTop + 1;
                                //Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop - 1);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                    finally
                    {
                    }
                }
            }
        }
    }
}
