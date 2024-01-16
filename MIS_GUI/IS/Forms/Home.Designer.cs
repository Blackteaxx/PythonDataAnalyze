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
            components = new System.ComponentModel.Container();
            SIderPanel = new Panel();
            PersonContainer = new Panel();
            button2 = new Button();
            button1 = new Button();
            UserInfoUpdateButton = new Button();
            PersonButton = new Button();
            label1 = new Label();
            TaskContainer = new Panel();
            CreateTaskButton = new Button();
            TaskButton = new Button();
            UserTaskButton = new Button();
            TeamTaskButton = new Button();
            TeamContainer = new Panel();
            UserTeamButton = new Button();
            TeamInviteMemberButton = new Button();
            TeamInfoButton = new Button();
            SearchTeamButton = new Button();
            CreateTeamButton = new Button();
            TeamButton = new Button();
            HeaderPanel = new Panel();
            NextButton = new Button();
            ForwardButton = new Button();
            MainPanel = new Panel();
            TeamTimer = new System.Windows.Forms.Timer(components);
            TaskTimer = new System.Windows.Forms.Timer(components);
            PersonTimer = new System.Windows.Forms.Timer(components);
            SIderPanel.SuspendLayout();
            PersonContainer.SuspendLayout();
            TaskContainer.SuspendLayout();
            TeamContainer.SuspendLayout();
            HeaderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // SIderPanel
            // 
            SIderPanel.BackColor = Color.FromArgb(30, 40, 35);
            SIderPanel.Controls.Add(PersonContainer);
            SIderPanel.Controls.Add(label1);
            SIderPanel.Controls.Add(TaskContainer);
            SIderPanel.Controls.Add(TeamContainer);
            SIderPanel.Dock = DockStyle.Left;
            SIderPanel.Location = new Point(0, 0);
            SIderPanel.Name = "SIderPanel";
            SIderPanel.Size = new Size(200, 552);
            SIderPanel.TabIndex = 6;
            // 
            // PersonContainer
            // 
            PersonContainer.Controls.Add(button2);
            PersonContainer.Controls.Add(button1);
            PersonContainer.Controls.Add(UserInfoUpdateButton);
            PersonContainer.Controls.Add(PersonButton);
            PersonContainer.Location = new Point(0, 406);
            PersonContainer.Margin = new Padding(2);
            PersonContainer.MaximumSize = new Size(200, 147);
            PersonContainer.MinimumSize = new Size(200, 42);
            PersonContainer.Name = "PersonContainer";
            PersonContainer.Size = new Size(200, 42);
            PersonContainer.TabIndex = 2;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.AppWorkspace;
            button2.CausesValidation = false;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderColor = Color.White;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.White;
            button2.FlatAppearance.MouseOverBackColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Image = Properties.Resources.正确;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(-11, 112);
            button2.Name = "button2";
            button2.Padding = new Padding(25, 0, 0, 0);
            button2.Size = new Size(223, 34);
            button2.TabIndex = 5;
            button2.Text = "            文件上传";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.AppWorkspace;
            button1.CausesValidation = false;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.White;
            button1.FlatAppearance.MouseOverBackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.正确;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(-11, 78);
            button1.Name = "button1";
            button1.Padding = new Padding(25, 0, 0, 0);
            button1.Size = new Size(223, 34);
            button1.TabIndex = 4;
            button1.Text = "               通知";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            // 
            // UserInfoUpdateButton
            // 
            UserInfoUpdateButton.BackColor = SystemColors.AppWorkspace;
            UserInfoUpdateButton.CausesValidation = false;
            UserInfoUpdateButton.Cursor = Cursors.Hand;
            UserInfoUpdateButton.FlatAppearance.BorderColor = Color.White;
            UserInfoUpdateButton.FlatAppearance.BorderSize = 0;
            UserInfoUpdateButton.FlatAppearance.MouseDownBackColor = Color.White;
            UserInfoUpdateButton.FlatAppearance.MouseOverBackColor = Color.White;
            UserInfoUpdateButton.FlatStyle = FlatStyle.Popup;
            UserInfoUpdateButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            UserInfoUpdateButton.ForeColor = Color.White;
            UserInfoUpdateButton.Image = Properties.Resources.正确;
            UserInfoUpdateButton.ImageAlign = ContentAlignment.MiddleLeft;
            UserInfoUpdateButton.Location = new Point(-11, 45);
            UserInfoUpdateButton.Name = "UserInfoUpdateButton";
            UserInfoUpdateButton.Padding = new Padding(25, 0, 0, 0);
            UserInfoUpdateButton.Size = new Size(223, 34);
            UserInfoUpdateButton.TabIndex = 3;
            UserInfoUpdateButton.Text = "修改个人信息";
            UserInfoUpdateButton.UseVisualStyleBackColor = false;
            UserInfoUpdateButton.Click += UserInfoUpdateButton_Click;
            // 
            // PersonButton
            // 
            PersonButton.BackColor = Color.FromArgb(30, 40, 35);
            PersonButton.CausesValidation = false;
            PersonButton.Cursor = Cursors.Hand;
            PersonButton.FlatAppearance.BorderColor = Color.White;
            PersonButton.FlatAppearance.BorderSize = 0;
            PersonButton.FlatAppearance.MouseDownBackColor = Color.White;
            PersonButton.FlatAppearance.MouseOverBackColor = Color.White;
            PersonButton.FlatStyle = FlatStyle.Popup;
            PersonButton.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            PersonButton.ForeColor = Color.White;
            PersonButton.ImageAlign = ContentAlignment.MiddleLeft;
            PersonButton.Location = new Point(-34, -12);
            PersonButton.Name = "PersonButton";
            PersonButton.Padding = new Padding(25, 0, 0, 0);
            PersonButton.Size = new Size(243, 69);
            PersonButton.TabIndex = 1;
            PersonButton.Text = "个人";
            PersonButton.UseVisualStyleBackColor = false;
            PersonButton.Click += PersonButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(23, -4);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(171, 29);
            label1.TabIndex = 0;
            label1.Text = "---功能一览---";
            // 
            // TaskContainer
            // 
            TaskContainer.Controls.Add(CreateTaskButton);
            TaskContainer.Controls.Add(TaskButton);
            TaskContainer.Controls.Add(UserTaskButton);
            TaskContainer.Controls.Add(TeamTaskButton);
            TaskContainer.Location = new Point(0, 248);
            TaskContainer.Margin = new Padding(2);
            TaskContainer.MaximumSize = new Size(200, 151);
            TaskContainer.MinimumSize = new Size(200, 49);
            TaskContainer.Name = "TaskContainer";
            TaskContainer.Size = new Size(200, 49);
            TaskContainer.TabIndex = 1;
            // 
            // CreateTaskButton
            // 
            CreateTaskButton.BackColor = SystemColors.AppWorkspace;
            CreateTaskButton.CausesValidation = false;
            CreateTaskButton.Cursor = Cursors.Hand;
            CreateTaskButton.FlatAppearance.BorderColor = Color.White;
            CreateTaskButton.FlatAppearance.BorderSize = 0;
            CreateTaskButton.FlatAppearance.MouseDownBackColor = Color.White;
            CreateTaskButton.FlatAppearance.MouseOverBackColor = Color.White;
            CreateTaskButton.FlatStyle = FlatStyle.Flat;
            CreateTaskButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            CreateTaskButton.ForeColor = Color.White;
            CreateTaskButton.Image = Properties.Resources.正确;
            CreateTaskButton.ImageAlign = ContentAlignment.MiddleLeft;
            CreateTaskButton.Location = new Point(-13, 51);
            CreateTaskButton.Name = "CreateTaskButton";
            CreateTaskButton.Padding = new Padding(25, 0, 0, 0);
            CreateTaskButton.Size = new Size(223, 34);
            CreateTaskButton.TabIndex = 6;
            CreateTaskButton.Text = "创建任务";
            CreateTaskButton.UseVisualStyleBackColor = false;
            // 
            // TaskButton
            // 
            TaskButton.BackColor = Color.FromArgb(30, 40, 35);
            TaskButton.CausesValidation = false;
            TaskButton.Cursor = Cursors.Hand;
            TaskButton.FlatAppearance.BorderColor = Color.White;
            TaskButton.FlatAppearance.BorderSize = 0;
            TaskButton.FlatAppearance.MouseDownBackColor = Color.White;
            TaskButton.FlatAppearance.MouseOverBackColor = Color.White;
            TaskButton.FlatStyle = FlatStyle.Popup;
            TaskButton.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            TaskButton.ForeColor = Color.White;
            TaskButton.ImageAlign = ContentAlignment.MiddleLeft;
            TaskButton.Location = new Point(-28, -18);
            TaskButton.Name = "TaskButton";
            TaskButton.Padding = new Padding(25, 0, 0, 0);
            TaskButton.Size = new Size(229, 78);
            TaskButton.TabIndex = 1;
            TaskButton.Text = "任务";
            TaskButton.UseVisualStyleBackColor = false;
            TaskButton.Click += TaskButton_Click;
            // 
            // UserTaskButton
            // 
            UserTaskButton.BackColor = SystemColors.AppWorkspace;
            UserTaskButton.CausesValidation = false;
            UserTaskButton.Cursor = Cursors.Hand;
            UserTaskButton.FlatAppearance.BorderColor = Color.White;
            UserTaskButton.FlatAppearance.BorderSize = 0;
            UserTaskButton.FlatAppearance.MouseDownBackColor = Color.White;
            UserTaskButton.FlatAppearance.MouseOverBackColor = Color.White;
            UserTaskButton.FlatStyle = FlatStyle.Flat;
            UserTaskButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            UserTaskButton.ForeColor = Color.White;
            UserTaskButton.Image = Properties.Resources.正确;
            UserTaskButton.ImageAlign = ContentAlignment.MiddleLeft;
            UserTaskButton.Location = new Point(-13, 116);
            UserTaskButton.Name = "UserTaskButton";
            UserTaskButton.Padding = new Padding(25, 0, 0, 0);
            UserTaskButton.Size = new Size(223, 34);
            UserTaskButton.TabIndex = 2;
            UserTaskButton.Text = "个人任务";
            UserTaskButton.UseVisualStyleBackColor = false;
            // 
            // TeamTaskButton
            // 
            TeamTaskButton.BackColor = SystemColors.AppWorkspace;
            TeamTaskButton.CausesValidation = false;
            TeamTaskButton.Cursor = Cursors.Hand;
            TeamTaskButton.FlatAppearance.BorderColor = Color.White;
            TeamTaskButton.FlatAppearance.BorderSize = 0;
            TeamTaskButton.FlatAppearance.MouseDownBackColor = Color.White;
            TeamTaskButton.FlatAppearance.MouseOverBackColor = Color.White;
            TeamTaskButton.FlatStyle = FlatStyle.Flat;
            TeamTaskButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            TeamTaskButton.ForeColor = Color.White;
            TeamTaskButton.Image = Properties.Resources.正确;
            TeamTaskButton.ImageAlign = ContentAlignment.MiddleLeft;
            TeamTaskButton.Location = new Point(-13, 84);
            TeamTaskButton.Name = "TeamTaskButton";
            TeamTaskButton.Padding = new Padding(25, 0, 0, 0);
            TeamTaskButton.Size = new Size(223, 34);
            TeamTaskButton.TabIndex = 2;
            TeamTaskButton.Text = "团队任务";
            TeamTaskButton.UseVisualStyleBackColor = false;
            // 
            // TeamContainer
            // 
            TeamContainer.Controls.Add(UserTeamButton);
            TeamContainer.Controls.Add(TeamInviteMemberButton);
            TeamContainer.Controls.Add(TeamInfoButton);
            TeamContainer.Controls.Add(SearchTeamButton);
            TeamContainer.Controls.Add(CreateTeamButton);
            TeamContainer.Controls.Add(TeamButton);
            TeamContainer.Location = new Point(0, 24);
            TeamContainer.Margin = new Padding(2);
            TeamContainer.MaximumSize = new Size(200, 225);
            TeamContainer.MinimumSize = new Size(200, 52);
            TeamContainer.Name = "TeamContainer";
            TeamContainer.Size = new Size(200, 52);
            TeamContainer.TabIndex = 0;
            // 
            // UserTeamButton
            // 
            UserTeamButton.BackColor = SystemColors.AppWorkspace;
            UserTeamButton.CausesValidation = false;
            UserTeamButton.Cursor = Cursors.Hand;
            UserTeamButton.FlatAppearance.BorderColor = Color.White;
            UserTeamButton.FlatAppearance.BorderSize = 0;
            UserTeamButton.FlatAppearance.MouseDownBackColor = Color.White;
            UserTeamButton.FlatAppearance.MouseOverBackColor = Color.White;
            UserTeamButton.FlatStyle = FlatStyle.Flat;
            UserTeamButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            UserTeamButton.ForeColor = Color.White;
            UserTeamButton.Image = Properties.Resources.团队40;
            UserTeamButton.ImageAlign = ContentAlignment.MiddleLeft;
            UserTeamButton.Location = new Point(-14, 189);
            UserTeamButton.Name = "UserTeamButton";
            UserTeamButton.Padding = new Padding(25, 0, 0, 0);
            UserTeamButton.Size = new Size(223, 34);
            UserTeamButton.TabIndex = 5;
            UserTeamButton.Text = "已有团队";
            UserTeamButton.UseVisualStyleBackColor = false;
            UserTeamButton.Click += UserTeamButton_Click;
            // 
            // TeamInviteMemberButton
            // 
            TeamInviteMemberButton.BackColor = SystemColors.AppWorkspace;
            TeamInviteMemberButton.CausesValidation = false;
            TeamInviteMemberButton.Cursor = Cursors.Hand;
            TeamInviteMemberButton.FlatAppearance.BorderColor = Color.White;
            TeamInviteMemberButton.FlatAppearance.BorderSize = 0;
            TeamInviteMemberButton.FlatAppearance.MouseDownBackColor = Color.White;
            TeamInviteMemberButton.FlatAppearance.MouseOverBackColor = Color.White;
            TeamInviteMemberButton.FlatStyle = FlatStyle.Flat;
            TeamInviteMemberButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            TeamInviteMemberButton.ForeColor = Color.White;
            TeamInviteMemberButton.Image = Properties.Resources.团队40;
            TeamInviteMemberButton.ImageAlign = ContentAlignment.MiddleLeft;
            TeamInviteMemberButton.Location = new Point(-14, 156);
            TeamInviteMemberButton.Name = "TeamInviteMemberButton";
            TeamInviteMemberButton.Padding = new Padding(25, 0, 0, 0);
            TeamInviteMemberButton.Size = new Size(223, 34);
            TeamInviteMemberButton.TabIndex = 4;
            TeamInviteMemberButton.Text = "邀请成员";
            TeamInviteMemberButton.UseVisualStyleBackColor = false;
            // 
            // TeamInfoButton
            // 
            TeamInfoButton.BackColor = SystemColors.AppWorkspace;
            TeamInfoButton.CausesValidation = false;
            TeamInfoButton.Cursor = Cursors.Hand;
            TeamInfoButton.FlatAppearance.BorderColor = Color.White;
            TeamInfoButton.FlatAppearance.BorderSize = 0;
            TeamInfoButton.FlatAppearance.MouseDownBackColor = Color.White;
            TeamInfoButton.FlatAppearance.MouseOverBackColor = Color.White;
            TeamInfoButton.FlatStyle = FlatStyle.Flat;
            TeamInfoButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            TeamInfoButton.ForeColor = Color.White;
            TeamInfoButton.Image = Properties.Resources.团队40;
            TeamInfoButton.ImageAlign = ContentAlignment.MiddleLeft;
            TeamInfoButton.Location = new Point(-14, 122);
            TeamInfoButton.Name = "TeamInfoButton";
            TeamInfoButton.Padding = new Padding(25, 0, 0, 0);
            TeamInfoButton.Size = new Size(223, 34);
            TeamInfoButton.TabIndex = 3;
            TeamInfoButton.Text = "团队信息";
            TeamInfoButton.UseVisualStyleBackColor = false;
            // 
            // SearchTeamButton
            // 
            SearchTeamButton.BackColor = SystemColors.AppWorkspace;
            SearchTeamButton.CausesValidation = false;
            SearchTeamButton.Cursor = Cursors.Hand;
            SearchTeamButton.FlatAppearance.BorderColor = Color.White;
            SearchTeamButton.FlatAppearance.BorderSize = 0;
            SearchTeamButton.FlatAppearance.MouseDownBackColor = Color.White;
            SearchTeamButton.FlatAppearance.MouseOverBackColor = Color.White;
            SearchTeamButton.FlatStyle = FlatStyle.Flat;
            SearchTeamButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            SearchTeamButton.ForeColor = Color.White;
            SearchTeamButton.Image = Properties.Resources.团队40;
            SearchTeamButton.ImageAlign = ContentAlignment.MiddleLeft;
            SearchTeamButton.Location = new Point(-13, 89);
            SearchTeamButton.Name = "SearchTeamButton";
            SearchTeamButton.Padding = new Padding(25, 0, 0, 0);
            SearchTeamButton.Size = new Size(223, 34);
            SearchTeamButton.TabIndex = 2;
            SearchTeamButton.Text = "搜索团队";
            SearchTeamButton.UseVisualStyleBackColor = false;
            SearchTeamButton.Click += SearchTeamButton_Click;
            // 
            // CreateTeamButton
            // 
            CreateTeamButton.BackColor = SystemColors.AppWorkspace;
            CreateTeamButton.CausesValidation = false;
            CreateTeamButton.Cursor = Cursors.Hand;
            CreateTeamButton.FlatAppearance.BorderColor = Color.White;
            CreateTeamButton.FlatAppearance.BorderSize = 0;
            CreateTeamButton.FlatAppearance.MouseDownBackColor = Color.White;
            CreateTeamButton.FlatAppearance.MouseOverBackColor = Color.White;
            CreateTeamButton.FlatStyle = FlatStyle.Flat;
            CreateTeamButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            CreateTeamButton.ForeColor = Color.White;
            CreateTeamButton.Image = Properties.Resources.团队40;
            CreateTeamButton.ImageAlign = ContentAlignment.MiddleLeft;
            CreateTeamButton.Location = new Point(-13, 55);
            CreateTeamButton.Name = "CreateTeamButton";
            CreateTeamButton.Padding = new Padding(25, 0, 0, 0);
            CreateTeamButton.Size = new Size(223, 34);
            CreateTeamButton.TabIndex = 1;
            CreateTeamButton.Text = "创建团队";
            CreateTeamButton.UseVisualStyleBackColor = false;
            CreateTeamButton.Click += CreateTeamButton_Click;
            // 
            // TeamButton
            // 
            TeamButton.BackColor = Color.FromArgb(30, 40, 35);
            TeamButton.CausesValidation = false;
            TeamButton.Cursor = Cursors.Hand;
            TeamButton.FlatAppearance.BorderColor = Color.White;
            TeamButton.FlatAppearance.BorderSize = 0;
            TeamButton.FlatAppearance.MouseDownBackColor = Color.White;
            TeamButton.FlatAppearance.MouseOverBackColor = Color.White;
            TeamButton.FlatStyle = FlatStyle.Popup;
            TeamButton.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            TeamButton.ForeColor = Color.White;
            TeamButton.ImageAlign = ContentAlignment.MiddleLeft;
            TeamButton.Location = new Point(-22, -14);
            TeamButton.Name = "TeamButton";
            TeamButton.Padding = new Padding(25, 0, 0, 0);
            TeamButton.Size = new Size(223, 78);
            TeamButton.TabIndex = 0;
            TeamButton.Text = "团队";
            TeamButton.UseVisualStyleBackColor = false;
            TeamButton.Click += button1_Click_1;
            // 
            // HeaderPanel
            // 
            HeaderPanel.Controls.Add(NextButton);
            HeaderPanel.Controls.Add(ForwardButton);
            HeaderPanel.Dock = DockStyle.Top;
            HeaderPanel.Location = new Point(200, 0);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(900, 40);
            HeaderPanel.TabIndex = 9;
            HeaderPanel.Paint += HeaderPanel_Paint;
            // 
            // NextButton
            // 
            NextButton.Image = Properties.Resources.向右;
            NextButton.Location = new Point(46, 2);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(36, 36);
            NextButton.TabIndex = 3;
            NextButton.UseVisualStyleBackColor = true;
            // 
            // ForwardButton
            // 
            ForwardButton.Image = Properties.Resources.向左;
            ForwardButton.Location = new Point(5, 2);
            ForwardButton.Name = "ForwardButton";
            ForwardButton.Size = new Size(36, 36);
            ForwardButton.TabIndex = 2;
            ForwardButton.UseVisualStyleBackColor = true;
            ForwardButton.Click += ForwardButton_Click;
            // 
            // MainPanel
            // 
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.ForeColor = Color.Black;
            MainPanel.Location = new Point(200, 40);
            MainPanel.Margin = new Padding(0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(900, 512);
            MainPanel.TabIndex = 10;
            // 
            // TeamTimer
            // 
            TeamTimer.Interval = 10;
            TeamTimer.Tick += TeamTimer_Tick;
            // 
            // TaskTimer
            // 
            TaskTimer.Interval = 10;
            TaskTimer.Tick += TaskTimer_Tick;
            // 
            // PersonTimer
            // 
            PersonTimer.Interval = 10;
            PersonTimer.Tick += PersonTimer_Tick;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 552);
            Controls.Add(MainPanel);
            Controls.Add(HeaderPanel);
            Controls.Add(SIderPanel);
            IsMdiContainer = true;
            Name = "Home";
            Text = "Home";
            FormClosed += Home_FormClosed;
            Load += Home_Load;
            SIderPanel.ResumeLayout(false);
            SIderPanel.PerformLayout();
            PersonContainer.ResumeLayout(false);
            TaskContainer.ResumeLayout(false);
            TeamContainer.ResumeLayout(false);
            HeaderPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel TaskContainer;
        private Panel SIderPanel;
        private Panel HeaderPanel;
        private Panel MainPanel;
        private Button ForwardButton;
        private Button NextButton;
        private Button TeamButton;
        private Panel TeamContainer;
        private Button PersonButton;
        private Button TaskButton;
        private Panel PersonContainer;
        private Button CreateTeamButton;
        private Button UserTeamButton;
        private Button TeamInviteMemberButton;
        private Button TeamInfoButton;
        private Button SearchTeamButton;
        private Button CreateTaskButton;
        private Button UserTaskButton;
        private Button TeamTaskButton;
        private Button UserInfoUpdateButton;
        private System.Windows.Forms.Timer TeamTimer;
        private System.Windows.Forms.Timer TaskTimer;
        private System.Windows.Forms.Timer PersonTimer;
        private Label label1;
        private Button button1;
        private Button button2;
    }
}