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
        public readonly IActionLogDAL actionLogDAL;
        private DataTable _dataTable;

        public RestaurantService(IActionLogDAL actionLogDAL)
        {
            this.actionLogDAL = actionLogDAL;
        }

        public List<ActionLog> GetAllActionLogs()
        {
            var actionLogList = new List<ActionLog>();
            _dataTable = actionLogDAL.GetDataTable("GetActionLogs");

            actionLogList = LoadActionLogList(_dataTable);

            return actionLogList;
        }

        private static List<ActionLog> LoadActionLogList(DataTable dt)
        {
            return (from DataRow dr in dt.Rows

                    select new ActionLog()
                    {
                        ActionLogId = Convert.ToInt32(dr["ActionLogId"]),
                        Controller = Convert.ToString(dr["Controller"]),
                        Action = Convert.ToString(dr["Action"]),
                        IP1 = Convert.ToString(dr["IP"]),
                        DateTime = Convert.ToDateTime(dr["DateTime"])
                    }).ToList();
        }

        public Drinks GetAllDrinks()
        {
            var drinkList = new List<Drink>();
            _dataTable = actionLogDAL.GetDataTable("GetAllDrinks");

            drinkList = LoadDrinksList();

            var drinks = new Drinks();
            drinks.SetDrinks(drinkList);
            return drinks;
        }

        private List<Drink> LoadDrinksList()
        {
            return (from DataRow dr in _dataTable.Rows

                    select new Drink()
                    {
                        Id = Convert.ToInt32(dr["DrinkId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Ice = Convert.ToBoolean(dr["Ice"]),
                        Temperature = Convert.ToString(dr["Temperature"]),
                        Calories = Convert.ToString(dr["Calories"]),
                        Alcoholic = Convert.ToBoolean(dr["Alcoholic"])
                    }).ToList();
        }

        public List<Drink> GetDrinkList()
        {
            var drinkList = new List<Drink>();
            _dataTable = actionLogDAL.GetDataTable("GetAllDrinks");

            drinkList = LoadDrinkList();

            return drinkList;
        }

        private List<Drink> LoadDrinkList()
        {
            return (from DataRow dr in _dataTable.Rows

                    select new Drink()
                    {
                        Id = Convert.ToInt32(dr["DrinkId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Ice = Convert.ToBoolean(dr["Ice"]),
                        Temperature = Convert.ToString(dr["Temperature"]),
                        Calories = Convert.ToString(dr["Calories"]),
                        Alcoholic = Convert.ToBoolean(dr["Alcoholic"])
                    }).ToList();
        }
    }
}