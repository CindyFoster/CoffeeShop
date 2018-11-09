using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public class MenuItemCategory
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public List<Drink> Drinks { get; set; }
    }
}