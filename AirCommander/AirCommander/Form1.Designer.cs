namespace AirCommander
{
    partial class airCommanderMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(airCommanderMain));
            this.mainTitle = new System.Windows.Forms.Label();
            this.playBtn = new System.Windows.Forms.Button();
            this.rulesBtn = new System.Windows.Forms.Button();
            this.quitBtn = new System.Windows.Forms.Button();
            this.battlePage1 = new AirCommander.BattlePage();
            this.rulesPage1 = new AirCommander.RulesPage();
            this.SuspendLayout();
            // 
            // mainTitle
            // 
            this.mainTitle.AutoSize = true;
            this.mainTitle.Font = new System.Drawing.Font("Arial", 62F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTitle.Location = new System.Drawing.Point(125, 81);
            this.mainTitle.Name = "mainTitle";
            this.mainTitle.Size = new System.Drawing.Size(949, 120);
            this.mainTitle.TabIndex = 0;
            this.mainTitle.Text = "AIR COMMANDER";
            // 
            // playBtn
            // 
            this.playBtn.BackColor = System.Drawing.SystemColors.Window;
            this.playBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playBtn.Font = new System.Drawing.Font("Times New Roman", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playBtn.Location = new System.Drawing.Point(506, 270);
            this.playBtn.Margin = new System.Windows.Forms.Padding(5);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(200, 100);
            this.playBtn.TabIndex = 1;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = false;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // rulesBtn
            // 
            this.rulesBtn.BackColor = System.Drawing.SystemColors.Window;
            this.rulesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rulesBtn.Font = new System.Drawing.Font("Times New Roman", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rulesBtn.Location = new System.Drawing.Point(506, 400);
            this.rulesBtn.Margin = new System.Windows.Forms.Padding(5);
            this.rulesBtn.Name = "rulesBtn";
            this.rulesBtn.Size = new System.Drawing.Size(200, 100);
            this.rulesBtn.TabIndex = 2;
            this.rulesBtn.Text = "Rules";
            this.rulesBtn.UseVisualStyleBackColor = false;
            this.rulesBtn.Click += new System.EventHandler(this.rulesBtn_Click);
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.SystemColors.Window;
            this.quitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quitBtn.Font = new System.Drawing.Font("Times New Roman", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.Location = new System.Drawing.Point(506, 530);
            this.quitBtn.Margin = new System.Windows.Forms.Padding(5);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(200, 100);
            this.quitBtn.TabIndex = 3;
            this.quitBtn.Text = "Quit";
            this.quitBtn.UseVisualStyleBackColor = false;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // battlePage1
            // 
            this.battlePage1.BackColor = System.Drawing.SystemColors.Control;
            this.battlePage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("battlePage1.BackgroundImage")));
            this.battlePage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.battlePage1.Location = new System.Drawing.Point(-169, 351);
            this.battlePage1.Margin = new System.Windows.Forms.Padding(4);
            this.battlePage1.Name = "battlePage1";
            this.battlePage1.Size = new System.Drawing.Size(412, 511);
            this.battlePage1.TabIndex = 5;
            // 
            // rulesPage1
            // 
            this.rulesPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rulesPage1.BackgroundImage")));
            this.rulesPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rulesPage1.Location = new System.Drawing.Point(0, 0);
            this.rulesPage1.Margin = new System.Windows.Forms.Padding(4);
            this.rulesPage1.Name = "rulesPage1";
            this.rulesPage1.Size = new System.Drawing.Size(1920, 1080);
            this.rulesPage1.TabIndex = 4;
            // 
            // airCommanderMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AirCommander.Properties.Resources.background_main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.battlePage1);
            this.Controls.Add(this.rulesPage1);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.rulesBtn);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.mainTitle);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "airCommanderMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Air Commander";
            this.Load += new System.EventHandler(this.airCommanderMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainTitle;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button rulesBtn;
        private System.Windows.Forms.Button quitBtn;
        private RulesPage rulesPage1;
        private BattlePage battlePage1;
    }
}

