using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuProcessor
{
    interface IMealHandler
    {
        void ProcessItems(StringBuilder sb, List<string> items);
    }
}
