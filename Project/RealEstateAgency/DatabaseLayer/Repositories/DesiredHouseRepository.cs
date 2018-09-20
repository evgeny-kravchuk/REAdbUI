using DatabaseLayer.DLObjects;
using DatabaseLayer.Interfaces;
using Objects.Validation;
using Objects.Tables;
using Objects;
using System.Collections.Generic;
using System.Data.Common;
using System;
using Npgsql;

namespace DatabaseLayer.Repositories
{
    public class DesiredHouseRepository : IDesiredHouseRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public DesiredHouseRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region TableDesiredHouse Select
        public ValidationResult<List<TableDesiredHouse>> SelectDesiredHouse()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableDesiredHouse tableDesiredHouse;
            ValidationResult<List<TableDesiredHouse>> result = new ValidationResult<List<TableDesiredHouse>>()
            {
                IsValid = true,
                ResultObject = new List<TableDesiredHouse>()
            };

            try
            {
                string commPart =
                      "SELECT \"id_desiredObject\", \"id_client\", \"City\", \"Hood\", \"Street\", \"Type\", \"Area\", \"Status\", \"NumberOfStoreys\", \"Room\", \"Price\" " +
                      "FROM readb.\"DesiredHouse\" " +
                      "ORDER BY \"id_desiredObject\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();
                
                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableDesiredHouse = new TableDesiredHouse(

                        dbDataRecord["id_desiredObject"].ToString(),
                        dbDataRecord["id_client"].ToString(),

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

                    result.ResultObject.Add(tableDesiredHouse);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableDesiredHouse>>
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

        #region TableDesiredHouse Insert
        public bool AddDesiredHouseMember(DesiredHouseMember desiredHouseMember)
        {
            var result = AddDesiredHouse(desiredHouseMember);
            return result.IsValid;
        }

        public ValidationResultString AddDesiredHouse(DesiredHouseMember desiredHouseMember)
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
                string commPart = "INSERT INTO readb.\"DesiredHouse\" (\"id_client\", \"City\", \"Hood\", \"Street\", \"Type\", \"Area\", \"Status\", \"NumberOfStoreys\", \"Room\", \"Price\") VALUES " +
                "(@IdClient, @City, @Hood, @Street, @Type, @Area, @Status, @NumberOfStoreys, @Room, @Price)";
                
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@IdClient", Convert.ToInt32(desiredHouseMember.id_client));

                command.Parameters.AddWithValue("@City", desiredHouseMember.City);
                command.Parameters.AddWithValue("@Hood", desiredHouseMember.Hood);
                command.Parameters.AddWithValue("@Street", desiredHouseMember.Street);

                command.Parameters.AddWithValue("@Type", desiredHouseMember.Type);
                command.Parameters.AddWithValue("@Area", Convert.ToInt32(desiredHouseMember.Area));
                command.Parameters.AddWithValue("@Status", desiredHouseMember.Status);
                command.Parameters.AddWithValue("@NumberOfStoreys", Convert.ToInt32(desiredHouseMember.NumberOfStoreys));
                command.Parameters.AddWithValue("@Room", Convert.ToInt32(desiredHouseMember.Room));
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(desiredHouseMember.Price));

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

        #region TableDesiredHouse Update
        public bool UpdateDesiredHouseMember(DesiredHouseMember desiredHouseMember)
        {
            var result = EditDesiredHouse(desiredHouseMember);
            return result.IsValid;
        }

        public ValidationResultString EditDesiredHouse(DesiredHouseMember desiredHouseMember)
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
                string commPart = "UPDATE readb.\"DesiredHouse\" SET \"id_client\" = @IdClient, \"City\" = @City, \"Hood\" = @Hood, \"Street\" = @Street, " +
                "\"Type\" = @Type, \"Area\" = @Area, \"Status\" = @Status, \"NumberOfStoreys\" = @NumberOfStoreys, \"Room\" = @Room, \"Price\" = @Price " +
                "WHERE \"id_object\" = @HouseId";
                
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                
                command.Parameters.AddWithValue("@HouseId", Convert.ToInt32(desiredHouseMember.id_desiredObject));
                command.Parameters.AddWithValue("@IdClient", Convert.ToInt32(desiredHouseMember.id_client));

                command.Parameters.AddWithValue("@City", desiredHouseMember.City);
                command.Parameters.AddWithValue("@Hood", desiredHouseMember.Hood);
                command.Parameters.AddWithValue("@Street", desiredHouseMember.Street);

                command.Parameters.AddWithValue("@Type", desiredHouseMember.Type);
                command.Parameters.AddWithValue("@Area", Convert.ToInt32(desiredHouseMember.Area));
                command.Parameters.AddWithValue("@Status", desiredHouseMember.Status);
                command.Parameters.AddWithValue("@NumberOfStoreys", Convert.ToInt32(desiredHouseMember.NumberOfStoreys));
                command.Parameters.AddWithValue("@Room", Convert.ToInt32(desiredHouseMember.Room));
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(desiredHouseMember.Price));

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

        #region TableDesiredHouse Delete
        public bool DeleteDesiredHouseMember(DesiredHouseMember desiredHouseMember)
        {
            var result = DeleteDesiredHouse(desiredHouseMember);
            return result.IsValid;
        }

        public ValidationResultString DeleteDesiredHouse(DesiredHouseMember desiredHousemember)
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
                string commPart = "DELETE FROM readb.\"DesiredHouse\" WHERE \"id_desiredObject\" = @HouseId";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@HouseId", Convert.ToInt32(desiredHousemember.id_desiredObject));

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
