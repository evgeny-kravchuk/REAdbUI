using PositionMemberDLO = DatabaseLayer.DLObjects.PositionMember;
using System.Collections.Generic;
using DatabaseLayer.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Services
{
    public class PositionService : IPositionService
    {
        private IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public bool UpdatePositionMember(PositionMember positionMember)
        {
            return _positionRepository.UpdatePositionMember(new PositionMemberDLO
            {
                Position = positionMember.Position,
                Salary = positionMember.Salary
            });
        }

        public ValidationResult<List<TablePosition>> SelectPosition()
        {
            return _positionRepository.SelectPosition();
        }
    }
}
