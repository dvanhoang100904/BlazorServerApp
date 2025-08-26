using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerApp.Models
{
    [Table("tbl_DM_Nha_Cung_Cap")]
    public class NhaCungCap
    {
        public int Id { get; set; }

        [Column("Ma_Nha_Cung_Cap")]
        [Required(ErrorMessage ="Mã nhà cung cấp không được để trống")]
        public string MaNhaCungCap { get; set; }

        [Column("Ten_Nha_Cung_Cap")]
        [Required(ErrorMessage ="Tên nhà cung cấp không được để trống")]
        public string TenNhaCungCap { get; set; }

        [Column("Ghi_Chu")]
        public string? GhiChu {  get; set; }
    }
}
