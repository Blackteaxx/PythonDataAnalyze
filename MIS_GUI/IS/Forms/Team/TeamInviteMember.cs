using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Forms.Team
{
    public partial class TeamInviteMember : Form
    {
        private readonly int Tid;
        private readonly Dictionary<int, string> StatusLabel = new Dictionary<int, string>
        {
            {0 , "未答复" },
            {1 , "已同意" },
            {2 , "已拒绝" },
        };

        public TeamInviteMember(int tid)
        {
            InitializeComponent();
            Tid = tid;
        }

        public void LoadData()
        {
            var data = Main.team.GetInvites(Tid);
            if (data.Count == 0)
            {
                return;
            }
            dataGridView1.Rows.Clear();



            // 添加行数据
            foreach (var item in data)
            {
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.Name;
                dataGridView1.Rows[index].Cells[1].Value = StatusLabel[item.Status];
            }
        }

        private void TeamInviteMember_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResultLabel.Text = Main.team.InviteMember(Tid, textBox1.Text.Trim(), textBox2.Text.Trim());
            LoadData();
        }
    }
}
