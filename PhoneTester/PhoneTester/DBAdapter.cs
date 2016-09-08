using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PhoneTester
{
    class DBAdapter
    {
        private static DBAdapter _instance;

        public static DBAdapter Instance {
            get {
                if (_instance == null) _instance = new DBAdapter();
                return _instance;
            }
        }
        private DBAdapter() {
            CreateTables();
        }

        private SQLiteConnection connect;

        private void CreateTables()
        {
            CreateConnection();
            SQLiteCommand com = connect.CreateCommand();
            com.CommandText = "CREATE TABLE IF NOT EXISTS phones ("+
                              "id INTEGER PRIMARY KEY AUTOINCREMENT, "+
                              "phone TEXT, "+
                              "country TEXT);";
            com.ExecuteNonQuery();
            com.CommandText = "CREATE TABLE IF NOT EXISTS setting (" +
                              "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                              "string_position INTEGER); INSERT INTO setting (string_position) VALUES (0);";
            com.ExecuteNonQuery();



            CloseConnection();
        }

        private void CreateConnection() {
            connect = new SQLiteConnection("Data Source=base_phone.db; Version=3;");
            connect.Open();
        }

        private void CloseConnection() {
            connect.Dispose();
        }

        public void AddPhone(PhoneInfo pi) {
            CreateConnection();
            SQLiteCommand com = connect.CreateCommand();
            com.CommandText = "INSERT INTO phones (phone, country) VALUES ('"+pi.phone+"','"+ pi.country + "');";
            com.ExecuteNonQuery();
            CloseConnection();
        }

        public List<PhoneInfo> GetAllPhones() {
            List<PhoneInfo> lpi = new List<PhoneInfo>();
            CreateConnection();
            SQLiteCommand com = connect.CreateCommand();
            com.CommandText = "SELECT * FROM phones;";
            SQLiteDataReader dr = com.ExecuteReader();
            while (dr.Read()) {
                lpi.Add(new PhoneInfo() {
                    phone = dr["phone"].ToString(),
                    country = dr["country"].ToString()
                });
            }
            CloseConnection();
            return lpi;
        }

        public List<PhoneInfo> GetPhonesFromCountry(string country) {
            List<PhoneInfo> lpi = new List<PhoneInfo>();
            CreateConnection();
            SQLiteCommand com = connect.CreateCommand();
            com.CommandText = "SELECT * FROM phones WHERE country LIKE '"+country+"';";
            SQLiteDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                lpi.Add(new PhoneInfo()
                {
                    phone = dr["phone"].ToString(),
                    country = dr["country"].ToString()
                });
            }
            CloseConnection();
            return lpi;
        }

        public List<PhoneInfo> GetCountries() {
            List<PhoneInfo> lpi = new List<PhoneInfo>();
            CreateConnection();
            SQLiteCommand com = connect.CreateCommand();
            com.CommandText = "SELECT * FROM phones GROUP BY country;";
            SQLiteDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                lpi.Add(new PhoneInfo()
                {
                    phone = dr["phone"].ToString(),
                    country = dr["country"].ToString()
                });
            }
            CloseConnection();
            return lpi;
        }

        public int GetLastPositionFromFile() {
            int pos=-1;
            CreateConnection();
            SQLiteCommand com = connect.CreateCommand();
            com.CommandText = "SELECT string_position FROM setting WHERE id=1;";
            SQLiteDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                pos = Int32.Parse(dr["string_position"].ToString());
            }
            CloseConnection();
            return pos;
        }
        public void SetLastPositionFromFile(int pos) {
            CreateConnection();
            SQLiteCommand com = connect.CreateCommand();
            com.CommandText = "UPDATE TABLE setting SET string_position=" + pos+" WHERE id=1;";
            com.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
