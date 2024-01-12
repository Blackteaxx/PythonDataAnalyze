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
    public partial class UserPasswordChange : Form
    {
        private readonly Services.UserChange userChange = new();
        private bool exit = true;
        public UserPasswordChange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginName = textBox1.Text.Trim();
            var password = textBox2.Text.Trim();
            var newpassword = textBox3.Text.Trim();
            if (password == newpassword)
            {
                MessageBox.Show("新登录名和旧登录名不能相同");
                return;
            }
            var r = userChange.ChangeLoginName(loginName, password, newpassword);
            if (r.Status)
            {
                MessageBox.Show("修改密码成功");
                exit = false;
                var m = this.Parent as Main;
                m.FormShow(new Login(loginName));

                this.Hide();
                this.Close();
            }
            else
                MessageBox.Show(r.Message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exit = false;
            var m = this.Parent as Main;
            m.FormShow(new Login());
            Close();
        }

        private void UserPasswordChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit) Application.Exit();
        }
    }
}
