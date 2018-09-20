using SignInMemberDLO = DatabaseLayer.DLObjects.SignInMember;
using System.Collections.Generic;
using DatabaseLayer.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Objects.Tables;

namespace BusinessLogic.Services
{
    public class SignInService : ISignInService
    {
        private ISignInRepository _signInRepository;
        
        public SignInService(ISignInRepository signInRepository)
        {
            _signInRepository = signInRepository;
        }

        public ValidationResult<List<TableDBUsers>> SignInUser(SignInMember signInMember)
        {
            return _signInRepository.SignInUser(new SignInMemberDLO
            {
                Login = signInMember.Login,
                Password = signInMember.Password
            });
        }
    }
}
