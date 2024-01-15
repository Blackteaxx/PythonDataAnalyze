using IS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Forms.Task
{
    public partial class UserTask : Form
    {
        private readonly Services.Task task = new Services.Task();
        private readonly int uid = 1;

        public UserTask(int uid)
        {
            InitializeComponent();
            this.uid = uid;
        }

        private void LoadData()
        {
            var data = task.GetTasks(uid);
            if (data is null)
            {
                return;
            }

            dataGridView1.Rows.Clear();

            // 添加行数据
            foreach (var item in data)
            {
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item[1];
                dataGridView1.Rows[index].Cells[1].Value = item[2];
                dataGridView1.Rows[index].Cells[2].Value = item[3];
                dataGridView1.Rows[index].Cells[3].Value = Convert.ToInt32(item[4])==1?"已完成":"未完成";
                dataGridView1.Rows[index].Cells[6].Value = item[0]; // 隐藏的tid列

                var btn = new DataGridViewButtonCell();
                btn.Value = "查看";
                var btn1 = new DataGridViewButtonCell();
                btn1.Value = "审核";
                dataGridView1.Rows[index].Cells[4] = btn;
                dataGridView1.Rows[index].Cells[5] = btn1;

            }
        }

        private void LoadData(string filter)
        {
            var data = task.GetTasks(uid);
            if (data is null)
            {
                return;
            }

            dataGridView1.Rows.Clear();

            // 添加行数据
            foreach (var item in data)
            {
                if (this.comboBox1.SelectedIndex == 0)
                {
                    if (!item[1].Contains(filter)) continue;
                }
                else if (this.comboBox1.SelectedIndex == 1)
                {
                    if (!item[2].Contains(filter)) continue;
                }
                // 根据radioButton1~3的选中情况筛选
                if (this.radioButton1.Checked == true)
                {
                    
                }
                else if (this.radioButton2.Checked == true)
                {
                    if (Convert.ToInt32(item[4]) != 1) continue;
                }
                else if (this.radioButton3.Checked == true)
                {
                    if (Convert.ToInt32(item[4]) != 0) continue;
                }


                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item[1];
                dataGridView1.Rows[index].Cells[1].Value = item[2];
                dataGridView1.Rows[index].Cells[2].Value = item[3];
                dataGridView1.Rows[index].Cells[3].Value = item[4];
                dataGridView1.Rows[index].Cells[6].Value = item[0]; // 隐藏的tid列

                var btn = new DataGridViewButtonCell();
                btn.Value = "查看";
                var btn1 = new DataGridViewButtonCell();
                btn1.Value = "审核";
                dataGridView1.Rows[index].Cells[4] = btn;
                dataGridView1.Rows[index].Cells[5] = btn1;

            }
        }

        private void TaskInfo_Load(object sender, EventArgs e)
        {
            // 设置初始筛选
            this.comboBox1.SelectedIndex = 0;
            this.radioButton1.Checked = true;

            // 先添加列
            var columns = new List<string> { "TaskName", "TeamName", "人数", "状态", "查看", "审核", "tid" };
            foreach (var column in columns) dataGridView1.Columns.Add(column, column);

            dataGridView1.ScrollBars = ScrollBars.Vertical;

            // 设置列宽
            var width = dataGridView1.Width;
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Width = 0;

            // 设置为只读
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;

            // 加载数据
            LoadData();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var filter = this.textBox1.Text.Trim();
            this.LoadData(filter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = this.Parent.Parent as Home;
            CreateTask createTask = new CreateTask(uid);
            f.AddHeaderLabel("创建任务", createTask);
            f.SetMainPanel(createTask);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // 判断是否点击到了表格
                                                             //点击button按钮事件

            int tid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            if (dataGridView1.Columns[e.ColumnIndex].Name == "查看")
            {
                var f = this.Parent.Parent as Home; // parent是panel，因此这里要Parent.Parent
                // 传入tid
                var t = new TaskInfo(tid);
                // 根据taskid获取taskname
                var taskName = task.GetTask(tid)[0];
                f.AddHeaderLabel(taskName, t);
                f.SetMainPanel(t);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "审核")
            {
                // 
                MessageBox.Show("2");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 根据radioButton1~3的选中情况筛选
            if (this.radioButton1.Checked == true)
            {

            }
        }
    }
}
