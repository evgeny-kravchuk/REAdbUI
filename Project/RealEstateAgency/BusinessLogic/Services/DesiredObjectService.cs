using DesiredObjectMemberDLO = DatabaseLayer.DLObjects.DesiredObjectMember;
using System.Collections.Generic;
using DatabaseLayer.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Services
{
    public class DesiredObjectService : IDesiredObjectService
    {
        private IDesiredObjectRepository _desiredObjectRepository;

        public DesiredObjectService(IDesiredObjectRepository desiredObjectRepository)
        {
            _desiredObjectRepository = desiredObjectRepository;
        }

        public bool AddDesiredObjectMember(DesiredObjectMember desiredObjectMember)
        {
            return _desiredObjectRepository.AddDesiredObjectMember(new DesiredObjectMemberDLO
            {
                id_desiredObject = desiredObjectMember.id_desiredObject,
                id_client = desiredObjectMember.id_client,

                City = desiredObjectMember.City,
                Hood = desiredObjectMember.Hood,
                Street = desiredObjectMember.Street,

                Type = desiredObjectMember.Type,
                Price = desiredObjectMember.Price
            });
        }

        public bool UpdateDesiredObjectMember(DesiredObjectMember desiredObjectMember)
        {
            return _desiredObjectRepository.UpdateDesiredObjectMember(new DesiredObjectMemberDLO
            {
                id_desiredObject = desiredObjectMember.id_desiredObject,
                id_client = desiredObjectMember.id_client,

                City = desiredObjectMember.City,
                Hood = desiredObjectMember.Hood,
                Street = desiredObjectMember.Street,

                Type = desiredObjectMember.Type,
                Price = desiredObjectMember.Price
            });
        }

        public bool DeleteDesiredObjectMember(DesiredObjectMember desiredObjectMember)
        {
            return _desiredObjectRepository.DeleteDesiredObjectMember(new DesiredObjectMemberDLO
            {
                id_desiredObject = desiredObjectMember.id_desiredObject
            });
        }

        public ValidationResult<List<TableDesiredObject>> SelectDesiredObject()
        {
            return _desiredObjectRepository.SelectDesiredObject();
        }
    }
}
