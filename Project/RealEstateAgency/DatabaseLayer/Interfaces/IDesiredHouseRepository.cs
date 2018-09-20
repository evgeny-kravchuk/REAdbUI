using System.Collections.Generic;
using DatabaseLayer.DLObjects;
using Objects.Validation;
using Objects.Tables;

namespace DatabaseLayer.Interfaces
{
    public interface IDesiredHouseRepository
    {
        bool AddDesiredHouseMember(DesiredHouseMember desiredHouseMember);
        bool UpdateDesiredHouseMember(DesiredHouseMember desiredHouseMember);
        bool DeleteDesiredHouseMember(DesiredHouseMember desiredHouseMember);
        ValidationResult<List<TableDesiredHouse>> SelectDesiredHouse();
    }
}
