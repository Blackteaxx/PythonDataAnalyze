using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Forms.User
{
    public partial class Notice : Form
    {
        public Notice()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            dataGridView1.Rows.Clear();

            var data = Main.user.GetUserNotices(Main.uid);
            if (data.Count == 0)
            {
                return;
            }
            // 添加行数据
            foreach (var item in data)
            {
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.Content;
                var btn = new DataGridViewButtonCell();
                btn.Value = "答复";
                dataGridView1.Rows[index].Cells[1] = btn;
                dataGridView1.Rows[index].Cells[2].Value = item.Nid;// 隐藏的Nid列
                dataGridView1.Rows[index].Cells[3].Value = item.Type; // 隐藏的Type列
                dataGridView1.Rows[index].Cells[4].Value = item.Tid;
            }

            // 取消选择的第一行
            dataGridView1.Rows[0].Selected = false;
        }

        private void Notice_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // 判断是否点击到了表格
                                                             //点击button按钮事件
            if (dataGridView1.Columns[e.ColumnIndex].Name == "答复")
            {
                var type = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                if (type == 0)
                {
                    Main.user.HandleNotice(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value),1);
                    var t = new DataGridViewTextBoxCell();
                    t.Value = "已处理";
                    dataGridView1.Rows[e.RowIndex].Cells[1] = t;
                    t.ReadOnly = true;
                    dataGridView1.Rows[e.RowIndex].Selected = false;
                }
                else
                {
                    var r = MessageBox.Show("是否确认邀请", "确认", MessageBoxButtons.YesNoCancel);
                    if (r == DialogResult.Yes)
                    {
                        Main.team.JoinTeam(Main.uid, Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value));
                        Main.user.HandleNotice(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value),2);
                        var t = new DataGridViewTextBoxCell();
                        t.Value = "已接受";
                        dataGridView1.Rows[e.RowIndex].Cells[1] = t;
                        t.ReadOnly = true;
                        dataGridView1.Rows[e.RowIndex].Selected = false;
                    }
                    else if (r == DialogResult.No)
                    {
                        Main.user.HandleNotice(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value),3);
                        var t = new DataGridViewTextBoxCell();
                        t.Value = "已拒绝";
                        dataGridView1.Rows[e.RowIndex].Cells[1] = t;
                        t.ReadOnly = true;
                        dataGridView1.Rows[e.RowIndex].Selected = false;
                    }
                }
                LoadData();
            }
        }
    }
}
