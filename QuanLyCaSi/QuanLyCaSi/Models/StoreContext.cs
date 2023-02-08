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

        public int InsertAlbum (Album al)
        {
            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into Album (MaAlbum, TenAlbum, MaCaSi) " +
                    "value (@maAB, @tenAB, @maCS)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("maAB", al.MaAlbum);
                cmd.Parameters.AddWithValue("tenAB", al.TenAlbum);
                cmd.Parameters.AddWithValue("maCS", al.MaCaSi);
                return(cmd.ExecuteNonQuery());
            }
        }

        public List<BaiHat> getBaiHats()
        {
            List<BaiHat> list = new List<BaiHat>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select *from BaiHat";
                MySqlCommand cmd = new MySqlCommand(str,conn);
                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new BaiHat()
                        {
                            MaBaiHat = reader.GetString(0),
                            TenBaiHat= reader.GetString(1),
                            TheLoai = reader.GetString(2),
                            MaAlbum = reader.GetString(3),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public int DeleteBaiHat (string id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from BaiHat where MaBaiHat = @maBaiHat";
                MySqlCommand cmd = new MySqlCommand(str,conn);  
                cmd.Parameters.AddWithValue("maBaiHat", id);
                return (cmd.ExecuteNonQuery());
            }
        }

        public int TimBaiHatTheoTen (string st)
        {
            int i = 0;
            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from BaiHat where TenBaiHat =@tenBH";
                MySqlCommand cmd = new MySqlCommand(str,conn);
                cmd.Parameters.AddWithValue("tenBH", st);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) { i++; }
                    reader.Close();
                }
                conn.Close();
            }
            return i;
        }

        public List<BaiHat> LietKeNBaiHat(int num)
        {
            List<BaiHat> list = new List<BaiHat>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from BaiHat limit @number";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("number", num);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new BaiHat()
                        {
                            MaBaiHat = reader.GetString(0),
                            TenBaiHat = reader.GetString(1),
                            TheLoai = reader.GetString(2),
                            MaAlbum = reader.GetString(3),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public List<Album> AlbumCoNhieuBaiHatNhat()
        {
            List<Album> list = new List<Album>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select AB.MaAlbum, AB.TenAlbum, count(MaBaiHat) " +
                    "from Album AB, BaiHat BH " +
                    "where AB.MaAlbum = BH.MaAlbum " +
                    "GROUP by AB.MaAlbum, AB.TenAlbum " +
                    "having count(MaBaiHat) = " +
                    "(select count(MaBaiHat) " +
                    "from BaiHat " +
                    "GROUP by MaAlBum " +
                    "limit 1);";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Album()
                        {
                            MaAlbum = reader.GetString(0),
                            TenAlbum = reader.GetString(1),
                            MaCaSi = reader.GetString(2),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<Album> LietKeAlbum()
        {
            List<Album> list = new List<Album>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Select *from Album";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Album()
                        {
                            MaAlbum = reader.GetString(0),
                            TenAlbum = reader.GetString(1),
                            MaCaSi = reader.GetString(2),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<BaiHat> LietKeCacBaiHatCoTrongAlbum(string id)
        {
            List<BaiHat> list = new List<BaiHat>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Select *from BaiHat where MaAlbum = @maAB";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("maAB", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new BaiHat()
                        {
                            MaBaiHat = reader.GetString(0),
                            TenBaiHat = reader.GetString(1),
                            TheLoai = reader.GetString(2),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public List<object> SoLuongBaiHatTrongMoiAlbum()
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select AB.MaAlbum, AB.TenAlbum, count(BH.MaBaiHat) " +
                    "from Album AB left join BaiHat BH " +
                    "ON AB.MaAlbum = BH.MaAlbum " +
                    "Group by AB.MaAlbum ";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
                            MaAlbum = reader.GetString(0),
                            TenAlbum = reader.GetString(1),
                            SoluongBaiHat = Convert.ToInt32(reader.GetString(2)),
                        };
                        list.Add(ob);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
    }
}
