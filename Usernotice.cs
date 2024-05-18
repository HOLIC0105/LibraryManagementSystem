using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMS
{
    public partial class Usernotice : Form
    {
        public Usernotice()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Usernotice_Load(object sender, EventArgs e)
        {
            Table();
            string Nid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中公告的序号
            label2.Text = "序号：" + Nid;

        }
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空表格里的旧数据
            SQL dao = new SQL();
            string sql = "select * from notice";//查询数据库信息表里的全部信息
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
                //将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
            dc.Close();//断开连接
            dao.SQLClose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string Nid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中公告的序号
            label2.Text = "序号：" + Nid;
        }

        private void button2_Click(object sender, EventArgs e)//显示选中公告
        {
            listBox1.Items.Clear();
            string Nid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中公告的序号
            SQL dao = new SQL();
            string sql = $"select * from notice where id ='{Nid}'";//查询数据库公告信息表里的对应序号的公告
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                listBox1.Items.Add(dc[1].ToString());
                //将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
