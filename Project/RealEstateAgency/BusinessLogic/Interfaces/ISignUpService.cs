using BusinessLogic.BLObjects;

namespace BusinessLogic.Interfaces
{
    public interface ISignUpService
    {
        bool SignUpMember(SignUpMember signUpMember);
    }
}
