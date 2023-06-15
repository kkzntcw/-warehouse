using Npgsql;
using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_storage
{
    public class DataBase 
    {
        private NpgsqlConnection npgsqlConnection;



        public DataBase()
        {
            npgsqlConnection = new NpgsqlConnection();
            string connString = $"host=localhost;Port=5432;" +
           $"database=pharma_storage;User Id=postgres;Password=1111";

            npgsqlConnection = new NpgsqlConnection(connString);
        }


        public void OpenConnection()
        {
            if (npgsqlConnection.State == System.Data.ConnectionState.Closed)
            {
                npgsqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (npgsqlConnection.State == System.Data.ConnectionState.Open && npgsqlConnection != null)
            {
                npgsqlConnection.Close();
            }
        }

        public NpgsqlConnection GetConnection()
        {
            return npgsqlConnection;
        }


    }
    
}
