namespace QLHGXDA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Khachhang()
        {
            tbl_Hoadon = new HashSet<tbl_Hoadon>();
        }

        [Key]
        public long PK_iKhachhangID { get; set; }

        [Required]
        [StringLength(50)]
        public string sHoten { get; set; }

        [Required]
        [StringLength(10)]
        public string sSodienthoai { get; set; }

        [Required]
        [StringLength(150)]
        public string sDiachi { get; set; }

        public bool bGioitinh { get; set; }

        public DateTime tNgaysinh { get; set; }

        [Required]
        [StringLength(12)]
        public string sSoCMND { get; set; }

        public long FK_iTaikhoanID { get; set; }

        public long? FK_iVeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Hoadon> tbl_Hoadon { get; set; }

        public virtual tbl_Taikhoan tbl_Taikhoan { get; set; }

        public virtual tbl_Vexe tbl_Vexe { get; set; }
    }
}
