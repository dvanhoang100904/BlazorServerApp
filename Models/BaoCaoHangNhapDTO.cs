namespace BlazorServerApp.Models
{
    public class BaoCaoHangNhapDTO
    {
        public DateTime NgayNhap { get; set; }
        public string SoPhieuNhap { get; set; } = "";
        public string NhaCungCap { get; set; } = "";
        public string MaSanPham { get; set; } = "";
        public string TenSanPham { get; set; } = "";
        public int SoLuongNhap { get; set; }
        public double DonGia { get; set; }
        public double TriGia { get; set; }
    }
}
