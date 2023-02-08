namespace QuanLyCaSi.Models
{
    public class BaiHat
    {
        private string maBaiHat, tenBaiHat, theLoai, maAlbum;
        public BaiHat() { }

        public BaiHat(string maBaiHat, string tenBaiHat, string theLoai, string maAlbum)
        {
            this.maBaiHat = maBaiHat;
            this.tenBaiHat = tenBaiHat;
            this.theLoai = theLoai;
            this.maAlbum = maAlbum;
        }

        public string MaBaiHat { get => maBaiHat; set => maBaiHat = value; }
        public string TenBaiHat { get => tenBaiHat; set => tenBaiHat = value; }
        public string TheLoai { get => theLoai; set => theLoai = value; }
        public string MaAlbum { get => maAlbum; set => maAlbum = value; }
    }
}
