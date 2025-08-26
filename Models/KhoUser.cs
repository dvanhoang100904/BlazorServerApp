using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerApp.Models
{
    [Table("tbl_DM_Kho_User")]
    public class KhoUser
    {
        public int Id { get; set; }

        [Column("Ma_Dang_Nhap")]
        [Required(ErrorMessage = "Mã đăng nhập không được để trống")]
        public string MaDangNhap {  get; set; }

        [Column("Kho_ID")]
        [Required(ErrorMessage ="Kho không được để trống")]
        public int KhoId { get; set; }

        [ForeignKey("KhoId")]
        public Kho? Kho { get; set; }
    }
}
