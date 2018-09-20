using DatabaseLayer.DLObjects;
using DatabaseLayer.Interfaces;
using Objects.Validation;
using Objects.Tables;
using Objects.Tables.IndividualTables;
using Objects;
using System.Collections.Generic;
using System.Data.Common;
using System;
using Npgsql;

namespace DatabaseLayer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        private string oldLogin { get; set; }
        private string newPassword { get; set; }

        public ClientRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region TableClient Select
        public ValidationResult<List<TableClient>> SelectClient()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableClient tableClient;
            ValidationResult<List<TableClient>> result = new ValidationResult<List<TableClient>>()
            {
                IsValid = true,
                ResultObject = new List<TableClient>()
            };

            try
            {
                string commPart =
                      "SELECT \"id_client\", \"Login\", (\"Name\").\"LastName\", (\"Name\").\"FirstName\", (\"Name\").\"Patronymic\", \"PhoneNumber\" " +
                      "FROM readb.\"Clients\" " +
                      "ORDER BY \"id_client\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();
                
                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableClient = new TableClient(
                        dbDataRecord["id_client"].ToString(),
                        dbDataRecord["Login"].ToString(),

                        dbDataRecord["LastName"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["Patronymic"].ToString(),

                        dbDataRecord["PhoneNumber"].ToString()
                        );

                    result.ResultObject.Add(tableClient);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableClient>>
                {
                    IsValid = false,
                    Errors = new List<string> { exp.SqlState }
                };
            }
            finally
            {
                if (!sqlConnect.GetConnect)
                {
                    sqlConnect.CloseConn();
                }
            }
            return result;
        }
        #endregion

        #region TableClient Insert
        public bool AddClientMember(ClientMember clientMember)
        {
            var result = AddClient(clientMember);
            return result.IsValid;
        }

        public ValidationResultString AddClient(ClientMember clientMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            ValidationResultString result = new ValidationResultString()
            {
                IsValid = true
            };
            try
            {
                string commPart = "SELECT * FROM login.add_client (@Login, @Password, @LastName, @FirstName, @Patronymic, @PhoneNumber)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login", clientMember.Login);
                command.Parameters.AddWithValue("@Password", clientMember.NewPassword);

                command.Parameters.AddWithValue("@LastName", clientMember.LastName);
                command.Parameters.AddWithValue("@FirstName", clientMember.FirstName);
                command.Parameters.AddWithValue("@Patronymic", clientMember.Patronymic);

                command.Parameters.AddWithValue("@PhoneNumber", clientMember.PhoneNumber);

                NpgsqlDataReader readerTable = command.ExecuteReader();
                readerTable.Close();
            }
            catch (Npgsql.PostgresException exp)
            {
                return new ValidationResultString
                {
                    Errors = new List<string> { exp.SqlState }
                };
            }
            finally
            {
                if (!sqlConnect.GetConnect)
                {
                    sqlConnect.CloseConn();
                }
            }
            return result;
        }
        #endregion

        #region TableClient Update
        public bool UpdateClientMember(ClientMember clientMember)
        {
            var result = EditClient(clientMember);
            return result.IsValid;
        }

        public ValidationResultString EditClient(ClientMember clientMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }
            ValidationResultString result = new ValidationResultString()
            {
                IsValid = true
            };
            try
            {
                string commPart = "UPDATE readb.\"Clients\" SET \"Name\" = ROW(@LastName, @FirstName, @Patronymic), " +
                "\"PhoneNumber\" = @PhoneNumber " +
                "WHERE \"id_client\" = @ClientId";
                
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                
                command.Parameters.AddWithValue("@ClientId", Convert.ToInt32(clientMember.id_client));

                command.Parameters.AddWithValue("@LastName", clientMember.LastName);
                command.Parameters.AddWithValue("@FirstName", clientMember.FirstName);
                command.Parameters.AddWithValue("@Patronymic", clientMember.Patronymic);

                command.Parameters.AddWithValue("@PhoneNumber", clientMember.PhoneNumber);

                NpgsqlDataReader readerTable = command.ExecuteReader();
                readerTable.Close();
            }
            catch (Npgsql.PostgresException exp)
            {
                return new ValidationResultString
                {
                    Errors = new List<string> { exp.SqlState }
                };
            }
            finally
            {
                if (!sqlConnect.GetConnect)
                {
                    sqlConnect.CloseConn();
                }
            }
            return result;
        }
        #endregion

        #region TableClient Delete
        public bool DeleteClientMember(ClientMember clientMember)
        {
            var result = DeleteClient(clientMember);
            return result.IsValid;
        }

        public ValidationResultString DeleteClient(ClientMember clientmember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }
            ValidationResultString result = new ValidationResultString()
            {
                IsValid = true
            };
            try
            {
                string commPart = "SELECT * FROM readb.delete_client (@ClientId)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@ClientId", Convert.ToInt32(clientmember.id_client));

                NpgsqlDataReader readerTable = command.ExecuteReader();
                readerTable.Close();
            }
            catch (Npgsql.PostgresException exp)
            {
                return new ValidationResultString
                {
                    Errors = new List<string> { exp.SqlState }
                };
            }
            finally
            {
                if (!sqlConnect.GetConnect)
                {
                    sqlConnect.CloseConn();
                }
            }
            return result;
        }
        #endregion

        #region TableSelectContract
        public ValidationResult<List<TableClientContractInfo>> SelectContractClient(ClientMember clientMember)
        {
            var res = GetSingleTable(clientMember);
            return res;
        }

        public ValidationResult<List<TableClientContractInfo>> GetSingleTable(ClientMember clientMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn(); ;
            }

            TableClientContractInfo tableClient;

            ValidationResult<List<TableClientContractInfo>> result = new ValidationResult<List<TableClientContractInfo>>()
            {
                IsValid = true,
                ResultObject = new List<TableClientContractInfo>()
            };

            try
            {
                string commPart = "SELECT (o.\"Address\").\"City\", (o.\"Address\").\"Street\", (o.\"Address\").\"HouseNumber\", (o.\"Address\").\"FlatNumber\", c.\"ContractType\", c.\"StartDate\", c.\"FinishDate\", c.\"Price\" " +
                                  "FROM readb.\"Objects\" o,readb.\"Contracts\" c, readb.\"Clients\" cl " +
                                  "WHERE o.\"id_object\" = c.\"id_object\" AND cl.\"id_client\" = c.\"id_client\" AND cl.\"Login\" = @Login " +
                                  "GROUP BY (o.\"Address\").\"City\", (o.\"Address\").\"Street\", (o.\"Address\").\"HouseNumber\",(o.\"Address\").\"FlatNumber\", c.\"ContractType\", c.\"StartDate\", c.\"FinishDate\", c.\"Price\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login", Convert.ToString(clientMember.Login));

                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableClient = new TableClientContractInfo(
                        dbDataRecord["City"].ToString(),
                        dbDataRecord["Street"].ToString(),
                        dbDataRecord["HouseNumber"].ToString(),
                        dbDataRecord["FlatNumber"].ToString(),
                        dbDataRecord["ContractType"].ToString(),
                        Convert.ToDateTime(dbDataRecord["StartDate"]).ToString("dd/MM/yyyy"),
                        Convert.ToDateTime(dbDataRecord["FinishDate"]).ToString("dd/MM/yyyy"),
                        dbDataRecord["Price"].ToString()
                        );
                    result.ResultObject.Add(tableClient);
                }
                readerTable.Close();
            }
            catch (Npgsql.PostgresException exp)
            {
                result = new ValidationResult<List<TableClientContractInfo>>
                {
                    IsValid = false,
                    Errors = new List<string> { exp.SqlState }
                };
            }
            finally
            {
                if (!sqlConnect.GetConnect)
                {
                    sqlConnect.CloseConn();
                }
            }
            return result;
        }
        #endregion

        #region TableSelectClientPersonalInfo
        public ValidationResult<List<TableClientPersonalInfo>> SelectPersonalInfoClient(ClientMember clientMember)
        {
            var res = GetClientPersonalInfo(clientMember);
            return res;
        }

        public ValidationResult<List<TableClientPersonalInfo>> GetClientPersonalInfo(ClientMember clientMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableClientPersonalInfo tableClientPersonalInfo;

            ValidationResult<List<TableClientPersonalInfo>> result = new ValidationResult<List<TableClientPersonalInfo>>()
            {
                IsValid = true,
                ResultObject = new List<TableClientPersonalInfo>()
            };
            try
            {
                string commPart = "SELECT c.\"Login\", (c.\"Name\").\"LastName\", (c.\"Name\").\"FirstName\", (c.\"Name\").\"Patronymic\", c.\"PhoneNumber\" " +
                                  "FROM readb.\"Clients\" c, login.\"DBUsers\" as l " +
                                  "WHERE l.Login = c.\"Login\" AND l.Login = @Login";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login", Convert.ToString(clientMember.Login));

                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableClientPersonalInfo = new TableClientPersonalInfo(
                        dbDataRecord["Login"].ToString(),

                        dbDataRecord["LastName"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["Patronymic"].ToString(),

                        dbDataRecord["PhoneNumber"].ToString()
                        );

                    result.ResultObject.Add(tableClientPersonalInfo);
                }
                readerTable.Close();
            }
            catch (Npgsql.PostgresException exp)
            {
                result = new ValidationResult<List<TableClientPersonalInfo>>
                {
                    IsValid = false,
                    Errors = new List<string> { exp.SqlState }
                };
            }
            finally
            {
                if (!sqlConnect.GetConnect)
                {
                    sqlConnect.CloseConn();
                }
            }
            return result;
        }
        #endregion

        #region TableSelectClientDesiredFlat
        public ValidationResult<List<TableClientDesiredFlat>> SelectDesiredFlatClient(ClientMember clientMember)
        {
            var res = GetDesiredFlatInfo(clientMember);
            return res;
        }

        public ValidationResult<List<TableClientDesiredFlat>> GetDesiredFlatInfo(ClientMember clientMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableClientDesiredFlat tableClientDesiredFlat;
            
            ValidationResult<List<TableClientDesiredFlat>> result = new ValidationResult<List<TableClientDesiredFlat>>()
            {
                IsValid = true,
                ResultObject = new List<TableClientDesiredFlat>()
            };

            try
            {
                string commPart = "SELECT df.\"City\", df.\"Hood\", df.\"Street\", df.\"Type\", df.\"Area\", df.\"Status\", df.\"Floor\", df.\"Room\", df.\"Price\" " +
                                  "FROM readb.\"Clients\" c, readb.\"DesiredFlat\" df " +
                                  "WHERE df.\"id_client\" = c.\"id_client\" AND c.\"Login\" = @Login ";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login", Convert.ToString(clientMember.Login));

                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableClientDesiredFlat = new TableClientDesiredFlat(
                        dbDataRecord["City"].ToString(),
                        dbDataRecord["Hood"].ToString(),
                        dbDataRecord["Street"].ToString(),

                        dbDataRecord["Type"].ToString(),
                        dbDataRecord["Area"].ToString(),
                        dbDataRecord["Status"].ToString(),
                        dbDataRecord["Floor"].ToString(),
                        dbDataRecord["Room"].ToString(),
                        dbDataRecord["Price"].ToString()
                        );

                        result.ResultObject.Add(tableClientDesiredFlat);
                }
                readerTable.Close();

            }
            catch (Npgsql.PostgresException exp)
            {
                result = new ValidationResult<List<TableClientDesiredFlat>>
                {
                    IsValid = false,
                    Errors = new List<string> { exp.SqlState }
                };
            }
            finally
            {
                if (!sqlConnect.GetConnect)
                {
                    sqlConnect.CloseConn();
                }
            }
            return result;
        }
        #endregion

        #region TableSelectClientDesiredHouse
        public ValidationResult<List<TableClientDesiredHouse>> SelectDesiredHouseClient(ClientMember clientMember)
        {
            var res = GetDesiredHouseInfo(clientMember);
            return res;
        }

        public ValidationResult<List<TableClientDesiredHouse>> GetDesiredHouseInfo(ClientMember clientMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableClientDesiredHouse tableClientDesiredHouse;

            ValidationResult<List<TableClientDesiredHouse>> result = new ValidationResult<List<TableClientDesiredHouse>>()
            {
                IsValid = true,
                ResultObject = new List<TableClientDesiredHouse>()
            };

            try
            {
                string commPart = "SELECT dh.\"City\", dh.\"Hood\", dh.\"Street\", dh.\"Type\", dh.\"Area\", dh.\"Status\", dh.\"NumberOfStoreys\", dh.\"Room\", dh.\"Price\" " +
                                  "FROM readb.\"Clients\" c, readb.\"DesiredHouse\" dh, login.\"DBUsers\" l " +
                                  "WHERE dh.\"id_client\" = c.\"id_client\" AND l.Login = c.\"Login\" AND l.Login = @Login";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login", Convert.ToString(clientMember.Login));

                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableClientDesiredHouse = new TableClientDesiredHouse(
                        dbDataRecord["City"].ToString(),
                        dbDataRecord["Hood"].ToString(),
                        dbDataRecord["Street"].ToString(),

                        dbDataRecord["Type"].ToString(),
                        dbDataRecord["Area"].ToString(),
                        dbDataRecord["Status"].ToString(),
                        dbDataRecord["NumberOfStoreys"].ToString(),
                        dbDataRecord["Room"].ToString(),
                        dbDataRecord["Price"].ToString()
                        );

                    result.ResultObject.Add(tableClientDesiredHouse);
                }
                readerTable.Close();

            }
            catch (Npgsql.PostgresException exp)
            {
                result = new ValidationResult<List<TableClientDesiredHouse>>
                {
                    IsValid = false,
                    Errors = new List<string> { exp.SqlState }
                };
            }
            finally
            {
                if (!sqlConnect.GetConnect)
                {
                    sqlConnect.CloseConn();
                }
            }
            return result;
        }
        #endregion

        #region TableSelectClientDesiredPlot
        public ValidationResult<List<TableClientDesiredPlot>> SelectDesiredPlotClient(ClientMember clientMember)
        {
            var res = GetDesiredPlotInfo(clientMember);
            return res;
        }

        public ValidationResult<List<TableClientDesiredPlot>> GetDesiredPlotInfo(ClientMember clientMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableClientDesiredPlot tableClientDesiredPlot;

            ValidationResult<List<TableClientDesiredPlot>> result = new ValidationResult<List<TableClientDesiredPlot>>()
            {
                IsValid = true,
                ResultObject = new List<TableClientDesiredPlot>()
            };

            try
            {
                string commPart = "SELECT dp.\"City\", dp.\"Hood\", dp.\"Street\", dp.\"Type\", dp.\"Area\", dp.\"Status\", dp.\"Price\" " +
                                  "FROM readb.\"Clients\" c, readb.\"DesiredPlot\" dp, login.\"DBUsers\" l " +
                                  "WHERE dp.\"id_client\" = c.\"id_client\" AND l.Login = c.\"Login\" AND l.Login = @Login";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login", Convert.ToString(clientMember.Login));

                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableClientDesiredPlot = new TableClientDesiredPlot(
                        dbDataRecord["City"].ToString(),
                        dbDataRecord["Hood"].ToString(),
                        dbDataRecord["Street"].ToString(),

                        dbDataRecord["Type"].ToString(),
                        dbDataRecord["Area"].ToString(),
                        dbDataRecord["Status"].ToString(),
                        dbDataRecord["Price"].ToString()
                        );

                    result.ResultObject.Add(tableClientDesiredPlot);
                }
                readerTable.Close();

            }
            catch (Npgsql.PostgresException exp)
            {
                result = new ValidationResult<List<TableClientDesiredPlot>>
                {
                    IsValid = false,
                    Errors = new List<string> { exp.SqlState }
                };
            }
            finally
            {
                if (!sqlConnect.GetConnect)
                {
                    sqlConnect.CloseConn();
                }
            }
            return result;
        }
        #endregion

        #region TableUpdatePassword Client
        public bool UpdatePassword(ClientMember clientMember)
        {
            var res = UpdatePass(clientMember);
            return res.IsValid;
        }

        public ValidationResultString UpdatePass(ClientMember clientMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            ValidationResultString result = new ValidationResultString()
            {
                IsValid = true
            };

            try
            {
                string commPart = "SELECT * FROM readb.edit_Password(@Login, @NewPassword, @OldPassword)";
                
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                
                command.Parameters.AddWithValue("@Login", Convert.ToString(clientMember.Login));
                command.Parameters.AddWithValue("@OldPassword", Convert.ToString(clientMember.OldPassword));
                command.Parameters.AddWithValue("@NewPassword", Convert.ToString(clientMember.NewPassword));

                NpgsqlDataReader readerTable = command.ExecuteReader();

                readerTable.Close();

                string commParts = " SELECT Login, Passwd " +
                                   " FROM login.\"DBUsers\" " +
                                   " WHERE Login = @Log ";

                NpgsqlCommand commands = new NpgsqlCommand(commParts, sqlConnect.GetNewSqlConn().GetConn);

                commands.Parameters.AddWithValue("@Log", Convert.ToString(clientMember.Login));

                NpgsqlDataReader readerTables = commands.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTables)
                {
                    oldLogin = dbDataRecord["Login"].ToString();
                    newPassword = dbDataRecord["Passwd"].ToString();
                }

                if (oldLogin == null && newPassword == null)
                {
                    return new ValidationResultString
                    {
                        Errors = new List<string> { "Не верно введен старый пароль" }
                    };
                }
                readerTables.Close();
            }
            catch (PostgresException exp)
            {
                return new ValidationResultString
                {
                    Errors = new List<string> { exp.SqlState }
                };
            }
            finally
            {
                if (!sqlConnect.GetConnect)
                {
                    sqlConnect.CloseConn();
                }
            }
            return result;
        }
        #endregion

        #region UpdateLogin Client
        public bool UpdateLogin(ClientMember clientMember)
        {
            var res = UpdateLog(clientMember);
            return res.IsValid;
        }

        public ValidationResultString UpdateLog(ClientMember clientMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            ValidationResultString result = new ValidationResultString()
            {
                IsValid = true
            };

            try
            {
                string commPart = "SELECT * FROM readb.edit_clientLogin(@NewLogin, @Login)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@NewLogin", Convert.ToString(clientMember.NewLogin));
                command.Parameters.AddWithValue("@Login", Convert.ToString(clientMember.Login));
                
                NpgsqlDataReader readerTable = command.ExecuteReader();
                readerTable.Close();
            }
            catch (Npgsql.PostgresException exp)
            {
                return new ValidationResultString
                {
                    Errors = new List<string> { exp.SqlState }
                };
            }
            finally
            {
                if (!sqlConnect.GetConnect)
                {
                    sqlConnect.CloseConn();
                }
            }
            return result;
        }
        #endregion

        #region UpdatePersonalInfo Client
        public bool UpdateClientPersonalInfo(ClientMember clientMember)
        {
            var res = UpdateClientInfoPrivate(clientMember);
            return res.IsValid;
        }

        public ValidationResultString UpdateClientInfoPrivate(ClientMember clientMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            ValidationResultString result = new ValidationResultString()
            {
                IsValid = true
            };
            try
            {
                string commPart = "SELECT * FROM readb.edit_clientInfo(@Login, @LastName, @FirstName, @Patronymic, @PhoneNumber);";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login", clientMember.Login);

                command.Parameters.AddWithValue("@LastName", clientMember.LastName);
                command.Parameters.AddWithValue("@FirstName", clientMember.FirstName);
                command.Parameters.AddWithValue("@Patronymic", clientMember.Patronymic);

                command.Parameters.AddWithValue("@PhoneNumber", clientMember.PhoneNumber);
                               
                NpgsqlDataReader readerTable = command.ExecuteReader();
                readerTable.Close();

            }
            catch (Npgsql.PostgresException exp)
            {
                return new ValidationResultString
                {
                    Errors = new List<string> { exp.SqlState }
                };
            }
            finally
            {
                if (!sqlConnect.GetConnect)
                {
                    sqlConnect.CloseConn();
                }
            }
            return result;
        }
        #endregion
    }
}