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
    public class PositionRepository : IPositionRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public PositionRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region TablePosition Select
        public ValidationResult<List<TablePosition>> SelectPosition()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }
            TablePosition tablePosition;
            ValidationResult<List<TablePosition>> result = new ValidationResult<List<TablePosition>>()
            {
                IsValid = true,
                ResultObject = new List<TablePosition>()
            };
            try
            {
                string commPart =
                  "SELECT  \"Position\", \"Salary\" " +
                  "FROM readb.\"Positions\" " +
                  "ORDER BY \"Position\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tablePosition = new TablePosition(

                            dbDataRecord["Position"].ToString(),
                            dbDataRecord["Salary"].ToString()

                            );
                    result.ResultObject.Add(tablePosition);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TablePosition>>
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

        #region TablePosition Update
        public bool UpdatePositionMember(PositionMember positionMember)
        {
            var result = UpdatePosition(positionMember);
            return result.IsValid;
        }

        public ValidationResultString UpdatePosition(PositionMember positionMember)
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
                string commPart = "UPDATE readb.\"Positions\" SET \"Salary\" = @Salary " +
                    "WHERE \"Position\" = @Name";
                
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Name", positionMember.Position);
                command.Parameters.AddWithValue("@Salary", Convert.ToInt32(positionMember.Salary));
                
                NpgsqlDataReader readerTable = command.ExecuteReader();
                readerTable.Close();
                
                //MessageBox.Show(@"Данные успешно обновлены");
            }
            catch (Npgsql.PostgresException exp)
            {
                return new ValidationResultString
                {
                    Errors = new List<string> { exp.SqlState }
                };
                //MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
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
