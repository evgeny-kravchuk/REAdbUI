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
    public class DesiredPlotRepository : IDesiredPlotRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public DesiredPlotRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region TableDesiredPlot Select
        public ValidationResult<List<TableDesiredPlot>> SelectDesiredPlot()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableDesiredPlot tableDesiredPlot;
            ValidationResult<List<TableDesiredPlot>> result = new ValidationResult<List<TableDesiredPlot>>()
            {
                IsValid = true,
                ResultObject = new List<TableDesiredPlot>()
            };

            try
            {
                string commPart =
                      "SELECT \"id_desiredObject\", \"id_client\", \"City\", \"Hood\", \"Street\", \"Type\", \"Area\", \"Status\", \"Price\" " +
                      "FROM readb.\"DesiredPlot\" " +
                      "ORDER BY \"id_desiredObject\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();
                
                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableDesiredPlot = new TableDesiredPlot(

                        dbDataRecord["id_desiredObject"].ToString(),
                        dbDataRecord["id_client"].ToString(),

                        dbDataRecord["City"].ToString(),
                        dbDataRecord["Hood"].ToString(),
                        dbDataRecord["Street"].ToString(),

                        dbDataRecord["Type"].ToString(),
                        dbDataRecord["Area"].ToString(),
                        dbDataRecord["Status"].ToString(),
                        dbDataRecord["Price"].ToString()
                        );

                    result.ResultObject.Add(tableDesiredPlot);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableDesiredPlot>>
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

        #region TableDesiredPlot Insert
        public bool AddDesiredPlotMember(DesiredPlotMember desiredPlotMember)
        {
            var result = AddDesiredPlot(desiredPlotMember);
            return result.IsValid;
        }

        public ValidationResultString AddDesiredPlot(DesiredPlotMember desiredPlotMember)
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
                string commPart = "INSERT INTO readb.\"DesiredPlot\" (\"id_client\", \"City\", \"Hood\", \"Street\", \"Type\", \"Area\", \"Status\", \"Price\") VALUES " +
                "(@IdClient, @City, @Hood, @Street, @Type, @Area, @Status, @Price)";
                
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@IdClient", Convert.ToInt32(desiredPlotMember.id_client));

                command.Parameters.AddWithValue("@City", desiredPlotMember.City);
                command.Parameters.AddWithValue("@Hood", desiredPlotMember.Hood);
                command.Parameters.AddWithValue("@Street", desiredPlotMember.Street);

                command.Parameters.AddWithValue("@Type", desiredPlotMember.Type);
                command.Parameters.AddWithValue("@Area", Convert.ToInt32(desiredPlotMember.Area));
                command.Parameters.AddWithValue("@Status", desiredPlotMember.Status);
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(desiredPlotMember.Price));

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

        #region TableDesiredPlot Update
        public bool UpdateDesiredPlotMember(DesiredPlotMember desiredPlotMember)
        {
            var result = EditDesiredPlot(desiredPlotMember);
            return result.IsValid;
        }

        public ValidationResultString EditDesiredPlot(DesiredPlotMember desiredPlotMember)
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
                string commPart = "UPDATE readb.\"DesiredPlot\" SET \"id_client\" = @IdClient, \"City\" = @City, \"Hood\" = @Hood, " +
                "\"Street\" = @Street, \"Type\" = @Type, \"Area\" = @Area, \"Status\" = @Status, \"Price\" = @Price " +
                "WHERE \"id_desiredObject\" = @PlotId";
                
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                
                command.Parameters.AddWithValue("@PlotId", Convert.ToInt32(desiredPlotMember.id_desiredObject));
                command.Parameters.AddWithValue("@IdClient", Convert.ToInt32(desiredPlotMember.id_client));

                command.Parameters.AddWithValue("@City", desiredPlotMember.City);
                command.Parameters.AddWithValue("@Hood", desiredPlotMember.Hood);
                command.Parameters.AddWithValue("@Street", desiredPlotMember.Street);

                command.Parameters.AddWithValue("@Type", desiredPlotMember.Type);
                command.Parameters.AddWithValue("@Area", Convert.ToInt32(desiredPlotMember.Area));
                command.Parameters.AddWithValue("@Status", desiredPlotMember.Status);
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(desiredPlotMember.Price));

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

        #region TableDesiredPlot Delete
        public bool DeleteDesiredPlotMember(DesiredPlotMember desiredPlotMember)
        {
            var result = DeleteDesiredPlot(desiredPlotMember);
            return result.IsValid;
        }

        public ValidationResultString DeleteDesiredPlot(DesiredPlotMember desiredPlotmember)
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
                string commPart = "DELETE FROM readb.\"DesiredPlot\" WHERE \"id_desiredObject\" = @PlotId";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@PlotId", Convert.ToInt32(desiredPlotmember.id_desiredObject));

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
