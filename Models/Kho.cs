using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerApp.Models
{
    [Table("tbl_DM_Kho")]
    public class Kho
    {
        public int Id { get; set; }

        [Column("Ten_Kho")]
        [Required(ErrorMessage ="Tên kho không được để trống")]
        public string TenKho { get; set; }

        [Column("Ghi_Chu")]
        public string? GhiChu { get; set; }
    }
}
