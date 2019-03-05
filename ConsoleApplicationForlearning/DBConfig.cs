using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ConsoleApplicationForlearning
{
    public class DBConfig
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["EmployeeDbEntities"].ConnectionString;

        public void UpdateEmployee(string firstName, string lastName, string email, string gender, int age)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=mohammedhossen\sqlexpress;Initial Catalog=EmployeeDb;Integrated Security=True"))
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
