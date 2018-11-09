using System.Data;

namespace CoffeeShop.DAL
{
    public interface IActionLogDAL
    {
        DataTable GetDataTable(string storedProc);
    }
}