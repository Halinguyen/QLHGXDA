namespace QLHGXDA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Vexe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Vexe()
        {
            tbl_CTHD = new HashSet<tbl_CTHD>();
            tbl_Khachhang = new HashSet<tbl_Khachhang>();
            tbl_Xeravao = new HashSet<tbl_Xeravao>();
        }

        [Key]
        public long PK_iVeID { get; set; }

        [Required]
        [StringLength(10)]
        public string sMasove { get; set; }

        public DateTime tNgaytao { get; set; }

        public DateTime tNgayhethan { get; set; }

        public byte FK_iLoaiveID { get; set; }

        public byte? iTrangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CTHD> tbl_CTHD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Khachhang> tbl_Khachhang { get; set; }

        public virtual tbl_Loaive tbl_Loaive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Xeravao> tbl_Xeravao { get; set; }
    }
}
