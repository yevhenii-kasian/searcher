using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace SearcherWPF
{
    [Serializable]
    public abstract class WebSite
    {
        protected string Name { get; set; }
        protected string Url { get; set; }
        protected string Filters { get; set; }
 
        protected WebSite()
        {
        }

        protected WebSite(string name, string url, string filters)
        {
            Name = name;
            Url = url;
            Filters = filters;
        }

        public static void SaveToBin(List<WebSite> siteList)
        {
            FileStream fs = new FileStream("sites.dat", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, siteList);
            }
            catch (SerializationException e)
            {
                //Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                // do smth with exeption (:
                MessageBox.Show(e.Message, "Error");
            }
            finally
            {
                fs.Close();
            }
        }

        public static void SaveToXml(List<WebSite> sitelList)
        {
            // think about XML... for what? o_0
        }

        public static List<WebSite> OpenBin()
        {
            List<WebSite> sites;
            using (FileStream fs = new FileStream("sites.dat", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                sites = (List<WebSite>) formatter.Deserialize(fs);
            }
            return sites;
        }

        public static List<WebSite> OpenXml()
        {
            return new List<WebSite>();
        }
    }
}
