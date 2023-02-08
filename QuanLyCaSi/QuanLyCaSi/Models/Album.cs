namespace QuanLyCaSi.Models
{
    public class Album
    {
        private string maAlbum, tenAlbum, maCaSi;

        public Album() { }

        public Album(string maAlbum, string tenAlbum, string maCaSi)
        {
            this.maAlbum = maAlbum;
            this.tenAlbum = tenAlbum;
            this.maCaSi = maCaSi;
        }
        

        public string MaAlbum { get => maAlbum; set => maAlbum = value; }
        public string TenAlbum { get => tenAlbum; set => tenAlbum = value; }
        public string MaCaSi { get => maCaSi; set => maCaSi = value; }
    }
}
