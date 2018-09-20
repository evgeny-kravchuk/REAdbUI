using PlotMemberDLO = DatabaseLayer.DLObjects.PlotMember;
using System.Collections.Generic;
using DatabaseLayer.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;
using Objects.Tables.IndividualTables;

namespace BusinessLogic.Services
{
    public class PlotService : IPlotService
    {
        private IPlotRepository _plotRepository;

        public PlotService(IPlotRepository plotRepository)
        {
            _plotRepository = plotRepository;
        }

        public bool AddPlotMember(PlotMember plotMember)
        {
            return _plotRepository.AddPlotMember(new PlotMemberDLO
            {
                id_object = plotMember.id_object,
                id_owner = plotMember.id_owner,

                PostCode = plotMember.PostCode,
                City = plotMember.City,
                Hood = plotMember.Hood,
                Street = plotMember.Street,
                HouseNumber = plotMember.HouseNumber,
                FlatNumber = plotMember.FlatNumber,

                Type = plotMember.Type,
                Area = plotMember.Area,
                Status = plotMember.Status,
                Price = plotMember.Price
            });
        }

        public bool UpdatePlotMember(PlotMember plotMember)
        {
            return _plotRepository.UpdatePlotMember(new PlotMemberDLO
            {
                id_object = plotMember.id_object,
                id_owner = plotMember.id_owner,

                PostCode = plotMember.PostCode,
                City = plotMember.City,
                Hood = plotMember.Hood,
                Street = plotMember.Street,
                HouseNumber = plotMember.HouseNumber,
                FlatNumber = plotMember.FlatNumber,

                Type = plotMember.Type,
                Area = plotMember.Area,
                Status = plotMember.Status,
                Price = plotMember.Price
            });
        }

        public bool DeletePlotMember(PlotMember plotMember)
        {
            return _plotRepository.DeletePlotMember(new PlotMemberDLO
            {
                id_object = plotMember.id_object
            });
        }

        public ValidationResult<List<TableFindPlot>> FindPlot(PlotMember plotMember)
        {
            return _plotRepository.FindPlot(new PlotMemberDLO
            {
                City = plotMember.City,
                Hood = plotMember.Hood,
                Street = plotMember.Street,

                Type = plotMember.Type,
                Area = plotMember.Area,
                Status = plotMember.Status,
                Price = plotMember.Price
            });
        }

        public ValidationResult<List<TablePlot>> SelectPlot()
        {
            return _plotRepository.SelectPlot();
        }
    }
}
