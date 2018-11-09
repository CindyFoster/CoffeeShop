using CoffeeShop.DAL;
using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CoffeeShop.Services
{
    public class RestaurantService: IRestaurantService
    {
        public ActionLogDAL alDAL = new ActionLogDAL();

        public List<ActionLog> GetAllActionLogs()
        {
            var actionLogList = new List<ActionLog>();
            var dt = alDAL.GetDataTable("GetActionLogs");
            
            actionLogList = 
                (from DataRow dr in dt.Rows

                 select new ActionLog() {
                     ActionLogId = Convert.ToInt32(dr["ActionLogId"]),
                     Controller = Convert.ToString(dr["Controller"]),
                     Action = Convert.ToString(dr["Action"]),
                     IP1 = Convert.ToString(dr["IP"]),
                     DateTime = Convert.ToDateTime(dr["DateTime"])
                 }).ToList();

            return actionLogList;
        }

        public Drinks GetAllDrinks()
        {
            var drinkList = new List<Drink>();
            var dt = alDAL.GetDataTable("GetAllDrinks");

            drinkList =
                (from DataRow dr in dt.Rows

                 select new Drink()
                 {
                     Id = Convert.ToInt32(dr["DrinkId"]),
                     Name = Convert.ToString(dr["Name"]),
                     Ice = Convert.ToBoolean(dr["Ice"]),
                     Temperature = Convert.ToString(dr["Temperature"]),
                     Calories = Convert.ToString(dr["Calories"]),
                     Alcoholic = Convert.ToBoolean(dr["Alcoholic"])
                 }).ToList();

            var drinks = new Drinks();
            drinks.SetDrinks(drinkList);
            return drinks;
        }

        public List<Drink> GetDrinkList()
        {
            var drinkList = new List<Drink>();
            var dt = alDAL.GetDataTable("GetAllDrinks");

            drinkList =
                (from DataRow dr in dt.Rows

                 select new Drink()
                 {
                     Id = Convert.ToInt32(dr["DrinkId"]),
                     Name = Convert.ToString(dr["Name"]),
                     Ice = Convert.ToBoolean(dr["Ice"]),
                     Temperature = Convert.ToString(dr["Temperature"]),
                     Calories = Convert.ToString(dr["Calories"]),
                     Alcoholic = Convert.ToBoolean(dr["Alcoholic"])
                 }).ToList();

            return drinkList;
        }
    }
}