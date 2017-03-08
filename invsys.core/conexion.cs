using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Reflection;

namespace invsys.core
{
    public class conexion
    {

        public string cnnstr { get; set; }
        public SqlCeConnection cnn { get; set; }

        public conexion()
        {
            var set = new Settings();
            this.cnnstr = "Data Source=" + (set.dir + "\\EmbInv.sdf") + ";Max Database Size=4091";
            this.cnn = new SqlCeConnection(this.cnnstr);
        }

        public DataTable QueryReader(string query, object[] parametros)
        {
            var dt = new DataTable();
            try
            {
                var cmd = new SqlCeCommand(query, this.cnn);
                if (cnn.State == ConnectionState.Closed) cnn.Open();

                foreach (var item in parametros)
                    cmd.Parameters.AddWithValue(item.GetType().Name, item);

                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception) { throw; }
            finally { cnn.Close(); }
            return dt;
        }
    }
}
