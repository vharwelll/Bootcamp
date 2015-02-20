using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuProcessor
{
    abstract class MealHandlerBase : IMealHandler
    {
        public static class DishType
        {
            public const int Entree = 1;
            public const int Side = 2;
            public const int Drink = 3;
            public const int Dessert = 4;
        }

        private static void addOutputToBuilder(SortedDictionary<int, string> output, StringBuilder sb)
        {
            bool addComma = false;
            foreach (var key in output.Keys)
            {
                if (addComma) sb.Append(", ");
                sb.Append(output[key]);                
                addComma = true;
            }
        }

        protected abstract Dictionary<int, MealEntry> getRules();

        public void ProcessItems(StringBuilder sb, List<string> items)
        {
            var output = new SortedDictionary<int, string>();
            if (items.Count == 0)
            {
                output.appendError();
            }
            else
            {
                var rules = getRules();

                foreach (var item in items)
                { 
                    int dish;

                    // can't parse string to int? then error
                    if (!int.TryParse(item, out dish)) 
                    {
                        output.appendError();
                        break;
                    }

                    // valid meal entry id for this meal?
                    if (!rules.ContainsKey(dish))
                    {
                        output.appendError();
                        break;
                    }

                    var mealEntry = rules[dish];
                    if (!mealEntry.addItemToOutputAndReturnContinueFlag(dish, output))
                    {
                        break;
                    }

                }
            }
            addOutputToBuilder(output, sb);
        }
    }
}
