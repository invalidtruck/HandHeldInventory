using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using invsys.Mobile.Data.Core;
using invsys.Mobile.Data.Login;
using System.Data;

namespace invsys.Mobile.Logic.Login
{
    public class Login
    {
        public bool GetLogin(string us, string pass, out string Err)
        {
            return new Data.Login.Login().GetLogin(us, pass, out Err);
        }

        public DataTable DDLConexionesEmpresas(out string Err)
        {
            return new invsys.Mobile.Data.Login.Login().DDLConexionesEmpresas(out Err);
        }
        public void GetConexionesWS(out string Err, DataTable dt) {
             new invsys.Mobile.Data.Login.Login().GetConexionesWS(out Err, dt);
        }
    }
}
