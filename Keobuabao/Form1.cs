using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Keobuabao
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;

        public Form1()
        {
            InitializeComponent();
            btnKeo.Visible = false;
            btnBua.Visible = false;
            btnBao.Visible = false;
            btnPlayAgain.Visible = false;
            btnExit.Visible = false;
            lbl_Result.Visible = false;
            lbl_VS.Visible = false;
            pic_Enemy.Visible = false;
            pic_You.Visible = false;
            lbl_You.Visible = false;
            lbl_Enemy.Visible = false;

            MakeCircleButton(btnKeo);
            MakeCircleButton(btnBua);
            MakeCircleButton(btnBao);
        }

        private void ReceiveMessages()
        {
            try
            {
                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (message.StartsWith("Ket qua la:"))
                        {
                            string result = message.Split(':')[1].Trim();
                            lbl_Result.Visible = true;
                            btnPlayAgain.Visible = true;
                            btnExit.Visible = true;
                            lbl_Result.Text = result;
                            txtStatus.AppendText("-" + message + Environment.NewLine);
                        }
                        else if (message.StartsWith("Doi thu chon:"))
                        {
                            string Enemy_choice = message.Split(':')[1].Trim();
                            ShowEnemyChoice(Enemy_choice);
                        }
                        else
                        {
                            txtStatus.AppendText("-" + message + Environment.NewLine);
                        }


                        // Khi bắt đầu game → hiện nút chọn
                        if (message.Contains("BẮT ĐẦU"))
                        {
                            txtStatus.Clear();
                            txtStatus.AppendText("-" + message + Environment.NewLine);
                            lbl_Result.Visible = false;
                            pic_You.Visible = true;
                            pic_Enemy.Visible = true;
                            pic_Background.Visible = false;
                            pic_Enemy.Image = null;
                            pic_You.Image = null;
                            btnKeo.Visible = true;
                            btnBua.Visible = true;
                            btnBao.Visible = true;

                            btnPlayAgain.Visible = false;
                            btnExit.Visible = false;

                        }

                    });

                }
            }
            catch { }
        }

        private void SendChoice(string choice)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(choice);
                stream.Write(data, 0, data.Length);


                this.Invoke((MethodInvoker)delegate
                {
                    btnKeo.Visible = false;
                    btnBua.Visible = false;
                    btnBao.Visible = false;
                    if (choice == "N")
                    {
                        txtStatus.AppendText("Ban da thoat");
                        btnKeo.Visible = false;
                        btnBua.Visible = false;
                        btnBao.Visible = false;
                        btnPlayAgain.Visible = false;
                        btnExit.Enabled = false;
                        lbl_Result.Visible = false;
                        pic_Enemy.Visible = false;
                        pic_You.Visible = false;

                    }
                    else if (choice == "Y") txtStatus.AppendText("Dang doi doi thu");
                    else txtStatus.AppendText("Đã gửi lựa chọn... Đang chờ kết quả" + Environment.NewLine);



                });


                // Ẩn nút sau khi chọn

            }
            catch { }
        }
        private bool IsLocalhost127_0_0_X(string ip)
        {
            if (!IPAddress.TryParse(ip, out IPAddress address)) return false;
            byte[] bytes = address.GetAddressBytes();
            return bytes[0] == 127 && bytes[1] == 0 && bytes[2] == 0;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stream?.Close();
            client?.Close();
        }

        private void MakeCircleButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Color.Transparent;
            button.Width = 100;
            button.Height = 100;
            button.Region = new Region(new RectangleF(0, 0, button.Width, button.Height));
        }

        private void btnKeo_Click(object sender, EventArgs e)
        {
            
            SendChoice("1");
            pic_You.Image = Properties.Resources.Keo;
          

        }
        private void btnBua_Click(object sender, EventArgs e)
        {
            SendChoice("2");
            pic_You.Image = Properties.Resources.Bua;
            
        }

    }
}
