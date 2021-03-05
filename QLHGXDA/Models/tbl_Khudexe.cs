namespace QLHGXDA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Khudexe
    {
        [Key]
        public short PK_iKhudexeID { get; set; }

        [Required]
        [StringLength(20)]
        public string sTenkhu { get; set; }

        public byte FK_iLoaixeID { get; set; }

        public virtual tbl_Loaixe tbl_Loaixe { get; set; }
    }
}
