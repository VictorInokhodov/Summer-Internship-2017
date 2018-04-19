using System;
using System.IO;
using Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Controller;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

namespace Tanks
{
    public partial class MainForm : Form
    {
        public Controller.BlockController blockController = new Controller.BlockController();
        public Controller.BallController ballController = new BallController();
        public Controller.TankController tankController = new TankController();

        public double blockSize;
        public int fieldSize;
        public int speed;
        public bool gameOver = false;

        public MainForm(int size, int enemies, int apples, int speed)
        {
            this.speed = speed;
            fieldSize = size;
            blockSize = size / 13.0;
            var dir = Directory.GetCurrentDirectory();

            List<Point> tanksPositions = new List<Point>
            {
                new Point(0, 0),
                new Point((int)blockSize * 2, 0),
                new Point((int)blockSize * 4, 0),
                new Point((int)blockSize * 8, 0),
                new Point((int)blockSize * 12, 0)
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
                "      w      ",
            };

            InitializeComponent();
            ImageController.LoadImages();
            blockController.InitializeField(field, (int)blockSize);
            ballController.CreateBall(135 , 540, (int)blockSize - 10, speed);
            tankController.InitializeTanks(enemies, (int)blockSize - 10, tanksPositions, speed - 1);

            Size = pictureBox.Size = new Size(size, size);
        }

        public void Update(object sender, EventArgs e)
        {
            gameOver = tankController.MoveTank(pictureBox.Width, pictureBox.Height);

            Draw();

            if (gameOver)
            {
                timer.Enabled = false;
            }
        }

        public void Draw()
        {
            Bitmap flag = new Bitmap(fieldSize, fieldSize);
            Graphics flagGraphics = Graphics.FromImage(flag);

            BallView.DrawBall(BallModel.GetBall(), flagGraphics);
            BlocksView.DrawBlocks(BlockModel.GetBlocks(), flagGraphics);
            TankView.DrawTanks(TankModel.GetTanks(), flagGraphics);

            pictureBox.Image = flag;
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
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

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FormInfo.Invoke();
        }
    }
}
