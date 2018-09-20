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
    public class DesiredObjectRepository : IDesiredObjectRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public DesiredObjectRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region TableDesiredObject Select
        public ValidationResult<List<TableDesiredObject>> SelectDesiredObject()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableDesiredObject tableDesiredObject;
            ValidationResult<List<TableDesiredObject>> result = new ValidationResult<List<TableDesiredObject>>()
            {
                IsValid = true,
                ResultObject = new List<TableDesiredObject>()
            };

            try
            {
                string commPart =
                      "SELECT \"id_desiredObject\", \"id_client\", \"City\", \"Hood\", \"Street\", \"Type\", \"Price\" " +
                      "FROM readb.\"DesiredObjects\" " +
                      "ORDER BY \"id_desiredObject\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();
                
                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableDesiredObject = new TableDesiredObject(

                        dbDataRecord["id_desiredObject"].ToString(),
                        dbDataRecord["id_client"].ToString(),

                        dbDataRecord["City"].ToString(),
                        dbDataRecord["Hood"].ToString(),
                        dbDataRecord["Street"].ToString(),

                        dbDataRecord["Type"].ToString(),
                        dbDataRecord["Price"].ToString()
                        );

                    result.ResultObject.Add(tableDesiredObject);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableDesiredObject>>
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

        #region TableDesiredObject Insert
        public bool AddDesiredObjectMember(DesiredObjectMember desiredObjectMember)
        {
            var result = AddDesiredObject(desiredObjectMember);
            return result.IsValid;
        }

        public ValidationResultString AddDesiredObject(DesiredObjectMember desiredObjectMember)
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
                string commPart = "INSERT INTO readb.\"DesiredObjects\" (\"id_client\", \"City\", \"Hood\", \"Street\", \"Type\", \"Price\") VALUES " +
                "@IdClient, @City, @Hood, @Street, @Type, @Price)";
                
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@IdClient", Convert.ToInt32(desiredObjectMember.id_client));

                command.Parameters.AddWithValue("@City", desiredObjectMember.City);
                command.Parameters.AddWithValue("@Hood", desiredObjectMember.Hood);
                command.Parameters.AddWithValue("@Street", desiredObjectMember.Street);

                command.Parameters.AddWithValue("@Type", desiredObjectMember.Type);
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(desiredObjectMember.Price));

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

        #region TableDesiredObject Update
        public bool UpdateDesiredObjectMember(DesiredObjectMember desiredObjectMember)
        {
            var result = EditDesiredObject(desiredObjectMember);
            return result.IsValid;
        }

        public ValidationResultString EditDesiredObject(DesiredObjectMember desiredObjectMember)
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
                string commPart = "UPDATE readb.\"DesiredObjects\" SET \"id_client\" = @IdClient, \"City\" = @City, " + 
                "\"Hood\" = @Hood, \"Street\" = @Street, \"Type\" = @Type, \"Price\" = @Price " +
                "WHERE \"id_desiredObject\" = @ObjectId";
                
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                
                command.Parameters.AddWithValue("@ObjectId", Convert.ToInt32(desiredObjectMember.id_desiredObject));
                command.Parameters.AddWithValue("@IdClient", Convert.ToInt32(desiredObjectMember.id_client));

                command.Parameters.AddWithValue("@City", desiredObjectMember.City);
                command.Parameters.AddWithValue("@Hood", desiredObjectMember.Hood);
                command.Parameters.AddWithValue("@Street", desiredObjectMember.Street);

                command.Parameters.AddWithValue("@Type", desiredObjectMember.Type);
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(desiredObjectMember.Price));

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

        #region TableDesiredObject Delete
        public bool DeleteDesiredObjectMember(DesiredObjectMember desiredObjectMember)
        {
            var result = DeleteDesiredObject(desiredObjectMember);
            return result.IsValid;
        }

        public ValidationResultString DeleteDesiredObject(DesiredObjectMember desiredObjectmember)
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
                string commPart = "DELETE FROM readb.\"DesiredObjects\" WHERE \"id_desiredObject\" = @ObjectId";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@ObjectId", Convert.ToInt32(desiredObjectmember.id_desiredObject));

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
