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

    public partial class tbl_Calam_Nhanvien
    {
        [Key]
        public long PK_iNhanvien_CalamID { get; set; }
        public tbl_Calam_Nhanvien() { }

        public tbl_Calam_Nhanvien(string pK_iNhanvien_CalamID, string fK_iNhanvienID, string fK_iCalamID)
        {
            PK_iNhanvien_CalamID = Convert.ToInt64(pK_iNhanvien_CalamID);
            FK_iNhanvienID =Convert.ToInt16(fK_iNhanvienID);
            FK_iCalamID = Convert.ToInt16(fK_iCalamID);
        }

        public short FK_iNhanvienID { get; set; }

        public short FK_iCalamID { get; set; }

        public virtual tbl_Calam tbl_Calam { get; set; }

        public virtual tbl_Nhanvien tbl_Nhanvien { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_Calam_Nhanvien> GetCalamNhanvienByPK(long nhanvienCalamID)
        {
            List<tbl_Calam_Nhanvien> dsCalam_Nhanvien = new List<tbl_Calam_Nhanvien>();
            cmd = new SqlCommand("sp_GetCalam_NhanvienByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nhanviencalamID", nhanvienCalamID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Calam_Nhanvien calam_nhanvien = new tbl_Calam_Nhanvien(
                      dar["PK_iNhanvien_CalamID"].ToString(),
                      dar["FK_iNhanvienID"].ToString(),
                      dar["FK_iCalamID"].ToString());
                    dsCalam_Nhanvien.Add(calam_nhanvien);
                }
            }
            conn.Close();
            return dsCalam_Nhanvien;
        }
    }
}
