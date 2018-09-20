using System.Collections.Generic;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Interfaces
{
    public interface IDesiredObjectService
    {
        bool AddDesiredObjectMember(DesiredObjectMember desiredObjectMember);
        bool UpdateDesiredObjectMember(DesiredObjectMember desiredObjectMember);
        bool DeleteDesiredObjectMember(DesiredObjectMember desiredObjectMember);
        ValidationResult<List<TableDesiredObject>> SelectDesiredObject();
    }
}
