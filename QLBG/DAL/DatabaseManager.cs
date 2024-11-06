using System;
using QLBG.Helpers;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

namespace QLBG.DAL
{
    internal class DatabaseManager
    {
        private static DatabaseManager instance;
        private readonly string connectionString;

        private DatabaseManager()
        {
            connectionString = App_Default.DefaultConnectionString;
            //connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static DatabaseManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseManager();
                }
                return instance;
            }
        }

        public void OpenConnection(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    OpenConnection(connection);

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        try
                        {
                            adapter.Fill(dataTable);
                        }
                        catch (Exception ex)
                        {
                            ShowErrorMessage("Error executing query: " + ex.Message);
                        }
                    }
                }
            }
            return dataTable;
        }

        public int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddRange(parameters);

                    try
                    {
                        int result = command.ExecuteNonQuery();
                        transaction.Commit();
                        Console.WriteLine($"Query executed: {query}");
                        Console.WriteLine($"Rows affected: {result}");
                        foreach (var param in parameters)
                        {
                            Console.WriteLine($"{param.ParameterName}: {param.Value}");
                        }
                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ShowErrorMessage("Error executing non-query: " + ex.Message);
                        return -1;
                    }
                }
            }
        }


        public object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    OpenConnection(connection);
                    try
                    {
                        return command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("Error executing scalar: " + ex.Message);
                        return null;
                    }
                }
            }
        }

            /// <summary>
            /// Displays an error message to the user.
            /// </summary>
        internal void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

            /// <summary>
            /// Displays a success message to the user.
            /// </summary>
        internal void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DataTable ExecuteDataTable(string query, SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

    }
}