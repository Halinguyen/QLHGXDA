using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLHGXDA.Models
{
    public class TTXe : tbl_Xe
    {
        string mavexe;
        string tenLoaixe;

        public string sMasove { get => mavexe; set => mavexe = value; }
        public string sTenloaixe { get => tenLoaixe; set => tenLoaixe = value; }
        public TTXe() { }

        public TTXe(string pK_iXeID, string fK_iLoaixeID, string sBiensoxe, string sAnhxe, string mavexe, string tenLoaixe)
        {
            PK_iXeID = Convert.ToInt64(pK_iXeID);
            FK_iLoaixeID = Convert.ToByte(fK_iLoaixeID);
            this.sBiensoxe = sBiensoxe;
            this.sAnhxe = sAnhxe;
            this.mavexe = mavexe;
            this.tenLoaixe = tenLoaixe;
        }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        SqlDataReader dar;
        SqlCommand cmd;
        public List<TTXe> GetTTXe()
        {
            List<TTXe> dsTTxe = new List<TTXe>();
            cmd = new SqlCommand("sp_GetTTVexe", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    TTXe ttxe = new TTXe(
                         dar["PK_iXeID"].ToString(),
                      dar["FK_iLoaixeID"].ToString(),
                      dar["sBiensoxe"].ToString(),
                      dar["sAnhxe"].ToString(),
                    dar["sMasove"].ToString(),
                      dar["sTenloaive"].ToString());
                    dsTTxe.Add(ttxe);
                }
            }
            conn.Close();
            return dsTTxe;
        }
    }
}