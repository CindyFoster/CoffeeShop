using System.Data;
using System.Data.SqlClient;

namespace CoffeeShop.DAL
{
    public class ActionLogDAL : IActionLogDAL
    {
        private RestaurantDBConnection dbConnection;
        private SqlConnection sqlConnection;

        /*public ActionLogDAL(RestaurantDBConnection dbc, SqlConnection sqlc)
        {
            this.dbConnection = dbc;
            this.sqlConnection = sqlc;
        }
        */
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