using System.Data;
using System.Data.SqlClient;

namespace CoffeeShop.DAL
{
    public class ActionLogDAL : IActionLogDAL
    {
        //TODO add to source control.
        //TODO: making a change so it shows up in source control!
        private RestaurantDBConnection dbConnection;
        private SqlConnection sqlConnection;

        public DataTable GetDataTable(string storedProc)
        {
            dbConnection = new RestaurantDBConnection();
            sqlConnection = dbConnection.Connection();

            SqlCommand com = new SqlCommand(storedProc, sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            var da = new SqlDataAdapter(com);
            var dt = new DataTable();
            sqlConnection.Open();
            da.Fill(dt);
            sqlConnection.Close();

            return dt;
        }
    }
}