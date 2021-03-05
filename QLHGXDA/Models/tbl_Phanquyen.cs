namespace QLHGXDA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Phanquyen
    {
        [Key]
        public short PK_iPhanquyenID { get; set; }

        public short FK_iQuyenID { get; set; }

        public long FK_iTaikhoanID { get; set; }

        public DateTime tNgaybatdau { get; set; }

        public DateTime tNgayhethan { get; set; }

        public virtual tbl_Quyen tbl_Quyen { get; set; }

        public virtual tbl_Taikhoan tbl_Taikhoan { get; set; }
    }
}
