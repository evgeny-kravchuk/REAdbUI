using System.Collections.Generic;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Interfaces
{
    public interface IContractService
    {
        bool AddContractMember(ContractMember contractMember);
        bool UpdateContractMember(ContractMember contractMember);
        bool DeleteContractMember(ContractMember contractMember);
        ValidationResult<List<TableContract>> SelectContract();
    }
}
