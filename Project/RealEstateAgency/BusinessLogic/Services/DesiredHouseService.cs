using DesiredHouseMemberDLO = DatabaseLayer.DLObjects.DesiredHouseMember;
using System.Collections.Generic;
using DatabaseLayer.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Services
{
    public class DesiredHouseService : IDesiredHouseService
    {
        private IDesiredHouseRepository _desiredHouseRepository;

        public DesiredHouseService(IDesiredHouseRepository desiredHouseRepository)
        {
            _desiredHouseRepository = desiredHouseRepository;
        }

        public bool AddDesiredHouseMember(DesiredHouseMember desiredHouseMember)
        {
            return _desiredHouseRepository.AddDesiredHouseMember(new DesiredHouseMemberDLO
            {
                id_desiredObject = desiredHouseMember.id_desiredObject,
                id_client = desiredHouseMember.id_client,

                City = desiredHouseMember.City,
                Hood = desiredHouseMember.Hood,
                Street = desiredHouseMember.Street,

                Type = desiredHouseMember.Type,
                Area = desiredHouseMember.Area,
                Status = desiredHouseMember.Status,
                NumberOfStoreys = desiredHouseMember.NumberOfStoreys,
                Room = desiredHouseMember.Room,
                Price = desiredHouseMember.Price
            });
        }

        public bool UpdateDesiredHouseMember(DesiredHouseMember desiredHouseMember)
        {
            return _desiredHouseRepository.UpdateDesiredHouseMember(new DesiredHouseMemberDLO
            {
                id_desiredObject = desiredHouseMember.id_desiredObject,
                id_client = desiredHouseMember.id_client,

                City = desiredHouseMember.City,
                Hood = desiredHouseMember.Hood,
                Street = desiredHouseMember.Street,

                Type = desiredHouseMember.Type,
                Area = desiredHouseMember.Area,
                Status = desiredHouseMember.Status,
                NumberOfStoreys = desiredHouseMember.NumberOfStoreys,
                Room = desiredHouseMember.Room,
                Price = desiredHouseMember.Price
            });
        }

        public bool DeleteDesiredHouseMember(DesiredHouseMember desiredHouseMember)
        {
            return _desiredHouseRepository.DeleteDesiredHouseMember(new DesiredHouseMemberDLO
            {
                id_desiredObject = desiredHouseMember.id_desiredObject
            });
        }

        public ValidationResult<List<TableDesiredHouse>> SelectDesiredHouse()
        {
            return _desiredHouseRepository.SelectDesiredHouse();
        }
    }
}
