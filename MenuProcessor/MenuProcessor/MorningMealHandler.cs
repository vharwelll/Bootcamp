using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuProcessor
{
    class MorningMealHandler : MealHandlerBase
    {
        protected override Dictionary<int, MealEntry> getRules()
        {
            return new Dictionary<int, MealEntry>
                {
                    {DishType.Entree, MealEntry.createWithDishNameAndMoreThanOneFlag("eggs", false)},
                    {DishType.Side, MealEntry.createWithDishNameAndMoreThanOneFlag("toast", false)},
                    {DishType.Drink, MealEntry.createWithDishNameAndMoreThanOneFlag("coffee", true)},
                };
        }
    }
}
