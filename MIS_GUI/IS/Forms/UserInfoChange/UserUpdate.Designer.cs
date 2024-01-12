namespace UserInfo
{
    partial class UserUpdate
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
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            UpdateButton = new Button();
            ReCheckButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(156, 87);
            label1.Name = "label1";
            label1.Size = new Size(87, 35);
            label1.TabIndex = 0;
            label1.Text = "登录名";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(283, 93);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(272, 30);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(156, 158);
            label2.Name = "label2";
            label2.Size = new Size(87, 35);
            label2.TabIndex = 2;
            label2.Text = "用户名";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(283, 164);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(272, 30);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(167, 228);
            label3.Name = "label3";
            label3.Size = new Size(63, 35);
            label3.TabIndex = 4;
            label3.Text = "密码";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(283, 228);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(272, 30);
            textBox3.TabIndex = 5;
            // 
            // UpdateButton
            // 
            UpdateButton.Font = new Font("楷体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            UpdateButton.Location = new Point(61, 306);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(182, 51);
            UpdateButton.TabIndex = 6;
            UpdateButton.Text = "更新";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // ReCheckButton
            // 
            ReCheckButton.Font = new Font("楷体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ReCheckButton.Location = new Point(500, 306);
            ReCheckButton.Name = "ReCheckButton";
            ReCheckButton.Size = new Size(224, 51);
            ReCheckButton.TabIndex = 7;
            ReCheckButton.Text = "查看更新后信息";
            ReCheckButton.UseVisualStyleBackColor = true;
            ReCheckButton.Click += ReCheckButton_Click;
            // 
            // UserUpdate
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ReCheckButton);
            Controls.Add(UpdateButton);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "UserUpdate";
            Text = "UserUpdate";
            Load += UserUpdate_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Button UpdateButton;
        private Button ReCheckButton;
    }
}