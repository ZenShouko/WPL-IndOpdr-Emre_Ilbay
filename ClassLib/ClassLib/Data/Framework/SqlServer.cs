using ClassLib.Data.Framework;
using ClassLib.Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibTeam05.Data.Framework
{
    public abstract class SqlServer
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlDataReader reader;

        public SqlServer()
        {
            connection = new SqlConnection(Settings.GetConnectionString());
        }

        protected SelectResult Select(SqlCommand selectCommand)
        {
            var result = new SelectResult();

            try
            {
                using (connection)
                {
                    selectCommand.Connection = connection;
                    connection.Open();

                    adapter = new SqlDataAdapter(selectCommand);
                    result.DataTable = new System.Data.DataTable();
                    adapter.Fill(result.DataTable);
                    connection.Close();
                }
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return result;
        }

        protected SelectResult Select(string tableName)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = $"SELECT * FROM {tableName}";
            return Select(command);
        }

        protected InsertResult Insert(SqlCommand insertCommand)
        {
            var result = new InsertResult();

            try
            {
                using (connection)
                {
                    insertCommand.Connection = connection;
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    connection.Close();
                }
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
