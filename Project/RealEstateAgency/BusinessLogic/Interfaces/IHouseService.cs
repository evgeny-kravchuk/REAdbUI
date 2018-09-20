using System.Collections.Generic;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;
using Objects.Tables.IndividualTables;

namespace BusinessLogic.Interfaces
{
    public interface IHouseService
    {
        bool AddHouseMember(HouseMember houseMember);
        bool UpdateHouseMember(HouseMember houseMember);
        bool DeleteHouseMember(HouseMember houseMember);
        ValidationResult<List<TableFindHouse>> FindHouse(HouseMember houseMember);
        ValidationResult<List<TableHouse>> SelectHouse();
    }
}
