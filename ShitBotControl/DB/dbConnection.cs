using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShitBotControl.DB
{
    class dbConnection {
        public dbConnection()
        {
            addMap("map1", 8, 8);
            getMap();
            addIntersection(1, 5, 4, false, false, false, false, false);
            getIntersection(1);

        }
        public void addMap(string name, int width, int height)
        {
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=C:\\Users\\regil\\Documents\\GitHub\\ShitBotControl\\shitbot.sqlite;Version=3;");
            SQLiteCommand sql_cmd;
            string txtQuery;

            sql_con.Open();

            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery = "insert into map (name, x, y) values ('" + name + "', " + width + ", " + height + ");";
            sql_cmd.ExecuteNonQuery();

            sql_con.Close();

        }

        public void getMap()
        {
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=C:\\Users\\regil\\Documents\\GitHub\\ShitBotControl\\shitbot.sqlite;Version=3;");

            sql_con.Open();
            var cmd = new SQLiteCommand("SELECT * FROM map", sql_con);

            SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetInt32(2)} {rdr.GetInt32(3)}");
            }
            sql_con.Close();
        }
        public void addIntersection(int mapId, int height, int widht, Boolean isEnabled, Boolean isConnectedLeft, Boolean isConnectedDown, Boolean isConnectedRight, Boolean isConnectedUp)
        {
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=C:\\Users\\regil\\Documents\\GitHub\\ShitBotControl\\shitbot.sqlite;Version=3;");
            SQLiteCommand sql_cmd;
            string txtQuery;

            sql_con.Open();

            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery = "insert into intersection (mapId, height, widht, isEnabled,isConnectedLeft,isConnectedDown,isConnectedRight,isConnectedUp) values (" + mapId + "," + widht + ", " + height + ", " + (isEnabled ? 1 : 0) + "," + (isConnectedLeft ? 1 : 0) + ", " + (isConnectedDown ? 1 : 0) + ", " + (isConnectedRight ? 1 : 0) + "," + (isConnectedUp ? 1 : 0) + ");";
            sql_cmd.ExecuteNonQuery();

            sql_con.Close();
        }

        public void getIntersection(int mapId)
        {
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=C:\\Users\\regil\\Documents\\GitHub\\ShitBotControl\\shitbot.sqlite;Version=3;");

            sql_con.Open();
            Console.WriteLine("connection open");
            var cmd = new SQLiteCommand("SELECT * FROM intersection WHERE mapId = " + mapId + " ", sql_con);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine("execute reader");
            while (rdr.Read())
            {
                Console.WriteLine("rdr read");
                Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetInt32(1)} {rdr.GetInt32(2)} {rdr.GetInt32(3)} {rdr.GetInt32(4)} {rdr.GetInt32(5)} {rdr.GetInt32(6)} {rdr.GetInt32(7)} {rdr.GetInt32(8)}");
            }
            sql_con.Close();
        }
    }
}
