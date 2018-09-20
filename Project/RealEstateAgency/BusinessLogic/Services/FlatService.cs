using FlatMemberDLO = DatabaseLayer.DLObjects.FlatMember;
using System.Collections.Generic;
using DatabaseLayer.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;
using Objects.Tables.IndividualTables;

namespace BusinessLogic.Services
{
    public class FlatService : IFlatService
    {
        private IFlatRepository _flatRepository;

        public FlatService(IFlatRepository flatRepository)
        {
            _flatRepository = flatRepository;
        }

        public bool AddFlatMember(FlatMember flatMember)
        {
            return _flatRepository.AddFlatMember(new FlatMemberDLO
            {
                id_object = flatMember.id_object,
                id_owner = flatMember.id_owner,

                PostCode = flatMember.PostCode,
                City = flatMember.City,
                Hood = flatMember.Hood,
                Street = flatMember.Street,
                HouseNumber = flatMember.HouseNumber,
                FlatNumber = flatMember.FlatNumber,

                Type = flatMember.Type,
                Area = flatMember.Area,
                Status = flatMember.Status,
                Floor = flatMember.Floor,
                Room = flatMember.Room,
                Price = flatMember.Price
            });
        }

        public bool UpdateFlatMember(FlatMember flatMember)
        {
            return _flatRepository.UpdateFlatMember(new FlatMemberDLO
            {
                id_object = flatMember.id_object,
                id_owner = flatMember.id_owner,

                PostCode = flatMember.PostCode,
                City = flatMember.City,
                Hood = flatMember.Hood,
                Street = flatMember.Street,
                HouseNumber = flatMember.HouseNumber,
                FlatNumber = flatMember.FlatNumber,

                Type = flatMember.Type,
                Area = flatMember.Area,
                Status = flatMember.Status,
                Floor = flatMember.Floor,
                Room = flatMember.Room,
                Price = flatMember.Price
            });
        }

        public bool DeleteFlatMember(FlatMember flatMember)
        {
            return _flatRepository.DeleteFlatMember(new FlatMemberDLO
            {
                id_object = flatMember.id_object
            });
        }

        public ValidationResult<List<TableFindFlat>> FindFlat(FlatMember flatMember)
        {
            return _flatRepository.FindFlat(new FlatMemberDLO
            {
                City = flatMember.City,
                Hood = flatMember.Hood,
                Street = flatMember.Street,

                Type = flatMember.Type,
                Area = flatMember.Area,
                Status = flatMember.Status,
                Floor = flatMember.Floor,
                Room = flatMember.Room,
                Price = flatMember.Price
            });
        }

        public ValidationResult<List<TableFlat>> SelectFlat()
        {
            return _flatRepository.SelectFlat();
        }
    }
}
