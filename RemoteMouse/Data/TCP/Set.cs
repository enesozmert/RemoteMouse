using RemoteMouse.Business;
using RemoteMouse.Controller;
using RemoteMouse.Entities;
using RemoteMouse.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteMouse.Data.TCP
{
    public class Set : IDisposable
    {
        bool computerKey=false;
        string remoteIP;
        static Socket soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        const int PORT = 52000;
        public static Size TCPGetWindowSize;
        public Set(string remoteIP)
        {
            this.remoteIP = remoteIP;
            //Ipv4Adress.Get(NetworkInterfaceType.Wireless80211) == null ? Ipv4Adress.Get(NetworkInterfaceType.Ethernet) : Ipv4Adress.Get(NetworkInterfaceType.Wireless80211);
            Console.WriteLine(remoteIP);
        }
        public void Data()
        {
            MainManager mainManager = new MainManager();
            try
            {
                soket.Connect(new IPEndPoint(IPAddress.Parse(remoteIP), PORT));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n (X) -> Bağlanmaya çalışırken hata oluştu: " + ex.Message);
            }
            while (true && soket.Connected)
            {
                if (KeyboardClick.GetAsyncKeyState(17) != 0)
                {
                    computerKey = true;
                }
                if (KeyboardClick.GetAsyncKeyState(18) != 0)
                {
                    computerKey = false;
                }
                if (computerKey == true)
                {
                    TCPGetWindowSize = Window.GetSize();
                    soket.Send(Encoding.UTF8.GetBytes(mainManager.Get()));
                }
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
