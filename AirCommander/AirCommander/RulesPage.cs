using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirCommander
{
    public partial class RulesPage : UserControl
    {
        public RulesPage()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void RulesPage_Load(object sender, EventArgs e)
        {
            //get desktop resolution
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            //position screen and resize based on resolution
            this.Location = new Point(0, 0);
            this.Size = new Size(width, height);
            //position rules text and back button
            this.rulesText.Width = width - 10;
            this.rulesText.Height = height / 3;
            this.rulesBackBtn.Location = new Point(width / 2 + this.rulesBackBtn.Size.Width + 150, height - 350);
            //rules image
            this.rulesPicture.Width = width / 2 + 200;
            this.rulesPicture.Height = height / 2 + 100;
            this.rulesPicture.Location = new Point(3, height / 2 - 120);
            //make sure it starts off as invisible until called on
            this.Visible = false;
        }

        private void rulesBackBtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
