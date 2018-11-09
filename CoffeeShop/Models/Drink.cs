using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    public class Drink
    {
        private int _id;
        private string _name;
        private bool _ice;
        private string _temperature;
        private string _calories;
        private bool _alcoholic;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public bool Ice { get => _ice; set => _ice = value; }
        public string Temperature { get => _temperature; set => _temperature = value; }
        public string Calories { get => _calories; set => _calories = value; }
        public bool Alcoholic { get => _alcoholic; set => _alcoholic = value; }
    }
}