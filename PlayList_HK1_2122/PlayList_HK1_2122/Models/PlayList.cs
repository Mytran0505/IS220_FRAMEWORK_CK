namespace PlayList_HK1_2122.Models
{
    public class PlayList
    {
        private string maPlayList, tenPlayList, maNN;
        private int soLuong;

        public PlayList() { }
        public PlayList(string maPlayList, string tenPlayList, string maNN, int soLuong)
        {
            this.maPlayList = maPlayList;
            this.tenPlayList = tenPlayList;
            this.maNN = maNN;
            this.soLuong = soLuong;
        }

        public string MaPlayList { get => maPlayList; set => maPlayList = value; }
        public string TenPlayList { get => tenPlayList; set => tenPlayList = value; }
        public string MaNN { get => maNN; set => maNN = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
