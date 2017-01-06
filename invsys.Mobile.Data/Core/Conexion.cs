using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Reflection;

namespace invsys.Mobile.Data.Core
{
    public static class Conexion
    {
        private static SqlCeConnection cnn;
        private static string dir = Assembly.GetExecutingAssembly().GetName().CodeBase
            .Substring(0, Assembly.GetExecutingAssembly().GetName().CodeBase.LastIndexOf("\\"));
        public static SqlCeConnection GetConexion()
        {
            var cnn = new SqlCeConnection("Data Source=" + (dir + "\\EmbInv.sdf" + ";Max Database Size=4091"));
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();

                return cnn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
