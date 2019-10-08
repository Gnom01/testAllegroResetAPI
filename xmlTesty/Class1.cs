using System;
using System.Data.SqlClient;

namespace xmlTesty
{
    class Class1
    {
        public SqlConnection connection = new SqlConnection(@"Data Source=GNOM-MINI1\SQLEXPRESS;Initial Catalog=TestXml;Integrated Security=True");
        public void NewTest(string name)
        {
            connection.Open();
            string Xml = $"ALTER TABLE XML ADD {name} nvarchar(MAX)";
            SqlCommand command = new SqlCommand(Xml, connection);          

            try
            {
              command.ExecuteNonQuery();  
            }
            catch (Exception)
            {
                Console.WriteLine("EXCEPTION" );
            }
            finally
            {
                //  connection.Close();
            }
        }

        public void AddAtributy(string name, string atrebuty)
        {
        SqlCommand command = new SqlCommand($"INSERT INTO[XML]({name}) VALUES (@{name})", connection);
        command.Parameters.AddWithValue($@"{name}", atrebuty.ToString());
            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception)
            {
                Console.WriteLine("EXCEPTION");
            }

        }
    }
}
