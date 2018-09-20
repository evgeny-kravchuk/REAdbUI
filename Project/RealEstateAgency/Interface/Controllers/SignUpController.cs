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
    public class SignUpController
    {
        private SignUpForm _signUpForm;
        private Validators _validators;

        private ISignUpService _signUpService;

        private Button _regist;
        private Button _btnExit;

        public SignUpController(SignUpForm signUpForm, ISignUpService signUpService, Validators validators)
        {
            _signUpForm = signUpForm;
            _signUpService = signUpService;
            _validators = validators;

            _regist = _signUpForm.SignUp;
            _regist.Click += SignUp_Click;

            _btnExit = _signUpForm.Exit;
            _btnExit.Click += Exit_Click;
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidSignUp(_signUpForm.Login, _signUpForm.Password,
                    _signUpForm.LastName, _signUpForm.FirstName, _signUpForm.Patronymic, _signUpForm.PhoneNumber))
                {
                    bool res = _signUpService.SignUpMember(new SignUpMember
                    {
                        Login = _signUpForm.Login,
                        Password = MD5.GetHashMD5(_signUpForm.Password),

                        LastName = _signUpForm.LastName,
                        FirstName = _signUpForm.FirstName,
                        Patronymic = _signUpForm.Patronymic,

                        PhoneNumber = _signUpForm.PhoneNumber
                    });

                    if (res == false)
                    {

                        MessageBox.Show("Не удалось выполнить запрос! Возможно этот ник занят!");
                    }
                    else
                    {
                        MessageBox.Show("Вы успешно зарегестрировались в нашей системе!");
                        _signUpForm.Close();
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
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            _signUpForm.Close();
        }
    }
}
