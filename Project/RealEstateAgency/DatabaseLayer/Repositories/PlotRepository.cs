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
    public class PlotRepository : IPlotRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public PlotRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region TablePlot Select
        public ValidationResult<List<TablePlot>> SelectPlot()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TablePlot tablePlot;
            ValidationResult<List<TablePlot>> result = new ValidationResult<List<TablePlot>>()
            {
                IsValid = true,
                ResultObject = new List<TablePlot>()
            };

            try
            {
                string commPart =
                      "SELECT \"id_object\", \"id_owner\", (\"Address\").\"PostCode\", (\"Address\").\"City\", (\"Address\").\"Hood\", (\"Address\").\"Street\", (\"Address\").\"HouseNumber\", (\"Address\").\"FlatNumber\", \"Type\", \"Area\", \"Status\", \"Price\" " +
                      "FROM readb.\"Plot\" " +
                      "ORDER BY \"id_object\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tablePlot = new TablePlot(

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
                        dbDataRecord["Price"].ToString()
                        );

                    result.ResultObject.Add(tablePlot);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TablePlot>>
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

        #region TablePlot Find
        public ValidationResult<List<TableFindPlot>> FindPlot(PlotMember plotMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableFindPlot tableFindPlot;
            ValidationResult<List<TableFindPlot>> result = new ValidationResult<List<TableFindPlot>>()
            {
                IsValid = true,
                ResultObject = new List<TableFindPlot>()
            };

            try
            {
                string commPart =
                      "SELECT (\"Address\").\"PostCode\", (\"Address\").\"City\", (\"Address\").\"Hood\", (\"Address\").\"Street\", (\"Address\").\"HouseNumber\", (\"Address\").\"FlatNumber\", \"Type\", \"Area\", \"Status\", \"Price\" " +
                      "FROM readb.\"Plot\" " +
                      "WHERE (\"Address\").\"City\" = @City " +
                      "AND ((\"Address\").\"Hood\" = @Hood OR @Hood IS NULL) " +
                      "AND ((\"Address\").\"Street\" = @Street OR @Street IS NULL) " +
                      "AND (\"Type\" = @Type) " +
                      "AND ((\"Area\" < @Area * 1.5 AND \"Area\" > @Area * 0.5) OR @Area IS NULL) " +
                      "AND (\"Status\" = @Status OR @Status IS NULL) " +
                      "AND ((\"Price\" < @Price * 1.5 AND \"Price\" > @Price * 0.5) OR @Price IS NULL) ";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@City", Convert.ToString(plotMember.City));
                command.Parameters.AddWithValue("@Hood", Convert.ToString(plotMember.Hood));
                command.Parameters.AddWithValue("@Street", Convert.ToString(plotMember.Street));

                command.Parameters.AddWithValue("@Type", Convert.ToString(plotMember.Type));
                command.Parameters.AddWithValue("@Area", Convert.ToString(plotMember.Area));
                command.Parameters.AddWithValue("@Status", Convert.ToString(plotMember.Status));
                command.Parameters.AddWithValue("@Price", Convert.ToString(plotMember.Price));

                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableFindPlot = new TableFindPlot(

                        dbDataRecord["PostCode"].ToString(),
                        dbDataRecord["City"].ToString(),
                        dbDataRecord["Hood"].ToString(),
                        dbDataRecord["Street"].ToString(),
                        dbDataRecord["HouseNumber"].ToString(),
                        dbDataRecord["FlatNumber"].ToString(),

                        dbDataRecord["Type"].ToString(),
                        dbDataRecord["Area"].ToString(),
                        dbDataRecord["Status"].ToString(),
                        dbDataRecord["Price"].ToString()
                        );

                    result.ResultObject.Add(tableFindPlot);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableFindPlot>>
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

        #region TablePlot Insert
        public bool AddPlotMember(PlotMember plotMember)
        {
            var result = AddPlot(plotMember);
            return result.IsValid;
        }

        public ValidationResultString AddPlot(PlotMember plotMember)
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
                string commPart = "INSERT INTO readb.\"Plot\" (\"id_owner\", \"Address\", \"Type\", \"Area\", \"Status\", \"Price\") VALUES " +
                "(@IdOwner, ROW(@PostCode, @City, @Hood, @Street, @HouseNumber, @FlatNumber), @Type, @Area, @Status, @Price)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@IdOwner", Convert.ToInt32(plotMember.id_owner));

                command.Parameters.AddWithValue("@PostCode", plotMember.PostCode);
                command.Parameters.AddWithValue("@City", plotMember.City);
                command.Parameters.AddWithValue("@Hood", plotMember.Hood);
                command.Parameters.AddWithValue("@Street", plotMember.Street);
                command.Parameters.AddWithValue("@HouseNumber", Convert.ToInt32(plotMember.HouseNumber));
                command.Parameters.AddWithValue("@FlatNumber", Convert.ToInt32(plotMember.FlatNumber));

                command.Parameters.AddWithValue("@Type", plotMember.Type);
                command.Parameters.AddWithValue("@Area", Convert.ToInt32(plotMember.Area));
                command.Parameters.AddWithValue("@Status", plotMember.Status);
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(plotMember.Price));

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

        #region TablePlot Update
        public bool UpdatePlotMember(PlotMember plotMember)
        {
            var result = EditPlot(plotMember);
            return result.IsValid;
        }

        public ValidationResultString EditPlot(PlotMember plotMember)
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
                string commPart = "UPDATE readb.\"Plot\" SET \"id_owner\" = @IdOwner, \"Address\" = ROW(@PostCode, @City, @Hood, @Street, @HouseNumber, @FlatNumber), " +
                "\"Type\" = @Type, \"Area\" = @Area, \"Status\" = @Status, \"Price\" = @Price " +
                "WHERE \"id_object\" = @PlotId";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@PlotId", Convert.ToInt32(plotMember.id_object));
                command.Parameters.AddWithValue("@IdOwner", Convert.ToInt32(plotMember.id_owner));

                command.Parameters.AddWithValue("@PostCode", plotMember.PostCode);
                command.Parameters.AddWithValue("@City", plotMember.City);
                command.Parameters.AddWithValue("@Hood", plotMember.Hood);
                command.Parameters.AddWithValue("@Street", plotMember.Street);
                command.Parameters.AddWithValue("@HouseNumber", Convert.ToInt32(plotMember.HouseNumber));
                command.Parameters.AddWithValue("@FlatNumber", Convert.ToInt32(plotMember.FlatNumber));

                command.Parameters.AddWithValue("@Type", plotMember.Type);
                command.Parameters.AddWithValue("@Area", Convert.ToInt32(plotMember.Area));
                command.Parameters.AddWithValue("@Status", plotMember.Status);
                command.Parameters.AddWithValue("@Price", Convert.ToInt32(plotMember.Price));

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

        #region TablePlot Delete
        public bool DeletePlotMember(PlotMember plotMember)
        {
            var result = DeletePlot(plotMember);
            return result.IsValid;
        }

        public ValidationResultString DeletePlot(PlotMember plotMember)
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
                string commPart = "DELETE FROM readb.\"Plot\" WHERE \"id_object\" = @PlotId";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@PlotId", Convert.ToInt32(plotMember.id_object));

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
