using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IS.Forms;

namespace IS.Forms.Task
{
    public partial class TaskInfo : Form
    {
        private readonly int taskid = 1;
        private readonly Services.Task task = new Services.Task();
        private readonly Services.Team team = new Services.Team();

        public TaskInfo(int taskid)
        {
            InitializeComponent();
            this.taskid = taskid;
        }

        private void TaskInfo_Load(object sender, EventArgs e)
        {
            updateForm();
        }

        private void updateForm()
        {
            // 根据taskid获取task信息
            var data = task.GetTask(taskid);
            this.textBox1.Text = data[0];
            this.textBox2.Text = data[1];
            this.label5.Text = data[2];

            // 绘制添加成员框

            // 清空listbox1和listbox2
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();

            // 根据tid获取所有成员信息
            int teamId = task.GetTeamId(taskid);
            // 获取team的成员信息
            var members = team.GetTeamMembers(teamId);
            // 从members二维列表获取members名字的一维列表
            var membersName = members.Select(x => x[1]).ToList();
            //获取已加入task的成员信息
            var membersInTask = task.GetTaskMembers(taskid);


            if (membersInTask is not null)
            {
                // 从members中删除已加入task的成员信息
                foreach (var item in membersInTask)
                {
                    membersName.Remove(item);
                }
                // 将加入task的成员信息加入listbox2中
                foreach (var item in membersInTask)
                {
                    this.listBox2.Items.Add(item);
                }
            }
            // 将未加入task的成员信息加入listbox1中
            foreach (var item in membersName)
            {
                this.listBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 将listbox1中的成员加入listbox2中 
            if (this.listBox1.SelectedItem is null) return;
            this.listBox2.Items.Add(this.listBox1.SelectedItem);
            this.listBox1.Items.Remove(this.listBox1.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 将listbox2中的成员加入listbox1中
            if (this.listBox2.SelectedItem is null) return;
            this.listBox1.Items.Add(this.listBox2.SelectedItem);
            this.listBox2.Items.Remove(this.listBox2.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 根据text123更新task信息
            if (
                task.UpdateTask(taskid,
                this.textBox1.Text.Trim(),
                this.textBox2.Text.Trim()) == "ok")
            {
                // 同时根据listbox2更新task成员信息
                var members = new List<string>();
                foreach (var item in this.listBox2.Items)
                {
                    members.Add(item.ToString());
                }
                // 根据tid获取所有成员信息
                int teamId = task.GetTeamId(taskid);
                // 获取team的成员信息
                var allMembers = team.GetTeamMembers(teamId);

                // 从allMembers中获取members的uid
                var membersUid = new List<int>();
                foreach (var item in members)
                {
                    foreach (var item1 in allMembers)
                    {
                        if (item == item1[1])
                        {
                            membersUid.Add(Convert.ToInt32(item1[0]));
                        }
                    }
                }
                // 将membersUid加入task
                if (task.UpdateTaskMembers(taskid, membersUid) == "ok")
                {
                    MessageBox.Show("更新成功");

                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
            else
            {
                MessageBox.Show("更新失败");
            }
            updateForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
