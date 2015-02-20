using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuProcessor
{
    public static class MenuProcessorFactory
    {
        private static readonly IMenuProcessor m_processor = MenuProcessorImpl.create();
        
        public static IMenuProcessor getInstance() 
        {
            return m_processor;
        }

    }
}
