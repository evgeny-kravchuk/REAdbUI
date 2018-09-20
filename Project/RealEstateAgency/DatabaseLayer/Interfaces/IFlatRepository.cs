using System.Collections.Generic;
using DatabaseLayer.DLObjects;
using Objects.Validation;
using Objects.Tables;
using Objects.Tables.IndividualTables;

namespace DatabaseLayer.Interfaces
{
    public interface IFlatRepository
    {
        bool AddFlatMember(FlatMember flatMember);
        bool UpdateFlatMember(FlatMember flatMember);
        bool DeleteFlatMember(FlatMember flatMember);
        ValidationResult<List<TableFindFlat>> FindFlat(FlatMember flatMember);
        ValidationResult<List<TableFlat>> SelectFlat();
    }
}
