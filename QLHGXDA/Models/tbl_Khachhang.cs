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

    public partial class tbl_Khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Khachhang()
        {

        }

        public tbl_Khachhang(string pK_iKhachhangID, string sHoten, string sSodienthoai, string sDiachi, string bGioitinh, string tNgaysinh, string sSoCMND, string fK_iTaikhoanID, string fK_iVeID)
        {
            PK_iKhachhangID = Convert.ToInt64(pK_iKhachhangID);
            this.sHoten = sHoten;
            this.sSodienthoai = sSodienthoai;
            this.sDiachi = sDiachi;
            this.bGioitinh = Convert.ToBoolean(bGioitinh);
            this.tNgaysinh = Convert.ToDateTime(tNgaysinh);
            this.sSoCMND = sSoCMND;
            FK_iTaikhoanID = Convert.ToInt64(fK_iTaikhoanID);
            FK_iVeID = Convert.ToInt64(fK_iVeID);
        }

        [Key]
        public long PK_iKhachhangID { get; set; }

        [Required]
        [StringLength(50)]
        public string sHoten { get; set; }

        [Required]
        [StringLength(10)]
        public string sSodienthoai { get; set; }

        [Required]
        [StringLength(150)]
        public string sDiachi { get; set; }

        public bool bGioitinh { get; set; }

        public DateTime tNgaysinh { get; set; }

        [Required]
        [StringLength(12)]
        public string sSoCMND { get; set; }

        public long FK_iTaikhoanID { get; set; }

        public long? FK_iVeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Hoadon> tbl_Hoadon { get; set; }

        public virtual tbl_Taikhoan tbl_Taikhoan { get; set; }

        public virtual tbl_Vexe tbl_Vexe { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

        SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_Khachhang> GetKhachhangByPK(long khachhangID)
        {
            List<tbl_Khachhang> dsKhachhang = new List<tbl_Khachhang>();
            cmd = new SqlCommand("sp_GetKhachhangByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@khachhangID", khachhangID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Khachhang kh = new tbl_Khachhang(
                      dar["PK_iKhachhangID"].ToString(),
                      dar["sHoten"].ToString(),
                      dar["sSodienthoai"].ToString(),
                      dar["sDiachi"].ToString(),
                      dar["bGioitinh"].ToString(),
                      dar["tNgaysinh"].ToString(),
                      dar["sSoCMND"].ToString(),
                      dar["FK_iTaikhoanID"].ToString(),
                      dar["FK_iVeID"].ToString());
                    dsKhachhang.Add(kh);
                }
            }
            conn.Close();
            return dsKhachhang;
        }
    }
}
