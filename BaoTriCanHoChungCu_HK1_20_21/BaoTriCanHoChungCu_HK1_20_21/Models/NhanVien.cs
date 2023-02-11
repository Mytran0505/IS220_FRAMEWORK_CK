namespace BaoTriCanHoChungCu_HK1_20_21.Models
{
    public class NhanVien
    {
        private string maNhanVien, tenNhanVien, soDienThoai, gioiTinh;

        public NhanVien() { }
        public NhanVien(string maNhanVien, string tenNhanVien, string soDienThoai, string gioiTinh)
        {
            this.maNhanVien = maNhanVien;
            this.tenNhanVien = tenNhanVien;
            this.soDienThoai = soDienThoai;
            this.gioiTinh = gioiTinh;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
    }
}
