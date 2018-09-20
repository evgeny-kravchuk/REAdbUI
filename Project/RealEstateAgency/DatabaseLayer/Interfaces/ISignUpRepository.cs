using DatabaseLayer.DLObjects;

namespace DatabaseLayer.Interfaces
{
    public interface ISignUpRepository
    {
        bool SignUpMember(SignUpMember signUpMember);
    }
}
