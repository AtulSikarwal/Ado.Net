using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDbConsole
{
    public class EmployeeRepositoey
    {
        public static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = null;


        public void GetAllEmployees()
        {
            try
            {
                using (connection = new SqlConnection(ConnectionString))
                {
                    EmployeeModel model = new EmployeeModel();
                    string query = "select * from employee_payroll2";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.EmployeeId = Convert.ToInt32(reader["ID"] == DBNull.Value ? default : reader["Id"]);
                            model.Name = reader["Name"] == DBNull.Value ? default : reader["Name"].ToString();
                            model.Salary = Convert.ToDouble(reader["Salary"] == DBNull.Value ? default : reader["Salary"]);
                            model.StartDate = (DateTime)((reader["StartDate"] == DBNull.Value ? default(DateTime) : reader["StartDate"]));
                            model.Gender = reader["Gender"] == DBNull.Value ? default : reader["Gender"].ToString();
                            model.PhoneNumber = Convert.ToInt32(reader["PhoneNumber"] == DBNull.Value ? default : reader["PhoneNumber"]);
                            model.Department = reader["Department"] == DBNull.Value ? default : reader["Department"].ToString();
                            model.Address = reader["Address"] == DBNull.Value ? default : reader["Address"].ToString();
                            model.TaxablePay = Convert.ToDouble(reader["TaxablePay"] == DBNull.Value ? default : reader["TaxablePay"]);
                            model.Deductions = Convert.ToDouble(reader["Deductions"] == DBNull.Value ? default : reader["Deductions"]);
                            model.NetPay = Convert.ToDouble(reader["NetPay"] == DBNull.Value ? default : reader["NetPay"]);
                            model.IncomeTax = Convert.ToDouble(reader["IncomeTax"] == DBNull.Value ? default : reader["IncomeTax"]);

                            Console.WriteLine(model.Name + model.Salary + model.StartDate + model.Gender + model.PhoneNumber + model.Department + model.Address);

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }



    }
}
