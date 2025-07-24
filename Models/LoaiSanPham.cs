using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerApp.Models
{
    [Table("tbl_DM_Loai_San_Pham")]
    public class LoaiSanPham
    {
        public int Id { get; set; }

        [Column("Ma_Loai_San_Pham")]
        [Required(ErrorMessage = "Mã loại sản phẩm không được để trống")]
        public string MaLoaiSanPham { get; set; }

        [Column("Ten_Loai_San_Pham")]
        [Required(ErrorMessage = "Tên loại sản phẩm không được để trống")]
        public string TenLoaiSanPham { get; set; }

        [Column("Ghi_Chu")]
        public string? GhiChu { get; set; }
        
    }
}
