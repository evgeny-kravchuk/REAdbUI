using System.Collections.Generic;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Interfaces
{
    public interface IObjectService
    {
        bool AddObjectMember(ObjectMember objectMember);
        bool UpdateObjectMember(ObjectMember objectMember);
        bool DeleteObjectMember(ObjectMember objectMember);
        ValidationResult<List<TableObject>> SelectObject();
    }
}
