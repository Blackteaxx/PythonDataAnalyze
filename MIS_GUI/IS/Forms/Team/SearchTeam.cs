using IS.Services.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Forms.Team
{
    public partial class SearchTeam : Form
    {
        private Services.Team t = new Services.Team();

        public SearchTeam()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = t.SearchTeam(this.textBox1.Text);

            dataGridView1.Rows.Clear();

            foreach (var item in result)
            {
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.Name;
                dataGridView1.Rows[index].Cells[1].Value = item.Description;
                var btn = new DataGridViewButtonCell();
                btn.Value = "加入";
                dataGridView1.Rows[index].Cells[2] = btn;
                dataGridView1.Rows[index].Cells[3].Value = item.Tid; // 隐藏的tid列
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // 判断是否点击到了表格
                                                             //点击button按钮事件
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column3")
            {
                // 获取对应的uid
                var tid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                MessageBox.Show(t.JoinTeam(Main.uid,tid));
            }
        }
    }
}
