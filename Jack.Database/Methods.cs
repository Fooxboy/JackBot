using System;
using MySql.Data.MySqlClient;

namespace Jack.Database
{
    public class Methods
    {
        private string table = "";
        private MySqlConnection connect = null;

        public Methods(string Database, string Table)
        {
            string server = "localhost";
            string database = Database;
            string sslmode = "None";
            string user = "root";
            string password = "0000";
            table = Table;
            string connectionString = $"server={server};Ssl-mode={sslmode};user={user};database={database};password={password}";
            connect = new MySqlConnection(connectionString);
        }

        public string GetFromId(string id, string field)
        {
            connect.Open();
            string sql = $"SELECT {field} FROM {table} WHERE id={id}";
            MySqlCommand command = new MySqlCommand(sql, connect);
            string response = command.ExecuteScalar().ToString();
            connect.Close();
            return response;
        }

        public void EditField(string id, string field, string value)
        {
            connect.Open();
            string sql = $"UPDATE {table}  SET `{field}`='{value}' WHERE `id`='{id}';";
            MySqlCommand command = new MySqlCommand(sql, connect);
            command.ExecuteScalar();
            connect.Close();
        }

        public void Delete(string id)
        {
            connect.Open();
            string sql = $"DELETE FROM {table} WHERE id={id}";
            MySqlCommand command = new MySqlCommand(sql, connect);
            command.ExecuteScalar();
            connect.Close();
        }

        public bool Check(string id)
        {
            connect.Open();
            string sql = $"SELECT Is FROM {table} WHERE id={id}";
            MySqlCommand command = new MySqlCommand(sql, connect);
            MySqlDataReader reader = command.ExecuteReader();
            bool response = false;
            if (reader.Read())
            {
                response = true;
            }
            reader.Close();
            connect.Close();
            return response;
        }

        public void Add(string fields, string values)
        {
            connect.Open();
            string sql = $@"INSERT INTO {table} ({fields}) VALUES ({values});";
            MySqlCommand command = new MySqlCommand(sql, connect);
            command.ExecuteScalar();
            connect.Close();
        }
    }
}

