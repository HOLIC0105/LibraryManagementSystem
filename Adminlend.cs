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
    public partial class Adminlend : Form
    {
        public Adminlend()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Adminlend_Load(object sender, EventArgs e)
        {
            Table();//打开界面自动显示信息表里的信息
            string Uid = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中记录的用户名
            string Bid = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取选中记录的书号
            label2.Text = "学号：" + Uid + " 书号：" + Bid;
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空表格里的旧数据
            SQL dao = new SQL();
            string sql = "select * from lendbook";//查询数据库图书信息表里的全部信息
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(),dc[1].ToString(), dc[2].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString());
                //将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
            dc.Close();//断开连接
            dao.SQLClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string no = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的序号
                string Bid = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取选中图书的书号
                DialogResult dr = MessageBox.Show("是否确认删除？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from lendbook where no = '{no}';update book set number = number +1 where id = '{Bid}'";
                    SQL dao = new SQL();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功，该图书已归还");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
            }
            catch
            {
                MessageBox.Show("请选中想要删除的图书");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string Uid = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中记录的用户名
            string Bid = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取选中记录的书名
            label2.Text = "学号：" + Uid+" 书号："+Bid;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
