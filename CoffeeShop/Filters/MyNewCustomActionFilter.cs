using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using CoffeeShop.DAL;
using CoffeeShop.Models;

namespace CoffeeShop.Filters
{
    public class MyNewCustomActionFilter : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)

        {
            ActionLog log = new ActionLog()
            {
                Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Action = filterContext.ActionDescriptor.ActionName + " (Logged By: MyNewCustomActionFilter)",
                   IP1 = filterContext.HttpContext.Request.UserHostAddress,
             DateTime = filterContext.HttpContext.Timestamp
              };

            var rdb = new RestaurantDBConnection();
            var conn = rdb.Connection();

            SqlCommand com = new SqlCommand("InsertActionLog", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.Add(new SqlParameter("@Controller", SqlDbType.VarChar)).Value = log.Controller;
            com.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar)).Value = log.Action;
            com.Parameters.Add(new SqlParameter("@IP", SqlDbType.VarChar)).Value = log.IP1;
            com.Parameters.Add(new SqlParameter("@DateTime", SqlDbType.DateTime)).Value = log.DateTime;
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();

            this.OnActionExecuting(filterContext);
    }
}
}