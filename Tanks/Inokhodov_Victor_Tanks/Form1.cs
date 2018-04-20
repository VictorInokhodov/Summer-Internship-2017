using System;
using Model;
using Controller;
using Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inokhodov_Victor_Tanks
{
    public partial class MainForm : Form
    {
        private Controller.BlockController blockController = new Controller.BlockController();
        private Controller.BallController ballController = new BallController();
        private Controller.TankController tankController = new TankController();
        private Controller.AppleController appleController = new AppleController();

        private int score = 0;
        private int numOfApples;
        private int numOfTanks;
        private double blockSize;
        private int fieldSize;
        private int speed;
        private bool gameOver = false;
        private int killedTanks = 0;

        public MainForm(int size, int enemies, int apples, int speed)
        {
            this.speed = speed;
            fieldSize = size;
            blockSize = size / 13.0;
            var dir = Directory.GetCurrentDirectory();
            numOfApples = apples;
            numOfTanks = enemies;

            List<Point> tanksPositions = new List<Point>
             {
                 new Point(0, 0),
                 new Point((int) blockSize * 2, 0),
                 new Point((int) blockSize * 4, 0),
                 new Point((int) blockSize * 8, 0),
                 new Point((int) blockSize * 12, 0)
             };
 
             List<string> field = new List<string>
             {
                "   b  w  b   ",
                " b         b ",
                " b         b ",
                " b bbbbbbb b ",
                "             ",
                "             ",
                " www w w www ",
                "             ",
                " b         b ",
                " b  bbbbb  b ",
                " b         b ",
                " b   bbb   b ",
                "     bwb     ",
            };

            InitializeComponent();
            ImageController.LoadImages();
            blockController.InitializeField(field, (int) blockSize);
            ballController.CreateBall(135 , 540, (int) blockSize - 10, speed);
            tankController.InitializeTanks(enemies, (int) blockSize - 10, tanksPositions, speed - 1);
            appleController.Initialize();

            pictureBox.Size = new Size(size, size);
            Size = new Size(size + 15, size + 60);
        }

       public void Update(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                gameOver = tankController.MoveTank(pictureBox.Width, pictureBox.Height);

                if (gameOver)
                    return;

                if (ballController.MoveBullet(pictureBox.Width, pictureBox.Height))
                {
                    killedTanks++;
                }

                tankController.Shoot();
                gameOver = tankController.MoveBullets(pictureBox.Width, pictureBox.Height);
                appleController.Add(numOfApples, (int)blockSize / 2, pictureBox.Width, pictureBox.Height);
                score += appleController.CheckCollision();
                Draw();

                if (killedTanks == numOfTanks)
                {
                    timer.Enabled = false;

                    DialogResult dr = MessageBox.Show("Congratulation!\nDo you want to try again?", "You win!", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    else
                    {
                        Dispose();
                    }
                }
            }
            else
            {
                timer.Enabled = false;

                DialogResult dr = MessageBox.Show("Do you want to try again?", "You lose!", MessageBoxButtons.YesNo);

               if (dr == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    Dispose();
                }
            }
        }

        public void Draw()
        {
            Bitmap flag = new Bitmap(fieldSize, fieldSize);
            Graphics flagGraphics = Graphics.FromImage(flag);

            BallView.DrawBall(BallModel.GetBall(), flagGraphics);
            BlocksView.DrawBlocks(BlockModel.GetBlocks(), flagGraphics);
            TankView.DrawTanks(TankModel.GetTanks(), flagGraphics);
            AppleView.DrawApples(AppleModel.GetApples(), flagGraphics);

            pictureBox.Image = flag;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                ballController.Shoot();
            }

            switch (e.KeyCode)
            {
                case Keys.Left:
                    ballController.MoveBall(-speed, 0, pictureBox.Width, pictureBox.Height, Direction.Left);
                    break;

                case Keys.Up:
                    ballController.MoveBall(0, -speed, pictureBox.Width, pictureBox.Height, Direction.Up);
                    break;

                case Keys.Right:
                    ballController.MoveBall(speed, 0, pictureBox.Width, pictureBox.Height, Direction.Right);
                    break;

                case Keys.Down:
                    ballController.MoveBall(0, speed, pictureBox.Width, pictureBox.Height, Direction.Down);
                    break;
            }
        }

        private void NewGame_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm(score);
            timer.Stop();
            infoForm.ShowDialog();
            timer.Start();
        }
    }
}
