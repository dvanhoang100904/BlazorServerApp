using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerApp.Models
{
    [Table("tbl_DM_Don_Vi_Tinh")]
    public class DonViTinh
    {
        public int Id { get; set; }

        [Column("Ten_Don_Vi_Tinh")]
        [Required(ErrorMessage = "Tên đơn vị tính không được để trống")]
        public string TenDonViTinh { get; set; }

        [Column("Ghi_Chu")]
        public string? GhiChu { get; set; }
    }
}
