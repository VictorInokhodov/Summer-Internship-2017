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
        private Controller.BlockController blockController = new BlockController();
        private Controller.BallController ballController = new BallController();
        private Controller.TankController tankController = new TankController();
        private Controller.AppleController appleController = new AppleController();
        public Controller.ImageController imageController = new ImageController();

        private List<Point> tanksPositions;
        private Point ballPosition = new Point(135, 540);
        InfoForm infoForm;

        private const int horizontalSizeDifference = 15;
        private const int verticalSizeDifference = 60;

        private int width = 0;
        private int height = 0;
        private int score = 0;
        private int numOfApples;
        private int numOfTanks;
        private double blockSize;
        private int fieldSize;
        private int speed;
        private bool gameOver = false;
        private int killedTanks = 0;
        private const double numOfBlocks = 13.0;
        private const int blockTankSizeDifference = 10;

        public MainForm(int size, int enemies, int apples, int speed)
        {
            width = height = size;
            this.speed = speed;
            fieldSize = size;
            blockSize = size / numOfBlocks;
            var dir = Directory.GetCurrentDirectory();
            numOfApples = apples;
            numOfTanks = enemies;

            tanksPositions = new List<Point>
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
            imageController.LoadImages();
            blockController.InitializeField(field, (int) blockSize);
            ballController.CreateBall(ballPosition.X , ballPosition.Y, (int) blockSize - blockTankSizeDifference, speed);
            tankController.InitializeTanks(enemies, (int) blockSize - blockTankSizeDifference, tanksPositions, speed);
            appleController.Initialize();

            pictureBox.Size = new Size(size, size);
            Size = new Size(size + horizontalSizeDifference, size + verticalSizeDifference);
        }

       public void Update(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                OnGame();
            }
            else
            {
                GameOver();
            }
        }

        public void GameOver()
        {
            timer.Enabled = false;

            DialogResult dr = MessageBox.Show("Do you want to try again?", "You lose!", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                Restart();
                timer.Enabled = true;
            }
        }

        public void OnGame()
        {
            gameOver = tankController.MoveTank(pictureBox.Width, pictureBox.Height, ballController.GetBall(), blockController.GetBlocks());

            if (gameOver)
                return;

            if (ballController.MoveBullet(pictureBox.Width, pictureBox.Height, blockController.GetBlocks(), tankController.GetTanks()))
            {
                killedTanks++;
            }

            tankController.Shoot();
            gameOver = tankController.MoveBullets(pictureBox.Width, pictureBox.Height, ballController.GetBall(), blockController.GetBlocks());
            appleController.Add(numOfApples, (int)blockSize / 2, pictureBox.Width, pictureBox.Height, blockController.GetBlocks());
            score += appleController.CheckCollision(ballController.GetBall());
            ballController.MoveBall(width, height ,blockController.GetBlocks());
            Draw();

            if (killedTanks == numOfTanks)
            {
                timer.Enabled = false;

                DialogResult dr = MessageBox.Show("Congratulation!\nDo you want to try again?", "You win!", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    Restart();
                    timer.Enabled = true;
                }
            }

            infoForm?.WriteInfo(score, ballController.GetBall(), tankController.GetTanks());
        }

        public void Restart()
        {
            var tanks = tankController.GetTanks().ToArray();
            var ball = ballController.GetBall();

            for (int i = 0; i < numOfTanks; i++)
            {
                tanks[i].PosX = tanksPositions[i].X;
                tanks[i].PosY = tanksPositions[i].Y;
                tanks[i].IsEnable = true;
                tanks[i].Bullet.IsEnable = false;
            }

            ball.PosX = ballPosition.X;
            ball.PosY = ballPosition.Y;
            ball.Bullet.IsEnable = false;

            killedTanks = 0;
            score = 0;

            gameOver = false;
        }

        public void Draw()
        {
            Bitmap flag = new Bitmap(fieldSize, fieldSize);
            Graphics flagGraphics = Graphics.FromImage(flag);

            BallView.DrawBall(ballController.GetBall(), flagGraphics, imageController.GetImages());
            BlocksView.DrawBlocks(blockController.GetBlocks(), flagGraphics);
            TankView.DrawTanks(tankController.GetTanks(), flagGraphics, imageController.GetImages());
            AppleView.DrawApples(appleController.GetApples(), flagGraphics);

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
                    ballController.GetBall().Direction = Direction.Left;
                    break;

                case Keys.Up:
                    ballController.GetBall().Direction = Direction.Up;
                    break;

                case Keys.Right:
                    ballController.GetBall().Direction = Direction.Right;
                    break;

                case Keys.Down:
                    ballController.GetBall().Direction = Direction.Down;
                    break;
            }
        }

        private void NewGame_Click_1(object sender, EventArgs e)
        {
            timer.Stop();

            DialogResult dr = MessageBox.Show("Start new game?", "Seriously?", MessageBoxButtons.YesNo);

            timer.Start();

            if (dr == DialogResult.Yes)
            {
                Restart();
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoForm?.Dispose();
            infoForm = new InfoForm(score, ballController.GetBall(), tankController.GetTanks());
            infoForm.Show();
        }
    }
}
