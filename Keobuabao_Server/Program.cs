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
      static void HandleGame(TcpClient p1, TcpClient p2)
        {
            try
            {
                SendMessage(p1, "ĐÃ GHÉP ĐÔI! Sẵn sàng chơi nhiều ván.\n");
                SendMessage(p2, "ĐÃ GHÉP ĐÔI! Sẵn sàng chơi nhiều ván.\n");

                while (true)
                {
                    // Gửi thông báo bắt đầu cho cả 2
                    SendMessage(p1, "BẮT ĐẦU! Chọn: Kéo, Búa, Bao\n");
                    Thread.Sleep(100);
                    SendMessage(p2, "BẮT ĐẦU! Chọn: Kéo, Búa, Bao\n");
                    string choice1 = "";
                    string choice2 = "";

                    // Nhận lựa chọn từ player 1
                    choice1 = ReceiveChoice(p1);
                    if (choice1 == null)
                    {
                        SendMessage(p2, "Đối thủ đã thoát!\n");
                        p2.Close();
                        break;
                    }


                    // Nhận lựa chọn từ player 2
                    choice2 = ReceiveChoice(p2);
                    if (choice2 == null)
                    {
                        SendMessage(p1, "Đối thủ đã thoát!\n");
                        p1.Close();
                        break;
                    }
                    SendMessage(p1, "Doi thu chon:" + choice2 + "\n");
                    SendMessage(p2, "Doi thu chon:" + choice1 + "\n");



                    // Tính kết quả
                    string result1 = CalculateResult(choice1, choice2);
                    string result2 = CalculateResult(choice2, choice1);
                    SendMessage(p1, "Ket qua la:" + result1 + "\n");
                    SendMessage(p2, "Ket qua la:" + result2 + "\n");

                    SendMessage(p1, "Nhan choi lai de tiep tuc\n");
                    SendMessage(p2, "Nhan choi lai de tiep tuc\n");

                    string? again1 = ReceiveAgain(p1);
                    string? again2 = ReceiveAgain(p2);
                    if (again1?.ToUpper() != "Y" || again2?.ToUpper() != "Y")
                    {
                        SendMessage(p1, "Kết thúc trò chơi!\n");
                        SendMessage(p2, "Kết thúc trò chơi!\n");
                        break;
                    }
                    // Đóng kết nối (hoặc có thể cho chơi tiếp)

                }
            }
            catch { }
            finally
            {
                p1.Close();
                p2.Close();
            }
        }

        
        static string ReceiveAgain(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                    return null;

                string choiceAgain = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                return (choiceAgain == "Y" || choiceAgain == "N") ? choiceAgain : null;
            }
            catch
            {
                return null;
            }
        }

        static void SendMessage(TcpClient client, string msg)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.UTF8.GetBytes(msg);
                stream.Write(data, 0, data.Length);
            }
            catch { }
        }

        static string CalculateResult(string c1, string c2)
        {
            if (c1 == c2) return "HÒA!";

            if ((c1 == "1" && c2 == "3") ||    // Kéo thắng Bao
                (c1 == "2" && c2 == "1") ||    // Búa thắng Kéo
                (c1 == "3" && c2 == "2"))      // Bao thắng Búa
                return "Bạn THẮNG! 🎉";

            return "Bạn THUA! 😢";
        }
        ///2
        static string ReceiveChoice(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                    return null;

                string choice = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                return (choice == "1" || choice == "2" || choice == "3") ? choice : null;
            }
            catch
            {
                return null;
            }
        }

    }
}
