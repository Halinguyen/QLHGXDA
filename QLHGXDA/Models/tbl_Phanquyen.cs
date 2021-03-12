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

    public partial class tbl_Phanquyen
    {
        public tbl_Phanquyen() { }

        public tbl_Phanquyen(string pK_iPhanquyenID, string fK_iQuyenID, string fK_iTaikhoanID, string tNgaybatdau, string tNgayhethan)
        {
            PK_iPhanquyenID = Convert.ToInt16( pK_iPhanquyenID);
            FK_iQuyenID = Convert.ToInt16( fK_iQuyenID);
            FK_iTaikhoanID =Convert.ToInt64( fK_iTaikhoanID);
            this.tNgaybatdau = Convert.ToDateTime( tNgaybatdau);
            this.tNgayhethan = Convert.ToDateTime( tNgayhethan);
        }

        [Key]
        public short PK_iPhanquyenID { get; set; }

        public short FK_iQuyenID { get; set; }

        public long FK_iTaikhoanID { get; set; }

        public DateTime tNgaybatdau { get; set; }

        public DateTime tNgayhethan { get; set; }

        public virtual tbl_Quyen tbl_Quyen { get; set; }

        public virtual tbl_Taikhoan tbl_Taikhoan { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_Phanquyen> GetPhanquyenByPK(short phanquyenID)
        {
            List<tbl_Phanquyen> dsPhanquyen = new List<tbl_Phanquyen>();
            cmd = new SqlCommand("sp_GetPhanquyenByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@phanquyenID", phanquyenID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Phanquyen pq = new tbl_Phanquyen(
                      dar["PK_iPhanquyenID"].ToString(),
                      dar["FK_iQuyenID"].ToString(),
                        dar["FK_iTaikhoanID"].ToString(),
                      dar["tNgaybatdau"].ToString(),
                      dar["tNgayhethan"].ToString());
                    dsPhanquyen.Add(pq);
                }
            }
            conn.Close();
            return dsPhanquyen;
        }
        public List<tbl_Phanquyen> GetPhanquyenByFK_iTaikhoanID (long taikhoanID)
        {
            List<tbl_Phanquyen> dsPhanquyen = new List<tbl_Phanquyen>();
            cmd = new SqlCommand("sp_GetPhanquyenByFK_iTaikhoanID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoanID", taikhoanID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Phanquyen pq = new tbl_Phanquyen(
                      dar["PK_iPhanquyenID"].ToString(),
                      dar["FK_iQuyenID"].ToString(),
                        dar["FK_iTaikhoanID"].ToString(),
                      dar["tNgaybatdau"].ToString(),
                      dar["tNgayhethan"].ToString());
                    dsPhanquyen.Add(pq);
                }
            }
            conn.Close();
            return dsPhanquyen;
        }

        public bool InsertPhanQuyen(short quyenID, long taikhoanID, DateTime ngaybatdau, DateTime ngayhethan)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertPhanquyen", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@quyenID", quyenID);
                cmd.Parameters.AddWithValue("@taikhoanID", taikhoanID);
                cmd.Parameters.AddWithValue("@ngaybatdau", ngaybatdau);
                cmd.Parameters.AddWithValue("@ngayhethan", ngayhethan);
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



        public bool UpdatePhanQuyen(short phanquyenID,short quyenID, long taikhoanID, DateTime ngaybatdau, DateTime ngayhethan)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdatePhanquyen", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@quyenID", quyenID);
                cmd.Parameters.AddWithValue("@taikhoanID", taikhoanID);
                cmd.Parameters.AddWithValue("@ngaybatdau", ngaybatdau);
                cmd.Parameters.AddWithValue("@ngayhethan", ngayhethan);
                cmd.Parameters.AddWithValue("@phanquyenID", phanquyenID);
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

        public bool DeletePhanQuyen(short phanquyenID)
        {
            bool ketqua = false;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeletePhanquyen", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@phanquyenID", phanquyenID);
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
