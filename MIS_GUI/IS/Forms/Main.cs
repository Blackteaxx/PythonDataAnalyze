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
    public partial class Main : Form
    {
        // 全局变量区域
        public static int uid = 0;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // 登录窗体
            Login login = new Login();
            login.Show();
            // 这个窗体是主窗体，不显示
            this.BeginInvoke(new Action(() =>
            {
                this.Hide();
                this.Opacity = 1;
            }));
        }
    }
}
