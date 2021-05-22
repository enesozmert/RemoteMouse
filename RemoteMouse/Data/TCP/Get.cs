using RemoteMouse.Business;
using RemoteMouse.Controller;
using RemoteMouse.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteMouse.Data.TCP
{
    public class Get : IDisposable
    {
        BaseManager baseManager = new BaseManager();
        static Socket dinleyiciSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        const int PORT = 52000;
        public static Size TCPSetWindowSize;
        public void Data()
        {

            TcpListener dinle = new TcpListener(IPAddress.Any, PORT);
            dinle.Start();

            Console.WriteLine("Bağlantı bekleniyor...");
            dinleyiciSoket = dinle.AcceptSocket();
            Console.WriteLine("Bağlantı sağlandı. ");

            while (true)
            {
                try
                {
                    Console.WriteLine("-----------------------");
                    TCPSetWindowSize = Window.GetSize();
                    byte[] gelenData = new byte[256];
                    dinleyiciSoket.Receive(gelenData);

                    string mesaj = (Encoding.UTF8.GetString(gelenData)).Split('\0')[0];
                    baseManager.Set(mesaj);
                    if (mesaj.ToLower().StartsWith("exit"))
                    {
                        Console.WriteLine("Bağlantı kapatılıyor.");
                        dinleyiciSoket.Dispose();
                        break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Bağlantı kesildi. Çıkış yapılıyor." + e.Message);
                    break;
                }
            }
        }
        public Mouse GetMouse()
        {
            return baseManager.GetMouse();
        }
        public void Dispose()
        {
            dinleyiciSoket.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
