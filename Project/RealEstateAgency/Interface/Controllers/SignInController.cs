using System;
using System.Collections.Generic;
using BusinessLogic.BLObjects;
using BusinessLogic.Interfaces;
using Objects.Encrypting;
using Objects.Validation;
using Objects.Tables;
using Interface.Forms;
using System.Windows.Forms;

namespace Interface.Controllers
{
    public class SignInController
    {
        private SignInForm _signInForm;
        private SignUpForm _signUpForm;
        private Validators _validators;

        private ISignInService _signInService;

        private Button _btnSignIn;
        private Button _btnSignUp;
        private Button _btnExit;

        public string Login { get; set; }
        public string Vacant { get; set; }

        public SignInController(SignInForm signInForm, SignUpForm signUpForm, ISignInService signInService, Validators validators)
        {
            _signInForm = signInForm;
            _signUpForm = signUpForm;
            _signInService = signInService;
            _validators = validators;
            
            _btnSignIn = _signInForm.SignIn;
            _btnSignIn.Click += SignIn_Click;

            _btnSignUp = _signInForm.SignUp;
            _btnSignUp.Click += SignUp_Click;

            _btnExit = _signInForm.Exit;
            _btnExit.Click += Exit_Click;
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            if (_validators.ValidSignIn(_signInForm.Login, _signInForm.Password))
            {
                ValidationResult<List<TableDBUsers>> myResult = _signInService.SignInUser(new SignInMember
                {
                    Login = _signInForm.Login,
                    Password = MD5.GetHashMD5(_signInForm.Password)
                });
                if (myResult.ResultObject.Count != 0)
                {
                    Vacant = myResult.ResultObject[0].Vacant;
                    Login = myResult.ResultObject[0].Login;
                    _signInForm.Close();

                }
                else
                {
                    MessageBox.Show("Не верный логин или пароль");
                }
            }
            else
            {
                for (int i = 0; i < _validators.ErrorStrings.Count; i++)
                {
                    MessageBox.Show(_validators.ErrorStrings[i]);
                    _validators.ErrorStrings.Clear();
                }
            }
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            _signUpForm.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            _signInForm.Close();
        }
    }
}