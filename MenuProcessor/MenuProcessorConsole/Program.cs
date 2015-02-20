using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuProcessor;

namespace MenuProcessorConsole
{
    class Program
    {
        private static readonly IMenuProcessor m_processor = MenuProcessorFactory.getInstance();
 
        public static void Main(string[] args)
        {
            var input = string.Join(string.Empty, args);
            string output = null;
            try 
            {
                output = m_processor.ProcessOrder(input);
            }
            catch (Exception e) 
            {
                Console.WriteLine("Exception occured processing menu order '{0}', message is: {1}", input, e.Message);
                Console.WriteLine(e.StackTrace);
                // just being paranoid, exception should preclude the processor returning anything...
                output = null;
            }
            if (!string.IsNullOrEmpty(output))
            {
                Console.WriteLine(output);
            }
        }
    }
}
