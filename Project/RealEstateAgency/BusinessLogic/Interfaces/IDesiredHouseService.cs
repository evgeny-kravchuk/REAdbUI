using System.Collections.Generic;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Interfaces
{
    public interface IDesiredHouseService
    {
        bool AddDesiredHouseMember(DesiredHouseMember desiredHouseMember);
        bool UpdateDesiredHouseMember(DesiredHouseMember desiredHouseMember);
        bool DeleteDesiredHouseMember(DesiredHouseMember desiredHouseMember);
        ValidationResult<List<TableDesiredHouse>> SelectDesiredHouse();
    }
}
