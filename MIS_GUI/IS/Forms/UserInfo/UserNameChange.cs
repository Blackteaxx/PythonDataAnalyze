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
    public partial class UserNameChange : Form
    {
        private readonly Services.UserChange userChange = new();
        private bool exit = true;
        public UserNameChange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 获取输入框的值
            var loginName = textBox1.Text.Trim();
            var password = textBox2.Text.Trim();
            var oldname = textBox3.Text.Trim();
            var newname = textBox4.Text.Trim();
            if (newname == oldname)
            {
                MessageBox.Show("新用户名和旧用户名不能相同");
                return;
            }
            var r = userChange.ChangeName(loginName, password, oldname, newname);
            if (r.Status)
            {
                MessageBox.Show("修改用户名成功");
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
        private void UserNameChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit) Application.Exit();
        }
    }
}
