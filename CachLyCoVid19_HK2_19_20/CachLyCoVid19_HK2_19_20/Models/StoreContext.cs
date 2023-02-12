using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using CachLyCoVid19_HK2_19_20.Models;
namespace CachLyCoVid19_HK2_19_20.Models
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
        public void ThemDiemCachLy(DiemCachLy dcl)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                var str = "insert into DiemCachLy (MaDiemCachLy, TenDiemCachLy, DiaChi) " +
                    "values (@MaDCL, @TenDCL, @DC)";
                MySqlCommand cmd = new MySqlCommand(str, connection);
                cmd.Parameters.AddWithValue("MaDCL", dcl.MaDiemCachLy);
                cmd.Parameters.AddWithValue("TenDCL", dcl.TenDiemCachLy);
                cmd.Parameters.AddWithValue("DC", dcl.DiaChi);
                cmd.ExecuteNonQuery();
            }
        }

        public List<object> LietKeCongNhanCoTuNTrieuChung(int num)
        {
            var list = new List<object>();
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                var str = "select TenCongNhan, NamSinh, NuocVe, count(*) as STC " +
                    "from CongNhan CN, CN_TC CNTC " +
                    "where CN.MaCongNhan = CNTC.MaCongNhan " +
                    "group by TenCongNhan, NamSinh, NuocVe " +
                    "having STC >= @num ";
                MySqlCommand cmd = new MySqlCommand(str, connection);
                cmd.Parameters.AddWithValue("num", num);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
                            TenCongNhan = reader.GetString(0),
                            NamSinh = reader.GetInt32(1),
                            NuocVe = reader.GetString(2),
                            SoTrieuChung = reader.GetInt32(3)
                        };
                        list.Add(ob);
                    }
                    reader.Close();
                }
                connection.Close(); 
            }
            return list;
        }

        public List<DiemCachLy> LietKeDiemCachLy()
        {
            var list = new List<DiemCachLy>();
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                var str = "select MaDiemCachLy, TenDiemCachLy " +
                    "from DiemCachLy ";
                MySqlCommand cmd = new MySqlCommand(str, connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DiemCachLy
                        {
                            MaDiemCachLy = reader.GetString(0),
                            TenDiemCachLy = reader.GetString(1),
                        });
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return list;
        }

        public List<CongNhan> LietKeCongNhanTrongDiemCachLy(DiemCachLy dcl)
        {
            var list = new List<CongNhan>();
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                var str = "select MaCongNhan, TenCongNhan " +
                    "from CongNhan " +
                    "where MaDiemCachly = @MaDCL ";
                MySqlCommand cmd = new MySqlCommand(str, connection);
                cmd.Parameters.AddWithValue("MaDCL", dcl.MaDiemCachLy);
                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new CongNhan
                        {
                            MaCongNhan = reader.GetString(0),
                            TenCongNhan = reader.GetString(1)
                        });
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return list;
        }
        public void XoaCongNhan(string MaCongNhan)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                var str = "delete from CongNhan " +
                    "where MaCongNhan = @MaCN ";
                MySqlCommand cmd = new MySqlCommand(str, connection);
                cmd.Parameters.AddWithValue("MaCN", MaCongNhan);
                cmd.ExecuteNonQuery();
            }
        }
        public CongNhan ViewCongNhan(string MaCongNhan)
        {
            CongNhan cn = new CongNhan();
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                var str = "select MaCongNhan, TenCongNhan, GioiTinh, NamSinh, NuocVe " +
                    "from CongNhan " +
                    "where MaCongNhan = @MaCN ";
                MySqlCommand cmd = new MySqlCommand(str, connection);
                cmd.Parameters.AddWithValue("MaCN", MaCongNhan);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    cn.MaCongNhan = reader.GetString(0);
                    cn.TenCongNhan = reader.GetString(1);
                    cn.GioiTinh = reader.GetBoolean(2);
                    cn.NamSinh = reader.GetInt32(3);
                    cn.NuocVe = reader.GetString(4);
                }
                connection.Close();
            }
            return cn;
        }
    }
}