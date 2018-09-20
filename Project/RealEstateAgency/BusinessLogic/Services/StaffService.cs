using StaffMemberDLO = DatabaseLayer.DLObjects.StaffMember;
using System.Collections.Generic;
using DatabaseLayer.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;
using Objects.Tables.IndividualTables;

namespace BusinessLogic.Services
{
    public class StaffService : IStaffService
    {
        private IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public bool AddStaffMember(StaffMember staffMember)
        {
            return _staffRepository.AddStaffMember(new StaffMemberDLO
            {
                id_employee = staffMember.id_employee,
                Login = staffMember.Login,
                NewPassword = staffMember.NewPassword,

                LastName = staffMember.LastName,
                FirstName = staffMember.FirstName,
                Patronymic = staffMember.Patronymic,

                Sex = staffMember.Sex,
                DateOfBirth = staffMember.DateOfBirth,
                Position = staffMember.Position,
                PhoneNumber = staffMember.PhoneNumber
            });
        }

        public bool UpdateStaffMember(StaffMember staffMember)
        {
            return _staffRepository.UpdateStaffMember(new StaffMemberDLO
            {
                id_employee = staffMember.id_employee,

                LastName = staffMember.LastName,
                FirstName = staffMember.FirstName,
                Patronymic = staffMember.Patronymic,

                Sex = staffMember.Sex,
                DateOfBirth = staffMember.DateOfBirth,
                Position = staffMember.Position,
                PhoneNumber = staffMember.PhoneNumber
            });
        }

        public bool DeleteStaffMember(StaffMember staffMember)
        {
            return _staffRepository.DeleteStaffMember(new StaffMemberDLO
            {
                id_employee = staffMember.id_employee
            });
        }

        public ValidationResult<List<TableStaff>> SelectStaff()
        {
            return _staffRepository.SelectStaff();
        }

        public ValidationResult<List<TableStaffContractInfo>> SelectContractStaff(string login)
        {
            return _staffRepository.SelectContractStaff(new StaffMemberDLO
            {
                Login = login
            });
        }

        public ValidationResult<List<TableStaffPersonalInfo>> SelectInfoStaff(string login)
        {
            return _staffRepository.SelectPersonalInfoStaff(new StaffMemberDLO
            {
                Login = login
            });
        }

        public bool UpdatePassword(string login, StaffMember staffMember)
        {
            return _staffRepository.UpdatePassword(new StaffMemberDLO
            {
                Login = login,
                OldPassword = staffMember.OldPassword,
                NewPassword = staffMember.NewPassword
            });
        }

        public bool UpdateLogin(string login, StaffMember staffMember)
        {
            return _staffRepository.UpdateLogin(new StaffMemberDLO
            {
                Login = login,
                NewLogin = staffMember.NewLogin
            });
        }

        public bool UpdateStaffPersonalInfo(string login, StaffMember staffMember)
        {
            return _staffRepository.UpdateStaffPersonalInfo(new StaffMemberDLO
            {
                Login = login,

                LastName = staffMember.LastName,
                FirstName = staffMember.FirstName,
                Patronymic = staffMember.Patronymic,

                Sex = staffMember.Sex,
                DateOfBirth = staffMember.DateOfBirth,
                PhoneNumber = staffMember.PhoneNumber
            });
        }
    }
}
