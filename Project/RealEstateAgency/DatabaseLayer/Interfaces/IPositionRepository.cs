using System.Collections.Generic;
using DatabaseLayer.DLObjects;
using Objects.Validation;
using Objects.Tables;

namespace DatabaseLayer.Interfaces
{
    public interface IPositionRepository
    {
        bool UpdatePositionMember(PositionMember positionMember);
        ValidationResult<List<TablePosition>> SelectPosition();
    }
}
