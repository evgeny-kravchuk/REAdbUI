using HouseMemberDLO = DatabaseLayer.DLObjects.HouseMember;
using System.Collections.Generic;
using DatabaseLayer.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;
using Objects.Tables.IndividualTables;

namespace BusinessLogic.Services
{
    public class HouseService : IHouseService
    {
        private IHouseRepository _houseRepository;

        public HouseService(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public bool AddHouseMember(HouseMember houseMember)
        {
            return _houseRepository.AddHouseMember(new HouseMemberDLO
            {
                id_object = houseMember.id_object,
                id_owner = houseMember.id_owner,

                PostCode = houseMember.PostCode,
                City = houseMember.City,
                Hood = houseMember.Hood,
                Street = houseMember.Street,
                HouseNumber = houseMember.HouseNumber,
                FlatNumber = houseMember.FlatNumber,

                Type = houseMember.Type,
                Area = houseMember.Area,
                Status = houseMember.Status,
                NumberOfStoreys = houseMember.NumberOfStoreys,
                Room = houseMember.Room,
                Price = houseMember.Price
            });
        }

        public bool UpdateHouseMember(HouseMember houseMember)
        {
            return _houseRepository.UpdateHouseMember(new HouseMemberDLO
            {
                id_object = houseMember.id_object,
                id_owner = houseMember.id_owner,

                PostCode = houseMember.PostCode,
                City = houseMember.City,
                Hood = houseMember.Hood,
                Street = houseMember.Street,
                HouseNumber = houseMember.HouseNumber,
                FlatNumber = houseMember.FlatNumber,

                Type = houseMember.Type,
                Area = houseMember.Area,
                Status = houseMember.Status,
                NumberOfStoreys = houseMember.NumberOfStoreys,
                Room = houseMember.Room,
                Price = houseMember.Price
            });
        }

        public bool DeleteHouseMember(HouseMember houseMember)
        {
            return _houseRepository.DeleteHouseMember(new HouseMemberDLO
            {
                id_object = houseMember.id_object
            });
        }

        public ValidationResult<List<TableFindHouse>> FindHouse(HouseMember houseMember)
        {
            return _houseRepository.FindHouse(new HouseMemberDLO
            {
                City = houseMember.City,
                Hood = houseMember.Hood,
                Street = houseMember.Street,

                Type = houseMember.Type,
                Area = houseMember.Area,
                Status = houseMember.Status,
                NumberOfStoreys = houseMember.NumberOfStoreys,
                Room = houseMember.Room,
                Price = houseMember.Price
            });
        }

        public ValidationResult<List<TableHouse>> SelectHouse()
        {
            return _houseRepository.SelectHouse();
        }
    }
}
