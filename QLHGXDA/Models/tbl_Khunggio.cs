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

    public partial class tbl_Khunggio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Khunggio()
        {
            
        }

        public tbl_Khunggio(string pK_iKhunggioID, string tGiobatdau, string tGioketthuc)
        {
            PK_iKhunggioID = Convert.ToInt16( pK_iKhunggioID);
            this.tGiobatdau = tGiobatdau;
            this.tGioketthuc = tGioketthuc;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short PK_iKhunggioID { get; set; }

        public string tGiobatdau { get; set; }

        public string tGioketthuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Giave> tbl_Giave { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_Khunggio> GetKhudexeByPK(short khunggioID)
        {
            List<tbl_Khunggio> dsKhunggio = new List<tbl_Khunggio>();
            cmd = new SqlCommand("sp_GetKhunggioByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@khunggioID", khunggioID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Khunggio kg = new tbl_Khunggio(
                      dar["PK_iKhunggioID"].ToString(),
                      dar["tGiobatdau"].ToString(),
                      dar["tGioketthuc"].ToString());
                    dsKhunggio.Add(kg);
                }
            }
            conn.Close();
            return dsKhunggio;
        }


        public bool InsertKhunggio(DateTime giobatdau, DateTime gioketthuc)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertKhunggio", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@giobatdau", giobatdau);
                cmd.Parameters.AddWithValue("@gioketthuc", gioketthuc);
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



        public bool UpdateKhunggio(short khunggioID,DateTime giobatdau, DateTime gioketthuc)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateKhunggio", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@makhunggio", khunggioID);
                cmd.Parameters.AddWithValue("@giobatdau", giobatdau);
                cmd.Parameters.AddWithValue("@gioketthuc", gioketthuc);
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


        public bool DeleteKhunggio(short khunggioID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteKhunggio", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@makhunggio", khunggioID);               
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
