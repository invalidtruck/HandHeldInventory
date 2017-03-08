using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace invsys.core
{
    public class Settings
    {
        public int idHandHeld { get; set; }
        public string dir { get; set; }

        public Settings()
        { 
            // Traer el directorio
            string codebase = Assembly.GetExecutingAssembly().GetName().CodeBase;
            this.dir = codebase.Substring(0, codebase.LastIndexOf("\\"));

            // leer el id de la handheld
            var x = System.IO.File.OpenText(this.dir + "\\config.ivt");
            this.idHandHeld = Convert.ToInt32(x.ReadLine().Trim());
        }
    }
}
