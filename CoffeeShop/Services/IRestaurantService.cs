using CoffeeShop.Models;
using System.Collections.Generic;

namespace CoffeeShop.Services
{
    public interface IRestaurantService
    {
        List<ActionLog> GetAllActionLogs();
        Drinks GetAllDrinks();
    }
}