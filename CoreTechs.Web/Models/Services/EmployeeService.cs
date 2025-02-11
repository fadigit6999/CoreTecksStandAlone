using CoreTechs.Web.Models.ModelEntities;
using CoreTechs.Web.Models.Data;
using CoreTechs.Web.WebHelper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CoreTechs.Web.Models.Services
{
    public class EmployeeService
    {
        private readonly DataContextDB _dataContextDB;

        public EmployeeService(DataContextDB dataContextDB)
        {
            _dataContextDB = dataContextDB;
        }

        public List<Employees> GetEmployees()
        {
            return _dataContextDB.GetEmployees();
        }
    }
}
