using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public class Drinks
    {
        private List<Drink> drinks;

        public List<Drink> GetDrinks()
        {
            return drinks;
        }

        public void SetDrinks(List<Drink> value)
        {
            drinks = value;
        }
    }
}