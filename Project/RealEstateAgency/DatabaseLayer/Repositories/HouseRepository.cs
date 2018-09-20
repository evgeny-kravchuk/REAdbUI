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
    public class HouseRepository : IHouseRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public HouseRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region TableHouse Select
        public ValidationResult<List<TableHouse>> SelectHouse()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableHouse tableHouse;
            ValidationResult<List<TableHouse>> result = new ValidationResult<List<TableHouse>>()
            {
                IsValid = true,
                ResultObject = new List<TableHouse>()
            };

            try
            {
                string commPart =
                      "SELECT \"id_object\", \"id_owner\", (\"Address\").\"PostCode\", (\"Address\").\"City\", (\"Address\").\"Hood\", (\"Address\").\"Street\", (\"Address\").\"HouseNumber\", (\"Address\").\"FlatNumber\", \"Type\", \"Area\", \"Status\", \"NumberOfStoreys\", \"Room\", \"Price\" " +
                      "FROM readb.\"House\" " +
                      "ORDER BY \"id_object\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableHouse = new TableHouse(

                        dbDataRecord["id_object"].ToString(),
                        dbDataRecord["id_owner"].ToString(),

                        dbDataRecord["PostCode"].ToString(),
                        dbDataRecord["City"].ToString(),
                        dbDataRecord["Hood"].ToString(),
                        dbDataRecord["Street"].ToString(),
                        dbDataRecord["HouseNumber"].ToString(),
                        dbDataRecord["FlatNumber"].ToString(),

                        dbDataRecord["Type"].ToString(),
                        dbDataRecord["Area"].ToString(),
                        dbDataRecord["Status"].ToString(),
                        dbDataRecord["NumberOfStoreys"].ToString(),
                        dbDataRecord["Room"].ToString(),
                        dbDataRecord["Price"].ToString()
                        );

                    result.ResultObject.Add(tableHouse);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableHouse>>
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

        #region TableHouse Find
        public ValidationResult<List<TableFindHouse>> FindHouse(HouseMember houseMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableFindHouse tableFindHouse;
            ValidationResult<List<TableFindHouse>> result = new ValidationResult<List<TableFindHouse>>()
            {
                IsValid = true,
                ResultObject = new List<TableFindHouse>()
            };

            try
            {
                string commPart =
                      "SELECT (\"Address\").\"PostCode\", (\"Address\").\"City\", (\"Address\").\"Hood\", (\"Address\").\"Street\", (\"Address\").\"HouseNumber\", (\"Address\").\"FlatNumber\", \"Type\", \"Area\", \"Status\", \"NumberOfStoreys\", \"Room\", \"Price\" " +
                      "FROM readb.\"House\" " +
                      "WHERE (\"Address\").\"City\" = @City " +
                      "AND ((\"Address\").\"Hood\" = @Hood OR @Hood IS NULL) " +
                      "AND ((\"Address\").\"Street\" = @Street OR @Street IS NULL) " +
                      "AND (\"Type\" = @Type) " +
                      "AND ((\"Area\" < @Area * 1.5 AND \"Area\" > @Area * 0.5) OR @Area IS NULL) " +
                      "AND (\"Status\" = @Status OR @Status IS NULL) " +
                      "AND ((\"NumberOfStoreys\" < @NumberOfStoreys + 2 AND \"NumberOfStoreys\" > @NumberOfStoreys - 2) OR @NumberOfStoreys IS NULL) " +
                      "AND ((\"Room\" < @Room + 2 AND \"Room\" > @Room - 2) OR @Room IS NULL) " +
                      "AND ((\"Price\" < @Price * 1.5 AND \"Price\" > @Price * 0.5) OR @Price IS NULL) ";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@City", Convert.ToString(houseMember.City));
                command.Parameters.AddWithValue("@Hood", Convert.ToString(houseMember.Hood));
                command.Parameters.AddWithValue("@Street", Convert.ToString(houseMember.Street));

                command.Parameters.AddWithValue("@Type", Convert.ToString(houseMember.Type));
                command.Parameters.AddWithValue("@Area", Convert.ToString(houseMember.Area));
                command.Parameters.AddWithValue("@Status", Convert.ToString(houseMember.Status));
                command.Parameters.AddWithValue("@NumberOfStoreys", Convert.ToString(houseMember.NumberOfStoreys));
                command.Parameters.AddWithValue("@Room", Convert.ToString(houseMember.Room));
                command.Parameters.AddWithValue("@Price", Convert.ToString(houseMember.Price));

                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableFindHouse = new TableFindHouse(

                        dbDataRecord["PostCode"].ToString(),
                        dbDataRecord["City"].ToString(),
                        dbDataRecord["Hood"].ToString(),
                        dbDataRecord["Street"].ToString(),
                        dbDataRecord["HouseNumber"].ToString(),
                        dbDataRecord["FlatNumber"].ToString(),

                        dbDataRecord["Type"].ToString(),
                        dbDataRecord["Area"].ToString(),
                        dbDataRecord["Status"].ToString(),
                        dbDataRecord["NumberOfStoreys"].ToString(),
                        dbDataRecord["Room"].ToString(),
                        dbDataRecord["Price"].ToString()
                        );

                    result.ResultObject.Add(tableFindHouse);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableFindHouse>>
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

        #region TableHouse Insert
        public bool AddHouseMember(HouseMember houseMember)
        {
            var result = AddHouse(houseMember);
            return result.IsValid;
        }

        public ValidationResultString AddHouse(HouseMember houseMember)
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
                string commPart = "INSERT INTO readb.\"House\" (\"id_owner\", \"Address\", \"Type\", \"Area\", \"Status\", \"NumberOfStoreys\", \"Room\", \"Price\") VALUES " +
                "(@IdOwner, ROW(@PostCode, @City, @Hood, @Street, @HouseNumber, @FlatNumber), @Type, @Area, @Status, @NumberOfStoreys, @Room, @Price)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@IdOwner", Convert.ToInt32(houseMember.id_owner));

                command.Parameters.AddWithValue("@PostCode", houseMember.PostCode);
                command.Parameters.AddWithValue("@City", houseMember.City);
                command.Parameters.AddWithValue("@Hood", houseMember.Hood);
                command.Parameters.AddWithValue("@Street", houseMember.Street);
                command.Parameters.AddWithValue("@HouseNumber", Convert.ToInt32(houseMember.HouseNumber));
                command.Parameters.AddWithValue("@FlatNumber", Convert.ToInt32(houseMember.FlatNumber));

                command.Parameters.AddWithValue("@Type", houseMember.Type);
                command.Parameters.AddWithValue("@Area", Convert.ToInt32(houseMember.Area));
                command.Parameters.AddWithValue("@Status", houseMember.Status);
                command.Parameters.AddWithValue("@NumberOfStoreys", Convert.ToInt32(houseMember.NumberOfStoreys));
                command.Parameters.AddWithValue("@Room", Convert.ToInt32(houseMember.Room));
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(houseMember.Price));

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

        #region TableHouse Update
        public bool UpdateHouseMember(HouseMember houseMember)
        {
            var result = EditHouse(houseMember);
            return result.IsValid;
        }

        public ValidationResultString EditHouse(HouseMember houseMember)
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
                string commPart = "UPDATE readb.\"House\" SET \"id_owner\" = @IdOwner, \"Address\" = ROW(@PostCode, @City, @Hood, @Street, @HouseNumber, @FlatNumber), " +
                "\"Type\" = @Type, \"Area\" = @Area, \"Status\" = @Status, \"NumberOfStoreys\" = @NumberOfStoreys, \"Room\" = @Room, \"Price\" = @Price " +
                "WHERE \"id_object\" = @HouseId";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@HouseId", Convert.ToInt32(houseMember.id_object));
                command.Parameters.AddWithValue("@IdOwner", Convert.ToInt32(houseMember.id_owner));

                command.Parameters.AddWithValue("@PostCode", houseMember.PostCode);
                command.Parameters.AddWithValue("@City", houseMember.City);
                command.Parameters.AddWithValue("@Hood", houseMember.Hood);
                command.Parameters.AddWithValue("@Street", houseMember.Street);
                command.Parameters.AddWithValue("@HouseNumber", Convert.ToInt32(houseMember.HouseNumber));
                command.Parameters.AddWithValue("@FlatNumber", Convert.ToInt32(houseMember.FlatNumber));

                command.Parameters.AddWithValue("@Type", houseMember.Type);
                command.Parameters.AddWithValue("@Area", Convert.ToInt32(houseMember.Area));
                command.Parameters.AddWithValue("@Status", houseMember.Status);
                command.Parameters.AddWithValue("@NumberOfStoreys", Convert.ToInt32(houseMember.NumberOfStoreys));
                command.Parameters.AddWithValue("@Room", Convert.ToInt32(houseMember.Room));
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(houseMember.Price));

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

        #region TableHouse Delete
        public bool DeleteHouseMember(HouseMember houseMember)
        {
            var result = DeleteHouse(houseMember);
            return result.IsValid;
        }

        public ValidationResultString DeleteHouse(HouseMember houseMember)
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
                string commPart = "DELETE FROM readb.\"House\" WHERE \"id_object\" = @HouseId";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@HouseId", Convert.ToInt32(houseMember.id_object));

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
