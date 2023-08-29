namespace AirCommander
{
    partial class BattlePage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.battleBackBtn = new System.Windows.Forms.Button();
            this.battlePhaseText = new System.Windows.Forms.Label();
            this.playerPanel = new System.Windows.Forms.Panel();
            this.playerLabel = new System.Windows.Forms.Label();
            this.enemyPanel = new System.Windows.Forms.Panel();
            this.enemyLabel = new System.Windows.Forms.Label();
            this.battleLog = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.battleStartBtn = new System.Windows.Forms.Button();
            this.playerPanel.SuspendLayout();
            this.enemyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // battleBackBtn
            // 
            this.battleBackBtn.BackColor = System.Drawing.SystemColors.Window;
            this.battleBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.battleBackBtn.Font = new System.Drawing.Font("Times New Roman", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.battleBackBtn.Location = new System.Drawing.Point(613, 656);
            this.battleBackBtn.Margin = new System.Windows.Forms.Padding(5);
            this.battleBackBtn.Name = "battleBackBtn";
            this.battleBackBtn.Size = new System.Drawing.Size(200, 100);
            this.battleBackBtn.TabIndex = 3;
            this.battleBackBtn.Text = "Back";
            this.battleBackBtn.UseVisualStyleBackColor = false;
            this.battleBackBtn.Click += new System.EventHandler(this.battleBackBtn_Click);
            // 
            // battlePhaseText
            // 
            this.battlePhaseText.AutoSize = true;
            this.battlePhaseText.Font = new System.Drawing.Font("Times New Roman", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.battlePhaseText.Location = new System.Drawing.Point(541, 18);
            this.battlePhaseText.Name = "battlePhaseText";
            this.battlePhaseText.Size = new System.Drawing.Size(235, 53);
            this.battlePhaseText.TabIndex = 4;
            this.battlePhaseText.Text = "Press start";
            // 
            // playerPanel
            // 
            this.playerPanel.Controls.Add(this.playerLabel);
            this.playerPanel.Location = new System.Drawing.Point(46, 111);
            this.playerPanel.Name = "playerPanel";
            this.playerPanel.Size = new System.Drawing.Size(430, 460);
            this.playerPanel.TabIndex = 5;
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerLabel.Location = new System.Drawing.Point(168, 0);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(90, 31);
            this.playerLabel.TabIndex = 0;
            this.playerLabel.Text = "Player";
            // 
            // enemyPanel
            // 
            this.enemyPanel.Controls.Add(this.enemyLabel);
            this.enemyPanel.Location = new System.Drawing.Point(881, 111);
            this.enemyPanel.Name = "enemyPanel";
            this.enemyPanel.Size = new System.Drawing.Size(430, 460);
            this.enemyPanel.TabIndex = 6;
            // 
            // enemyLabel
            // 
            this.enemyLabel.AutoSize = true;
            this.enemyLabel.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyLabel.Location = new System.Drawing.Point(168, 0);
            this.enemyLabel.Name = "enemyLabel";
            this.enemyLabel.Size = new System.Drawing.Size(94, 31);
            this.enemyLabel.TabIndex = 0;
            this.enemyLabel.Text = "Enemy";
            // 
            // battleLog
            // 
            this.battleLog.BackColor = System.Drawing.SystemColors.HighlightText;
            this.battleLog.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.battleLog.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.battleLog.Location = new System.Drawing.Point(512, 217);
            this.battleLog.Multiline = true;
            this.battleLog.Name = "battleLog";
            this.battleLog.ReadOnly = true;
            this.battleLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.battleLog.Size = new System.Drawing.Size(340, 300);
            this.battleLog.TabIndex = 7;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // battleStartBtn
            // 
            this.battleStartBtn.BackColor = System.Drawing.Color.Maroon;
            this.battleStartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.battleStartBtn.Font = new System.Drawing.Font("Times New Roman", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.battleStartBtn.ForeColor = System.Drawing.Color.White;
            this.battleStartBtn.Location = new System.Drawing.Point(613, 535);
            this.battleStartBtn.Margin = new System.Windows.Forms.Padding(5);
            this.battleStartBtn.Name = "battleStartBtn";
            this.battleStartBtn.Size = new System.Drawing.Size(200, 100);
            this.battleStartBtn.TabIndex = 8;
            this.battleStartBtn.Text = "Start";
            this.battleStartBtn.UseVisualStyleBackColor = false;
            this.battleStartBtn.Click += new System.EventHandler(this.battleStartBtn_Click);
            // 
            // BattlePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::AirCommander.Properties.Resources.background_main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.battleStartBtn);
            this.Controls.Add(this.battleLog);
            this.Controls.Add(this.enemyPanel);
            this.Controls.Add(this.playerPanel);
            this.Controls.Add(this.battlePhaseText);
            this.Controls.Add(this.battleBackBtn);
            this.Name = "BattlePage";
            this.Size = new System.Drawing.Size(1393, 827);
            this.Load += new System.EventHandler(this.BattlePage_Load);
            this.playerPanel.ResumeLayout(false);
            this.playerPanel.PerformLayout();
            this.enemyPanel.ResumeLayout(false);
            this.enemyPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button battleBackBtn;
        private System.Windows.Forms.Label battlePhaseText;
        private System.Windows.Forms.Panel playerPanel;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Panel enemyPanel;
        private System.Windows.Forms.Label enemyLabel;
        private System.Windows.Forms.TextBox battleLog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button battleStartBtn;
    }
}
