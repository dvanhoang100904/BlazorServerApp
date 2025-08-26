using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerApp.Models
{
    [Table("tbl_DM_Xuat_Kho_Raw_Data")]
    public class PhieuXuatRawData
    {
        public int Id { get; set; }

        [Column("Xuat_Kho_ID")]
        [Required(ErrorMessage = "Xuất kho không được để trống")]
        public int XuatKhoId {  get; set; }

        [Column("San_Pham_ID")]
        [Required(ErrorMessage = "Sản phẩm không được để trống")]
        public int SanPhamId {  get; set; }

        [Column("So_Luong_Xuat")]
        [Required(ErrorMessage ="Số lượng xuất không được để trống")]
        public int SoLuongXuat { get; set; }

        [Column("Don_Gia_Xuat")]
        [Required(ErrorMessage ="Đơn giá xuất không được để trống")]
        public double DonGiaXuat { get; set; }

        [ForeignKey("XuatKhoId")]
        public PhieuXuat? PhieuXuat { get; set; }

        [ForeignKey("SanPhamId")]
        public SanPham? SanPham { get; set; }

    }
}
