using SignUpMemberDLO = DatabaseLayer.DLObjects.SignUpMember;
using DatabaseLayer.Interfaces;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;

namespace BusinessLogic.Services
{
    public class SignUpService : ISignUpService
    {
        private ISignUpRepository _signUpRepository;

        public SignUpService(ISignUpRepository signUpRepository)
        {
            _signUpRepository = signUpRepository;
        }

        public bool SignUpMember(SignUpMember signUpMember)
        {
            return _signUpRepository.SignUpMember(new SignUpMemberDLO
            {
                Login = signUpMember.Login,
                Password = signUpMember.Password,
                LastName = signUpMember.LastName,
                FirstName = signUpMember.FirstName,
                Patronymic = signUpMember.Patronymic,
                PhoneNumber = signUpMember.PhoneNumber
            });
        }
    }
}
