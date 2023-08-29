namespace AirCommander
{
    partial class RulesPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesPage));
            this.rulesText = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rulesBackBtn = new System.Windows.Forms.Button();
            this.rulesPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rulesPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // rulesText
            // 
            this.rulesText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rulesText.Cursor = System.Windows.Forms.Cursors.Default;
            this.rulesText.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rulesText.Location = new System.Drawing.Point(4, 8);
            this.rulesText.Name = "rulesText";
            this.rulesText.ReadOnly = true;
            this.rulesText.Size = new System.Drawing.Size(1240, 410);
            this.rulesText.TabIndex = 0;
            this.rulesText.Text = resources.GetString("rulesText.Text");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // rulesBackBtn
            // 
            this.rulesBackBtn.BackColor = System.Drawing.SystemColors.Window;
            this.rulesBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rulesBackBtn.Font = new System.Drawing.Font("Times New Roman", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rulesBackBtn.Location = new System.Drawing.Point(523, 723);
            this.rulesBackBtn.Margin = new System.Windows.Forms.Padding(5);
            this.rulesBackBtn.Name = "rulesBackBtn";
            this.rulesBackBtn.Size = new System.Drawing.Size(200, 100);
            this.rulesBackBtn.TabIndex = 2;
            this.rulesBackBtn.Text = "Back";
            this.rulesBackBtn.UseVisualStyleBackColor = false;
            this.rulesBackBtn.Click += new System.EventHandler(this.rulesBackBtn_Click);
            // 
            // rulesPicture
            // 
            this.rulesPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rulesPicture.BackgroundImage")));
            this.rulesPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rulesPicture.Location = new System.Drawing.Point(251, 424);
            this.rulesPicture.Name = "rulesPicture";
            this.rulesPicture.Size = new System.Drawing.Size(861, 410);
            this.rulesPicture.TabIndex = 3;
            this.rulesPicture.TabStop = false;
            // 
            // RulesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AirCommander.Properties.Resources.background_main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.rulesPicture);
            this.Controls.Add(this.rulesBackBtn);
            this.Controls.Add(this.rulesText);
            this.Name = "RulesPage";
            this.Size = new System.Drawing.Size(1256, 945);
            this.Load += new System.EventHandler(this.RulesPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rulesPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rulesText;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button rulesBackBtn;
        private System.Windows.Forms.PictureBox rulesPicture;
    }
}
