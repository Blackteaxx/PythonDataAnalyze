using IS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace IS.Forms.Team
{
    public partial class UserTeam : Form
    {
        private int Uid = 1;
        private Services.Team team = new Services.Team();

        public UserTeam(int uid)
        {
            InitializeComponent();
            Uid = uid;
        }

        public UserTeam()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UserTeam_Load(object sender, EventArgs e)
        {
            var data = team.GetTeams(Uid);
            if (data is null) return;

            // 先添加列
            var columns = new List<string>() { "名称", "介绍", "人数", "操作","操作1" };
            foreach (var column in columns)
            {
                this.dataGridView1.Columns.Add(column, column);
            }

            // 添加行数据
            foreach (var item in data)
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = item[1];
                this.dataGridView1.Rows[index].Cells[1].Value = item[2];
                this.dataGridView1.Rows[index].Cells[2].Value = item[3];
                var btn = new DataGridViewButtonCell();
                btn.Value = "查看";
                var btn1 = new DataGridViewButtonCell();
                btn1.Value = "进入";
                this.dataGridView1.Rows[index].Cells[3] = btn;
                this.dataGridView1.Rows[index].Cells[4] = btn1;           
             }

            // 设置列宽
            var width = this.dataGridView1.Width;
            this.dataGridView1.Columns[0].Width = 180;
            this.dataGridView1.Columns[1].Width = width - 380;
            this.dataGridView1.Columns[2].Width = 50;
            this.dataGridView1.Columns[2].Width = 100;

            // 设置为只读
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.RowHeadersVisible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击button按钮事件
            if (dataGridView1.Columns[e.ColumnIndex].Name == "" && e.RowIndex >= 0)
            {
                var flag = true;
                if (flag)
                {
                    MessageBox.Show("更新成功！");
                }
                else
                {
                    MessageBox.Show("更新失败！");
                }
            } 
        }
    }


}
