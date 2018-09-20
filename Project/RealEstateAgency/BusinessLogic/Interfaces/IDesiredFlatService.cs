using System.Collections.Generic;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Interfaces
{
    public interface IDesiredFlatService
    {
        bool AddDesiredFlatMember(DesiredFlatMember desiredFlatMember);
        bool UpdateDesiredFlatMember(DesiredFlatMember desiredFlatMember);
        bool DeleteDesiredFlatMember(DesiredFlatMember desiredFlatMember);
        ValidationResult<List<TableDesiredFlat>> SelectDesiredFlat();
    }
}
