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

    public partial class tbl_Loaive
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Loaive()
        {
           
        }

        public tbl_Loaive(string pK_iLoaiveID, string sTenloaive)
        {
            PK_iLoaiveID = Convert.ToByte( pK_iLoaiveID);
            this.sTenloaive = sTenloaive;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte PK_iLoaiveID { get; set; }

        [Required]
        [StringLength(50)]
        public string sTenloaive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Giave> tbl_Giave { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Vexe> tbl_Vexe { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_Loaive> GetLoaiveByPK(byte loaiveID)
        {
            List<tbl_Loaive> dsLoaive = new List<tbl_Loaive>();
            cmd = new SqlCommand("sp_GetLoaiveByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@loaiveID", loaiveID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Loaive lv = new tbl_Loaive(
                      dar["PK_iLoaiveID"].ToString(),                    
                      dar["sTenloaive"].ToString());
                    dsLoaive.Add(lv);
                }
            }
            conn.Close();
            return dsLoaive;
        }
    }
}
