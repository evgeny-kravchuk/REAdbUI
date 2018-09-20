using System.Collections.Generic;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Interfaces
{
    public interface IDesiredPlotService
    {
        bool AddDesiredPlotMember(DesiredPlotMember desiredPlotMember);
        bool UpdateDesiredPlotMember(DesiredPlotMember desiredPlotMember);
        bool DeleteDesiredPlotMember(DesiredPlotMember desiredPlotMember);
        ValidationResult<List<TableDesiredPlot>> SelectDesiredPlot();
    }
}
