namespace QLHGXDA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Taikhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Taikhoan()
        {
            tbl_Khachhang = new HashSet<tbl_Khachhang>();
            tbl_Nhanvien = new HashSet<tbl_Nhanvien>();
            tbl_Phanquyen = new HashSet<tbl_Phanquyen>();
        }

        [Key]
        public long PK_iTaikhoanID { get; set; }

        [Required]
        [StringLength(150)]
        public string sUsername { get; set; }

        [Required]
        [StringLength(30)]
        public string sPassword { get; set; }

        public DateTime tNgaytao { get; set; }

        public bool bTrangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Khachhang> tbl_Khachhang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Nhanvien> tbl_Nhanvien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Phanquyen> tbl_Phanquyen { get; set; }
    }
}
