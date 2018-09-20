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
    public class FlatRepository : IFlatRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public FlatRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region TableFlat Select
        public ValidationResult<List<TableFlat>> SelectFlat()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableFlat tableFlat;
            ValidationResult<List<TableFlat>> result = new ValidationResult<List<TableFlat>>()
            {
                IsValid = true,
                ResultObject = new List<TableFlat>()
            };

            try
            {
                string commPart =
                      "SELECT \"id_object\", \"id_owner\", (\"Address\").\"PostCode\", (\"Address\").\"City\", (\"Address\").\"Hood\", (\"Address\").\"Street\", (\"Address\").\"HouseNumber\", (\"Address\").\"FlatNumber\", \"Type\", \"Area\", \"Status\", \"Floor\", \"Room\", \"Price\" " +
                      "FROM readb.\"Flat\" " +
                      "ORDER BY \"id_object\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableFlat = new TableFlat(

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
                        dbDataRecord["Floor"].ToString(),
                        dbDataRecord["Room"].ToString(),
                        dbDataRecord["Price"].ToString()
                        );

                    result.ResultObject.Add(tableFlat);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableFlat>>
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

        #region TableFlat Find
        public ValidationResult<List<TableFindFlat>> FindFlat(FlatMember flatMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableFindFlat tableFindFlat;
            ValidationResult<List<TableFindFlat>> result = new ValidationResult<List<TableFindFlat>>()
            {
                IsValid = true,
                ResultObject = new List<TableFindFlat>()
            };

            try
            {
                string commPart =
                      "SELECT (\"Address\").\"PostCode\", (\"Address\").\"City\", (\"Address\").\"Hood\", (\"Address\").\"Street\", (\"Address\").\"HouseNumber\", (\"Address\").\"FlatNumber\", \"Type\", \"Area\", \"Status\", \"Floor\", \"Room\", \"Price\" " +
                      "FROM readb.\"Flat\" " +
                      "WHERE (\"Address\").\"City\" = @City " +
                      "AND ((\"Address\").\"Hood\" = @Hood OR @Hood IS NULL) " +
                      "AND ((\"Address\").\"Street\" = @Street OR @Street IS NULL) " +
                      "AND (\"Type\" = @Type) " +
                      "AND ((\"Area\" < @Area * 1.5 AND \"Area\" > @Area * 0.5) OR @Area IS NULL) " +
                      "AND (\"Status\" = @Status OR @Status IS NULL) " +
                      "AND ((\"Floor\" < @Floor + 2 AND \"Floor\" > @Floor - 2) OR @Floor IS NULL) " +
                      "AND ((\"Room\" < @Room + 2 AND \"Room\" > @Room - 2) OR @Room IS NULL) " +
                      "AND ((\"Price\" < @Price * 1.5 AND \"Price\" > @Price * 0.5) OR @Price IS NULL) ";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@City", Convert.ToString(flatMember.City));
                command.Parameters.AddWithValue("@Hood", Convert.ToString(flatMember.Hood));
                command.Parameters.AddWithValue("@Street", Convert.ToString(flatMember.Street));

                command.Parameters.AddWithValue("@Type", Convert.ToString(flatMember.Type));
                command.Parameters.AddWithValue("@Area", Convert.ToInt32(flatMember.Area));
                command.Parameters.AddWithValue("@Status", Convert.ToString(flatMember.Status));
                command.Parameters.AddWithValue("@Floor", Convert.ToInt32(flatMember.Floor));
                command.Parameters.AddWithValue("@Room", Convert.ToInt32(flatMember.Room));
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(flatMember.Price));

                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableFindFlat = new TableFindFlat(
                        
                        dbDataRecord["PostCode"].ToString(),
                        dbDataRecord["City"].ToString(),
                        dbDataRecord["Hood"].ToString(),
                        dbDataRecord["Street"].ToString(),
                        dbDataRecord["HouseNumber"].ToString(),
                        dbDataRecord["FlatNumber"].ToString(),

                        dbDataRecord["Type"].ToString(),
                        dbDataRecord["Area"].ToString(),
                        dbDataRecord["Status"].ToString(),
                        dbDataRecord["Floor"].ToString(),
                        dbDataRecord["Room"].ToString(),
                        dbDataRecord["Price"].ToString()
                        );

                    result.ResultObject.Add(tableFindFlat);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableFindFlat>>
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

        #region TableFlat Insert
        public bool AddFlatMember(FlatMember flatMember)
        {
            var result = AddFlat(flatMember);
            return result.IsValid;
        }

        public ValidationResultString AddFlat(FlatMember flatMember)
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
                string commPart = "INSERT INTO readb.\"Flat\" (\"id_owner\", \"Address\", \"Type\", \"Area\", \"Status\", \"Floor\", \"Room\", \"Price\") VALUES " +
                "(@IdOwner, ROW(@PostCode, @City, @Hood, @Street, @HouseNumber, @FlatNumber), @Type, @Area, @Status, @Floor, @Room, @Price)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@IdOwner", Convert.ToInt32(flatMember.id_owner));

                command.Parameters.AddWithValue("@PostCode", flatMember.PostCode);
                command.Parameters.AddWithValue("@City", flatMember.City);
                command.Parameters.AddWithValue("@Hood", flatMember.Hood);
                command.Parameters.AddWithValue("@Street", flatMember.Street);
                command.Parameters.AddWithValue("@HouseNumber", Convert.ToInt32(flatMember.HouseNumber));
                command.Parameters.AddWithValue("@FlatNumber", Convert.ToInt32(flatMember.FlatNumber));

                command.Parameters.AddWithValue("@Type", flatMember.Type);
                command.Parameters.AddWithValue("@Area", Convert.ToInt32(flatMember.Area));
                command.Parameters.AddWithValue("@Status", flatMember.Status);
                command.Parameters.AddWithValue("@Floor", Convert.ToInt32(flatMember.Floor));
                command.Parameters.AddWithValue("@Room", Convert.ToInt32(flatMember.Room));
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(flatMember.Price));

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

        #region TableFlat Update
        public bool UpdateFlatMember(FlatMember flatMember)
        {
            var result = EditFlat(flatMember);
            return result.IsValid;
        }

        public ValidationResultString EditFlat(FlatMember flatMember)
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
                string commPart = "UPDATE readb.\"Flat\" SET \"id_owner\" = @IdOwner, \"Address\" = ROW(@PostCode, @City, @Hood, @Street, @HouseNumber, @FlatNumber), " +
                "\"Type\" = @Type, \"Area\" = @Area, \"Status\" = @Status, \"Floor\" = @Floor, \"Room\" = @Room, \"Price\" = @Price " +
                "WHERE \"id_object\" = @FlatId";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@FlatId", Convert.ToInt32(flatMember.id_object));
                command.Parameters.AddWithValue("@IdOwner", Convert.ToInt32(flatMember.id_owner));

                command.Parameters.AddWithValue("@PostCode", flatMember.PostCode);
                command.Parameters.AddWithValue("@City", flatMember.City);
                command.Parameters.AddWithValue("@Hood", flatMember.Hood);
                command.Parameters.AddWithValue("@Street", flatMember.Street);
                command.Parameters.AddWithValue("@HouseNumber", Convert.ToInt32(flatMember.HouseNumber));
                command.Parameters.AddWithValue("@FlatNumber", Convert.ToInt32(flatMember.FlatNumber));

                command.Parameters.AddWithValue("@Type", flatMember.Type);
                command.Parameters.AddWithValue("@Area", Convert.ToInt32(flatMember.Area));
                command.Parameters.AddWithValue("@Status", flatMember.Status);
                command.Parameters.AddWithValue("@Floor", Convert.ToInt32(flatMember.Floor));
                command.Parameters.AddWithValue("@Room", Convert.ToInt32(flatMember.Room));
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(flatMember.Price));

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

        #region TableFlat Delete
        public bool DeleteFlatMember(FlatMember flatMember)
        {
            var result = DeleteFlat(flatMember);
            return result.IsValid;
        }

        public ValidationResultString DeleteFlat(FlatMember flatMember)
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
                string commPart = "DELETE FROM readb.\"Flat\" WHERE \"id_object\" = @FlatId";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@FlatId", Convert.ToInt32(flatMember.id_object));

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
