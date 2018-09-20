using System.Collections.Generic;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;
using Objects.Tables.IndividualTables;

namespace BusinessLogic.Interfaces
{
    public interface IPlotService
    {
        bool AddPlotMember(PlotMember plotMember);
        bool UpdatePlotMember(PlotMember plotMember);
        bool DeletePlotMember(PlotMember plotMember);
        ValidationResult<List<TableFindPlot>> FindPlot(PlotMember plotMember);
        ValidationResult<List<TablePlot>> SelectPlot();
    }
}
