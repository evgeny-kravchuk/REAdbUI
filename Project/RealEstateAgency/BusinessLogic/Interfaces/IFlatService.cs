using System.Collections.Generic;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;
using Objects.Tables.IndividualTables;

namespace BusinessLogic.Interfaces
{
    public interface IFlatService
    {
        bool AddFlatMember(FlatMember flatMember);
        bool UpdateFlatMember(FlatMember flatMember);
        bool DeleteFlatMember(FlatMember flatMember);
        ValidationResult<List<TableFindFlat>> FindFlat(FlatMember flatMember);
        ValidationResult<List<TableFlat>> SelectFlat();
    }
}
