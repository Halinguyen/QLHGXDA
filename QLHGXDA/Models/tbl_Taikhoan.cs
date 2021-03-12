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

    public partial class tbl_Taikhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Taikhoan()
        {
           
        }

        public tbl_Taikhoan(string pK_iTaikhoanID, string sUsername, string sPassword, string tNgaytao, string bTrangthai)
        {
            PK_iTaikhoanID =Convert.ToInt64( pK_iTaikhoanID);
            this.sUsername = sUsername;
            this.sPassword = sPassword;
            this.tNgaytao = Convert.ToDateTime( tNgaytao);
            this.bTrangthai = Convert.ToBoolean( bTrangthai);
        }

        [Key]
        public long PK_iTaikhoanID { get; set; }

        [Required]
        [StringLength(150)]
        public string sUsername { get; set; }

        [Required]
        [StringLength(30)]
        public string sPassword { get; set; }

        public DateTime tNgaytao { get; set; }

        public bool bTrangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Khachhang> tbl_Khachhang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Nhanvien> tbl_Nhanvien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Phanquyen> tbl_Phanquyen { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_Taikhoan> GetTaikhoanByPK(long taikhoanID)
        {
            List<tbl_Taikhoan> dsTaikhoan = new List<tbl_Taikhoan>();
            cmd = new SqlCommand("spGetTaikhoanByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoanID", taikhoanID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Taikhoan tk = new tbl_Taikhoan(
                      dar["PK_iTaikhoanID"].ToString(),
                      dar["sUsername"].ToString(),
                      dar["sPassword"].ToString(),
                      dar["tNgaytao"].ToString(),
                      dar["bTrangthai"].ToString());
                    dsTaikhoan.Add(tk);
                }
            }
            conn.Close();
            return dsTaikhoan;
        }

        public List<tbl_Taikhoan> GetTaikhoanByUsernameandPassword(string username, string pass)
        {
            List<tbl_Taikhoan> dsTaikhoan = new List<tbl_Taikhoan>();
            cmd = new SqlCommand("sp_GetTaikhoanByUaP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", pass);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Taikhoan tk = new tbl_Taikhoan(
                      dar["PK_iTaikhoanID"].ToString(),
                      dar["sUsername"].ToString(),
                      dar["sPassword"].ToString(),
                      dar["tNgaytao"].ToString(),
                      dar["bTrangthai"].ToString());
                    dsTaikhoan.Add(tk);
                }
            }
            conn.Close();
            return dsTaikhoan;

        }

        public bool InsertTaikhoan(string username, string pass, DateTime ngaytao, bool trangthai)
        {
        
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertTaikhoan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@ngaytao", ngaytao);
                cmd.Parameters.AddWithValue("@trangthai", trangthai);
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


        public bool UpdateTaikhoan(long taikhoanID,string username, string pass, DateTime ngaytao, bool trangthai)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateTaikhoan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@taikhoanID", taikhoanID);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@ngaytao", ngaytao);
                cmd.Parameters.AddWithValue("@trangthai", trangthai);
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


        public bool DeleteTaikhoan(long taikhoanID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteTaikhoan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@taikhoanID", taikhoanID);
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
