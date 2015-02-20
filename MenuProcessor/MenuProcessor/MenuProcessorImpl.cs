using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuProcessor
{
    class MenuProcessorImpl : IMenuProcessor
    {
        private static readonly Dictionary<string, IMealHandler> m_mealHandlers = new Dictionary<string, IMealHandler> 
        {
            {Resources.MORNING, new MorningMealHandler()},
            {Resources.NIGHT, new NightMealHandler()}
        };
        
        private MenuProcessorImpl() { }

        private void process(StringBuilder sb, string order)
        {
            var parts = order.Split(',');
            if (parts.Length == 0)
            {
                sb.Append(Resources.ERROR);
            }
            else
            {
                var meal = parts[0].ToLowerInvariant();
                var items = parts.Skip(1).ToList();
                if (m_mealHandlers.ContainsKey(meal)) 
                    m_mealHandlers[meal].ProcessItems(sb, items);
                else
                    sb.Append(Resources.ERROR);
            }
        }

        public static IMenuProcessor create()
        {
            return new MenuProcessorImpl();
        }

        public string ProcessOrder(string order) 
        {
            var sb = new StringBuilder();
            if (string.IsNullOrEmpty(order)) 
                sb.Append(Resources.ERROR);
            else
                process(sb, order);
            return sb.ToString();
        }
    }
}
