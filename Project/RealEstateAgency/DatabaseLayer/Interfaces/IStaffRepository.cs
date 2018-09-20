using System.Collections.Generic;
using DatabaseLayer.DLObjects;
using Objects.Validation;
using Objects.Tables;
using Objects.Tables.IndividualTables;

namespace DatabaseLayer.Interfaces
{
    public interface IStaffRepository
    {
        #region Admin
        bool AddStaffMember(StaffMember staffMember);
        bool UpdateStaffMember(StaffMember staffMember);
        bool DeleteStaffMember(StaffMember staffMember);
        ValidationResult<List<TableStaff>> SelectStaff();
        #endregion

        #region Staff
        ValidationResult<List<TableStaffContractInfo>> SelectContractStaff(StaffMember staffMember);
        ValidationResult<List<TableStaffPersonalInfo>> SelectPersonalInfoStaff(StaffMember staffMember);
        bool UpdatePassword(StaffMember staffMember);
        bool UpdateLogin(StaffMember staffMember);
        bool UpdateStaffPersonalInfo(StaffMember staffMember);
        #endregion
    }
}
