using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tmp
{
    class Program
    {
        static void Main()
        {

            List<ISite> siteList = new List<ISite>(); // список сайтів


            //створили один сайт -- 0day
            MyClass m = new MyClass();
            m.Name = "site 1";
            m.Filter = "filter 1";
            siteList.Add(m);

            //створили 2й сайт -- сландо
            MyClass2 m2 = new MyClass2 { Name = "site 2", Filter = "filter 2" };
            siteList.Add(m2);

            Task<Dictionary<string, string>>[] tasks = new Task<Dictionary<string, string>>[2]; // порахували скільки елементів в списку --- ListView.Count; ---  у нас зараз 2 елемента. Для кожного хуярим свій асинхронний поток
            for (int i = 0; i < 2; i++)
            {
                tasks[i] = Task<Dictionary<string, string>>.Factory.StartNew(siteList[i].Checker); // кожного запускаэмо метод в якому виконується вся логіка
            }
            Task.WaitAll(tasks); // чекаємо завершення задач-потоків

            // виводимо кудись всю цю муть гуі чи ще куди
            foreach (var task in tasks)
            {
                Dictionary<string, string> res = task.Result;
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var re in res)
                {
                    Console.WriteLine(m.Name + "\t" + m.Filter);
                    Console.WriteLine(re.Key + "\t" + re.Value);
                    Console.WriteLine(new string('_', 30) + "\n");
                }
            }
            // закрили прогу і зберігли
            SitesIo.SaveToBin(siteList);
            ///////////////////////////
            // відкрили прогу і прочитали з файлу
            List<ISite> sites = SitesIo.OpenBin();
            // вивели
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var site in sites)
            {
                Console.WriteLine(site.Name + "\t" + site.Filter);
                foreach (var s in site.TopicDictionary)
                {
                    Console.WriteLine(s.Key + "\t" + s.Value);
                }
                Console.WriteLine(new string('_', 30) + "\n");
            }

        }
    }
    // перший сайт
    [Serializable] // обов'язковий атрибут, щоб сутність сайту зберігалась в файл
    class MyClass : ISite
    {
        public string Name { get; set; }
        public string Filter { get; set; }
        public string SiteUri { get; set; }
        public Dictionary<string, string> TopicDictionary { get; set; }

        public Dictionary<string, string> Checker()
        {
            // логіка робити і фільтрування
            TopicDictionary = new Dictionary<string, string>();
            TopicDictionary["topic site 111"] = "url for topic site 111";
            // + всі інші топіки
            return TopicDictionary;
        }
    }
    // другий сайт
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
            // + всі інші топіки
            return TopicDictionary;
        }
    }
}
