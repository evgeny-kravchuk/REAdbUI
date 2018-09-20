using DesiredFlatMemberDLO = DatabaseLayer.DLObjects.DesiredFlatMember;
using System.Collections.Generic;
using DatabaseLayer.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Services
{
    public class DesiredFlatService : IDesiredFlatService
    {
        private IDesiredFlatRepository _desiredFlatRepository;

        public DesiredFlatService(IDesiredFlatRepository desiredFlatRepository)
        {
            _desiredFlatRepository = desiredFlatRepository;
        }

        public bool AddDesiredFlatMember(DesiredFlatMember desiredFlatMember)
        {
            return _desiredFlatRepository.AddDesiredFlatMember(new DesiredFlatMemberDLO
            {
                id_desiredObject = desiredFlatMember.id_desiredObject,
                id_client = desiredFlatMember.id_client,

                City = desiredFlatMember.City,
                Hood = desiredFlatMember.Hood,
                Street = desiredFlatMember.Street,

                Type = desiredFlatMember.Type,
                Area = desiredFlatMember.Area,
                Status = desiredFlatMember.Status,
                Floor = desiredFlatMember.Floor,
                Room = desiredFlatMember.Room,
                Price = desiredFlatMember.Price
            });
        }

        public bool UpdateDesiredFlatMember(DesiredFlatMember desiredFlatMember)
        {
            return _desiredFlatRepository.UpdateDesiredFlatMember(new DesiredFlatMemberDLO
            {
                id_desiredObject = desiredFlatMember.id_desiredObject,
                id_client = desiredFlatMember.id_client,

                City = desiredFlatMember.City,
                Hood = desiredFlatMember.Hood,
                Street = desiredFlatMember.Street,

                Type = desiredFlatMember.Type,
                Area = desiredFlatMember.Area,
                Status = desiredFlatMember.Status,
                Floor = desiredFlatMember.Floor,
                Room = desiredFlatMember.Room,
                Price = desiredFlatMember.Price
            });
        }

        public bool DeleteDesiredFlatMember(DesiredFlatMember desiredFlatMember)
        {
            return _desiredFlatRepository.DeleteDesiredFlatMember(new DesiredFlatMemberDLO
            {
                id_desiredObject = desiredFlatMember.id_desiredObject
            });
        }

        public ValidationResult<List<TableDesiredFlat>> SelectDesiredFlat()
        {
            return _desiredFlatRepository.SelectDesiredFlat();
        }
    }
}
