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

    public partial class tbl_Quyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Quyen()
        {
           
        }

        public tbl_Quyen(string pK_iQuyenID, string sTenquyen, string sMota)
        {
            PK_iQuyenID = Convert.ToInt16( pK_iQuyenID);
            this.sTenquyen = sTenquyen;
            this.sMota = sMota;
        }

        [Key]
        public short PK_iQuyenID { get; set; }

        [Required]
        [StringLength(50)]
        public string sTenquyen { get; set; }

        [StringLength(150)]
        public string sMota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Phanquyen> tbl_Phanquyen { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
          SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_Quyen> GetQuyenByPK(short quyenID)
        {
            List<tbl_Quyen> dsQuyen = new List<tbl_Quyen>();
            cmd = new SqlCommand("spGetQuyenByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@quyenID", quyenID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Quyen q = new tbl_Quyen(
                      dar["PK_iQuyenID"].ToString(),
                      dar["sTenquyen"].ToString(),
                      dar["sMota"].ToString());
                    dsQuyen.Add(q);
                }
            }
            conn.Close();
            return dsQuyen;
        }

        public bool InsertQuyen(string tenquyen, string mota)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Insertquyen", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenquyen", tenquyen);
                cmd.Parameters.AddWithValue("@mota", mota);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    ketqua = true;
                else
                    ketqua = false;
            }
            catch (Exception ex)
            {
                ketqua = false;
                throw new ApplicationException("ERROR: " + ex);
            }
            return ketqua;
        }

        public bool UpdateQuyen( short quyenID,string tenquyen, string mota)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateQuyen", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maquyen", quyenID);
                cmd.Parameters.AddWithValue("@tenquyen", tenquyen);
                cmd.Parameters.AddWithValue("@mota", mota);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    ketqua = true;
                else
                    ketqua = false;
            }
            catch (Exception ex)
            {
                ketqua = false;
                throw new ApplicationException("ERROR: " + ex);
            }
            return ketqua;
        }
        public bool DeleteQuyen(short quyenID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteQuyen", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maquyen", quyenID);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    ketqua = true;
                else
                    ketqua = false;
            }
            catch (Exception ex)
            {
                ketqua = false;
                throw new ApplicationException("ERROR: " + ex);
            }
            return ketqua;
        }
    }
}
