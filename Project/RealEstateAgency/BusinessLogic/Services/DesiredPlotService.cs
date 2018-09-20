using DesiredPlotMemberDLO = DatabaseLayer.DLObjects.DesiredPlotMember;
using System.Collections.Generic;
using DatabaseLayer.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Services
{
    public class DesiredPlotService : IDesiredPlotService
    {
        private IDesiredPlotRepository _desiredPlotRepository;

        public DesiredPlotService(IDesiredPlotRepository desiredPlotRepository)
        {
            _desiredPlotRepository = desiredPlotRepository;
        }

        public bool AddDesiredPlotMember(DesiredPlotMember desiredPlotMember)
        {
            return _desiredPlotRepository.AddDesiredPlotMember(new DesiredPlotMemberDLO
            {
                id_desiredObject = desiredPlotMember.id_desiredObject,
                id_client = desiredPlotMember.id_client,

                City = desiredPlotMember.City,
                Hood = desiredPlotMember.Hood,
                Street = desiredPlotMember.Street,

                Type = desiredPlotMember.Type,
                Area = desiredPlotMember.Area,
                Status = desiredPlotMember.Status,
                Price = desiredPlotMember.Price
            });
        }

        public bool UpdateDesiredPlotMember(DesiredPlotMember desiredPlotMember)
        {
            return _desiredPlotRepository.UpdateDesiredPlotMember(new DesiredPlotMemberDLO
            {
                id_desiredObject = desiredPlotMember.id_desiredObject,
                id_client = desiredPlotMember.id_client,

                City = desiredPlotMember.City,
                Hood = desiredPlotMember.Hood,
                Street = desiredPlotMember.Street,

                Type = desiredPlotMember.Type,
                Area = desiredPlotMember.Area,
                Status = desiredPlotMember.Status,
                Price = desiredPlotMember.Price
            });
        }

        public bool DeleteDesiredPlotMember(DesiredPlotMember desiredPlotMember)
        {
            return _desiredPlotRepository.DeleteDesiredPlotMember(new DesiredPlotMemberDLO
            {
                id_desiredObject = desiredPlotMember.id_desiredObject
            });
        }

        public ValidationResult<List<TableDesiredPlot>> SelectDesiredPlot()
        {
            return _desiredPlotRepository.SelectDesiredPlot();
        }
    }
}
