namespace PlayList_HK1_2122.Models
{
    public class NguoiNghe
    {
        private string maNN, tenNN, gioiTinh;
        public NguoiNghe() { }
        public NguoiNghe(string maNN, string tenNN, string gioiTinh)
        {
            this.maNN = maNN;
            this.tenNN = tenNN;
            this.gioiTinh = gioiTinh;
        }

        public string MaNN { get => maNN; set => maNN = value; }
        public string TenNN { get => tenNN; set => tenNN = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
    }
}
