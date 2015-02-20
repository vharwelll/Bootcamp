using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuProcessor
{
    public interface IMenuProcessor
    {
        string ProcessOrder(string order);
    }
}
