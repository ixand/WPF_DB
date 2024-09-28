using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace WPF_DB
{
    public static class DatabaseController
    {
        public static NpgsqlConnection? Connection;
        public static bool IsConnected => Connection != null;
        public static void Connect(string username, string password)
        {
            string connStr = $"Host=localhost;Port=5432;Username={username};Password={password};Database=ama";
            Connection = new(connStr);
            Connection.Open();

        }

        public static IEnumerable<Dictionary<string, object>> SelectQuery(string query)
        {
            using var cmd = new NpgsqlCommand(query, Connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var dict = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string column = reader.GetName(i);
                    object value = reader.GetValue(i);
                    dict[column] = value;
                }
                yield return dict;
            }
        }


        public static DataTable LoadReport1()
        {
            DataTable dataTable = new();

            var command = new NpgsqlCommand("SELECT * FROM Conn_Station_List", Connection);
            var reader = command.ExecuteReader();

            dataTable.Load(reader);
            reader.Close();

            return dataTable;
        }

        public static DataTable LoadReport2(string station,string from, string to)
        {
            DataTable dataTable = new();

            var command = new NpgsqlCommand("SELECT mu.title, AVG(me.measurement_value),  MIN(me.measurement_value),  MAX(me.measurement_value), s.station_name FROM measurement_unit mu, station s, measurment me WHERE me.measurement_unit_id = mu.ID_Measurement_Unit AND s.ID_Station = me.station_id  AND me.measurement_time BETWEEN @from::timestamp AND @to::timestamp AND station_name = @station GROUP BY mu.title,s.station_name", Connection);
            command.Parameters.AddWithValue("station",station);
            command.Parameters.AddWithValue("from", from);
            command.Parameters.AddWithValue("to", to);
            var reader = command.ExecuteReader();
            dataTable.Load(reader);
            reader.Close();

            return dataTable;
        }

        public static IEnumerable<string> GetStationsName()
        {
            var command = new NpgsqlCommand("select S.station_name from Station S ", Connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
               yield return reader.GetString(0);
            }
            reader.Close();
            yield break;

        }
        public static DataTable LoadReport3(string from, string to)
        {
            DataTable dataTable = new();

            var command = new NpgsqlCommand("SELECT S.City, Mu.Title, MAX(Me.measurement_value) AS Max_Value FROM Measurment Me JOIN Station S ON Me.station_id = S.ID_Station JOIN Measurement_Unit Mu ON Me.Measurement_Unit_id = Mu.ID_Measurement_Unit WHERE Mu.Title IN ('PM2.5', 'PM10') AND Me.measurement_time >= @from::timestamp AND Me.measurement_time <= @to::timestamp  GROUP BY S.City, Mu.Title;", Connection);
            command.Parameters.AddWithValue("from", from);
            command.Parameters.AddWithValue("to", to);
            var reader = command.ExecuteReader();
            dataTable.Load(reader);
            reader.Close();

            return dataTable;
        }

        public static DataTable LoadReport4()
        {
            DataTable dataTable = new();

            var command = new NpgsqlCommand("SELECT * FROM Graph2", Connection);
            var reader = command.ExecuteReader();

            dataTable.Load(reader);
            reader.Close();

            return dataTable;
        }
        public static DataTable LoadReport5()
        {
            DataTable dataTable = new();

            var command = new NpgsqlCommand("SELECT * FROM Graph3", Connection);
            var reader = command.ExecuteReader();

            dataTable.Load(reader);
            reader.Close();

            return dataTable;
        }

        public static DataTable LoadReport6()
        {
            DataTable dataTable = new();

            var command = new NpgsqlCommand("SELECT * FROM Graph4", Connection);
            var reader = command.ExecuteReader();

            dataTable.Load(reader);
            reader.Close();

            return dataTable;
        }
    }
}
