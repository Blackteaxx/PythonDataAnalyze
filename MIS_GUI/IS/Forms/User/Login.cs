using IS.Forms;
using IS.Forms.Team;
using IS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS
{
    public partial class Login : Form
    {
        private readonly User user = new User();
        private bool exit = false;
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // 先从输入框获取登录名和密码
            string name = textBox1.Text.Trim();
            string pwd = textBox2.Text.Trim();
            var r = user.Login(name, pwd);
            if (r.Status)
            {
                Main.uid = Convert.ToInt32(r.Data);
                exit = true;
                new UserTeam().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败");
            }
        }

        /// <summary>
        /// 清空事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            // 清空输入框
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var register = new Forms.User.Register();
            register.Show();
            this.Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exit) Application.Exit();
        }
    }
}
