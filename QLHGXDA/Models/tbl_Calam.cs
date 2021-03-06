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

    public partial class tbl_Calam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Calam()
        {

        }

        public tbl_Calam(string pK_iCalamID, string sTencalam, string sGiobatdau, string sGioketthuc, string sMota)
        {
            PK_iCalamID = Convert.ToInt16(pK_iCalamID);
            this.sTencalam = sTencalam;
            this.sGiobatdau = sGiobatdau;
            this.sGioketthuc = sGioketthuc;
            this.sMota = sMota;
        }

        [Key]
        public short PK_iCalamID { get; set; }

        [Required]
        [StringLength(50)]
        public string sTencalam { get; set; }

        [Required]
        [StringLength(10)]
        public string sGiobatdau { get; set; }

        [Required]
        [StringLength(10)]
        public string sGioketthuc { get; set; }

        [StringLength(50)]
        public string sMota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Calam_Nhanvien> tbl_Calam_Nhanvien { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        SqlDataReader dar;
        SqlCommand cmd;

        public List<tbl_Calam> GetCalamByPK(short calamID)
        {
            List<tbl_Calam> dsCalam = new List<tbl_Calam>();
            cmd = new SqlCommand("sp_GetCalamByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@calamID", calamID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Calam calam = new tbl_Calam(
                      dar["PK_iCalamID"].ToString(),
                      dar["sTencalam"].ToString(),
                      dar["sGiobatdau"].ToString(),
                      dar["sGioketthuc"].ToString(),
                      dar["sMota"].ToString()
                        );
                    dsCalam.Add(calam);
                }
            }
            conn.Close();
            return dsCalam;
        }


    }
}
