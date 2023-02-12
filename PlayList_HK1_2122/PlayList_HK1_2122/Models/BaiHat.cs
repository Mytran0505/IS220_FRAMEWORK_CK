namespace PlayList_HK1_2122.Models
{
    public class BaiHat
    {
        private string maBaiHat, tenBaiHat, theLoai;

        public BaiHat() { } 
        public BaiHat(string maBaiHat, string tenBaiHat, string theLoai)
        {
            this.maBaiHat = maBaiHat;
            this.tenBaiHat = tenBaiHat;
            this.theLoai = theLoai;
        }

        public string MaBaiHat { get => maBaiHat; set => maBaiHat = value; }
        public string TenBaiHat { get => tenBaiHat; set => tenBaiHat = value; }
        public string TheLoai { get => theLoai; set => theLoai = value; }
    }
}
