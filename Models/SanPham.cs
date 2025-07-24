using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerApp.Models
{
    [Table("tbl_DM_San_Pham")]
    public class SanPham
    {
        public int Id { get; set; }

        [Column("Ma_San_Pham")]
        [Required(ErrorMessage ="Mã sản phẩm không được để trống")]
        public string MaSanPham { get; set; }

        [Column("Ten_San_Pham")]
        [Required(ErrorMessage ="Tên sản phẩm không được để trống")]
        public string TenSanPham { get; set; }

        [Column("Loai_San_Pham_ID")]
        [Required(ErrorMessage = "Loại sản phẩm không được để trống")]
        public int LoaiSanPhamId { get; set; }

        [Column("Don_Vi_Tinh_ID")]
        [Required(ErrorMessage = "Đơn vị tính không được để trống")]
        public int DonViTinhId {  get; set; }

        [Column("Ghi_Chu")]
        public string? GhiChu {  get; set; }

        [ForeignKey("LoaiSanPhamId")]
        public LoaiSanPham? LoaiSanPham { get; set; }

        [ForeignKey("DonViTinhId")]
        public DonViTinh? DonViTinh { get; set; }

        public ICollection<PhieuNhapRawData> ChiTietPhieuNhap { get; set; } = new List<PhieuNhapRawData>();
        public ICollection<PhieuXuatRawData> ChiTietPhieuXuat { get; set; } = new List<PhieuXuatRawData>();
    }
}
