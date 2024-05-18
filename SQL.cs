using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMS
{
    class SQL
    {
        SqlConnection sc;
        public SqlConnection connect()
        {
            string str = @"Data Source=康;Initial Catalog=BookDB;Integrated Security=True";//数据库连接字符串
            sc = new SqlConnection(str);//创建数据库连接对象
            sc.Open();//打开数据库
            return sc;//返回数据库连接对象
        }
        public SqlCommand command(string sql)//更新操作
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }
        public int Execute(string sql)//更新操作
        {
            return command(sql).ExecuteNonQuery();
        }
        public SqlDataReader read(string sql)//读取操作
        {
            return command(sql).ExecuteReader();
        }
        public void SQLClose()
        {
            sc.Close();//关闭数据库连接
        }
    }
}
