using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerApp.Models
{
    [Table("tbl_DM_Nhap_Kho")]
    public class PhieuNhap
    {
        public int Id { get; set; }

        [Column("So_Phieu_Nhap_Kho")]
        [Required(ErrorMessage ="Số phiếu nhập không được để trống")]
        public string SoPhieuNhapKho { get; set; }

        [Column("Kho_ID")]
        [Required(ErrorMessage = "Kho không được để trống")]
        public int KhoId {  get; set; }

        [Column("Nha_Cung_Cap_ID")]
        [Required(ErrorMessage = "Nhà cung cấp không được để trống")]
        public int NhaCungCapId { get; set; }

        [Column("Ngay_Nhap_Kho")]
        [Required(ErrorMessage = "Ngày nhập không được để trống")]
        public DateTime NgayNhapKho { get; set; }

        [Column("Ghi_Chu")]
        public string? GhiChu { get; set; }

        [ForeignKey("KhoId")]
        public Kho? Kho { get; set; }

        [ForeignKey("NhaCungCapId")]
        public NhaCungCap? NhaCungCap { get; set; }

        public ICollection<PhieuNhapRawData> ChiTietPhieuNhap { get; set; } = new List<PhieuNhapRawData>();


    }
}
