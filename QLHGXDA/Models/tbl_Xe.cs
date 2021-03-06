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

    public partial class tbl_Xe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Xe()
        {
           
        }

        public tbl_Xe(string pK_iXeID, string fK_iLoaixeID, string sBiensoxe, string sAnhxe)
        {
            PK_iXeID = Convert.ToInt64( pK_iXeID);
            FK_iLoaixeID = Convert.ToByte( fK_iLoaixeID);
            this.sBiensoxe = sBiensoxe;
            this.sAnhxe = sAnhxe;
        }

        [Key]
        public long PK_iXeID { get; set; }

        public byte FK_iLoaixeID { get; set; }

        [Required]
        [StringLength(20)]
        public string sBiensoxe { get; set; }

        [Required]
        [StringLength(200)]
        public string sAnhxe { get; set; }

        public virtual tbl_Loaixe tbl_Loaixe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Xeravao> tbl_Xeravao { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_Xe> GetXeByPK(long xeID)
        {
            List<tbl_Xe> dsXe = new  List<tbl_Xe>();
            cmd = new SqlCommand("sp_GetXeByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@xeID", xeID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Xe xe = new tbl_Xe(
                      dar["PK_iXeID"].ToString(),
                      dar["FK_iLoaixeID"].ToString(),                                            
                      dar["sBiensoxe"].ToString(),
                      dar["sAnhxe"].ToString());
                    dsXe.Add(xe);
                }
            }
            conn.Close();
            return dsXe;
        }
    }
}
