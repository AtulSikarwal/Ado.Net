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




        public void AddEmployee(EmployeeModel model)
        {
            try
            {
                connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("dbo.spAddEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Address", model.Address);
                command.Parameters.AddWithValue("@Salary", model.Salary);
                command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                command.Parameters.AddWithValue("@Gender", model.Gender);

                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result != 0)
                    Console.WriteLine("Employee inserted into Table");
                else
                    Console.WriteLine("Not inserted");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public void UpdateEmployee(EmployeeModel model)
        {
            try
            {
                connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("dbo.spUpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Id", model.EmployeeId);
                command.Parameters.AddWithValue("@Salary", model.Salary);
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result != 0)
                    Console.WriteLine("Employee details update successfully into table");
                else
                    Console.WriteLine("Not inserted");
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


        public void DeleteEmployee(EmployeeModel model)

        {
            try
            {
                connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("dbo.spDeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Id", model.EmployeeId);
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result != 0)
                    Console.WriteLine("Employee data deleted successfully into table");
                else
                    Console.WriteLine("Not inserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        public void InsertIntoTwoTable(EmployeeModel model)
        {
            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("dbo.spInsertIntoTwoTable", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Gender", model.Gender);
                command.Parameters.AddWithValue("@Address", model.Address);
                command.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                var result = command.ExecuteScalar();
                string Id = command.Parameters["@id"].Value.ToString();
                int newid = Convert.ToInt32(Id);

                string query = $"insert into Salary(id,Salary)values({newid},{model.Salary})";
                SqlCommand comd = new SqlCommand(query, connection);
                int res = command.ExecuteNonQuery();
                if (res != 0)
                    Console.WriteLine("Employee inserted successfully into table");
                else
                    Console.WriteLine("Not inserted");
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
