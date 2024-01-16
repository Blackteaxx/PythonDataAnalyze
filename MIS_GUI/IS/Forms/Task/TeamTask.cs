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
using static System.Net.Mime.MediaTypeNames;

namespace IS.Forms.Task
{
    public partial class TeamTask : Form
    {
        private int Tid;

        public TeamTask(int tid)
        {
            InitializeComponent();
            Tid = tid;
        }



        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            var data = Main.team.GetTeamTasks(Tid);
            if (data is null) return;
            if (data.Count == 0) return;
            this.dataGridView1.Rows.Clear();
            foreach (var item in data)
            {
                var index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = item.Name;
                this.dataGridView1.Rows[index].Cells[1].Value = item.Description;
                this.dataGridView1.Rows[index].Cells[2].Value = item.MasterName;
                this.dataGridView1.Rows[index].Cells[3].Value = item.Status == 1 ? "已完成" : "未完成";
                var btn = new DataGridViewButtonCell();
                btn.Value = "查看";
                this.dataGridView1.Rows[index].Cells[4] = btn;
                this.dataGridView1.Rows[index].Cells[5].Value = item.Taskid;
            }
        }

        private void TeamTask_Load(object sender, EventArgs e)
        {
            LoadData();
        }



        private void FlushButton_Click(object sender, EventArgs e)
        {
            // 清空搜索和筛选
            this.SearchTextBox.Text = string.Empty;
            foreach (var item in FilterGroupBox.Controls)
            {
                var cb = item as CheckBox;
                cb.Checked = false;
            }
            LoadData();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var text = this.SearchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("请输入搜索内容");
                return;
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var name = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                if (!name.Contains(text))
                {
                    this.dataGridView1.Rows[i].Visible = false;
                }
                else
                {
                    this.dataGridView1.Rows[i].Visible = true;
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox3.Checked = false;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    var status = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                    if (status == "已完成")
                    {
                        this.dataGridView1.Rows[i].Visible = true;
                    }
                    else
                    {
                        this.dataGridView1.Rows[i].Visible = false;
                    }
                }
            }
            else
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    this.dataGridView1.Rows[i].Visible = true;
                }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox2.Checked = false;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    var status = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                    if (status == "未完成")
                    {
                        this.dataGridView1.Rows[i].Visible = true;
                    }
                    else
                    {
                        this.dataGridView1.Rows[i].Visible = false;
                    }
                }
            }
            else
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    this.dataGridView1.Rows[i].Visible = true;
                }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // 获取我参与的taskid
            var l = Main.team.GetTasksParticipating(Main.uid, Tid);
            if (checkBox1.Checked)
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    var tid = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[5].Value);
                    if (l.Contains(tid))
                    {
                        this.dataGridView1.Rows[i].Visible = true;
                    }
                    else
                    {
                        this.dataGridView1.Rows[i].Visible = false;
                    }
                }
            else
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    this.dataGridView1.Rows[i].Visible = true;
                }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // 判断是否点击到了表格
                                                             //点击button按钮事件
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column4")
            {
                var f = this.Parent.Parent as Home; // parent是panel，因此这里要Parent.Parent
                                                    // 传入tid和用户身份
                var t = new TaskInfo(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value));
                var teamName = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value) ?? "";
                f.AddHeaderLabel(teamName, t);
                f.SetMainPanel(t);
            }
        }
    }
}
