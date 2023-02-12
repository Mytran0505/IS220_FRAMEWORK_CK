namespace CachLyCoVid19_HK2_19_20.Models
{
    public class CongNhan
    {
        private string maCongNhan, tenCongNhan, nuocVe;
        private int namSinh;
        private bool gioiTinh;
        public CongNhan() { }
        public CongNhan(string maCongNhan, string tenCongNhan, string nuocVe, int namSinh, bool gioiTinh)
        {
            this.maCongNhan = maCongNhan;
            this.tenCongNhan = tenCongNhan;
            this.nuocVe = nuocVe;
            this.namSinh = namSinh;
            this.gioiTinh = gioiTinh;
        }

        public string MaCongNhan { get => maCongNhan; set => maCongNhan = value; }
        public string TenCongNhan { get => tenCongNhan; set => tenCongNhan = value; }
        public string NuocVe { get => nuocVe; set => nuocVe = value; }
        public int NamSinh { get => namSinh; set => namSinh = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
    }
}
