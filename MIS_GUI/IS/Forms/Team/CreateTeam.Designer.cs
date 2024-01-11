namespace IS.Forms.Team
{
    partial class CreateTeam
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
            NameTextBox = new TextBox();
            label3 = new Label();
            DescriptionTextBox = new TextBox();
            label4 = new Label();
            JoinRightComboBox = new ComboBox();
            JoinCodeRightComboBox = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            JoinCodeTextBox = new TextBox();
            AffirmButton = new Button();
            ClearButton = new Button();
            ExitButton = new Button();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(355, 9);
            label1.Name = "label1";
            label1.Size = new Size(182, 52);
            label1.TabIndex = 0;
            label1.Text = "创建团队";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(145, 110);
            label2.Name = "label2";
            label2.Size = new Size(52, 27);
            label2.TabIndex = 1;
            label2.Text = "名称";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(243, 112);
            NameTextBox.MaxLength = 20;
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(185, 27);
            NameTextBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(145, 165);
            label3.Name = "label3";
            label3.Size = new Size(52, 27);
            label3.TabIndex = 3;
            label3.Text = "描述";
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Location = new Point(243, 165);
            DescriptionTextBox.MaxLength = 140;
            DescriptionTextBox.Multiline = true;
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new Size(450, 94);
            DescriptionTextBox.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(145, 279);
            label4.Name = "label4";
            label4.Size = new Size(92, 27);
            label4.TabIndex = 5;
            label4.Text = "加入限制";
            // 
            // JoinRightComboBox
            // 
            JoinRightComboBox.FormattingEnabled = true;
            JoinRightComboBox.Location = new Point(243, 279);
            JoinRightComboBox.Name = "JoinRightComboBox";
            JoinRightComboBox.Size = new Size(151, 28);
            JoinRightComboBox.TabIndex = 6;
            // 
            // JoinCodeRightComboBox
            // 
            JoinCodeRightComboBox.FormattingEnabled = true;
            JoinCodeRightComboBox.Location = new Point(542, 278);
            JoinCodeRightComboBox.Name = "JoinCodeRightComboBox";
            JoinCodeRightComboBox.Size = new Size(151, 28);
            JoinCodeRightComboBox.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(425, 279);
            label5.Name = "label5";
            label5.Size = new Size(112, 27);
            label5.TabIndex = 7;
            label5.Text = "加入码限制";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(145, 331);
            label6.Name = "label6";
            label6.Size = new Size(72, 27);
            label6.TabIndex = 9;
            label6.Text = "加入码";
            // 
            // JoinCodeTextBox
            // 
            JoinCodeTextBox.Location = new Point(243, 331);
            JoinCodeTextBox.MaxLength = 9;
            JoinCodeTextBox.Name = "JoinCodeTextBox";
            JoinCodeTextBox.Size = new Size(151, 27);
            JoinCodeTextBox.TabIndex = 10;
            // 
            // AffirmButton
            // 
            AffirmButton.Location = new Point(168, 391);
            AffirmButton.Name = "AffirmButton";
            AffirmButton.Size = new Size(120, 60);
            AffirmButton.TabIndex = 11;
            AffirmButton.Text = "确认";
            AffirmButton.UseVisualStyleBackColor = true;
            AffirmButton.Click += AffirmButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(370, 391);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(120, 60);
            ClearButton.TabIndex = 12;
            ClearButton.Text = "清空";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(573, 391);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(120, 60);
            ExitButton.TabIndex = 13;
            ExitButton.Text = "退出";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(415, 318);
            label7.Name = "label7";
            label7.Size = new Size(309, 40);
            label7.TabIndex = 14;
            label7.Text = "加入码要求为九位，由数字和大写字母组成。\r\n如果留空，系统会自动生成";
            // 
            // CreateTeam
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 480);
            Controls.Add(label7);
            Controls.Add(ExitButton);
            Controls.Add(ClearButton);
            Controls.Add(AffirmButton);
            Controls.Add(JoinCodeTextBox);
            Controls.Add(label6);
            Controls.Add(JoinCodeRightComboBox);
            Controls.Add(label5);
            Controls.Add(JoinRightComboBox);
            Controls.Add(label4);
            Controls.Add(DescriptionTextBox);
            Controls.Add(label3);
            Controls.Add(NameTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CreateTeam";
            Text = "创建团队";
            Load += CreateTeam_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox NameTextBox;
        private Label label3;
        private TextBox DescriptionTextBox;
        private Label label4;
        private ComboBox JoinRightComboBox;
        private ComboBox JoinCodeRightComboBox;
        private Label label5;
        private Label label6;
        private TextBox JoinCodeTextBox;
        private Button AffirmButton;
        private Button ClearButton;
        private Button ExitButton;
        private Label label7;
    }
}