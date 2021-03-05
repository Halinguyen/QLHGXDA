namespace QLHGXDA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Xeravao
    {
        [Key]
        public long PK_iXeravaoID { get; set; }

        public long FK_iXeID { get; set; }

        public long FK_iVexeID { get; set; }

        public short FK_NhanvienID { get; set; }

        public DateTime tThoigianvao { get; set; }

        public DateTime? tThoigianra { get; set; }

        public virtual tbl_Nhanvien tbl_Nhanvien { get; set; }

        public virtual tbl_Vexe tbl_Vexe { get; set; }

        public virtual tbl_Xe tbl_Xe { get; set; }
    }
}
