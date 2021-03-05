namespace QLHGXDA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Calam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Calam()
        {
            tbl_Calam_Nhanvien = new HashSet<tbl_Calam_Nhanvien>();
        }

        [Key]
        public short PK_iCalamID { get; set; }

        [Required]
        [StringLength(50)]
        public string sTencalam { get; set; }

        [Required]
        [StringLength(10)]
        public string sGiobatdau { get; set; }

        [Required]
        [StringLength(10)]
        public string sGioketthuc { get; set; }

        [StringLength(50)]
        public string sMota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Calam_Nhanvien> tbl_Calam_Nhanvien { get; set; }
    }
}
