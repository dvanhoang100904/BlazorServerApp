using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerApp.Models
{
    [Table("tbl_XNK_Xuat_Kho")]
    public class XnkPhieuXuat
    {
        public int Id { get; set; }

        [Column("So_Phieu_Xuat_Kho")]
        [Required(ErrorMessage ="Số phiếu xuất không được để trống")]
        public string SoPhieuXuatKho { get; set; }

        [Column("Kho_ID")]
        [Required(ErrorMessage ="Kho không được để trống")]
        public int KhoId { get; set; }

        [Column("Ngay_Xuat_Kho")]
        [Required(ErrorMessage ="Ngày xuất không được để trống")]
        public DateTime NgayXuatKho { get; set; }

        [ForeignKey("KhoId")]
        public Kho? Kho { get; set; }
    }
}
