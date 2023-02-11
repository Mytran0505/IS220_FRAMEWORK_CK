namespace BaoTriCanHoChungCu_HK1_20_21.Models
{
    public class CanHo
    {
        private string maCanHo, tenChuHo;
        public CanHo() { }

        public CanHo(string maCanHo, string tenChuHo)
        {
            this.maCanHo = maCanHo;
            this.tenChuHo = tenChuHo;
        }

        public string MaCanHo { get => maCanHo; set => maCanHo = value; }
        public string TenChuHo { get => tenChuHo; set => tenChuHo = value; }
    }
}
