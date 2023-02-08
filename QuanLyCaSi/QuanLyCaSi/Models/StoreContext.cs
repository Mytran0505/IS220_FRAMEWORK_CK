using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using QuanLyCaSi.Models;
namespace QuanLyCaSi.Models
{
    public class StoreContext
    {
        public string ConnectionString { get; set; }//biết thành viên 

        public StoreContext(string connectionString) //phuong thuc khoi tao
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection() //lấy connection 
        {
            return new MySqlConnection(ConnectionString);
        }
        public StoreContext()
        {
        }

        public List<CaSi> GetCaSis()
        {
            List<CaSi> list = new List<CaSi>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from casi";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new CaSi()
                        {
                            MaCaSi = reader.GetString(0),
                            TenCaSi = reader.GetString(1),
                            Ngaysinh = reader.GetDateTime(2),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public int  XoaCaSi(string id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Delete from CaSi where MaCaSi = @Id";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("Id", id);
                return (cmd.ExecuteNonQuery());
            }
        }
        public CaSi ViewCaSi(string id)
        {
            CaSi cs = new CaSi();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = " select *from CaSi where MaCaSi = @Id";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    cs.MaCaSi = reader.GetString(0);    
                    cs.TenCaSi  = reader.GetString(1);
                    cs.Ngaysinh = reader.GetDateTime(2);
                }
            }
            return cs;
        }

        public int UpdateCaSi (CaSi cs)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Update CaSi set TenCaSi = @tenCaSi, NgaySinh = @ngaySinh" +
                    " where MaCaSi = @maCaSi";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("tenCaSi", cs.TenCaSi);
                cmd.Parameters.AddWithValue("ngaySinh", cs.Ngaysinh);
                cmd.Parameters.AddWithValue("maCaSi", cs.MaCaSi);
                return (cmd.ExecuteNonQuery());
            }
        }

        public int InsertCaSi (CaSi cs)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Insert into casi (MaCaSi, TenCaSi, NgaySinh)" +
                    "value (@maCS, @tenCS, @ngaySinh)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("maCS", cs.MaCaSi);
                cmd.Parameters.AddWithValue("tenCS", cs.TenCaSi);
                cmd.Parameters.AddWithValue("ngaySinh", cs.Ngaysinh);
                return (cmd.ExecuteNonQuery());
            }
        }
    }
}
