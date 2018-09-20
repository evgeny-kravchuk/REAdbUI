using System.Collections.Generic;
using DatabaseLayer.DLObjects;
using Objects.Validation;
using Objects.Tables;

namespace DatabaseLayer.Interfaces
{
    public interface IDesiredFlatRepository
    {
        bool AddDesiredFlatMember(DesiredFlatMember desiredFlatMember);
        bool UpdateDesiredFlatMember(DesiredFlatMember desiredFlatMember);
        bool DeleteDesiredFlatMember(DesiredFlatMember desiredFlatMember);
        ValidationResult<List<TableDesiredFlat>> SelectDesiredFlat();
    }
}
