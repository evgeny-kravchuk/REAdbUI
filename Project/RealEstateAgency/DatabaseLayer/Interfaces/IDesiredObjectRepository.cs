using System.Collections.Generic;
using DatabaseLayer.DLObjects;
using Objects.Validation;
using Objects.Tables;

namespace DatabaseLayer.Interfaces
{
    public interface IDesiredObjectRepository
    {
        bool AddDesiredObjectMember(DesiredObjectMember desiredObjectMember);
        bool UpdateDesiredObjectMember(DesiredObjectMember desiredObjectMember);
        bool DeleteDesiredObjectMember(DesiredObjectMember desiredObjectMember);
        ValidationResult<List<TableDesiredObject>> SelectDesiredObject();
    }
}
