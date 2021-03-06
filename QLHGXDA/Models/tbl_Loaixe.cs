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

    public partial class tbl_Loaixe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Loaixe()
        {
           
        }

        public tbl_Loaixe(string pK_iLoaixeID, string sTenloaixe)
        {
            PK_iLoaixeID = Convert.ToByte(pK_iLoaixeID);
            this.sTenloaixe = sTenloaixe;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte PK_iLoaixeID { get; set; }

        [Required]
        [StringLength(60)]
        public string sTenloaixe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Giave> tbl_Giave { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Khudexe> tbl_Khudexe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Xe> tbl_Xe { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

        SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_Loaixe> GetLoaixeByPK(byte loaixeID)
        {
            List<tbl_Loaixe> dsLoaixe = new List<tbl_Loaixe>();
            cmd = new SqlCommand("sp_GetLoaixeByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@loaixeID", loaixeID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Loaixe lx = new tbl_Loaixe(
                      dar["PK_iLoaixeID"].ToString(),
                      dar["sTenloaixe"].ToString());
                    dsLoaixe.Add(lx);
                }
            }
            conn.Close();
            return dsLoaixe;
        }
    }
}
