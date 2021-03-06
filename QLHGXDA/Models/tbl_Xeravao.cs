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

    public partial class tbl_Xeravao
    {
        public tbl_Xeravao()
        {

        }

        public tbl_Xeravao(string pK_iXeravaoID, string fK_iXeID, string fK_iVexeID, string fK_NhanvienID, string tThoigianvao, string tThoigianra)
        {
            PK_iXeravaoID = Convert.ToInt64( pK_iXeravaoID);
            FK_iXeID = Convert.ToInt64( fK_iXeID);
            FK_iVexeID = Convert.ToInt64( fK_iVexeID);
            FK_NhanvienID = Convert.ToInt16( fK_NhanvienID);
            this.tThoigianvao = Convert.ToDateTime( tThoigianvao);
            this.tThoigianra = Convert.ToDateTime( tThoigianra);
        }

        [Key]
        public long PK_iXeravaoID { get; set; }

        public long FK_iXeID { get; set; }

        public long FK_iVexeID { get; set; }

        public short FK_NhanvienID { get; set; }

        public DateTime tThoigianvao { get; set; }

        public DateTime? tThoigianra { get; set; }

        public virtual tbl_Nhanvien tbl_Nhanvien { get; set; }

        public virtual tbl_Vexe tbl_Vexe { get; set; }

        public virtual tbl_Xe tbl_Xe { get; set; }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

        SqlDataReader dar;
        SqlCommand cmd;
        public List<tbl_Xeravao> GetXeravaoByPK(long xeravaoID)
        {
            List<tbl_Xeravao> dsXeravao = new List<tbl_Xeravao>();
            cmd = new SqlCommand("sp_GetXeravaoByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@xeravaoID", xeravaoID);
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    tbl_Xeravao xeravao = new tbl_Xeravao(
                      dar["PK_iXeravaoID"].ToString(),
                      dar["FK_iXeID"].ToString(),
                      dar["FK_iVexeID"].ToString(),
                       dar["FK_NhanvienID"].ToString(),
                      dar["tThoigianvao"].ToString(),
                      dar["tThoigianra"].ToString());
                    dsXeravao.Add(xeravao);
                }
            }
            conn.Close();
            return dsXeravao;
        }
    }
}
