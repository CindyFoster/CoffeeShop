using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShop.DAL;
using CoffeeShop.Models;

namespace CoffeeShop.Filters
{
    public class CustomActionFilter : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            // TODO: Add your action filter's tasks here

            // Log Action Filter call
            //using (MusicStoreEntities storeDb = new MusicStoreEntities())
            //{
                ActionLog log = new ActionLog()
                {
                    Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    Action = string.Concat(filterContext.ActionDescriptor.ActionName, " (Logged By: Custom Action Filter)"),
                    IP1 = filterContext.HttpContext.Request.UserHostAddress,
                    DateTime = filterContext.HttpContext.Timestamp
                };
            //TODO: save to DB using connection
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

            OnActionExecuting(filterContext);
            //}
        }
    }
}