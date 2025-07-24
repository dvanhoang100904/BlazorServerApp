namespace BlazorServerApp.Models
{
    public class BaoCaoHangXuatDTO
    {
        public DateTime NgayXuat { get; set; }
        public string SoPhieuXuat { get; set; } = "";
        public string MaSanPham { get; set; } = "";
        public string TenSanPham { get; set; } = "";
        public int SoLuongXuat { get; set; }
        public double DonGia { get; set; }
        public double TriGia { get; set; }
    }
}
