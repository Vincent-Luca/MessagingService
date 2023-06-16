using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Helpers
{
    public class DBConnection
    {
        /// <summary>
        /// The command that sends all querys to the database
        /// </summary>
        private readonly SqlCommand _command;
        /// <summary>
        /// the connection to the databank
        /// </summary>
        private SqlConnection _con;
        /// <summary>
        /// The reader that reads all returns from the databank
        /// </summary>
        private SqlDataReader _reader;

        /// <summary>
        /// Creates a new Commander but nothing else
        /// </summary>
        public DBConnection()
        {
            _command = new SqlCommand();
        }

        /// <summary>
        /// Creates a New Database conenction with the given Connection string and sets the commander up aswell
        /// </summary>
        /// <param name="Connectionstring">The string needed to connect to the database</param>
        /// <exception cref="Exception"></exception>
        public DBConnection(string Connectionstring)
        {
            if (!string.IsNullOrEmpty(Connectionstring))
            {
                _con = new SqlConnection(Connectionstring);
                _command = new SqlCommand();
                _command.Connection = _con;
                _con.Open();
            }
            else
            {
                throw new Exception("No Connection String given");
            }
        }

        public DBConnection(SqlConnection con)
        {
            if (con == null)
            {
                throw new Exception("Connection is null");
            }
            else
            {
                _con = con;
                _command = new SqlCommand();
                _command.Connection = _con;
                _con.Open();
            }
        }

        /// <summary>
        /// Returns the connection string to the database
        /// </summary>
        /// <returns>string</returns>
        public string getConnectionstring()
        {
            return _command.Connection.ConnectionString;
        }

        /// <summary>
        /// Runs a Select Query and gives back the information as a Datatable
        /// </summary>
        /// <param name="SQLQuery">The sql Select query as a string</param>
        /// <returns>DataTable</returns>
        /// <exception cref="SqlException"></exception>
        public DataTable SQLSelect(string SQLQuery)
        {

            try
            {
                _command.Parameters.Clear();

                if (!isOpen())
                    _con.Open();

                DataTable dt = new DataTable();

                _command.CommandText = SQLQuery;
                _reader = _command.ExecuteReader();


                for (int i = 0; i < _reader.FieldCount; i++)
                {
                    DataColumn dc = new DataColumn();
                    dc.ColumnName = _reader.GetName(i);
                    dt.Columns.Add(dc);
                }

                _reader.Close();

                _command.CommandText = SQLQuery;
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < _reader.FieldCount; i++)
                    {
                        dr[dt.Columns[i].ColumnName] = _reader.GetValue(i);
                    }
                    dt.Rows.Add(dr);
                }
                _reader.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erorr while running query: " + ex.Message);
            }
        }


        /// <summary>
        /// Closes the connection to the databank and cleans itself up
        /// </summary>
        public void closeDB()
        {
            if (_reader != null)
                _reader.Close();

            _con.Close();
            _command.Dispose();
            _con.Dispose();
        }

        /// <summary>
        /// Runs a Select Query with the given parameters and gives back the information as a Datatable
        /// </summary>
        /// <param name="SQLQuery">The sql Select query as a string</param>
        /// <param name="parameters">if needed, the parameters that are needed in the sql query  (@parameter_name, value)</param>
        /// <returns>DataTable</returns>
        /// <exception cref="SqlException"></exception>

        public DataTable SQLSelect(string SQLQuery, Dictionary<string, dynamic> parameters)
        {
            try
            {
                _command.Parameters.Clear();

                if (!isOpen())
                    _con.Open();

                DataTable dt = new DataTable();

                foreach (var item in parameters)
                {
                    _command.Parameters.AddWithValue(item.Key, item.Value);
                }

                _command.CommandText = SQLQuery;
                _reader = _command.ExecuteReader();

                for (int i = 0; i < _reader.FieldCount; i++)
                {
                    DataColumn dc = new DataColumn();
                    dc.ColumnName = _reader.GetName(i);
                    dt.Columns.Add(dc);
                }

                _reader.Close();

                _command.CommandText = SQLQuery;
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < _reader.FieldCount; i++)
                    {
                        dr[dt.Columns[i].ColumnName] = _reader.GetValue(i);
                    }
                    dt.Rows.Add(dr);
                }
                _reader.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erorr while running query: " + ex.Message);
            }
        }

        /// <summary>
        /// Excutes a non query command (Insert, update, delete)
        /// </summary>
        /// <param name="SQLQuery">The SQL command as a string</param>
        /// <returns>bool, no problem occuring = true, problem occuring = false</returns>
        /// <exception cref="SqlException"></exception>
        public bool executenonquery(string SQLQuery)
        {
            try
            {
                _command.Parameters.Clear();

                if (!isOpen())
                    _con.Open();

                _command.CommandText = SQLQuery;
                _command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error while Finishing Query: " + ex.Message);
            }
        }


        /// <summary>
        /// Excutes a non query command (Insert, update, delete) with the given parameters
        /// </summary>
        /// <param name="SQLQuery">The SQL command as a string</param>
        /// <param name="parameters">if needed, the parameters for the sql query (@parametername, value)</param>
        /// <returns>bool</returns>
        /// <exception cref="SqlException"></exception>
        public bool executenonquery(string SQLQuery, Dictionary<string, dynamic> parameters)
        {
            try
            {
                _command.Parameters.Clear();

                if (!isOpen())
                    _con.Open();

                foreach (var item in parameters)
                {
                    _command.Parameters.AddWithValue(item.Key, item.Value);
                }

                _command.CommandText = SQLQuery;
                _command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error while Finishing Query: " + ex.Message);
            }
        }

        /// <summary>
        /// Checks if the connection is open
        /// </summary>
        /// <returns>bool, is open = true, not open = false</returns>
        public bool isOpen()
        {
            return _con.State == ConnectionState.Open;
        }

        /// <summary>
        /// Checkes if a given value in form of a sql query is still availbe in the databank or if a query returns a row, returns true if a value is found
        /// </summary>
        /// <param name="SQLQuery">the sql query</param>
        /// <returns>bool, value was found = true</returns>
        /// <exception cref="SqlException"></exception>
        public bool isAvailable(string SQLQuery)
        {
            try
            {
                if (!isOpen())
                    _con.Open();

                _command.CommandText = SQLQuery;
                _reader = _command.ExecuteReader();

                bool result = _reader.HasRows;

                _reader.Close();
                return result;
            }
            catch (SqlException ex)
            {
                throw new Exception("An error has happend while running the Query: " + ex.Message);
            }
        }
        /// <summary>
        /// Checkes if a given value in form of a sql query with the given parameters is still availbe in the databank or if a query returns a row, returns true if a value is found
        /// </summary>
        /// <param name="SQLQuery">the sql query</param>
        /// <param name="parameters">if needed, the parameters for the sql query</param>
        /// <returns>bool</returns>
        /// <exception cref="SqlException"></exception>

        public bool isAvailable(string SQLQuery, Dictionary<string, dynamic> parameters)
        {
            try
            {
                _command.Parameters.Clear();

                if (!isOpen())
                    _con.Open();

                foreach (var item in parameters)
                {
                    _command.Parameters.AddWithValue(item.Key, item.Value);
                }

                _command.CommandText = SQLQuery;
                _reader = _command.ExecuteReader();

                bool result = _reader.HasRows;

                _reader.Close();

                return result;
            }
            catch (SqlException ex)
            {
                throw new Exception("An error has happend while running the Query: " + ex.Message);
            }
        }
    }
}
