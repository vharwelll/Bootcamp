using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuProcessor
{
    class NightMealHandler : MealHandlerBase
    {
        protected override Dictionary<int, MealEntry> getRules()
        {
            return new Dictionary<int, MealEntry>
                {
                    {DishType.Entree, MealEntry.createWithDishNameAndMoreThanOneFlag("steak", false)},
                    {DishType.Side, MealEntry.createWithDishNameAndMoreThanOneFlag("potato", true)},
                    {DishType.Drink, MealEntry.createWithDishNameAndMoreThanOneFlag("wine", false)},
                    {DishType.Dessert, MealEntry.createWithDishNameAndMoreThanOneFlag("cake", false)}
                };
        }
    }
}
