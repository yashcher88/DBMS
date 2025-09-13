using Avalonia.Controls;
using DBMS.Enums;
using DBMS.Functions;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class Connection
    {
        public Server Server;
        public string NowDatabase;
        public DbDataSource dataSource;
        public List<ConnectionMessage> Messages = new List<ConnectionMessage>();
        public List<ViewTable> Results = new List<ViewTable>();
        public List<ConnectionExplain> Explains = new List<ConnectionExplain>();

        public ConnectionStateType State = ConnectionStateType.Disconnected;
        public DateTime LastStart;

        public bool ReadNotice = false;

        private void CreateDatasource()
        {
            State = ConnectionStateType.Disconnected;
            if (dataSource == null)
            {
                var connectionString = "Host=" + Server.Host + ":" + Server.Port + ";Username=" + Server.Login + ";Password=" + Server.Password + ";Database=" + NowDatabase;
                var builder = new NpgsqlDataSourceBuilder(connectionString);
                dataSource = builder.Build();
            }
        }
        public void Connect()
        {
            CreateDatasource();
            try
            {
                var B = dataSource.OpenConnection();
                State = ConnectionStateType.Connected;
            }
            catch (Exception ex)
            {
                Messages.Add(new ConnectionMessage() { ErrorType = ConnectionTypeError.Error, Message = ex.Message });
            }
        }
        public bool CheckConnection()
        {
            Messages.Clear();
            Connect();
            if (State != ConnectionStateType.Disconnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ChangeDB(string NewDatabase)
        {
            string OldDatabase = NowDatabase;
            dataSource = null;
            NowDatabase = NewDatabase;
            bool res = CheckConnection();
            if (!res)
            {
                //Пытаемся переключиться обратно
                NowDatabase = OldDatabase;
                CheckConnection();
            }
            return res;
        }
        public bool Execute(string Batch)
        {
            State = ConnectionStateType.Executing;
            LastStart = DateTime.Now;
            Results.Clear();
            ViewTable dataTable = new ViewTable();

            using (var connection = (dataSource as NpgsqlDataSource).CreateConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand(Batch, connection))
                using (var reader = command.ExecuteReader())
                {
                    bool b = true;
                    while (reader.Read())
                    {
                        if (b)
                        {
                            List<string> L = new List<string>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                L.Add(reader.GetName(i));
                            }
                            dataTable.FillColumns(L);
                            b = false;
                        }
                        List<string> R = new List<string>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            R.Add(reader.GetValue(i).ToString());
                        }
                        dataTable.AddRow(R);
                    }
                }
            }
            Results.Add(dataTable);
            return true;
        }
        public async Task<bool> ExecuteAsync(string batch)
        {
            State = ConnectionStateType.Executing;
            LastStart = DateTime.Now;
            Results.Clear();

            try
            {
                await using var connection = await (dataSource as NpgsqlDataSource).OpenConnectionAsync();
                await using var command = new NpgsqlCommand(batch, connection);

                await using var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    // Чтение результата
                    var dataTable = new ViewTable();
                    bool headerFilled = false;

                    while (await reader.ReadAsync())
                    {
                        if (!headerFilled)
                        {
                            List<string> columns = new List<string>();
                            for (int i = 0; i < reader.FieldCount; i++)
                                columns.Add(reader.GetName(i));
                            dataTable.FillColumns(columns);
                            headerFilled = true;
                        }

                        List<string> row = new List<string>();
                        for (int i = 0; i < reader.FieldCount; i++)
                            row.Add(reader.GetValue(i)?.ToString() ?? "NULL");
                        dataTable.AddRow(row);
                    }

                    Results.Add(dataTable);
                }
                else
                {
                    // Нет строк → это был DML/DDL
                    int affected = reader.RecordsAffected;
                    Messages.Add(new ConnectionMessage()
                    {
                        ErrorType = ConnectionTypeError.Info,
                        Message = $"Выполнено успешно, затронуто строк: {affected}"
                    });
                }

                State = ConnectionStateType.Complete;
                return true;
            }
            catch (Exception ex)
            {
                State = ConnectionStateType.CompleteError;
                Messages.Add(new ConnectionMessage()
                {
                    ErrorType = ConnectionTypeError.Error,
                    Message = ex.Message
                });
                return false;
            }
        }
        public ConnectionMessage GetLastError()
        {
            return Messages[Messages.Count - 1];
        }
    }
}
