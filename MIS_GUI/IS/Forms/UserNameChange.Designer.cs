namespace IS
{
    partial class UserNameChange
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
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label5 = new Label();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("华文楷体", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(309, 9);
            label1.Name = "label1";
            label1.Size = new Size(202, 40);
            label1.TabIndex = 0;
            label1.Text = "修改用户名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(216, 72);
            label2.Name = "label2";
            label2.Size = new Size(87, 35);
            label2.TabIndex = 1;
            label2.Text = "登录名";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(343, 75);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(249, 30);
            textBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(227, 136);
            label3.Name = "label3";
            label3.Size = new Size(63, 35);
            label3.TabIndex = 3;
            label3.Text = "密码";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(343, 136);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(249, 30);
            textBox2.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(207, 199);
            label4.Name = "label4";
            label4.Size = new Size(111, 35);
            label4.TabIndex = 5;
            label4.Text = "原用户名";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(343, 204);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(249, 30);
            textBox3.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(207, 262);
            label5.Name = "label5";
            label5.Size = new Size(111, 35);
            label5.TabIndex = 7;
            label5.Text = "新用户名";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(343, 261);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(249, 30);
            textBox4.TabIndex = 8;
            // 
            // button1
            // 
            button1.Font = new Font("华文楷体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(158, 340);
            button1.Name = "button1";
            button1.Size = new Size(175, 56);
            button1.TabIndex = 9;
            button1.Text = "修改用户名";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("华文楷体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(523, 340);
            button2.Name = "button2";
            button2.Size = new Size(180, 56);
            button2.TabIndex = 10;
            button2.Text = "重新登陆";
            button2.UseVisualStyleBackColor = true;
            // 
            // UserInfoChange
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UserInfoChange";
            Text = "UserInfoChange";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox3;
        private Label label5;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
    }
}