using System.Collections.Generic;
using DatabaseLayer.DLObjects;
using Objects.Validation;
using Objects.Tables;
using Objects.Tables.IndividualTables;

namespace DatabaseLayer.Interfaces
{
    public interface IHouseRepository
    {
        bool AddHouseMember(HouseMember houseMember);
        bool UpdateHouseMember(HouseMember houseMember);
        bool DeleteHouseMember(HouseMember houseMember);
        ValidationResult<List<TableFindHouse>> FindHouse(HouseMember houseMember);
        ValidationResult<List<TableHouse>> SelectHouse();
    }
}
