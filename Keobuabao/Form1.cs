using System.Net.Sockets;

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
    }
}
