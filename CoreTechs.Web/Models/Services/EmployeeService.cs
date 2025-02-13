using CoreTechs.Web.Models.ModelEntities;
using CoreTechs.Web.Models.Data;
using CoreTechs.Web.WebHelper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace CoreTechs.Web.Models.Services
{
    public class EmployeeService
    {
        private readonly DataContextDB _dataContextDB;

        public EmployeeService(DataContextDB dataContextDB)
        {
            _dataContextDB = dataContextDB;
        }

        #region CRUD
        public List<Employees> GetEmployees()
        {
            return _dataContextDB.GetEmployees();
        }
        public bool AddEmployees(string Name, string Phone, string Address, string Salary)
        {
            _dataContextDB.AddEmployee(Name, Phone, Address, Salary);
            return true;
        }

        public bool UpdateEmployees(int id, string Name, string Phone, string Address, string Salary)
        {
            _dataContextDB.Update(id, Name, Phone, Address, Salary);
            return true;
        }

        public bool DeleteEmployees(int id)
        {
            _dataContextDB.Delete(id);
            return true;
        }
        #endregion

    }
}
