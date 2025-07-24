namespace BlazorServerApp.Models
{
    public class BaoCaoXuatNhapTonDTO
    {
        public string MaSanPham { get; set; } = "";
        public string TenSanPham { get; set; } = "";
        public int SoLuongDauKy { get; set; }
        public int SoLuongNhap { get; set; }
        public int SoLuongXuat { get; set; }
        public int SoLuongCuoiKy { get; set; }
    }
}
