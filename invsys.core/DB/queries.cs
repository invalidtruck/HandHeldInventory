using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace invsys.core.DB
{
    public class queries
    {

    }

    public partial class Login
    {
        public static string FIND_USER = "select count(1) from catUsuarios where Usuario = @us and contrasena =@pass";

    }
    public class Embarques
    {

    }
    public class Inventario
    {

    }
}
