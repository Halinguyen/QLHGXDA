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

    public partial class tbl_Khudexe
    {
        public tbl_Khudexe()
        {

        }

        public tbl_Khudexe(string pK_iKhudexeID, string sTenkhu, string fK_iLoaixeID)
        {
            PK_iKhudexeID = Convert.ToInt16(pK_iKhudexeID);
            this.sTenkhu = sTenkhu;
            FK_iLoaixeID = Convert.ToByte(fK_iLoaixeID);
        }

        [Key]
        public short PK_iKhudexeID { get; set; }

        [Required]
        [StringLength(20)]
        public string sTenkhu { get; set; }

        public byte FK_iLoaixeID { get; set; }

        public virtual tbl_Loaixe tbl_Loaixe { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_Khudexe> GetKhudexeByPK(short khudexeID)
        {
            List<tbl_Khudexe> dsKhudexe = new List<tbl_Khudexe>();
            cmd = new SqlCommand("sp_GetKhudexeByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@khudexeID", khudexeID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Khudexe kdx = new tbl_Khudexe(
                      dar["PK_iKhudexeID"].ToString(),
                      dar["sTenkhu"].ToString(),
                      dar["FK_iLoaixeID"].ToString());
                    dsKhudexe.Add(kdx);
                }
            }
            conn.Close();
            return dsKhudexe;
        }


        public bool InsertKhudexe(string tenkhu, byte loaixeID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertKhudexe", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenkhu", tenkhu);
                cmd.Parameters.AddWithValue("@maloaixe", loaixeID);
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

        public bool UpdateKhudexe(short khudexeID, string tenkhu, byte loaixeID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateKhudexe", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@makhudexe", khudexeID);
                cmd.Parameters.AddWithValue("@tenkhu", tenkhu);
                cmd.Parameters.AddWithValue("@maloaixe", loaixeID);
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



        public bool DeleteKhudexe(short khudexeID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteKhudexe", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@makhudexe", khudexeID);
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
