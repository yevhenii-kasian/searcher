using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SearcherWPF
{
    [Serializable]
    internal class WebSite
    {
        protected static List<WebSite> Sites;

        public string Name { get; set; }
        public string Url { get; set; }
        public string Filters { get; set; }

        //constructors
        public WebSite()
        {
        }
        public WebSite(string name, string url, string filters)
        {
            Name = name;
            Url = url;
            Filters = filters;
        }

        static void SaveToBin(List<WebSite> siteList)
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
            }
            finally
            {
                fs.Close();
            }
        }

        static void SaveToXml(List<WebSite> sitelList)
        {
            // think about XML... for what? o_0
        }

        private static void OpenBin()
        {
            Sites = null;
            FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                Sites = (List<WebSite>)formatter.Deserialize(fs);
                // повернути все на місця
            }
            catch (SerializationException e)
            {
                //Console.WriteLine("Failed to deserialize. Reason: " + e.Message);

            }
            finally
            {
                fs.Close();
            }
        }

        private static void OpenXml()
        {
            // hz
        }
    }
}
