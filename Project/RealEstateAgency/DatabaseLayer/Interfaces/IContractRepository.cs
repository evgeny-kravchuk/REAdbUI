using System.Collections.Generic;
using DatabaseLayer.DLObjects;
using Objects.Validation;
using Objects.Tables;

namespace DatabaseLayer.Interfaces
{
    public interface IContractRepository
    {
        bool AddContractMember(ContractMember contractMember);
        bool UpdateContractMember(ContractMember contractMember);
        bool DeleteContractMember(ContractMember contractMember);
        ValidationResult<List<TableContract>> SelectContract();
    }
}
