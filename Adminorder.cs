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
    public partial class Adminorder : Form
    {
        public Adminorder()
        {
            InitializeComponent();
            Table();
        }
        private void Adminorder_Load(object sender, EventArgs e)
        {
            string Uid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中预约记录的学生学号
            string Bname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的书名
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空表格里的旧数据
            SQL dao = new SQL();
            string sql = $"select * from orderbook ";//查询数据库图书信息表里的全部信息
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(),dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
                //将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
            dc.Close();//断开连接
            dao.SQLClose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string Uid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中预约记录的学生学号
            string Bname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的书名
            label2.Text = "用户名："+Uid+" 书名："+Bname;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string Uid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中预约记录的学生的学号
                string Bname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中预约记录的图书的书名
                string Bauthor = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                DialogResult dr = MessageBox.Show("是否确认删除？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from orderbook where Uid = '{Uid}'and Bname = '{Bname}'and Bauthor = '{Bauthor}'";
                    SQL dao = new SQL();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功");
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
    }
}
