using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AirCommander
{
    public partial class airCommanderMain : Form
    {
        public airCommanderMain()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void airCommanderMain_Load(object sender, EventArgs e)
        {
            // get desktop resolution
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            //position app screen and adapt to desktop resolution
            this.Location = new Point(0, 0);
            this.Size = new Size(width, height);
            //position tittle and buttons based on resolution
            mainTitle.Location = new Point (width / 2 - mainTitle.Size.Width / 2, height / 6);
            mainTitle.BackColor = Color.Transparent;
            // make sure buttons are spread evenly
            int btnSpace = 130;
            playBtn.Location = new Point(width / 2 - playBtn.Size.Width / 2, height / 3);
            rulesBtn.Location = new Point(width / 2 - rulesBtn.Size.Width / 2, height / 3 + btnSpace);
            quitBtn.Location = new Point(width / 2 - quitBtn.Size.Width / 2, height / 3 + btnSpace * 2);
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rulesBtn_Click(object sender, EventArgs e)
        {
            rulesPage1.Visible = true;
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            battlePage1.Visible = true;
        }
    }
}
