using System.Collections.Generic;
using DatabaseLayer.DLObjects;
using Objects.Validation;
using Objects.Tables;
using Objects.Tables.IndividualTables;

namespace DatabaseLayer.Interfaces
{
    public interface IClientRepository
    {
        #region Admin/Staff
        bool AddClientMember(ClientMember clientMember);
        bool UpdateClientMember(ClientMember clientMember);
        bool DeleteClientMember(ClientMember clientMember);
        ValidationResult<List<TableClient>> SelectClient();
        #endregion

        #region Client
        ValidationResult<List<TableClientContractInfo>> SelectContractClient(ClientMember clientMember);
        ValidationResult<List<TableClientPersonalInfo>> SelectPersonalInfoClient(ClientMember clientMember);
        ValidationResult<List<TableClientDesiredFlat>> SelectDesiredFlatClient(ClientMember clientMember);
        ValidationResult<List<TableClientDesiredHouse>> SelectDesiredHouseClient(ClientMember clientMember);
        ValidationResult<List<TableClientDesiredPlot>> SelectDesiredPlotClient(ClientMember clientMember);
        bool UpdatePassword(ClientMember clientMember);
        bool UpdateLogin(ClientMember clientMember);
        bool UpdateClientPersonalInfo(ClientMember clientMember);
        #endregion
    }
}
