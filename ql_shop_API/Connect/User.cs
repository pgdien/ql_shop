using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ql_shop_API.Connect
{
    public class User
    {
        public string getUser()
        {
            string json;
            using (MySqlConnection connMySQL = new MySqlConnection(Conn.connString))
            {
                using (MySqlCommand cmd = connMySQL.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM NGUOIDUNG";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySQL;
                    connMySQL.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        var r = Serialize(reader);
                        json = JsonConvert.SerializeObject(r, Formatting.Indented);
                    }
                }
                connMySQL.Close();
            }
            return json;
        }

        public IEnumerable<Dictionary<string, object>> Serialize(MySqlDataReader reader)
        {
            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();
            for (var i = 0; i < reader.FieldCount; i++)
                cols.Add(reader.GetName(i));

            while (reader.Read())
                results.Add(SerializeRow(cols, reader));

            return results;
        }
        private Dictionary<string, object> SerializeRow(IEnumerable<string> cols,
                                                        MySqlDataReader reader)
        {
            var result = new Dictionary<string, object>();
            foreach (var col in cols)
                result.Add(col, reader[col]);
            return result;
        }
    }
}
