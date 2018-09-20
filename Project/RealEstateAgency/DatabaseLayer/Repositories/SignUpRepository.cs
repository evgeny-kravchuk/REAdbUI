using DatabaseLayer.DLObjects;
using DatabaseLayer.Interfaces;
using Objects.Validation;
using Objects;
using System.Collections.Generic;
using Npgsql;

namespace DatabaseLayer.Repositories
{
    public class SignUpRepository : ISignUpRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public SignUpRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        public bool SignUpMember(SignUpMember signUpMember)
        {
            var res = AddClient(signUpMember);
            return res.IsValid;
        }

        public ValidationResultString AddClient(SignUpMember signUpMember)
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
                string commPart = "SELECT * FROM  login.add_client(@Login, @Password, @LastName, @FirstName, @Patronymic, @PhoneNumber);";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login", signUpMember.Login);
                command.Parameters.AddWithValue("@Password", signUpMember.Password);

                command.Parameters.AddWithValue("@LastName", signUpMember.LastName);
                command.Parameters.AddWithValue("@FirstName", signUpMember.FirstName);
                command.Parameters.AddWithValue("@Patronymic", signUpMember.Patronymic);

                command.Parameters.AddWithValue("@PhoneNumber", signUpMember.PhoneNumber);
                
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
    }
}
