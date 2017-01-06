using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace invsys.Mobile.Logic
{
    public class Core
    {
        public static int IdHandHeld { get; set; }
        public static void Parameters()
        {
            try
            {
                string dir = Assembly.GetExecutingAssembly().GetName().CodeBase;
                dir = dir.Substring(0, dir.LastIndexOf("\\"));

                var x = System.IO.File.OpenText(dir + "\\config.ivt");
                Core.IdHandHeld = Convert.ToInt32(x.ReadLine().Trim());
                x.Close();

            }
            catch (Exception ex)
            {
            }
        }
    }
}
