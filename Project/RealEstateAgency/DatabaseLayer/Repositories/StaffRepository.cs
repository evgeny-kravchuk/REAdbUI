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
    public class StaffRepository : IStaffRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        private string oldLogin { get; set; }
        private string newPassword { get; set; }

        public StaffRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region TableStaff Select
        public ValidationResult<List<TableStaff>> SelectStaff()
        {
            var res = SelStaff();
            return res;
        }

        public ValidationResult<List<TableStaff>> SelStaff()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableStaff tableStaff;
            ValidationResult<List<TableStaff>> result = new ValidationResult<List<TableStaff>>()
            {
                IsValid = true,
                ResultObject = new List<TableStaff>()
            };

            try
            {
                string commPart =
                      "SELECT \"id_employee\", \"Login\", (\"Name\").\"LastName\", (\"Name\").\"FirstName\", (\"Name\").\"Patronymic\", \"Sex\", \"DateOfBirth\", \"Position\", \"PhoneNumber\" " +
                      "FROM readb.\"Staff\" " +
                      "ORDER BY \"id_employee\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableStaff = new TableStaff(
                        dbDataRecord["id_employee"].ToString(),
                        dbDataRecord["Login"].ToString(),

                        dbDataRecord["LastName"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["Patronymic"].ToString(),

                        dbDataRecord["Sex"].ToString(),
                        dbDataRecord["DateOfBirth"].ToString(),
                        dbDataRecord["Position"].ToString(),
                        dbDataRecord["PhoneNumber"].ToString()
                        );

                    result.ResultObject.Add(tableStaff);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableStaff>>
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

        #region TableStaff Insert
        public bool AddStaffMember(StaffMember staffMember)
        {
            var result = AddStaff(staffMember);
            return result.IsValid;
        }

        public ValidationResultString AddStaff(StaffMember staffMember)
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
                string commPart = "SELECT * FROM readb.add_staff (@Login, @Password, @LastName, @FirstName, @Patronymic, @Sex, @DateOfBirth::DATE, @Position, @PhoneNumber)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login", staffMember.Login);
                command.Parameters.AddWithValue("@Password", staffMember.NewPassword);

                command.Parameters.AddWithValue("@LastName", staffMember.LastName);
                command.Parameters.AddWithValue("@FirstName", staffMember.FirstName);
                command.Parameters.AddWithValue("@Patronymic", staffMember.Patronymic);

                command.Parameters.AddWithValue("@Sex", staffMember.Sex);
                command.Parameters.AddWithValue("@DateOfBirth", Convert.ToDateTime(staffMember.DateOfBirth));
                command.Parameters.AddWithValue("@Position", staffMember.Position);
                command.Parameters.AddWithValue("@PhoneNumber", staffMember.PhoneNumber);

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

        #region TableStaff Update
        public bool UpdateStaffMember(StaffMember staffMember)
        {
            var result = EditStaff(staffMember);
            return result.IsValid;
        }

        public ValidationResultString EditStaff(StaffMember staffMember)
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
                string commPart = "UPDATE readb.\"Staff\" SET \"Name\" = ROW(@LastName, @FirstName, @Patronymic), " +
                "\"Sex\" = @Sex, \"DateOfBirth\" = @DateOfBirth, \"Position\" = @Position, \"PhoneNumber\" = @PhoneNumber " +
                "WHERE \"id_employee\" = @StaffId";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@StaffId", Convert.ToInt32(staffMember.id_employee));

                command.Parameters.AddWithValue("@LastName", staffMember.LastName);
                command.Parameters.AddWithValue("@FirstName", staffMember.FirstName);
                command.Parameters.AddWithValue("@Patronymic", staffMember.Patronymic);

                command.Parameters.AddWithValue("@Sex", staffMember.Sex);
                command.Parameters.AddWithValue("@DateOfBirth", Convert.ToDateTime(staffMember.DateOfBirth));
                command.Parameters.AddWithValue("@Position", staffMember.Position);
                command.Parameters.AddWithValue("@PhoneNumber", staffMember.PhoneNumber);

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

        #region TableStaff Delete
        public bool DeleteStaffMember(StaffMember staffMember)
        {
            var result = DeleteStaff(staffMember);
            return result.IsValid;
        }

        public ValidationResultString DeleteStaff(StaffMember staffMember)
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
                string commPart = "SELECT * FROM readb.delete_staff (@StaffId)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@StaffId", Convert.ToInt32(staffMember.id_employee));

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

        #region TableSelectContract
        public ValidationResult<List<TableStaffContractInfo>> SelectContractStaff(StaffMember staffMember)
        {
            var res = GetSingleTable(staffMember);
            return res;
        }

        public ValidationResult<List<TableStaffContractInfo>> GetSingleTable(StaffMember staffMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn(); ;
            }

            TableStaffContractInfo tableStaff;

            ValidationResult<List<TableStaffContractInfo>> result = new ValidationResult<List<TableStaffContractInfo>>()
            {
                IsValid = true,
                ResultObject = new List<TableStaffContractInfo>()
            };

            try
            {
                string commPart = "SELECT c.\"City\", c.\"Street\", c.\"HouseNumber\", c.\"FlatNumber\", c.\"ContractType\", c.\"StartDate\", c.\"FinishDate\", c.\"Price\" " +
                                  "FROM readb.\"Contracts\" c, readb.\"Staff\" s, login.\"DBUsers\" as l " +
                                  "WHERE s.\"id_employee\" = c.\"id_employee\" AND s.\"Login\" = @Login ";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login", Convert.ToString(staffMember.Login));

                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableStaff = new TableStaffContractInfo(
                        dbDataRecord["City"].ToString(),
                        dbDataRecord["Street"].ToString(),
                        dbDataRecord["HouseNumber"].ToString(),
                        dbDataRecord["FlatNumber"].ToString(),
                        dbDataRecord["ContractType"].ToString(),
                        Convert.ToDateTime(dbDataRecord["StartDate"]).ToString("dd/MM/yyyy"),
                        Convert.ToDateTime(dbDataRecord["FinishDate"]).ToString("dd/MM/yyyy"),
                        dbDataRecord["Price"].ToString()
                        );
                    result.ResultObject.Add(tableStaff);
                }
                readerTable.Close();
            }
            catch (Npgsql.PostgresException exp)
            {
                result = new ValidationResult<List<TableStaffContractInfo>>
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

        #region TableSelectStaffPersonalInfo
        public ValidationResult<List<TableStaffPersonalInfo>> SelectPersonalInfoStaff(StaffMember staffMember)
        {
            var res = GetStaffPersonalInfo(staffMember);
            return res;
        }

        public ValidationResult<List<TableStaffPersonalInfo>> GetStaffPersonalInfo(StaffMember staffMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableStaffPersonalInfo tableStaffPersonalInfo;

            ValidationResult<List<TableStaffPersonalInfo>> result = new ValidationResult<List<TableStaffPersonalInfo>>()
            {
                IsValid = true,
                ResultObject = new List<TableStaffPersonalInfo>()
            };
            try
            {
                string commPart = "SELECT \"Login\", (\"Name\").\"LastName\", (\"Name\").\"FirstName\", (\"Name\").\"Patronymic\", \"Sex\", \"DateOfBirth\", \"Position\", \"PhoneNumber\" " +
                                  "FROM readb.\"Staff\" " +
                                  "WHERE \"Login\" = @Login";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login", Convert.ToString(staffMember.Login));

                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableStaffPersonalInfo = new TableStaffPersonalInfo(
                        dbDataRecord["Login"].ToString(),

                        dbDataRecord["LastName"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["Patronymic"].ToString(),

                        dbDataRecord["Sex"].ToString(),
                        dbDataRecord["DateOfBirth"].ToString(),
                        dbDataRecord["Position"].ToString(),
                        dbDataRecord["PhoneNumber"].ToString()
                        );

                    result.ResultObject.Add(tableStaffPersonalInfo);
                }
                readerTable.Close();
            }
            catch (Npgsql.PostgresException exp)
            {
                result = new ValidationResult<List<TableStaffPersonalInfo>>
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

        #region TableUpdatePassword Staff
        public bool UpdatePassword(StaffMember staffMember)
        {
            var res = UpdatePass(staffMember);
            return res.IsValid;
        }

        public ValidationResultString UpdatePass(StaffMember staffMember)
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
                string commPart = "SELECT * FROM readb.edit_Password(@Login, @NewPassword, @OldPassword)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login", Convert.ToString(staffMember.Login));
                command.Parameters.AddWithValue("@OldPassword", Convert.ToString(staffMember.OldPassword));
                command.Parameters.AddWithValue("@NewPassword", Convert.ToString(staffMember.NewPassword));

                NpgsqlDataReader readerTable = command.ExecuteReader();

                readerTable.Close();

                string commParts = "SELECT L.Login, L.Passwd " +
                                   "FROM login.\"DBUsers\" L " +
                                   "WHERE L.Login = @Log ";

                NpgsqlCommand commands = new NpgsqlCommand(commParts, sqlConnect.GetNewSqlConn().GetConn);

                commands.Parameters.AddWithValue("@Log", Convert.ToString(staffMember.Login));
                //commands.Parameters.AddWithValue("@NewPass", Convert.ToString(staffMember.NewPassword));

                NpgsqlDataReader readerTables = commands.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTables)
                {
                    oldLogin = dbDataRecord["Login"].ToString();
                    newPassword = dbDataRecord["Passwd"].ToString();
                }

                if (oldLogin == null && newPassword == null)
                {
                    return new ValidationResultString
                    {
                        Errors = new List<string> { "Не верно введен старый пароль" }
                    };
                }
                readerTables.Close();
            }
            catch (PostgresException exp)
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

        #region UpdateLogin Staff
        public bool UpdateLogin(StaffMember staffMember)
        {
            var res = UpdateLog(staffMember);
            return res.IsValid;
        }

        public ValidationResultString UpdateLog(StaffMember staffMember)
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
                string commPart = "SELECT * FROM readb.edit_staffLogin(@NewLogin, @Login)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@NewLogin", Convert.ToString(staffMember.NewLogin));
                command.Parameters.AddWithValue("@Login", Convert.ToString(staffMember.Login));

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

        #region UpdatePersonalInfo Staff
        public bool UpdateStaffPersonalInfo(StaffMember staffMember)
        {
            var res = UpdateStaffInfoPrivate(staffMember);
            return res.IsValid;
        }

        public ValidationResultString UpdateStaffInfoPrivate(StaffMember staffMember)
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
                string commPart = "SELECT * FROM readb.edit_staffInfo(@Login, @LastName, @FirstName, @Patronymic, @Sex, @DateOfBirth::DATE, @PhoneNumber);";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login", staffMember.Login);

                command.Parameters.AddWithValue("@LastName", staffMember.LastName);
                command.Parameters.AddWithValue("@FirstName", staffMember.FirstName);
                command.Parameters.AddWithValue("@Patronymic", staffMember.Patronymic);

                command.Parameters.AddWithValue("@Sex", staffMember.Sex);
                command.Parameters.AddWithValue("@DateOfBirth", Convert.ToDateTime(staffMember.DateOfBirth));
                command.Parameters.AddWithValue("@PhoneNumber", staffMember.PhoneNumber);

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
