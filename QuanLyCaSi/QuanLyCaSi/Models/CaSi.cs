namespace QuanLyCaSi.Models
{
    

    public class CaSi
    {
        private string maCaSi;
        private string tenCaSi;
        private DateTime ngaysinh;

        public CaSi(string maCaSi, string tenCaSi, DateTime ngaysinh)
        {
            this.MaCaSi = maCaSi;
            this.TenCaSi = tenCaSi;
            this.Ngaysinh = ngaysinh;
        }
        public CaSi() { }

        public string MaCaSi { get => maCaSi; set => maCaSi = value; }
        public string TenCaSi { get => tenCaSi; set => tenCaSi = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
    }
}
