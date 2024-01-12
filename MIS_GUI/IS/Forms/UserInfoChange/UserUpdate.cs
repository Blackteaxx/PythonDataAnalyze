using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInfo
{
    public partial class UserUpdate : Form
    {
        private readonly int Uid;
        private readonly UserChange userchange = new();
        public UserUpdate(int uid)
        {
            InitializeComponent();
            Uid = uid;
        }
        public UserUpdate()
        {
            InitializeComponent();
        }

        private void UserUpdate_Load(object sender, EventArgs e)
        {
            var user = userchange.GetUserInfo(Uid);
            textBox1.Text = user.loginName;
            textBox2.Text = user.Name;
            textBox3.Text = user.password;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (userchange.UpdateUserInfo(Uid, textBox1.Text, textBox2.Text, textBox3.Text) == "ok")
            {
                MessageBox.Show("更新成功");
            }
            else
            {
                MessageBox.Show("更新失败");
            }
        }

        private void ReCheckButton_Click(object sender, EventArgs e)
        {
            var user = userchange.GetUserInfo(Uid);
            textBox1.Text = user.loginName;
            textBox2.Text = user.Name;
            textBox3.Text = user.password;
        }
    }
}
