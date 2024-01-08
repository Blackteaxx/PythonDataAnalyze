namespace IS.Forms
{
    partial class Home
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
            SIderPanel = new Panel();
            button1 = new Button();
            HeaderPanel = new Panel();
            label1 = new Label();
            button2 = new Button();
            MainPanel = new Panel();
            SIderPanel.SuspendLayout();
            HeaderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // SIderPanel
            // 
            SIderPanel.BackColor = Color.White;
            SIderPanel.Controls.Add(button1);
            SIderPanel.Dock = DockStyle.Left;
            SIderPanel.Location = new Point(0, 0);
            SIderPanel.Name = "SIderPanel";
            SIderPanel.Size = new Size(200, 533);
            SIderPanel.TabIndex = 6;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.CausesValidation = false;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.White;
            button1.FlatAppearance.MouseOverBackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Image = Properties.Resources.团队40;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(12, 70);
            button1.Name = "button1";
            button1.Size = new Size(180, 40);
            button1.TabIndex = 0;
            button1.Text = "团队";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // HeaderPanel
            // 
            HeaderPanel.Controls.Add(label1);
            HeaderPanel.Controls.Add(button2);
            HeaderPanel.Dock = DockStyle.Top;
            HeaderPanel.Location = new Point(200, 0);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(900, 40);
            HeaderPanel.TabIndex = 9;
            HeaderPanel.Paint += HeaderPanel_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(42, 9);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(23, 23);
            label1.TabIndex = 1;
            label1.Text = ">";
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.HotTrack;
            button2.Location = new Point(0, 5);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(55, 30);
            button2.TabIndex = 0;
            button2.Text = "首页";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            // 
            // MainPanel
            // 
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.ForeColor = Color.Black;
            MainPanel.Location = new Point(200, 40);
            MainPanel.Margin = new Padding(0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(900, 493);
            MainPanel.TabIndex = 10;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 533);
            Controls.Add(MainPanel);
            Controls.Add(HeaderPanel);
            Controls.Add(SIderPanel);
            IsMdiContainer = true;
            Name = "Home";
            Text = "Home";
            FormClosed += Home_FormClosed;
            Load += Home_Load;
            SIderPanel.ResumeLayout(false);
            HeaderPanel.ResumeLayout(false);
            HeaderPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Panel SIderPanel;
        private Button button1;
        private Panel HeaderPanel;
        private Panel MainPanel;
        private Button button2;
        private Label label1;
    }
}