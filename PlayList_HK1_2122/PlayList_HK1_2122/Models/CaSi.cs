namespace PlayList_HK1_2122.Models
{
    public class CaSi
    {
        private string maCaSi, tenCaSi, gioiTinh;
        private DateTime namSinh;

        public CaSi() { }

        public CaSi(string maCaSi, string tenCaSi, string gioiTinh, DateTime namSinh)
        {
            this.maCaSi = maCaSi;
            this.tenCaSi = tenCaSi;
            this.gioiTinh = gioiTinh;
            this.namSinh = namSinh;
        }

        public string MaCaSi { get => maCaSi; set => maCaSi = value; }
        public string TenCaSi { get => tenCaSi; set => tenCaSi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NamSinh { get => namSinh; set => namSinh = value; }
    }
}
