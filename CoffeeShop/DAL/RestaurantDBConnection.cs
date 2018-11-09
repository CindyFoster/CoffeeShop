using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CoffeeShop.DAL
{
    public class RestaurantDBConnection
    {
        private SqlConnection _con;

        public SqlConnection Connection()
        {
            //TODO: Apply Singleton pattern. May be unnecessary due to way connection pooling works in .NET.
            //TODO: This code needs to be way cleaner.
            _con = new SqlConnection(ConfigurationManager.ConnectionStrings["RestaurantDB"].ToString());
            return _con;
        }
    }
}