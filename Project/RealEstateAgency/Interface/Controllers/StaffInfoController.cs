using System;
using System.Windows.Forms;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Interface.Forms;
using Objects.Encrypting;

namespace Interface.Controllers
{
    public class StaffInfoController
    {
        private string _login { get; set; }
        private IStaffService _staffService;
        private StaffForm _staffForm;
        private Validators _validators;

        private Button _updateStaffInfoButton;
        private Button _updateStaffLoginButton;
        private Button _updateStaffPasswordButton;
        private Button _exitStaff;

        public StaffInfoController() { }

        public StaffInfoController(StaffForm staffForm, IStaffService staffService, string login, Validators validators)
        {
            _validators = validators;
            _login = login;

            _staffForm = staffForm;
            _staffForm.Load += staffFormLoad;

            _staffService = staffService;

            #region Info
            #region Info's buttons
            _updateStaffInfoButton = staffForm.updateStaffInfo;
            _updateStaffInfoButton.Click += UpdateStaffInfo_Click;

            _updateStaffLoginButton = staffForm.updateStaffLogin;
            _updateStaffLoginButton.Click += UpdateStaffLogin_Click;

            _updateStaffPasswordButton = staffForm.updateStaffPassword;
            _updateStaffPasswordButton.Click += UpdateStaffPassword_Click;

            _exitStaff = staffForm.exitStaff;
            _exitStaff.Click += ExitStaff_Click;
            #endregion
            #endregion
        }

        #region Обработчик загрузки формы
        private void staffFormLoad(object sender, EventArgs e)
        {
            outputStaffInfo(_login);
        }
        #endregion

        #region Обработчики кнопок, DataGrid и ComboBox 
        private void ExitStaff_Click(object sender, EventArgs e)
        {
            _staffForm.Close();
        }
        #endregion

        #region Метод для заполнения Информации о клиенте
        public void outputStaffInfo(string login)
        {
            try
            {
                var result = _staffService.SelectInfoStaff(login);
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        _staffForm.lastName_staff = v.LastName;
                        _staffForm.firstName_staff = v.FirstName;
                        _staffForm.patronymic_staff = v.Patronymic;
                        _staffForm.sex_staff = v.Sex;
                        _staffForm.dateOfBirth_staff = v.DateOfBirth;
                        _staffForm.position_staff = v.Position;
                        _staffForm.phoneNumber_staff = v.PhoneNumber;
                        
                        _staffForm.login_staff = login;

                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion
        
        #region Обработчик события обновить пароль
        private void UpdateStaffPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidUpdateNewPassword(_staffForm.oldPassword_staff, _staffForm.newPassword_staff))
                {
                    bool res = _staffService.UpdatePassword(_login, new StaffMember
                    {
                        Login = _login,
                        OldPassword = MD5.GetHashMD5(_staffForm.oldPassword_staff),
                        NewPassword = MD5.GetHashMD5(_staffForm.newPassword_staff),
                    });

                    if (res == false)
                    {
                        MessageBox.Show("Не верно введен старый пароль!");
                    }
                    else
                    {
                        MessageBox.Show("Данные успешно обновлены!");
                        _staffForm.oldPassword_staff = string.Empty;
                        _staffForm.newPassword_staff = string.Empty;
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
        #endregion

        #region Обработчик события обновить Логин
        private void UpdateStaffLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidUpdateNewLogin(_staffForm.login_staff))
                {
                    bool res = _staffService.UpdateLogin(_login, new StaffMember
                    {
                        Login = _login,
                        NewLogin = _staffForm.login_staff
                    });

                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        MessageBox.Show("Данные успешно обновлены!");
                        _login = _staffForm.login_staff;
                        _staffForm.login_staff = string.Empty;
                    }
                    outputStaffInfo(_login);
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
        #endregion

        #region Обработчик события обновить персональные данные
        private void UpdateStaffInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidUpdatePrivateDataStaff(_staffForm.lastName_staff, _staffForm.firstName_staff, _staffForm.patronymic_staff,
                    _staffForm.sex_staff, _staffForm.dateOfBirth_staff, _staffForm.position_staff, _staffForm.phoneNumber_staff))
                {
                    bool res = _staffService.UpdateStaffPersonalInfo(_login, new StaffMember
                    {
                        Login = _login,
                        LastName = _staffForm.lastName_staff,
                        FirstName = _staffForm.firstName_staff,
                        Patronymic = _staffForm.patronymic_staff,
                        Sex = _staffForm.sex_staff,
                        DateOfBirth = _staffForm.dateOfBirth_staff,
                        PhoneNumber = _staffForm.phoneNumber_staff
                    });

                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        MessageBox.Show("Данные успешно обновлены!");
                    }
                    outputStaffInfo(_login);
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
        #endregion
    }
}
