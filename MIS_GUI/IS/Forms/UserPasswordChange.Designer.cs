namespace IS
{
    partial class UserPasswordChange
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
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("楷体", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(311, 37);
            label1.Name = "label1";
            label1.Size = new Size(137, 30);
            label1.TabIndex = 0;
            label1.Text = "修改密码";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(190, 98);
            label2.Name = "label2";
            label2.Size = new Size(87, 35);
            label2.TabIndex = 1;
            label2.Text = "登录名";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(190, 164);
            label3.Name = "label3";
            label3.Size = new Size(87, 35);
            label3.TabIndex = 2;
            label3.Text = "原密码";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(190, 234);
            label4.Name = "label4";
            label4.Size = new Size(87, 35);
            label4.TabIndex = 3;
            label4.Text = "新密码";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(336, 103);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(238, 30);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(336, 169);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(238, 30);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(336, 239);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(238, 30);
            textBox3.TabIndex = 6;
            // 
            // button1
            // 
            button1.Font = new Font("华文楷体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(134, 312);
            button1.Name = "button1";
            button1.Size = new Size(165, 53);
            button1.TabIndex = 7;
            button1.Text = "修改密码";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("华文楷体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(500, 312);
            button2.Name = "button2";
            button2.Size = new Size(158, 53);
            button2.TabIndex = 8;
            button2.Text = "重新登录";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // UserPasswordChange
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UserPasswordChange";
            Text = "UserPasswordChange";
            FormClosing += UserPasswordChange_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
    }
}