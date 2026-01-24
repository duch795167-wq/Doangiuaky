using System.Drawing.Drawing2D;
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
            lblResult.Visible = false;
            lblVS.Visible = false;
            picEnemy.Visible = false;
            picYou.Visible = false;
            lblYou.Visible = false;
            lblEnemy.Visible = false;

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
                            lblResult.Visible = true;
                            btnPlayAgain.Visible = true;
                            btnExit.Visible = true;
                            lblResult.Text = result;
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
                            lblResult.Visible = false;
                            lblVS.Visible = true;
                            lblYou.Visible = true;
                            lblEnemy.Visible = true;
                            picYou.Visible = true;
                            picEnemy.Visible = true;
                            pic_Background.Visible = false;
                            picEnemy.Image = null;
                            picYou.Image = null;
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
        void ShowEnemyChoice(string choice)
        {
            picEnemy.SizeMode = PictureBoxSizeMode.Zoom;

            switch (choice)
            {
                case "1":
                    picEnemy.Image = Properties.Resources.Keo;
                    break;
                case "2":
                    picEnemy.Image = Properties.Resources.Bua;
                    break;
                case "3":
                    picEnemy.Image = Properties.Resources.Bao;
                    break;
            }
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
                        lblVS.Visible = false;
                        lblYou.Visible = false;
                        lblEnemy.Visible = false;
                        btnPlayAgain.Visible = false;
                        btnExit.Enabled = false;
                        lblResult.Visible = false;
                        picEnemy.Visible = false;
                        picYou.Visible = false;

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

        private void MakeCircleButton(Button btn)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ip = string.IsNullOrEmpty(txtIP.Text) ? "127.0.0.1" : txtIP.Text.Trim();

            if (!IsLocalhost127_0_0_X(ip))
            {
                MessageBox.Show("Chỉ được kết nối đến địa chỉ 127.0.0.x (localhost)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {

                client = new TcpClient(ip, 8888);
                stream = client.GetStream();

                txtStatus.Text = "Đã kết nối server!\n";

                // Thread nhận tin nhắn từ server
                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();

                btnConnect.Enabled = false;
                txtIP.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được server!\n" + ex.Message);
            }
        }
        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            SendChoice("Y");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            SendChoice("N");
        }

        private void btnKeo_Click(object sender, EventArgs e)
        {

            SendChoice("1");
            picYou.Image = Properties.Resources.Keo;


        }
        private void btnBua_Click(object sender, EventArgs e)
        {
            SendChoice("2");
            picYou.Image = Properties.Resources.Bua;

        }
        private void btnBao_Click(object sender, EventArgs e)
        {

            SendChoice("3");
            picYou.Image = Properties.Resources.Bao;

        }

       
    }
}
