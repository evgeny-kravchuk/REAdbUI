using System.Collections.Generic;
using DatabaseLayer.DLObjects;
using Objects.Validation;
using Objects.Tables;
using Objects.Tables.IndividualTables;

namespace DatabaseLayer.Interfaces
{
    public interface IPlotRepository
    {
        bool AddPlotMember(PlotMember plotMember);
        bool UpdatePlotMember(PlotMember plotMember);
        bool DeletePlotMember(PlotMember plotMember);
        ValidationResult<List<TableFindPlot>> FindPlot(PlotMember plotMember);
        ValidationResult<List<TablePlot>> SelectPlot();
    }
}
