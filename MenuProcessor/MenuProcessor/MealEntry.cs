using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuProcessor
{
    class MealEntry
    {
        private readonly string m_name;
        private readonly bool m_moreThanOne;
        private int m_count;

        private bool addNewItemToOutputAndReturnContinueFlag(int dish, SortedDictionary<int, string> output)
        {
            //preconditions 
            if (output.ContainsKey(dish))
            {
                output.appendError();
                return false;
            }

            m_count++;
            output.Add(dish, m_name);
            return true;
        }

        private bool addExistingItemToOutputAndReturnContinueFlag(int dish, SortedDictionary<int, string> output)
        {
            //preconditions 
            if (!output.ContainsKey(dish))
            {
                output.appendError();
                return false;
            }

            if (!m_moreThanOne)
            {
                output.appendError();
                return false;
            }

            m_count++;
            output[dish] = string.Format("{0}(x{1})", m_name, m_count); 
            return true;
        }

        private MealEntry(string name, bool moreThanOne)
        {
            m_name = name;
            m_moreThanOne = moreThanOne;
            m_count = 0;
        }

        public static MealEntry createWithDishNameAndMoreThanOneFlag(string name, bool moreThanOne)
        {
            return new MealEntry(name, moreThanOne);
        }

        public bool addItemToOutputAndReturnContinueFlag(int dish, SortedDictionary<int, string> output) 
        {
            if (output.ContainsKey(dish))
                return addExistingItemToOutputAndReturnContinueFlag(dish, output);
            else
                return addNewItemToOutputAndReturnContinueFlag(dish, output);
        }
    }
}
