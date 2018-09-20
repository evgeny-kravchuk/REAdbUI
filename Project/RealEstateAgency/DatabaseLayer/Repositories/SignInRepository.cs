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
    public class SignInRepository : ISignInRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public SignInRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region SignIn
        public ValidationResult<List<TableDBUsers>> SignInUser(SignInMember signInMember)
        {
            var result = Authorization(signInMember);
            return result;
        }

        public ValidationResult<List<TableDBUsers>> Authorization(SignInMember signInMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }
            
            TableDBUsers tableDBUsers;

            ValidationResult<List<TableDBUsers>> result = new ValidationResult<List<TableDBUsers>>()
            {
                IsValid = true,
                ResultObject = new List<TableDBUsers>()
            };
            
            try
            {
                string commPart = "SELECT * " +
                                  "FROM login.\"DBUsers\" " +
                                  "WHERE Login = @Login  AND Passwd = @Password ";
                
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login", Convert.ToString(signInMember.Login));
                command.Parameters.AddWithValue("@Password", Convert.ToString(signInMember.Password));

                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableDBUsers = new TableDBUsers(
                        dbDataRecord["Login"].ToString(),
                        dbDataRecord["Passwd"].ToString(),
                        dbDataRecord["Vacant"].ToString()
                        );
                    result.ResultObject.Add(tableDBUsers);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableDBUsers>>
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
    }
}
