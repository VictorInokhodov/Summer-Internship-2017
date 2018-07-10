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
        int score;
        Ball ball;
        IEnumerable<Tank> tanks; 

        public InfoForm(int score, Ball ball, IEnumerable<Tank> tanks)
        { 
            this.ball = ball;
            this.tanks = tanks;
            this.score = score;

            InitializeComponent();
        }

        public void WriteInfo(int score, Ball ball, IEnumerable<Tank> tanks)
        {
            this.ball = ball;
            this.tanks = tanks;

            ctlBallDataGridView.DataSource = null;
            ctlBallDataGridView.DataSource = new List<BallDataGridView> { new BallDataGridView(ball, score) };

            ctlTanksDataGridView.DataSource = null;
            ctlTanksDataGridView.DataSource = tanks.Select(c => TankDataGridView.GetDataTank(c)).ToList();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            WriteInfo(score, ball, tanks);
        }
    }
}
