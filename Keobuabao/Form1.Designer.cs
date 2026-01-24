namespace Keobuabao
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pic_Background = new PictureBox();
            lblYou = new Label();
            lblEnemy = new Label();
            picYou = new PictureBox();
            picEnemy = new PictureBox();
            lblVS = new Label();
            label1 = new Label();
            txtIP = new TextBox();
            btnConnect = new Button();
            btnPlayAgain = new Button();
            btnExit = new Button();
            label2 = new Label();
            txtStatus = new TextBox();
            lblResult = new Label();
            btnKeo = new Button();
            btnBua = new Button();
            btnBao = new Button();
            ((System.ComponentModel.ISupportInitialize)pic_Background).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picYou).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picEnemy).BeginInit();
            SuspendLayout();
            // 
            // pic_Background
            // 
            pic_Background.BackgroundImage = Properties.Resources.Background;
            pic_Background.BackgroundImageLayout = ImageLayout.Zoom;
            pic_Background.Location = new Point(12, 12);
            pic_Background.Name = "pic_Background";
            pic_Background.Size = new Size(988, 724);
            pic_Background.TabIndex = 0;
            pic_Background.TabStop = false;
            // 
            // lblYou
            // 
            lblYou.AutoSize = true;
            lblYou.Font = new Font("Segoe UI", 20F);
            lblYou.Location = new Point(114, 92);
            lblYou.Name = "lblYou";
            lblYou.Size = new Size(75, 46);
            lblYou.TabIndex = 1;
            lblYou.Text = "Bạn";
            // 
            // lblEnemy
            // 
            lblEnemy.AutoSize = true;
            lblEnemy.Font = new Font("Segoe UI", 20F);
            lblEnemy.Location = new Point(464, 92);
            lblEnemy.Name = "lblEnemy";
            lblEnemy.Size = new Size(131, 46);
            lblEnemy.TabIndex = 2;
            lblEnemy.Text = "Đối thủ";
            // 
            // picYou
            // 
            picYou.BackgroundImageLayout = ImageLayout.Zoom;
            picYou.Location = new Point(27, 141);
            picYou.Name = "picYou";
            picYou.Size = new Size(246, 296);
            picYou.SizeMode = PictureBoxSizeMode.Zoom;
            picYou.TabIndex = 3;
            picYou.TabStop = false;
            // 
            // picEnemy
            // 
            picEnemy.BackgroundImageLayout = ImageLayout.Zoom;
            picEnemy.Location = new Point(407, 141);
            picEnemy.Name = "picEnemy";
            picEnemy.Size = new Size(246, 296);
            picEnemy.SizeMode = PictureBoxSizeMode.Zoom;
            picEnemy.TabIndex = 4;
            picEnemy.TabStop = false;
            // 
            // lblVS
            // 
            lblVS.AutoSize = true;
            lblVS.Font = new Font("Segoe UI", 20F);
            lblVS.Location = new Point(302, 267);
            lblVS.Name = "lblVS";
            lblVS.Size = new Size(59, 46);
            lblVS.TabIndex = 5;
            lblVS.Text = "VS";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(805, 103);
            label1.Name = "label1";
            label1.Size = new Size(119, 35);
            label1.TabIndex = 6;
            label1.Text = "Địa chỉ IP";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(805, 141);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(125, 27);
            txtIP.TabIndex = 7;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(821, 174);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(94, 29);
            btnConnect.TabIndex = 8;
            btnConnect.Text = "Kết nối";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnPlayAgain
            // 
            btnPlayAgain.Location = new Point(750, 241);
            btnPlayAgain.Name = "btnPlayAgain";
            btnPlayAgain.Size = new Size(94, 29);
            btnPlayAgain.TabIndex = 9;
            btnPlayAgain.Text = "Chơi lại";
            btnPlayAgain.UseVisualStyleBackColor = true;
            btnPlayAgain.Click += btnPlayAgain_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(891, 241);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 10;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(799, 325);
            label2.Name = "label2";
            label2.Size = new Size(125, 35);
            label2.TabIndex = 11;
            label2.Text = "Trạng thái";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(750, 363);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(235, 293);
            txtStatus.TabIndex = 12;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 20F);
            lblResult.Location = new Point(302, 573);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(59, 46);
            lblResult.TabIndex = 13;
            lblResult.Text = "VS";
            // 
            // btnKeo
            // 
            btnKeo.BackColor = Color.Cyan;
            btnKeo.BackgroundImage = Properties.Resources.Keo;
            btnKeo.BackgroundImageLayout = ImageLayout.Zoom;
            btnKeo.Location = new Point(27, 470);
            btnKeo.Name = "btnKeo";
            btnKeo.Size = new Size(171, 200);
            btnKeo.TabIndex = 14;
            btnKeo.UseVisualStyleBackColor = false;
            btnKeo.Click += btnKeo_Click;
            // 
            // btnBua
            // 
            btnBua.BackColor = Color.Blue;
            btnBua.BackgroundImage = Properties.Resources.Bua;
            btnBua.BackgroundImageLayout = ImageLayout.Zoom;
            btnBua.Location = new Point(255, 470);
            btnBua.Name = "btnBua";
            btnBua.Size = new Size(171, 200);
            btnBua.TabIndex = 15;
            btnBua.UseVisualStyleBackColor = false;
            btnBua.Click += btnBua_Click;
            // 
            // btnBao
            // 
            btnBao.BackColor = Color.DarkViolet;
            btnBao.BackgroundImage = Properties.Resources.Bao;
            btnBao.BackgroundImageLayout = ImageLayout.Zoom;
            btnBao.Location = new Point(482, 470);
            btnBao.Name = "btnBao";
            btnBao.Size = new Size(171, 200);
            btnBao.TabIndex = 16;
            btnBao.UseVisualStyleBackColor = false;
            btnBao.Click += btnBao_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(1010, 748);
            Controls.Add(btnBao);
            Controls.Add(btnBua);
            Controls.Add(lblResult);
            Controls.Add(btnKeo);
            Controls.Add(txtStatus);
            Controls.Add(label2);
            Controls.Add(btnExit);
            Controls.Add(btnPlayAgain);
            Controls.Add(btnConnect);
            Controls.Add(txtIP);
            Controls.Add(label1);
            Controls.Add(lblVS);
            Controls.Add(picEnemy);
            Controls.Add(picYou);
            Controls.Add(lblEnemy);
            Controls.Add(lblYou);
            Controls.Add(pic_Background);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pic_Background).EndInit();
            ((System.ComponentModel.ISupportInitialize)picYou).EndInit();
            ((System.ComponentModel.ISupportInitialize)picEnemy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private PictureBox pic_Background;
        private Label lblYou;
        private Label lblEnemy;
        private PictureBox picYou;
        private PictureBox picEnemy;
        private Label lblVS;
        private Label label1;
        private TextBox txtIP;
        private Button btnConnect;
        private Button btnPlayAgain;
        private Button btnExit;
        private Label label2;
        private TextBox txtStatus;
        private Label lblResult;
        private Button btnKeo;
        private Button btnBua;
        private Button btnBao;
    }
}
