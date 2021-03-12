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

    public partial class tbl_Giave
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Giave()
        {
            
        }
        public tbl_Giave(string pK_iGiaveID, string mGia, string fK_iLoaixeID, string fK_iLoaiveID, string fK_iKhunggioID, string tNgayApdung)
        {
            PK_iGiaveID = Convert.ToInt16(pK_iGiaveID);
            this.mGia = Convert.ToDecimal(mGia);
            FK_iLoaixeID = Convert.ToByte
                (fK_iLoaixeID);
            FK_iLoaiveID = Convert.ToByte(fK_iLoaiveID);
            FK_iKhunggioID = Convert.ToInt16( fK_iKhunggioID);
            this.tNgayApdung = Convert.ToDateTime(tNgayApdung);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short PK_iGiaveID { get; set; }

        public decimal mGia { get; set; }

        public byte FK_iLoaixeID { get; set; }

        public byte FK_iLoaiveID { get; set; }

        public short FK_iKhunggioID { get; set; }

        public DateTime tNgayApdung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CTHD> tbl_CTHD { get; set; }

        public virtual tbl_Khunggio tbl_Khunggio { get; set; }

        public virtual tbl_Loaive tbl_Loaive { get; set; }

        public virtual tbl_Loaixe tbl_Loaixe { get; set; }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_Giave> GetGiaveByPK(short giaveID)
        {
            List<tbl_Giave> dsGiave = new List<tbl_Giave>();
            cmd = new SqlCommand("sp_GetGiaveByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@giaveID", giaveID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Giave gv = new tbl_Giave(
                      dar["PK_iGiaveID"].ToString(),
                      dar["mGia"].ToString(),
                      dar["FK_iLoaixeID"].ToString(),
                      dar["FK_iLoaiveID"].ToString(),
                      dar["FK_iKhunggioID"].ToString(),
                      dar["tNgayApdung"].ToString());
                    dsGiave.Add(gv);
                }
            }
            conn.Close();
            return dsGiave;
        }
        public bool InsertGiave(double giave, byte loaixeID, byte loaiveID,short khunggioID, DateTime ngayapdung )
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertGiave", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@giave", giave);
                cmd.Parameters.AddWithValue("@maloaixe", loaixeID);
                cmd.Parameters.AddWithValue("@maloaive", loaiveID);
                cmd.Parameters.AddWithValue("@khunggio", khunggioID);
                cmd.Parameters.AddWithValue("@ngayapdung", ngayapdung);
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


        public bool UpdateGiave(short giaveID,double giave, byte loaixeID, byte loaiveID, short khunggioID, DateTime ngayapdung)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateGiave", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@magiave", giaveID);
                cmd.Parameters.AddWithValue("@giave", giave);
                cmd.Parameters.AddWithValue("@maloaixe", loaixeID);
                cmd.Parameters.AddWithValue("@maloaive", loaiveID);
                cmd.Parameters.AddWithValue("@khunggio", khunggioID);
                cmd.Parameters.AddWithValue("@ngayapdung", ngayapdung);
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

        public bool DeleteGiave(short giaveID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteGiave", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@magiave", giaveID);
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
