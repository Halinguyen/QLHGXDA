namespace QLHGXDA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Calam_Nhanvien
    {
        [Key]
        public long PK_iNhanvien_CalamID { get; set; }

        public short FK_iNhanvienID { get; set; }

        public short FK_iCalamID { get; set; }

        public virtual tbl_Calam tbl_Calam { get; set; }

        public virtual tbl_Nhanvien tbl_Nhanvien { get; set; }
    }
}
