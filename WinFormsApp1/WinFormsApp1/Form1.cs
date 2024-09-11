namespace WinFormsApp1
{
    public partial class SpaceShooter : Form
    {

        PictureBox[] stars;
        int backgroundspeed;
        Random rnd;
        int playerSpeed;
        PictureBox[] munitions;
        int MunitionSpeed;

        public SpaceShooter()
        {
            InitializeComponent();
        }
        

        private void SpaceShooter_Load(object sender, EventArgs e)
        {
            backgroundspeed = 4;
   
            playerSpeed = 4;

            MunitionSpeed = 20;
            munitions = new PictureBox[3];

            // Carrega imagens
            Image munition = Image.FromFile(@"D:\downloads do outro disco\downloads\downloads assets projeto game\drive-download-20240909T225527Z-001\asserts\munition.png");

            for (int i = 0; i < munitions.Length; i++)
            {
                munitions[i] = new PictureBox();
                munitions[i].Size = new Size(8, 8);
                munitions[i].Image = munition;
                munitions[i].SizeMode = PictureBoxSizeMode.Zoom;
                munitions[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(munitions[i]);

            }
            
            stars = new PictureBox[10];
            rnd = new Random();

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 580), rnd.Next(-10, 400));
                if (1 % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;

                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;
                }

                this.Controls.Add(stars[i]);

            }
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpaceShooter));
            Player = new PictureBox();
            MoveBgTimer = new System.Windows.Forms.Timer(components);
            LeftMoveTimer = new System.Windows.Forms.Timer(components);
            RightMoveTimer = new System.Windows.Forms.Timer(components);
            DownMoveTimer = new System.Windows.Forms.Timer(components);
            UpMoveTimer = new System.Windows.Forms.Timer(components);
            MoveMunitionTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)Player).BeginInit();
            SuspendLayout();
            // 
            // Player
            // 
            Player.BackColor = Color.Transparent;
            Player.Image = Properties.Resources.player;
            Player.Location = new Point(260, 400);
            Player.Name = "Player";
            Player.Size = new Size(50, 50);
            Player.SizeMode = PictureBoxSizeMode.Zoom;
            Player.TabIndex = 0;
            Player.TabStop = false;
            // 
            // MoveBgTimer
            // 
            MoveBgTimer.Interval = 10;
            MoveBgTimer.Tick += timer1_Tick;
            // 
            // LeftMoveTimer
            // 
            LeftMoveTimer.Interval = 5;
            LeftMoveTimer.Tick += LeftMoveTimer_Tick;
            // 
            // RightMoveTimer
            // 
            RightMoveTimer.Interval = 5;
            RightMoveTimer.Tick += RightMoveTimer_Tick;
            // 
            // DownMoveTimer
            // 
            DownMoveTimer.Interval = 5;
            DownMoveTimer.Tick += DownMoveTimer_Tick;
            // 
            // UpMoveTimer
            // 
            UpMoveTimer.Interval = 5;
            UpMoveTimer.Tick += UpMoveTimer_Tick;
            // 
            // MoveMunitionTimer
            // 
            MoveMunitionTimer.Enabled = true;
            MoveMunitionTimer.Interval = 20;
            MoveMunitionTimer.Tick += MoveMunitionTimer_Tick;
            // 
            // SpaceShooter
            // 
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(584, 461);
            Controls.Add(Player);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(600, 500);
            Name = "SpaceShooter";
            Load += SpaceShooter_Load;
            KeyDown += SpaceShooter_KeyDown;
            KeyUp += SpaceShooter_KeyUp;
            ((System.ComponentModel.ISupportInitialize)Player).EndInit();
            ResumeLayout(false);
        }

        private PictureBox Player;
        private System.Windows.Forms.Timer MoveBgTimer;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Timer LeftMoveTimer;


        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length / 2; i++)
            {
                stars[i].Top += backgroundspeed;
                if (stars[i].Top <= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += backgroundspeed - 2;
                if (stars[i].Top <= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }



        private System.Windows.Forms.Timer RightMoveTimer;
        private System.Windows.Forms.Timer DownMoveTimer;
        private System.Windows.Forms.Timer UpMoveTimer;

        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10)
            {
                Player.Top -= playerSpeed;
            }
        }

        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 400)
            {
                Player.Top += playerSpeed;
            }
        }

        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 580)
            {
                Player.Left += playerSpeed;
            }
        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= playerSpeed;
            }
        }

        private void SpaceShooter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                RightMoveTimer.Start();
            }
            if (e.KeyCode == Keys.Left)
            {
                LeftMoveTimer.Start();
            }
            if (e.KeyCode == Keys.Up)
            {
                UpMoveTimer.Start();
            }
            if (e.KeyCode == Keys.Down)
            {
                DownMoveTimer.Start();
            }
        }

        private void SpaceShooter_KeyUp(object sender, KeyEventArgs e)
        {
            RightMoveTimer.Stop();
            LeftMoveTimer.Stop();
            UpMoveTimer.Stop();
            DownMoveTimer.Stop();
        }

        private System.Windows.Forms.Timer MoveMunitionTimer;

        private void MoveMunitionTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < munitions.Length; i++)
            {
                if (munitions[i].Top > 0) 
                {
                    munitions[i].Visible = true;
                    munitions[i].Top -= MunitionSpeed;
                }
                else
                {
                    munitions[i].Visible = false;
                    munitions[i].Location = new Point(Player.Location.X + 20, Player.Location.Y - i * 30) ;
                }

            }

        }
    }
}
