using System.Collections.Generic;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;
using Objects.Tables.IndividualTables;

namespace BusinessLogic.Interfaces
{
    public interface IClientService
    {
        #region Admin/Staff
        bool AddClientMember(ClientMember clientMember);
        bool UpdateClientMember(ClientMember clientMember);
        bool DeleteClientMember(ClientMember clientMember);
        ValidationResult<List<TableClient>> SelectClient();
        #endregion

        #region Client
        ValidationResult<List<TableClientContractInfo>> SelectContractClient(string login);
        ValidationResult<List<TableClientPersonalInfo>> SelectInfoClient(string login);
        ValidationResult<List<TableClientDesiredFlat>> SelectDesiredFlatClient(string login);
        ValidationResult<List<TableClientDesiredHouse>> SelectDesiredHouseClient(string login);
        ValidationResult<List<TableClientDesiredPlot>> SelectDesiredPlotClient(string login);
        bool UpdatePassword(string login, ClientMember clientMember);
        bool UpdateLogin(string login, ClientMember clientMember);
        bool UpdateClientPersonalInfo(string login, ClientMember clientMember);
        #endregion
    }
}
