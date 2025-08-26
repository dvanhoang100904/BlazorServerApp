using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerApp.Models
{
    [Table("tbl_DM_Nhap_Kho_Raw_Data")]
    public class PhieuNhapRawData
    {
        public int Id { get; set; }

        [Column("Nhap_Kho_ID")]
        [Required(ErrorMessage ="Nhập kho không được để trống")]
        public int NhapKhoId { get; set; }

        [Column("San_Pham_ID")]
        [Required(ErrorMessage ="Sản phẩm không được để trống")]
        public int SanPhamId { get; set; }

        [Column("So_Luong_Nhap")]
        [Required(ErrorMessage ="Số lượng nhập không được để trống")]
        public int SoLuongNhap { get; set; }

        [Column("Don_Gia_Nhap")]
        [Required(ErrorMessage ="Đơn giá nhập không được để trống")]
        public double DonGiaNhap { get; set; }

        [ForeignKey("NhapKhoId")]
        public PhieuNhap? PhieuNhap { get; set; }

        [ForeignKey("SanPhamId")]
        public SanPham? SanPham { get; set; }
    }
}
