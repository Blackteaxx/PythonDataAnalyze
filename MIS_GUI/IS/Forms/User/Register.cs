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

namespace IS.Forms.User
{
    public partial class Register : Form
    {
        private readonly IS.Services.User user = new IS.Services.User();

        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 获取输入框的值
            string loginName = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string passwordAgain = textBox3.Text.Trim();
            string name = textBox4.Text.Trim();

            if (password != passwordAgain)
            {
                MessageBox.Show("两次输入的密码不一致");
                return;
            }

            var r = user.Register(loginName, password, name);
            // 进行注册
            if (r.Status)
            {
                MessageBox.Show("注册成功");
            }
            else
            {
                MessageBox.Show(r.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 清空输入框
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
