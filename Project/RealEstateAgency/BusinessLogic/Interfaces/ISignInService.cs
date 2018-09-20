using System.Collections.Generic;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Interfaces
{
    public interface ISignInService
    {
        ValidationResult<List<TableDBUsers>> SignInUser(SignInMember signInMember);
    }
}
