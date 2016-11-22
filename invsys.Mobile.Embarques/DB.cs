using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using ErikEJ.SqlCe;
using System.Reflection;

namespace invsys.Mobile.Embarques
{
    public class DB
    {
        private static string dir = Assembly.GetExecutingAssembly().GetName().CodeBase;
        public static string getcnnString()
        {
            
            dir = dir.Substring(0, dir.LastIndexOf("\\"));
            var x = System.IO.File.OpenText(dir + "\\config.ivt");
            var id = x.ReadLine();
            var sd = x.ReadLine().Replace("path=", "").Trim();
            x.Close();
            return Path.Combine(sd, "\\EmbInv.sdf;Max Database Size=4091");
        }
    }
    public class StorageCardFinder
    {
        public static List<string> GetMountDirs()
        {
            //get default sd card folder name
            string key = @"HKEY_LOCAL_MACHINE\System\StorageManager\Profiles";
            RegistryKey profiles = Registry.LocalMachine.OpenSubKey(@"System\StorageManager\Profiles");
            string sdprofilename = profiles.GetSubKeyNames().FirstOrDefault(k => k.Contains("SD"));
            if (sdprofilename == null)
                return new List<string>();

            key += "\\" + sdprofilename;
            string storageCardBaseName = Registry.GetValue(key, "Folder", "Storage Card") as String;
            if (storageCardBaseName == null)
                return new List<string>();

            //find storage card
            List<string> cardDirectories = GetFlashCardMountDirs();

            List<string> storageCards = new List<string>();
            foreach (string flashCard in GetFlashCardMountDirs())
            {
                string path = flashCard.Trim();
                if (path.StartsWith(storageCardBaseName))
                {
                    storageCards.Add("\\" + path);
                }
            }
            return storageCards;
        }

        private static List<string> GetFlashCardMountDirs()
        {
            DirectoryInfo root = new DirectoryInfo("\\");
            return root.GetDirectories().Where(d => (d.Attributes & FileAttributes.Temporary) != 0)
                                        .Select(d => d.Name).ToList();
        }

        internal static IEnumerable<object> GetMountrDirs()
        {
            throw new NotImplementedException();
        }
    }
}