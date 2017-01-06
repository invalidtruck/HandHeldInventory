using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using invsys.Mobile.Data.Core;
using System.Data.SqlServerCe;
using System.Data;

namespace invsys.Mobile.Data.Login
{
    public class Login
    {
        public bool GetLogin(string us, string pass, out String Err)
        {
            try
            {
                var cmd = new SqlCeCommand("SELECT COUNT(1) FROM "
                    + Tables.CATUSUARIOS +
                    " WHERE Usuario = @us AND contrasena =@pass", Conexion.GetConexion());
                cmd.Parameters.AddWithValue("@us", us);
                cmd.Parameters.AddWithValue("@pass", pass);
                Err = null;
                return (int)cmd.ExecuteScalar() > 0;
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return false;
            }
        }

        public DataTable DDLConexionesEmpresas(out String Err)
        {
            try
            {
                var cmd = new SqlCeCommand("select * from " + Tables.CATCONEXIONES, Conexion.GetConexion());
                var dr = cmd.ExecuteReader();
                var dts = new DataTable();
                dts.Load(dr);
                Err = null;
                return dts;
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return null;
            }
        }


        public void GetConexionesWS(out string Err, DataTable dt)
        {
            try
            {
                var cmd = new SqlCeCommand("DELETE " + Tables.CATCONEXIONES, Conexion.GetConexion());
                cmd.ExecuteNonQuery();
                foreach (DataRow item in dt.Rows)
                {
                    cmd = new SqlCeCommand("INSERT INTO " +
                        Tables.CATCONEXIONES +
                        " values( @NombreEmpresa,@IdCon)",
                        Conexion.GetConexion());
                    cmd.Parameters.AddWithValue("@IdCon", item["IdCon"]);
                    cmd.Parameters.AddWithValue("@NombreEmpresa", item["NombreEmpresa"]);
                    cmd.ExecuteNonQuery();
                }
                Err = null;
            }
            catch (Exception ex)
            {
                Err = ex.Message;
            }
        }
    }
}
