using System;
using System.Data.SqlClient;

namespace DBconnection
{
    class Program
    {
        class SqlHelper
        {
            public static SqlDataReader ExecuteReader(String connString, String commandText)
            {
                SqlConnection conn = new SqlConnection(connString);
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    return reader;
                }
            }
        }
        static void Main(string[] args)
        {
            String connString = "Data Source=.; Initial Catalog=pubs; Integrated Security=true;";
            String commandText = "SELECT au_fname, au_lname FROM authors;";

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connString, commandText))
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["au_fname"].ToString() + " " + reader["au_lname"].ToString());
                }
            }

            Console.WriteLine("Hello World!");
            Console.WriteLine("And Hello World! Again");
            Console.Read();
        }
    }
}