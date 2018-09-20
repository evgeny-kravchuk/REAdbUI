using ClientMemberDLO = DatabaseLayer.DLObjects.ClientMember;
using System.Collections.Generic;
using DatabaseLayer.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Tables.IndividualTables;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Services
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public bool AddClientMember(ClientMember clientMember)
        {
            return _clientRepository.AddClientMember(new ClientMemberDLO
            {
                id_client = clientMember.id_client,
                Login = clientMember.Login,
                NewPassword = clientMember.NewPassword,

                LastName = clientMember.LastName,
                FirstName = clientMember.FirstName,
                Patronymic = clientMember.Patronymic,

                PhoneNumber = clientMember.PhoneNumber
            });
        }

        public bool UpdateClientMember(ClientMember clientMember)
        {
            return _clientRepository.UpdateClientMember(new ClientMemberDLO
            {
                id_client = clientMember.id_client,

                LastName = clientMember.LastName,
                FirstName = clientMember.FirstName,
                Patronymic = clientMember.Patronymic,

                PhoneNumber = clientMember.PhoneNumber
            });
        }

        public bool DeleteClientMember(ClientMember clientMember)
        {
            return _clientRepository.DeleteClientMember(new ClientMemberDLO
            {
                id_client = clientMember.id_client
            });
        }

        public ValidationResult<List<TableClient>> SelectClient()
        {
            return _clientRepository.SelectClient();
        }

        public ValidationResult<List<TableClientContractInfo>> SelectContractClient(string login)
        {
            return _clientRepository.SelectContractClient(new ClientMemberDLO
            {
                Login = login
            });
        }

        public ValidationResult<List<TableClientPersonalInfo>> SelectInfoClient(string login)
        {
            return _clientRepository.SelectPersonalInfoClient(new ClientMemberDLO
            {
                Login = login
            });
        }

        public ValidationResult<List<TableClientDesiredFlat>> SelectDesiredFlatClient(string login)
        {
            return _clientRepository.SelectDesiredFlatClient(new ClientMemberDLO
            {
                Login = login
            });
        }

        public ValidationResult<List<TableClientDesiredHouse>> SelectDesiredHouseClient(string login)
        {
            return _clientRepository.SelectDesiredHouseClient(new ClientMemberDLO
            {
                Login = login
            });
        }

        public ValidationResult<List<TableClientDesiredPlot>> SelectDesiredPlotClient(string login)
        {
            return _clientRepository.SelectDesiredPlotClient(new ClientMemberDLO
            {
                Login = login
            });
        }

        public bool UpdatePassword(string login, ClientMember clientMember)
        {
            return _clientRepository.UpdatePassword(new ClientMemberDLO
            {
                Login = login,
                OldPassword = clientMember.OldPassword,
                NewPassword = clientMember.NewPassword
            });
        }

        public bool UpdateLogin(string login, ClientMember clientMember)
        {
            return _clientRepository.UpdateLogin(new ClientMemberDLO
            {
                Login = login,
                NewLogin = clientMember.NewLogin
            });
        }

        public bool UpdateClientPersonalInfo(string login, ClientMember clientMember)
        {
            return _clientRepository.UpdateClientPersonalInfo(new ClientMemberDLO
            {
                Login = login,

                LastName = clientMember.LastName,
                FirstName = clientMember.FirstName,
                Patronymic = clientMember.Patronymic,

                PhoneNumber = clientMember.PhoneNumber
            });
        }
    }
}
