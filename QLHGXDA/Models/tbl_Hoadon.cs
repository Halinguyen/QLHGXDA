namespace QLHGXDA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Hoadon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Hoadon()
        {
            tbl_CTHD = new HashSet<tbl_CTHD>();
        }

        [Key]
        public long PK_iHoadonID { get; set; }

        public long FK_iKhachhangID { get; set; }

        public short FK_iNhanvienID { get; set; }

        public bool bTrangthai { get; set; }

        public DateTime tNgaylap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CTHD> tbl_CTHD { get; set; }

        public virtual tbl_Khachhang tbl_Khachhang { get; set; }

        public virtual tbl_Nhanvien tbl_Nhanvien { get; set; }
    }
}
