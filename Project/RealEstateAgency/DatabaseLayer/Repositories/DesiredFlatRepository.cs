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
    public class DesiredFlatRepository : IDesiredFlatRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public DesiredFlatRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region TableDesiredFlat Select
        public ValidationResult<List<TableDesiredFlat>> SelectDesiredFlat()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableDesiredFlat tableDesiredFlat;
            ValidationResult<List<TableDesiredFlat>> result = new ValidationResult<List<TableDesiredFlat>>()
            {
                IsValid = true,
                ResultObject = new List<TableDesiredFlat>()
            };

            try
            {
                string commPart =
                      "SELECT \"id_desiredObject\", \"id_client\", \"City\", \"Hood\", \"Street\", \"Type\", \"Area\", \"Status\", \"Floor\", \"Room\", \"Price\" " +
                      "FROM readb.\"DesiredFlat\" " +
                      "ORDER BY \"id_desiredObject\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();
                
                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableDesiredFlat = new TableDesiredFlat(

                        dbDataRecord["id_desiredObject"].ToString(),
                        dbDataRecord["id_client"].ToString(),

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

                    result.ResultObject.Add(tableDesiredFlat);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableDesiredFlat>>
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

        #region TableDesiredFlat Insert
        public bool AddDesiredFlatMember(DesiredFlatMember desiredFlatMember)
        {
            var result = AddDesiredFlat(desiredFlatMember);
            return result.IsValid;
        }

        public ValidationResultString AddDesiredFlat(DesiredFlatMember desiredFlatMember)
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
                string commPart = "INSERT INTO readb.\"DesiredFlat\" (\"id_client\", \"City\", \"Hood\", \"Street\", \"Type\", \"Area\", \"Status\", \"Floor\", \"Room\", \"Price\") VALUES " +
                "(@IdClient, @City, @Hood, @Street, @Type, @Area, @Status, @Floor, @Room, @Price)";
                
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@IdClient", Convert.ToInt32(desiredFlatMember.id_client));

                command.Parameters.AddWithValue("@City", desiredFlatMember.City);
                command.Parameters.AddWithValue("@Hood", desiredFlatMember.Hood);
                command.Parameters.AddWithValue("@Street", desiredFlatMember.Street);

                command.Parameters.AddWithValue("@Type", desiredFlatMember.Type);
                command.Parameters.AddWithValue("@Area", Convert.ToInt32(desiredFlatMember.Area));
                command.Parameters.AddWithValue("@Status", desiredFlatMember.Status);
                command.Parameters.AddWithValue("@Floor", Convert.ToInt32(desiredFlatMember.Floor));
                command.Parameters.AddWithValue("@Room", Convert.ToInt32(desiredFlatMember.Room));
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(desiredFlatMember.Price));

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

        #region TableDesiredFlat Update
        public bool UpdateDesiredFlatMember(DesiredFlatMember desiredFlatMember)
        {
            var result = EditDesiredFlat(desiredFlatMember);
            return result.IsValid;
        }

        public ValidationResultString EditDesiredFlat(DesiredFlatMember desiredFlatMember)
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
                string commPart = "UPDATE readb.\"DesiredFlat\" SET \"id_client\" = @IdClient, \"City\" = @City, \"Hood\" = @Hood, \"Street\" = @Street, " +
                "\"Type\" = @Type, \"Area\" = @Area, \"Status\" = @Status, \"Floor\" = @Floor, \"Room\" = @Room, \"Price\" = @Price " +
                "WHERE \"id_desiredObject\" = @FlatId";
                
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                
                command.Parameters.AddWithValue("@FlatId", Convert.ToInt32(desiredFlatMember.id_desiredObject));
                command.Parameters.AddWithValue("@IdClient", Convert.ToInt32(desiredFlatMember.id_client));

                command.Parameters.AddWithValue("@City", desiredFlatMember.City);
                command.Parameters.AddWithValue("@Hood", desiredFlatMember.Hood);
                command.Parameters.AddWithValue("@Street", desiredFlatMember.Street);

                command.Parameters.AddWithValue("@Type", desiredFlatMember.Type);
                command.Parameters.AddWithValue("@Area", Convert.ToInt32(desiredFlatMember.Area));
                command.Parameters.AddWithValue("@Status", desiredFlatMember.Status);
                command.Parameters.AddWithValue("@Floor", Convert.ToInt32(desiredFlatMember.Floor));
                command.Parameters.AddWithValue("@Room", Convert.ToInt32(desiredFlatMember.Room));
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(desiredFlatMember.Price));

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

        #region TableDesiredFlat Delete
        public bool DeleteDesiredFlatMember(DesiredFlatMember desiredFlatMember)
        {
            var result = DeleteDesiredFlat(desiredFlatMember);
            return result.IsValid;
        }

        public ValidationResultString DeleteDesiredFlat(DesiredFlatMember desiredFlatmember)
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
                string commPart = "DELETE FROM readb.\"DesiredFlat\" WHERE \"id_desiredObject\" = @FlatId";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@FlatId", Convert.ToInt32(desiredFlatmember.id_desiredObject));

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
