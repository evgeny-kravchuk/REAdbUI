using ObjectMemberDLO = DatabaseLayer.DLObjects.ObjectMember;
using System.Collections.Generic;
using DatabaseLayer.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Services
{
    public class ObjectService : IObjectService
    {
        private IObjectRepository _objectRepository;

        public ObjectService(IObjectRepository objectRepository)
        {
            _objectRepository = objectRepository;
        }

        public bool AddObjectMember(ObjectMember objectMember)
        {
            return _objectRepository.AddObjectMember(new ObjectMemberDLO
            {
                id_object = objectMember.id_object,
                id_owner = objectMember.id_owner,

                PostCode = objectMember.PostCode,
                City = objectMember.City,
                Hood = objectMember.Hood,
                Street = objectMember.Street,
                HouseNumber = objectMember.HouseNumber,
                FlatNumber = objectMember.FlatNumber,

                Type = objectMember.Type,
                Price = objectMember.Price
            });
        }

        public bool UpdateObjectMember(ObjectMember objectMember)
        {
            return _objectRepository.UpdateObjectMember(new ObjectMemberDLO
            {
                id_object = objectMember.id_object,
                id_owner = objectMember.id_owner,

                PostCode = objectMember.PostCode,
                City = objectMember.City,
                Hood = objectMember.Hood,
                Street = objectMember.Street,
                HouseNumber = objectMember.HouseNumber,
                FlatNumber = objectMember.FlatNumber,

                Type = objectMember.Type,
                Price = objectMember.Price
            });
        }

        public bool DeleteObjectMember(ObjectMember objectMember)
        {
            return _objectRepository.DeleteObjectMember(new ObjectMemberDLO
            {
                id_object = objectMember.id_object
            });
        }

        public ValidationResult<List<TableObject>> SelectObject()
        {
            return _objectRepository.SelectObject();
        }
    }
}
