using System.Collections.Generic;
using DatabaseLayer.DLObjects;
using Objects.Validation;
using Objects.Tables;

namespace DatabaseLayer.Interfaces
{
    public interface ISignInRepository
    {
        ValidationResult<List<TableDBUsers>> SignInUser(SignInMember signInMember);
    }
}
