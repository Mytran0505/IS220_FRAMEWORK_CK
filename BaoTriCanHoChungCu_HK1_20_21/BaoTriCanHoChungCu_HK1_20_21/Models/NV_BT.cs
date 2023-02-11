namespace BaoTriCanHoChungCu_HK1_20_21.Models
{
    public class NV_BT
    {
        private string maNhanVien, maThietBi, maCanHo;
        private int lanThu;
        private DateTime ngayBaoTri;

        public NV_BT() { }
        public NV_BT(string maNhanVien, string maThietBi, string maCanHo, int lanThu, DateTime ngayBaoTri)
        {
            this.maNhanVien = maNhanVien;
            this.maThietBi = maThietBi;
            this.maCanHo = maCanHo;
            this.lanThu = lanThu;
            this.ngayBaoTri = ngayBaoTri;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string MaThietBi { get => maThietBi; set => maThietBi = value; }
        public string MaCanHo { get => maCanHo; set => maCanHo = value; }
        public int LanThu { get => lanThu; set => lanThu = value; }
        public DateTime NgayBaoTri { get => ngayBaoTri; set => ngayBaoTri = value; }
    }
}
