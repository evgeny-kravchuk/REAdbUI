using ContractMemberDLO = DatabaseLayer.DLObjects.ContractMember;
using System.Collections.Generic;
using DatabaseLayer.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Services
{
    public class ContractService : IContractService
    {
        private IContractRepository _contractRepository;

        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public bool AddContractMember(ContractMember contractMember)
        {
            return _contractRepository.AddContractMember(new ContractMemberDLO
            {
                id_contract = contractMember.id_contract,
                id_client = contractMember.id_client,
                id_employee = contractMember.id_employee,
                id_object = contractMember.id_object,
                id_owner = contractMember.id_owner,

                ContractType = contractMember.ContractType,
                StartDate = contractMember.StartDate,
                FinishDate = contractMember.FinishDate,
                Price = contractMember.Price
            });
        }

        public bool UpdateContractMember(ContractMember contractMember)
        {
            return _contractRepository.UpdateContractMember(new ContractMemberDLO
            {
                id_contract = contractMember.id_contract,
                id_client = contractMember.id_client,
                id_employee = contractMember.id_employee,
                id_object = contractMember.id_object,
                id_owner = contractMember.id_owner,

                ContractType = contractMember.ContractType,
                StartDate = contractMember.StartDate,
                FinishDate = contractMember.FinishDate,
                Price = contractMember.Price
            });
        }

        public bool DeleteContractMember(ContractMember contractMember)
        {
            return _contractRepository.DeleteContractMember(new ContractMemberDLO
            {
                id_contract = contractMember.id_contract
            });
        }

        public ValidationResult<List<TableContract>> SelectContract()
        {
            return _contractRepository.SelectContract();
        }
    }
}
