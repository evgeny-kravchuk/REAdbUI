using System.Collections.Generic;
using DatabaseLayer.DLObjects;
using Objects.Validation;
using Objects.Tables;

namespace DatabaseLayer.Interfaces
{
    public interface IObjectRepository
    {
        bool AddObjectMember(ObjectMember objectMember);
        bool UpdateObjectMember(ObjectMember objectMember);
        bool DeleteObjectMember(ObjectMember objectMember);
        ValidationResult<List<TableObject>> SelectObject();
    }
}
