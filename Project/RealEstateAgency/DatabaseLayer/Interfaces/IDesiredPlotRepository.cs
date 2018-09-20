using System.Collections.Generic;
using DatabaseLayer.DLObjects;
using Objects.Validation;
using Objects.Tables;

namespace DatabaseLayer.Interfaces
{
    public interface IDesiredPlotRepository
    {
        bool AddDesiredPlotMember(DesiredPlotMember desiredPlotMember);
        bool UpdateDesiredPlotMember(DesiredPlotMember desiredPlotMember);
        bool DeleteDesiredPlotMember(DesiredPlotMember desiredPlotMember);
        ValidationResult<List<TableDesiredPlot>> SelectDesiredPlot();
    }
}
