namespace QLHGXDA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Giave
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Giave()
        {
            tbl_CTHD = new HashSet<tbl_CTHD>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short PK_iGiaveID { get; set; }

        public decimal mGia { get; set; }

        public byte FK_iLoaixeID { get; set; }

        public byte FK_iLoaiveID { get; set; }

        public short FK_iKhunggioID { get; set; }

        public DateTime tNgayApdung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CTHD> tbl_CTHD { get; set; }

        public virtual tbl_Khunggio tbl_Khunggio { get; set; }

        public virtual tbl_Loaive tbl_Loaive { get; set; }

        public virtual tbl_Loaixe tbl_Loaixe { get; set; }
    }
}
