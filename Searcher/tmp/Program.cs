using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tmp
{
    class Program
    {
        static void Main()
        {
            // Tasks
            //List<Task> taskList;

            List<ISite> siteList = new List<ISite>(); // список сайтів


            //створили один сайт -- 0day
            MyClass m = new MyClass();
            m.Name = "ololo";
            m.Filter = "123";
            siteList.Add(m);

            //створили 2й сайт -- сландо
            MyClass2 m2 = new MyClass2 { Name = "22222", SiteUri = "-------------" };
            siteList.Add(m2);

            //var t = Task<Dictionary<string, string>>.Factory.StartNew(m.Checker);

            //Dictionary<string, string> res = t.Result;
            //    foreach (var re in res)
            //    {
            //        Console.WriteLine(m.Name + "\t" + m.Filter);
            //        Console.WriteLine(re.Key + "\t" + re.Value);
            //        Console.WriteLine(new string('_', 30) + "\n");

            //    }


            Task<Dictionary<string, string>>[] tasks = new Task<Dictionary<string, string>>[2]; // порахували скільки елементів в списку --- ListView.Count; ---  у нас зараз 2 елемента. Для кожного хуярим свій асинхронний поток
            for (int i = 0; i < 2; i++)
            {
                tasks[i] = Task<Dictionary<string, string>>.Factory.StartNew(siteList[i].Checker); // кожного запускаэмо метод в якому виконується вся логіка
            }
            Task.WaitAll(tasks); // чекаємо завершення задач-потоків

            foreach (var task in tasks)
            {
                Dictionary<string, string> res = task.Result;
                foreach (var re in res)
                {
                    Console.WriteLine(m.Name + "\t" + m.Filter);
                    Console.WriteLine(re.Key + "\t" + re.Value);
                    Console.WriteLine(new string('_', 30) + "\n");

                }
            }



        }
    }

    class MyClass : ISite
    {
        public string Name { get; set; }
        public string Filter { get; set; }
        public string SiteUri { get; set; }
        public Dictionary<string, string> TopicDictionary { get; set; }

        public Dictionary<string, string> Checker()
        {
            var dict = new Dictionary<string, string>();
            dict["topic"] = "url for topic";
            return dict;
        }
    }

    class MyClass2 : ISite
    {
        public string Name { get; set; }
        public string Filter { get; set; }
        public string SiteUri { get; set; }
        public Dictionary<string, string> TopicDictionary { get; set; }

        public Dictionary<string, string> Checker()
        {
            var dict = new Dictionary<string, string>();
            dict["topic22222"] = "url for topic2222222";
            return dict;
        }
    }
}
