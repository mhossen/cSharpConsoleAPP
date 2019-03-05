using System;
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
    }
}
