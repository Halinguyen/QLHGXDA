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

    public partial class tbl_CTHD
    {
        public tbl_CTHD() { }

        public tbl_CTHD(string pK_iCTHDID, string fK_iVexeID, string fK_iGiaveID, string iSoluong, string fK_iHoadonID)
        {
            PK_iCTHDID = Convert.ToInt64( pK_iCTHDID);
            FK_iVexeID = Convert.ToInt64( fK_iVexeID);
            FK_iGiaveID = Convert.ToInt16( fK_iGiaveID);
            this.iSoluong = Convert.ToInt32( iSoluong);
            FK_iHoadonID =  Convert.ToInt64(fK_iHoadonID);
        }

        [Key]
        public long PK_iCTHDID { get; set; }

        public long FK_iVexeID { get; set; }

        public short FK_iGiaveID { get; set; }

        public int iSoluong { get; set; }

        public long FK_iHoadonID { get; set; }

        public virtual tbl_Giave tbl_Giave { get; set; }

        public virtual tbl_Hoadon tbl_Hoadon { get; set; }

        public virtual tbl_Vexe tbl_Vexe { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_CTHD> GetCTHDByPK(long cthdID)
        {
            List<tbl_CTHD> dscthoadon = new List<tbl_CTHD>();
            cmd = new SqlCommand("sp_GetCTHDByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cthdID", cthdID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_CTHD cthd = new tbl_CTHD(
                      dar["PK_iCTHDID"].ToString(),
                      dar["FK_iVexeID"].ToString(),
                      dar["FK_iGiaveID"].ToString(),
                      dar["iSoluong"].ToString(),
                      dar["FK_iHoadonID"].ToString());
                    dscthoadon.Add(cthd);
                } 
                
            }
            conn.Close();
            return dscthoadon;
        }
        public bool InsertCTHD( long vexeID, short giaveID, int soluong, long hoadonID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertCTHD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@vexeID", vexeID);
                cmd.Parameters.AddWithValue("@giaveID", giaveID);
                cmd.Parameters.AddWithValue("@soluong", soluong);
                cmd.Parameters.AddWithValue("@hoadonID", hoadonID);
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


        public bool UpdateCTHD(long CTHDID,long vexeID, short giaveID, int soluong, long hoadonID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateCTHD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maCTHDID", CTHDID);
                cmd.Parameters.AddWithValue("@vexeID", vexeID);
                cmd.Parameters.AddWithValue("@giaveID", giaveID);
                cmd.Parameters.AddWithValue("@soluong", soluong);
                cmd.Parameters.AddWithValue("@hoadonID", hoadonID);
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

        public bool DeleteCTHD(long CTHDID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteCTHD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maCTHDID", CTHDID);
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
