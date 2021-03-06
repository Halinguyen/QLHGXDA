namespace QLHGXDA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Configuration;
    using System.Data;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;

    public partial class tbl_Vexe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Vexe()
        {

        }

        public tbl_Vexe(string pK_iVeID, string sMasove, string tNgaytao, string tNgayhethan, string fK_iLoaiveID, string iTrangthai)
        {
            PK_iVeID = Convert.ToInt64(pK_iVeID);
            this.sMasove = sMasove;
            this.tNgaytao = Convert.ToDateTime(tNgaytao);
            this.tNgayhethan = Convert.ToDateTime(tNgayhethan);
            FK_iLoaiveID = Convert.ToByte(fK_iLoaiveID);
            this.iTrangthai = Convert.ToByte(iTrangthai);
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
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

        SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_Vexe> GetVexeByPK(long vexeID)
        {
            List<tbl_Vexe> dsVexe = new List<tbl_Vexe>();
            cmd = new SqlCommand("sp_GetVexeByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vexeID", vexeID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Vexe vx = new tbl_Vexe(
                      dar["PK_iVeID"].ToString(),
                       dar["sMasove"].ToString(),
                        dar["tNgaytao"].ToString(),
                       dar["tNgayhethan"].ToString(),
                        dar["FK_iLoaiveID"].ToString(),
                      dar["iTrangthai"].ToString());
                    dsVexe.Add(vx);
                }
            }
            conn.Close();
            return dsVexe;
        }
    }
}
