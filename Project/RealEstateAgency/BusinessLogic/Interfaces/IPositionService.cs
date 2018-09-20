using System.Collections.Generic;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Interfaces
{
    public interface IPositionService
    {
        bool UpdatePositionMember(PositionMember positionMember);
        ValidationResult<List<TablePosition>> SelectPosition();
    }
}
