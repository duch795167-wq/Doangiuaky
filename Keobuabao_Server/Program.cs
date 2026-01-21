using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Keobuabao_Server


{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Kéo Búa Bao Server";
            TcpListener server = new TcpListener(IPAddress.Any, 8888);
            server.Start();
            Console.WriteLine("Server khởi động tại port 8888... Đang chờ người chơi");

            while (true)
            {
                // Chờ 2 người chơi
                TcpClient player1 = server.AcceptTcpClient();
                SendMessage(player1, "Đang chờ đối thủ...\n");

                TcpClient player2 = server.AcceptTcpClient();
                SendMessage(player2, "Đang chờ đối thủ...\n");

                // Xử lý trong thread riêng
                new Thread(() => HandleGame(player1, player2)).Start();
            }
        }
    }
}
