using System.Data;
using CoreTechs.Web.Models.ModelEntities;
using Microsoft.Data.SqlClient;
using CoreTechs.Web.WebHelper;

namespace CoreTechs.Web.Models.Data
{
    public class DataContextDB
    {
        public readonly string _ConnectionString;
        public DataContextDB(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public List<Employees> GetEmployees()
        {
            List<Employees> _employee = new List<Employees>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("ManageEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters for the stored procedure
                        command.Parameters.AddWithValue("@Operation", "READ");

                        // Open the connection
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Employees employees = new Employees();
                                    employees.Id = Convert.ToInt32(reader["Id"]);
                                    employees.Name = reader["Name"].ToString();
                                    employees.Address = reader["Address"].ToString();
                                    employees.Phone = reader["Phone"].ToString();
                                    employees.Salary = reader["Salary"].ToString();
                                    _employee.Add(employees);
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return _employee;
        }

        //public int AddEmployee(string name, string phone, string address, string salary)
        //{
        //    int rowImpact = 0;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(WebConfig.DatabaseConnection()))
        //        {
        //            using (SqlCommand command = new SqlCommand("ManageEmployee", connection))
        //            {
        //                //this command is type of store procedure 
        //                command.CommandType = CommandType.StoredProcedure;

        //                // Add parameters for the stored procedure
        //                command.Parameters.AddWithValue("@Operation", "CREATE");
        //                command.Parameters.AddWithValue("@Name", name);
        //                command.Parameters.AddWithValue("@Phone", phone);
        //                command.Parameters.AddWithValue("@Address", address);
        //                command.Parameters.AddWithValue("@Salary", salary);

        //                // Open the connection and execute the command
        //                connection.Open();
        //                rowImpact = command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine($"SQL Error: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }
        //    return rowImpact;
        //}

        //public int Update(int id, string name, string phone, string address, string salary)
        //{
        //    int rowImpact = 0;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(WebConfig.DatabaseConnection()))
        //        {
        //            using (SqlCommand command = new SqlCommand("ManageEmployee", connection))
        //            {
        //                //this command is type of store procedure 
        //                command.CommandType = CommandType.StoredProcedure;

        //                // Add parameters for the stored procedure
        //                command.Parameters.AddWithValue("@Operation", "UPDATE");
        //                command.Parameters.AddWithValue("@Id", id);
        //                command.Parameters.AddWithValue("@Name", name);
        //                command.Parameters.AddWithValue("@Phone", phone);
        //                command.Parameters.AddWithValue("@Address", address);
        //                command.Parameters.AddWithValue("@Salary", salary);

        //                // Open the connection and execute the command
        //                connection.Open();
        //                rowImpact = command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine($"SQL Error: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }
        //    return rowImpact;
        //}

        //public int Delete(int id)
        //{
        //    int rowImpact = 0;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(WebConfig.DatabaseConnection()))
        //        {
        //            using (SqlCommand command = new SqlCommand("ManageEmployee", connection))
        //            {
        //                //this command is type of store procedure 
        //                command.CommandType = CommandType.StoredProcedure;

        //                // Add parameters for the stored procedure
        //                command.Parameters.AddWithValue("@Operation", "DELETE");
        //                command.Parameters.AddWithValue("@Id", id);

        //                // Open the connection and execute the command
        //                connection.Open();
        //                rowImpact = command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine($"SQL Error: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }
        //    return rowImpact;
        //}
    }
}
