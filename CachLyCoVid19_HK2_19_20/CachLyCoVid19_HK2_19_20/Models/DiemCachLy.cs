namespace CachLyCoVid19_HK2_19_20.Models
{
    public class DiemCachLy
    {
        private string maDiemCachLy, tenDiemCachLy, diaChi;
        public DiemCachLy() { } 
        public DiemCachLy(string maDiemCachLy, string tenDiemCachLy, string diaChi)
        {
            this.maDiemCachLy = maDiemCachLy;
            this.tenDiemCachLy = tenDiemCachLy;
            this.diaChi = diaChi;
        }

        public string MaDiemCachLy { get => maDiemCachLy; set => maDiemCachLy = value; }
        public string TenDiemCachLy { get => tenDiemCachLy; set => tenDiemCachLy = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}
