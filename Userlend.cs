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
    public partial class Userlend : Form
    {
        private readonly string UserID;
        public Userlend(string UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
        }
        public Userlend()
        {
            InitializeComponent();
        }

        private void Booklend_Load(object sender, EventArgs e)
        {
            Table();
            string Bid = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的书号
            string Bname = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取选中图书的书名
            
            label2.Text = "书号：" + Bid + "  书名：" + Bname;
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空表格里的旧数据
            SQL dao = new SQL();
            string sql = $"select * from lendbook where LendUserID ='{UserID}'";//查询数据库信息表里的全部信息
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[2].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString());
                //将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
            dc.Close();//断开连接
            dao.SQLClose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//归还图书按钮
        {
            try
            {
                string no = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的序号
                string Bid = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的书号
                DialogResult dr = MessageBox.Show("是否确认归还该图书？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from lendbook where [no] = '{no}';update book set number = number +1 where id = '{Bid}'";
                    SQL dao = new SQL();
                    if (dao.Execute(sql) > 1)
                    {
                        MessageBox.Show("归还成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("归还失败");
                    }
                }
            }
            catch
            {
                MessageBox.Show("请选中想要归还的图书");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string Bid = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的书号
            string Bname = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取选中图书的书名
            label2.Text = "书号：" + Bid + "  书名：" + Bname;
        }
    }
}
