using IS.Forms.Team;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Forms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            // 初始化界面
            LoadMainPanel(new UserTeam(Main.uid));
        }

        private void LoadMainPanel(Form form)
        {
            form.TopLevel = false;
            // form.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(form);
            form.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 用于绘制header栏的下边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, HeaderPanel.ClientRectangle,
              Color.White, 0, ButtonBorderStyle.Solid, //左边
　　　　　    Color.White, 0, ButtonBorderStyle.Solid, //上边
　　　　　    Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
　　　　　    Color.DimGray, 1, ButtonBorderStyle.Solid //底边
            );
        }

        /// <summary>
        /// 创建header按钮，用于分级
        /// </summary>
        /// <param name="text"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        private Button CreateHeaderButton(string text, Form form)
        {
            Button button = new Button();
            button.Text = text;
            button.Size = new Size(55, 30);
            // button.Click = LoadMainPanel(form);
            return button;
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
