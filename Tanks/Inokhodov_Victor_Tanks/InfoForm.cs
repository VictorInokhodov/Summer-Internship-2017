using Model;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inokhodov_Victor_Tanks
{
    public partial class InfoForm : Form
    {
        public InfoForm(int score)
        {
            InitializeComponent();
            WriteInfo(score);
        }

        private void WriteInfo(int score)
        {
            StringBuilder info = new StringBuilder();

            var ball = BallModel.GetBall();
            var tanks = TankModel.GetTanks();
            int i = 0;

            info.Append($"Score: {score}\n\n");

            info.Append("Player:\nPosX: " + ball.PosX +
                "\nPosY: " + ball.PosY + "\n");

            foreach (Tank tank in tanks)
            {
                info.Append("\nTank[" + i + "]:\nPosX: " + tank.PosX +
                "\nPosY: " + tank.PosY + "\n" +
                "Is defeated: " + !tank.IsEnable + "\n");
                i++;
            }

            InfoTextBox.Text = info.ToString();
        }
    }
}
