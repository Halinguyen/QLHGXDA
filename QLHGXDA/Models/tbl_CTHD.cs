namespace QLHGXDA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_CTHD
    {
        [Key]
        public long PK_iCTHDID { get; set; }

        public long FK_iVexeID { get; set; }

        public short FK_iGiaveID { get; set; }

        public int iSoluong { get; set; }

        public long FK_iHoadonID { get; set; }

        public virtual tbl_Giave tbl_Giave { get; set; }

        public virtual tbl_Hoadon tbl_Hoadon { get; set; }

        public virtual tbl_Vexe tbl_Vexe { get; set; }
    }
}
