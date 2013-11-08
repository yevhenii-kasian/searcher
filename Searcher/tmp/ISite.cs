using System;
using System.Collections.Generic;

namespace tmp
{
    interface ISite
    {
        string Name { get; set; } // site Name
        string Filter { get; set; } // key Words
        string SiteUri { get; set; } // site uri
        Dictionary<string, string> TopicDictionary { get; set; } //dict of topics (topicname - url) || (topicname - url)

        Dictionary<string, string> Checker(); // for async threds --- у кожного класа сайта своя реалізація
    }
}
