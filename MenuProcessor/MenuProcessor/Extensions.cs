using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuProcessor
{
    public static class Extensions
    {
        public static void appendError(this SortedDictionary<int, string> output)
        {
            var keys = output.Keys;
            var next = keys.Any() ? keys.Max() + 1 : 1;
            output.Add(next, Resources.ERROR);
        }
    }
}
