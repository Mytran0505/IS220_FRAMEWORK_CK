using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using PlayList_HK1_2122.Models;
namespace PlayList_HK1_2122.Models
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

        public void ThemBaiHat(BaiHat bh)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into BaiHat(MaBaiHat, TenBaiHat, TheLoai) " +
                    "values (@MaBH, @TenBH, @TL)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MaBH", bh.MaBaiHat);
                cmd.Parameters.AddWithValue("TenBH", bh.TenBaiHat);
                cmd.Parameters.AddWithValue("TL", bh.TheLoai);
                cmd.ExecuteNonQuery();
            }
        }

        public List<CaSi> LietKeNgaySinhCủaCacCaSi()
        {
            List <CaSi> list = new List<CaSi>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select NamSinh from CaSi";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new CaSi()
                        {
                            NamSinh = reader.GetDateTime(0),

                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<CaSi> LietKeCaSiCoNgaySinhDuocChon(DateTime NamSinh)
        {
            List<CaSi> list = new List<CaSi>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select TenCaSi from CaSi where " +
                    "NamSinh = @NS ";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("NS", NamSinh.ToString("yyyy-dd-MM"));
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new CaSi()
                        {
                            TenCaSi = reader.GetString(0),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public List<NguoiNghe> LietKeTenNguoiNghe()
        {
            List<NguoiNghe> list = new List<NguoiNghe>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select MaNN, TenNN from nguoinghe";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NguoiNghe()
                        {
                            MaNN = reader.GetString(0),
                            TenNN = reader.GetString(1),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public List<PlayList> LietKePLCuaNguoiNghe(NguoiNghe nn)
        {
            List<PlayList> lists= new List<PlayList>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select MaPlayList, TenPlayList from PlayList " +
                    "where MaNN = @maNN ";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("maNN", nn.MaNN);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lists.Add(new PlayList()
                        {
                            MaPlayList = reader.GetString(0),
                            TenPlayList = reader.GetString(1),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return lists;
        }

        public void XoaPLayPlist(string MaPlayList)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from PlayList_BaiHat " +
                    "where MaPlayList = @maPL; " +
                    "delete from PlayList " +
                    "where MaPlayList = @maPL";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("maPL", MaPlayList);
                cmd.ExecuteNonQuery();
            }
        }

        public List<object> ViewThongTinPlayList(string MaPlayList) { 
            List<object> lists = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select TenBaiHat, TenCaSi " +
                    "from PlayList PL, PlayList_BaiHat PLBH, CaSi_BaiHat CSBH, " +
                    "CaSi CS, BaiHat BH " +
                    "where PL.MaPlayList = PLBH.MaPlayList and " +
                    "PLBH.MaBaiHat = BH.MaBaiHat and PLBH.MaBaiHat = CSBH.MaBaiHat " +
                    "and CSBH.MaCaSi = CS.MaCaSi and PL.MaPlayList = @MaPL";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MaPL", MaPlayList);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
                            TenBaiHat = reader.GetString(0),
                            TenCaSi = reader.GetString(1),
                        };
                        lists.Add(ob);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return lists;
        }
    }
}
