using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CoffeeShop.DAL;

namespace CoffeeShop
{
    public class RestaurantRepository
    {
        public List<Drink> GetAllDrinks()
        {
            //TODO: Clean this up.
            //TODO: Unit Test
            var rdb = new RestaurantDBConnection();
            var conn = rdb.Connection();
            var drinkList = new List<Drink>();

            SqlCommand com = new SqlCommand("GetAllDrinks", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();

            drinkList = (from DataRow dr in dt.Rows

                         select new Drink()
                         {
                             Id = Convert.ToInt32(dr["DrinkId"]),
                             Name = Convert.ToString(dr["Name"]),
                             Ice = Convert.ToBoolean(dr["Ice"])
                         }).ToList();

            return drinkList;
        }
    }
}