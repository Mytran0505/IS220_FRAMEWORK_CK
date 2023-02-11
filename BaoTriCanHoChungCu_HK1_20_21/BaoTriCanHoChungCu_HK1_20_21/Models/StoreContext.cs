using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using BaoTriCanHoChungCu_HK1_20_21.Models;
namespace BaoTriCanHoChungCu_HK1_20_21.Models
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

        public void ThemCanHo(CanHo ch)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Insert into canho (macanho, tenchuho) " +
                    "value(@mach, @tench)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mach", ch.MaCanHo);
                cmd.Parameters.AddWithValue("tench", ch.TenChuHo);
                cmd.ExecuteNonQuery();
            }
        }

        public List<object> CacNhanVienCoNLanSua(int num)
        {
            List<object> list = new List<object>();
            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select tennhanvien, sodienthoai, count(*) as SLS " +
                    "from nhanvien nv, nv_bt bt " +
                    "where nv.manhanvien = bt.manhanvien " +
                    "Group by tennhanvien, sodienthoai " +
                    "Having SLS >= @number";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("number", num);
                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()) 
                    {
                        var ob = new
                        {
                            TenNhanVien = reader.GetString(0),
                            SoDienThoai = reader.GetString(1),
                            SoLanSua = Convert.ToInt32(reader.GetString(2)),
                        };
                        list.Add(ob);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<NhanVien> LietKeNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();
            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from nhanvien";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhanVien()
                        {
                            MaNhanVien = reader.GetString(0),
                            TenNhanVien = reader.GetString(1),
                            SoDienThoai = reader.GetString(2),
                            GioiTinh = reader.GetString(3),
                        });
                    }
                    reader.Close() ;
                }
                conn.Close() ;
            }
            return list;
        }

        public List<NV_BT> LietKeChiTietThietBiNhanVienDaSua(string MaNhanVien)
        {
            List<NV_BT> list = new List<NV_BT>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select manhanvien,mathietbi, macanho, lanthu, ngaybaotri" +
                    " from nv_bt " +
                    "where manhanvien = @maNV";
                MySqlCommand cmd = new MySqlCommand(str, conn) ;
                cmd.Parameters.AddWithValue("maNV", MaNhanVien);
                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NV_BT()
                        {
                            MaNhanVien = reader.GetString(0),
                            MaThietBi = reader.GetString(1),
                            MaCanHo = reader.GetString(2),
                            LanThu= Convert.ToInt32(reader.GetString(3)),
                            NgayBaoTri = reader.GetDateTime(4),
                        });
                    }
                    reader.Close() ;
                }
                conn.Close() ;
            }
            return list;
        }

        public void XoaChiTietSuaThietbiCuaNhanVien(string MaNhanVien, string MaThietBi)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from nv_bt where manhanvien = @manv and mathietbi = @matb";
                MySqlCommand cmd = new MySqlCommand(str, conn) ;
                cmd.Parameters.AddWithValue("manv", MaNhanVien);
                cmd.Parameters.AddWithValue("matb", MaThietBi);
                cmd.ExecuteNonQuery();
            }
        }

        public NV_BT ViewChiTietThietBi(string MaNhanVien, string MaThietBi, string MaCanHo, int LanThu)
        {
            NV_BT bt = new NV_BT();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from nv_bt where manhanvien = @manv and mathietbi = @matb " +
                    "and macanho = @MaCH and lanthu =@LanThu";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("manv", MaNhanVien);
                cmd.Parameters.AddWithValue("matb", MaThietBi);
                cmd.Parameters.AddWithValue("MaCH", MaCanHo);
                cmd.Parameters.AddWithValue("LanThu", LanThu);
                using (var reader = cmd.ExecuteReader()) {
                    if(reader.Read()) {
                        bt.MaNhanVien = reader.GetString(0);
                        bt.MaThietBi = reader.GetString(1);
                        bt.MaCanHo= reader.GetString(2);
                        bt.LanThu =Convert.ToInt32(reader.GetString(3));
                        bt.NgayBaoTri = reader.GetDateTime(4);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return bt;
        }
        public void UpdateNV_BT(NV_BT bt, string MaNhanVien, string MaThietBi, string MaCanHo, int LanThu)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update nv_bt set mathietbi = @matb, " +
                    "macanho = @MaCH , lanthu =@LanThu, ngaybaotri=@ngaybt " +
                    "where manhanvien = @manv1 and mathietbi = @matb1 and macanho = @MaCH1 and lanthu =@LanThu1";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("matb", bt.MaThietBi);
                cmd.Parameters.AddWithValue("MaCH", bt.MaCanHo);
                cmd.Parameters.AddWithValue("LanThu", bt.LanThu);
                cmd.Parameters.AddWithValue("ngaybt", bt.NgayBaoTri);
                cmd.Parameters.AddWithValue("manv1", MaNhanVien);
                cmd.Parameters.AddWithValue("matb1", MaThietBi);
                cmd.Parameters.AddWithValue("MaCH1", MaCanHo);
                cmd.Parameters.AddWithValue("LanThu1",LanThu);

                cmd.ExecuteNonQuery();
            }
        }
    }
}