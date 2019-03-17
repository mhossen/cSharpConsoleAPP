using ConsoleApplicationForlearning.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApplicationForlearning.Controller
{
    public sealed class EmployeeController : DBConfig
    {

        public void CreateNewEmployee(string firstName, string lastName, string email, string gender, int age)
        {
            using (SqlConnection connection = new SqlConnection(_connect))
            {
                string query = "INSERT INTO tblEmployee(FirstName, LastName, Email, Gender, Age) Values (@FirstName, @LastName, @Email, @Gender, @Age)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Age", age);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                        Console.WriteLine("Error inserting Data!!");
                }
            }
        }

        public Employee GetEmployeeById(int id)
        {
            Employee e = new Employee();
            string query = $"SELECT * FROM tblEmployee WHERE Id = {id};";
            using (var connection = new SqlConnection(_connect))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        e.FirstName = reader["FirstName"].ToString();
                        e.LastName = reader["LastName"].ToString();
                        e.Email = reader["Email"].ToString();
                        e.Gender = reader["Gender"].ToString();
                        e.Age = Convert.ToInt32(reader["Age"]);
                    }

                }
            }
            return e;

        }

        public IList<Employee> GetEmployees()
        {
            var e = new List<Employee>();
            string query = $"SELECT * FROM tblEmployee;";
            using (var connection = new SqlConnection(_connect))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        e.Add(new Employee()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Age = Convert.ToInt32(reader["Age"])
                        });
                    }

                }
            }
            return e;
        }
    }
}
