using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace tmp
{
    static class SitesIo
    {
        public static void SaveToBin(List<ISite> siteList)
        {
            FileStream fs = new FileStream("sites.dat", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, siteList);
            }
            catch (SerializationException e)
            {
                //MessageBox.Show(e.Message, "Error");
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        public static void SaveToXml(List<ISite> sitelList)
        {
            // think about XML... for what? o_0
        }

        public static List<ISite> OpenBin()
        {
            List<ISite> sites;
            using (FileStream fs = new FileStream("sites.dat", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                sites = (List<ISite>)formatter.Deserialize(fs);
            }
            return sites;
        }

        public static List<ISite> OpenXml()
        {
            return new List<ISite>();
        }

    }
}
