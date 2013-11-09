﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tmp
{
    class Program
    {
        static void Main()
        {
            List<ISite> siteList = new List<ISite>();

            MyClass m = new MyClass();
            m.Name = "site 1";
            m.Filter = "filter 1";
            siteList.Add(m);

            MyClass2 m2 = new MyClass2 { Name = "site 2", Filter = "filter 2" };
            siteList.Add(m2);

            Task<Dictionary<string, string>>[] tasks = new Task<Dictionary<string, string>>[2];
            for (int i = 0; i < 2; i++)
            {
                tasks[i] = Task<Dictionary<string, string>>.Factory.StartNew(siteList[i].Checker);
            }
            Task.WaitAll(tasks); // think about :)


            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < siteList.Count; i++)
            {
                Console.WriteLine(siteList[i].Name + "\t" + siteList[i].Filter);
                foreach (var task in tasks[i].Result)
                {
                    Console.WriteLine("\t" + "--> " + task.Key + "\t" + task.Value);
                }
                Console.WriteLine(new string('_', 30) + "\n");
            }
            SitesIo.SaveToBin(siteList);
            ///////////////////////////
            List<ISite> sites = SitesIo.OpenBin();
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var site in sites)
            {
                Console.WriteLine(site.Name + "\t" + site.Filter);
                foreach (var s in site.TopicDictionary)
                {
                    Console.WriteLine("\t" + "--> " + s.Key + "\t" + s.Value);
                }
                Console.WriteLine(new string('_', 30) + "\n");
            }

        }
    }
    [Serializable]
    class MyClass : ISite
    {
        public string Name { get; set; }
        public string Filter { get; set; }
        public string SiteUri { get; set; }
        public Dictionary<string, string> TopicDictionary { get; set; }

        public Dictionary<string, string> Checker()
        {
            TopicDictionary = new Dictionary<string, string>();
            TopicDictionary["topic site 111"] = "url for topic site 111";
            TopicDictionary["topic site 111----2"] = "url for topic site 111----2";
            TopicDictionary["topic site 111----3"] = "url for topic site 111----3";
            return TopicDictionary;
        }
    }
    [Serializable]
    class MyClass2 : ISite
    {
        public string Name { get; set; }
        public string Filter { get; set; }
        public string SiteUri { get; set; }
        public Dictionary<string, string> TopicDictionary { get; set; }

        public Dictionary<string, string> Checker()
        {
            TopicDictionary = new Dictionary<string, string>();
            TopicDictionary["topic site 222"] = "url for topic site 222";
            return TopicDictionary;
        }
    }
}
