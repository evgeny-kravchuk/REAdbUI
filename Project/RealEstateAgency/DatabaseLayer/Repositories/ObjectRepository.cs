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
    public class ObjectRepository : IObjectRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public ObjectRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region TableObject Select
        public ValidationResult<List<TableObject>> SelectObject()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableObject tableObject;
            ValidationResult<List<TableObject>> result = new ValidationResult<List<TableObject>>()
            {
                IsValid = true,
                ResultObject = new List<TableObject>()
            };

            try
            {
                string commPart =
                      "SELECT \"id_object\", \"id_owner\", (\"Address\").\"PostCode\", (\"Address\").\"City\", (\"Address\").\"Hood\", (\"Address\").\"Street\", (\"Address\").\"HouseNumber\", (\"Address\").\"FlatNumber\", \"Type\", \"Price\" " +
                      "FROM readb.\"Objects\" " +
                      "ORDER BY \"id_object\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableObject = new TableObject(

                        dbDataRecord["id_object"].ToString(),
                        dbDataRecord["id_owner"].ToString(),

                        dbDataRecord["PostCode"].ToString(),
                        dbDataRecord["City"].ToString(),
                        dbDataRecord["Hood"].ToString(),
                        dbDataRecord["Street"].ToString(),
                        dbDataRecord["HouseNumber"].ToString(),
                        dbDataRecord["FlatNumber"].ToString(),

                        dbDataRecord["Type"].ToString(),
                        dbDataRecord["Price"].ToString()
                        );

                    result.ResultObject.Add(tableObject);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableObject>>
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

        #region TableObject Insert
        public bool AddObjectMember(ObjectMember objectMember)
        {
            var result = AddObject(objectMember);
            return result.IsValid;
        }

        public ValidationResultString AddObject(ObjectMember objectMember)
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
                string commPart = "INSERT INTO readb.\"Objects\" (\"id_owner\", \"Address\", \"Type\", \"Price\") VALUES " +
                "(@IdOwner, ROW(@PostCode, @City, @Hood, @Street, @HouseNumber, @FlatNumber), @Type, @Price)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@IdOwner", Convert.ToInt32(objectMember.id_owner));

                command.Parameters.AddWithValue("@PostCode", objectMember.PostCode);
                command.Parameters.AddWithValue("@City", objectMember.City);
                command.Parameters.AddWithValue("@Hood", objectMember.Hood);
                command.Parameters.AddWithValue("@Street", objectMember.Street);
                command.Parameters.AddWithValue("@HouseNumber", Convert.ToInt32(objectMember.HouseNumber));
                command.Parameters.AddWithValue("@FlatNumber", Convert.ToInt32(objectMember.FlatNumber));

                command.Parameters.AddWithValue("@Type", objectMember.Type);
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(objectMember.Price));

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

        #region TableObject Update
        public bool UpdateObjectMember(ObjectMember objectMember)
        {
            var result = EditObject(objectMember);
            return result.IsValid;
        }

        public ValidationResultString EditObject(ObjectMember objectMember)
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
                string commPart = "UPDATE readb.\"Objects\" SET \"id_owner\" = @IdOwner, " +
                "\"Address\" = ROW(@PostCode, @City, @Hood, @Street, @HouseNumber, @FlatNumber), " +
                "\"Type\" = @Type, \"Price\" = @Price " +
                "WHERE \"id_object\" = @ObjectId";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@ObjectId", Convert.ToInt32(objectMember.id_object));
                command.Parameters.AddWithValue("@IdOwner", Convert.ToInt32(objectMember.id_owner));

                command.Parameters.AddWithValue("@PostCode", objectMember.PostCode);
                command.Parameters.AddWithValue("@City", objectMember.City);
                command.Parameters.AddWithValue("@Hood", objectMember.Hood);
                command.Parameters.AddWithValue("@Street", objectMember.Street);
                command.Parameters.AddWithValue("@HouseNumber", Convert.ToInt32(objectMember.HouseNumber));
                command.Parameters.AddWithValue("@FlatNumber", Convert.ToInt32(objectMember.FlatNumber));

                command.Parameters.AddWithValue("@Type", objectMember.Type);
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(objectMember.Price));

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

        #region TableObject Delete
        public bool DeleteObjectMember(ObjectMember objectMember)
        {
            var result = DeleteObject(objectMember);
            return result.IsValid;
        }

        public ValidationResultString DeleteObject(ObjectMember objectMember)
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
                string commPart = "DELETE FROM readb.\"Objects\" WHERE \"id_object\" = @ObjectId";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@ObjectId", Convert.ToInt32(objectMember.id_object));

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
