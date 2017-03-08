using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using DB = invsys.core.DB;

namespace invsys.core.DB
{
    public partial class Login
    {
        public bool GetLogin(string us, string pass, out string err)
        {
            try
            {
                var cnn = new conexion().cnn;
                err = "";
                var cmd = new SqlCeCommand(DB.Login.FIND_USER, cnn);
                cmd.Parameters.AddWithValue("@us", us);
                cmd.Parameters.AddWithValue("@pass", pass);
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                return cmd.ExecuteNonQuery() > 1;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return false;
        }
    }
}
