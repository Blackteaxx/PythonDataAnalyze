namespace IS.Forms.Team
{
    partial class TeamInfo
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            comboBox2 = new ComboBox();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(32, 75);
            label1.Name = "label1";
            label1.Size = new Size(92, 27);
            label1.TabIndex = 0;
            label1.Text = "团队名称";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(32, 125);
            label2.Name = "label2";
            label2.Size = new Size(92, 27);
            label2.TabIndex = 1;
            label2.Text = "团队描述";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(130, 75);
            textBox1.MaxLength = 20;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(177, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(130, 127);
            textBox2.MaxLength = 140;
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(468, 128);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(324, 75);
            label3.Name = "label3";
            label3.Size = new Size(72, 27);
            label3.TabIndex = 4;
            label3.Text = "创建者";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(402, 75);
            label4.Name = "label4";
            label4.Size = new Size(92, 27);
            label4.TabIndex = 5;
            label4.Text = "未知用户";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(221, 19);
            label5.Name = "label5";
            label5.Size = new Size(204, 35);
            label5.TabIndex = 6;
            label5.Text = "团队信息详情页";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(32, 275);
            label6.Name = "label6";
            label6.Size = new Size(92, 27);
            label6.TabIndex = 7;
            label6.Text = "团队人数";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(130, 275);
            label7.Name = "label7";
            label7.Size = new Size(92, 27);
            label7.TabIndex = 8;
            label7.Text = "团队人数";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(304, 275);
            label8.Name = "label8";
            label8.Size = new Size(92, 27);
            label8.TabIndex = 9;
            label8.Text = "加入限制";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "允许所有方式", "禁止搜索加入", "禁止加入码加入" });
            comboBox1.Location = new Point(402, 274);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(149, 28);
            comboBox1.TabIndex = 10;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(110, 372);
            button1.Name = "button1";
            button1.Size = new Size(94, 33);
            button1.TabIndex = 11;
            button1.Text = "进入";
            button1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(132, 321);
            label9.Name = "label9";
            label9.Size = new Size(72, 27);
            label9.TabIndex = 13;
            label9.Text = "加入码";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(43, 321);
            label10.Name = "label10";
            label10.Size = new Size(72, 27);
            label10.TabIndex = 12;
            label10.Text = "加入码";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(284, 321);
            label11.Name = "label11";
            label11.Size = new Size(112, 27);
            label11.TabIndex = 14;
            label11.Text = "加入码权限";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "允许所有人查看", "只允许管理员查看", "禁止所有人查看" });
            comboBox2.Location = new Point(402, 320);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(149, 28);
            comboBox2.TabIndex = 15;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(254, 372);
            button2.Name = "button2";
            button2.Size = new Size(94, 33);
            button2.TabIndex = 16;
            button2.Text = "关闭";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(402, 372);
            button3.Name = "button3";
            button3.Size = new Size(105, 33);
            button3.TabIndex = 17;
            button3.Text = "退出团队";
            button3.UseVisualStyleBackColor = true;
            // 
            // TeamInfo
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 429);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(comboBox2);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TeamInfo";
            Text = "团队详情";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox comboBox1;
        private Button button1;
        private Label label9;
        private Label label10;
        private Label label11;
        private ComboBox comboBox2;
        private Button button2;
        private Button button3;
    }
}