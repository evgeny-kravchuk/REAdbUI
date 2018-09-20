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
    public class ContractRepository : IContractRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public ContractRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region TableContract Select
        public ValidationResult<List<TableContract>> SelectContract()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableContract tableContract;
            ValidationResult<List<TableContract>> result = new ValidationResult<List<TableContract>>()
            {
                IsValid = true,
                ResultObject = new List<TableContract>()
            };

            try
            {
                string commPart =
                      "SELECT \"id_contract\", \"id_client\", \"id_employee\", \"id_object\", \"id_owner\", \"ContractType\", \"StartDate\", \"FinishDate\", \"Price\" " +
                      "FROM readb.\"Contracts\" " +
                      "ORDER BY \"id_contract\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();
                
                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableContract = new TableContract(

                        dbDataRecord["id_contract"].ToString(),
                        dbDataRecord["id_client"].ToString(),
                        dbDataRecord["id_employee"].ToString(),
                        dbDataRecord["id_object"].ToString(),
                        dbDataRecord["id_owner"].ToString(),

                        dbDataRecord["ContractType"].ToString(),
                        Convert.ToDateTime(dbDataRecord["StartDate"]).ToString("dd/MM/yyyy"),
                        Convert.ToDateTime(dbDataRecord["FinishDate"]).ToString("dd/MM/yyyy"),
                        dbDataRecord["Price"].ToString()
                        );

                    result.ResultObject.Add(tableContract);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableContract>>
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

        #region TableContract Insert
        public bool AddContractMember(ContractMember contractMember)
        {
            var result = AddContract(contractMember);
            return result.IsValid;
        }

        public ValidationResultString AddContract(ContractMember contractMember)
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
                string commPart = "INSERT INTO readb.\"Contracts\" (\"id_client\", \"id_employee\", \"id_object\", \"id_owner\", \"ContractType\", \"StartDate\", \"FinishDate\", \"Price\") VALUES " +
                "(@IdClient, @IdEmployee, @IdObject, @IdOwner, @ContractType, @StartDate, @FinishDate, @Price)";
                
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@IdClient", Convert.ToInt32(contractMember.id_client));
                command.Parameters.AddWithValue("@IdEmployee", Convert.ToInt32(contractMember.id_employee));
                command.Parameters.AddWithValue("@IdObject", Convert.ToInt32(contractMember.id_object));
                command.Parameters.AddWithValue("@IdOwner", Convert.ToInt32(contractMember.id_owner));

                command.Parameters.AddWithValue("@ContractType", contractMember.ContractType);
                command.Parameters.AddWithValue("@StartDate", Convert.ToDateTime(contractMember.StartDate));
                command.Parameters.AddWithValue("@FinishDate", Convert.ToDateTime(contractMember.FinishDate));
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(contractMember.Price));

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

        #region TableContract Update
        public bool UpdateContractMember(ContractMember contractMember)
        {
            var result = EditContract(contractMember);
            return result.IsValid;
        }

        public ValidationResultString EditContract(ContractMember contractMember)
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
                string commPart = "UPDATE readb.\"Contracts\" SET \"id_client\" = @IdClient, \"id_employee\" = @IdEmployee, \"id_object\" = @IdObject, " +
                "\"id_owner\" = @IdOwner, \"ContractType\" = @ContractType, \"StartDate\" = @StartDate, \"FinishDate\" = @FinishDate, \"Price\" = @Price " +
                "WHERE \"id_contract\" = @ContractId";
                
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                
                command.Parameters.AddWithValue("@ContractId", Convert.ToInt32(contractMember.id_contract));
                command.Parameters.AddWithValue("@IdClient", Convert.ToInt32(contractMember.id_client));
                command.Parameters.AddWithValue("@IdEmployee", Convert.ToInt32(contractMember.id_employee));
                command.Parameters.AddWithValue("@IdObject", Convert.ToInt32(contractMember.id_object));
                command.Parameters.AddWithValue("@IdOwner", Convert.ToInt32(contractMember.id_owner));

                command.Parameters.AddWithValue("@ContractType", contractMember.ContractType);
                command.Parameters.AddWithValue("@StartDate", Convert.ToDateTime(contractMember.StartDate));
                command.Parameters.AddWithValue("@FinishDate", Convert.ToDateTime(contractMember.FinishDate));
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(contractMember.Price));

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

        #region TableContract Delete
        public bool DeleteContractMember(ContractMember contractMember)
        {
            var result = DeleteContract(contractMember);
            return result.IsValid;
        }

        public ValidationResultString DeleteContract(ContractMember contractmember)
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
                string commPart = "DELETE FROM readb.\"Contracts\" WHERE \"id_contract\" = @ContractId";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@ContractId", Convert.ToInt32(contractmember.id_contract));

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
