using System.Collections.Generic;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;
using Objects.Tables.IndividualTables;

namespace BusinessLogic.Interfaces
{
    public interface IStaffService
    {
        #region Admin
        bool AddStaffMember(StaffMember staffMember);
        bool UpdateStaffMember(StaffMember staffMember);
        bool DeleteStaffMember(StaffMember staffMember);
        ValidationResult<List<TableStaff>> SelectStaff();
        #endregion

        #region Staff
        ValidationResult<List<TableStaffContractInfo>> SelectContractStaff(string login);
        ValidationResult<List<TableStaffPersonalInfo>> SelectInfoStaff(string login);
        bool UpdatePassword(string login, StaffMember staffMember);
        bool UpdateLogin(string login, StaffMember staffMember);
        bool UpdateStaffPersonalInfo(string login, StaffMember staffMember);
        #endregion
    }
}
