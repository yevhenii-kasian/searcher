using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearcherWPF
{
    interface ISite
    {
        string ReturnFilter();
        string ReturnName();
        string ReturnUrl();
        List<string> ReturnTitleList();
    }
}
