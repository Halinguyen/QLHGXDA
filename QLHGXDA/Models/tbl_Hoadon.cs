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

    public partial class tbl_Hoadon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Hoadon()
        {
           
        }

        public tbl_Hoadon(string pK_iHoadonID, string fK_iKhachhangID, string fK_iNhanvienID, string bTrangthai, string tNgaylap)
        {
            PK_iHoadonID = Convert.ToInt64(pK_iHoadonID);
            FK_iKhachhangID = Convert.ToInt64( fK_iKhachhangID);
            FK_iNhanvienID = Convert.ToInt16( fK_iNhanvienID);
            this.bTrangthai = Convert.ToBoolean( bTrangthai);
            this.tNgaylap = Convert.ToDateTime( tNgaylap);
        }

        [Key]
        public long PK_iHoadonID { get; set; }

        public long FK_iKhachhangID { get; set; }

        public short FK_iNhanvienID { get; set; }

        public bool bTrangthai { get; set; }

        public DateTime tNgaylap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CTHD> tbl_CTHD { get; set; }

        public virtual tbl_Khachhang tbl_Khachhang { get; set; }

        public virtual tbl_Nhanvien tbl_Nhanvien { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_Hoadon> GetHoadonByPK(long hoadonID)
        {
            List<tbl_Hoadon> dsHoadon = new List<tbl_Hoadon>();
            cmd = new SqlCommand("sp_GetHoadonByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@hoadonID", hoadonID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Hoadon hd = new tbl_Hoadon(
                      dar["PK_iHoadonID"].ToString(),
                      dar["FK_iKhachhangID"].ToString(),
                      dar["FK_iNhanvienID"].ToString(),
                      dar["bTrangthai"].ToString(),                    
                      dar["tNgaylap"].ToString());
                    dsHoadon.Add(hd);
                }
            }
            conn.Close();
            return dsHoadon;
        }
    }
}
