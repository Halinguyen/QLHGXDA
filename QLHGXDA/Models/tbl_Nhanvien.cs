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

    public partial class tbl_Nhanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Nhanvien()
        {
            
        }

        public tbl_Nhanvien(string pK_iNhanvienID, string sHoten, string sSodienthoai, string sDiachi, string bGioitinh, string sSoCMND, string tNgaysinh, string tNgayvaolam, string iTrangthailamviec, string fK_iTaikhoanID)
        {
            PK_iNhanvienID = Convert.ToInt16( pK_iNhanvienID);
            this.sHoten = sHoten;
            this.sSodienthoai = sSodienthoai;
            this.sDiachi = sDiachi;
            this.bGioitinh = Convert.ToBoolean( bGioitinh);
            this.sSoCMND = sSoCMND;
            this.tNgaysinh = Convert.ToDateTime( tNgaysinh);
            this.tNgayvaolam = Convert.ToDateTime( tNgayvaolam);
            this.iTrangthailamviec = Convert.ToByte( iTrangthailamviec);
            FK_iTaikhoanID = Convert.ToInt64( fK_iTaikhoanID);
        }

        [Key]
        public short PK_iNhanvienID { get; set; }

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

        [Required]
        [StringLength(12)]
        public string sSoCMND { get; set; }

        public DateTime tNgaysinh { get; set; }

        public DateTime tNgayvaolam { get; set; }

        public byte iTrangthailamviec { get; set; }

        public long FK_iTaikhoanID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Calam_Nhanvien> tbl_Calam_Nhanvien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Hoadon> tbl_Hoadon { get; set; }

        public virtual tbl_Taikhoan tbl_Taikhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Xeravao> tbl_Xeravao { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_Nhanvien> GetNhanvienByPK(short nhanvienID)
        {
            List<tbl_Nhanvien> dsNhanvien = new List<tbl_Nhanvien>();
            cmd = new SqlCommand("sp_GetNhavienByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nhanvienID", nhanvienID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Nhanvien nv = new tbl_Nhanvien(
                      dar["PK_iNhanvienID"].ToString(),
                      dar["sHoten"].ToString(),
                      dar["sSodienthoai"].ToString(),
                      dar["sDiachi"].ToString(),
                      dar["bGioitinh"].ToString(),
                      dar["sSoCMND"].ToString(),
                      dar["tNgaysinh"].ToString(),
                      dar["tNgayvaolam"].ToString(),
                      dar["iTrangthailamviec"].ToString(),
                      dar["FK_iTaikhoanID"].ToString());
                    dsNhanvien.Add(nv);
                }
            }
            conn.Close();
            return dsNhanvien;
        }
    }
}
