using System;
using System.Windows.Forms;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Interface.Forms;
using Objects.Encrypting;

namespace Interface.Controllers
{
    public class ClientInfoController
    {
        private string _login { get; set; }
        private IClientService _clientService;
        private ClientForm _clientForm;
        private Validators _validators;

        private Button _updateClientInfoButton;
        private Button _updateClientLoginButton;
        private Button _updateClientPasswordButton;
        private Button _exitClient;

        public ClientInfoController() { }

        public ClientInfoController(ClientForm clientForm, IClientService clientService, string login, Validators validators)
        {
            _login = login;

            _validators = validators;

            _clientForm = clientForm;
            _clientForm.Load += clientFormLoad;

            _clientService = clientService;

            #region Info
            #region Info's buttons
            _updateClientInfoButton = clientForm.updateClientInfo;
            _updateClientInfoButton.Click += UpdateClientInfo_Click;

            _updateClientLoginButton = clientForm.updateClientLogin;
            _updateClientLoginButton.Click += UpdateClientLogin_Click;

            _updateClientPasswordButton = clientForm.updateClientPassword;
            _updateClientPasswordButton.Click += UpdateClientPassword_Click;

            _exitClient = clientForm.exitClient;
            _exitClient.Click += ExitClient_Click;
            #endregion
            #endregion
        }

        #region Обработчик загрузки формы
        private void clientFormLoad(object sender, EventArgs e)
        {
            outputClientInfo(_login);
        }
        #endregion

        #region Обработчики кнопок, DataGrid и ComboBox 
        private void ExitClient_Click(object sender, EventArgs e)
        {
            _clientForm.Close();
        }
        #endregion

        #region Метод для заполнения Информации о клиенте
        public void outputClientInfo(string login)
        {
            try
            {
                var result = _clientService.SelectInfoClient(login);
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        _clientForm.lastName_client = v.LastName;
                        _clientForm.firstName_client = v.FirstName;
                        _clientForm.patronymic_client = v.Patronymic;
                        _clientForm.phoneNumber_client = v.PhoneNumber;

                        _clientForm.login_client = login;

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
        private void UpdateClientPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidUpdateNewPassword(_clientForm.oldPassword_client, _clientForm.newPassword_client))
                {
                    bool res = _clientService.UpdatePassword(_login, new ClientMember
                    {
                        Login = _login,
                        OldPassword = MD5.GetHashMD5(_clientForm.oldPassword_client),
                        NewPassword = MD5.GetHashMD5(_clientForm.newPassword_client),
                    });

                    if (res == false)
                    {
                        MessageBox.Show("Не верно введен старый пароль!");
                    }
                    else
                    {
                        MessageBox.Show("Данные успешно обновлены!");
                        _clientForm.oldPassword_client = string.Empty;
                        _clientForm.newPassword_client = string.Empty;
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
        private void UpdateClientLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidUpdateNewLogin(_clientForm.login_client))
                {
                    bool res = _clientService.UpdateLogin(_login, new ClientMember
                    {
                        Login = _login,
                        NewLogin = _clientForm.login_client
                    });

                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        MessageBox.Show("Данные успешно обновлены!");
                        _login = _clientForm.login_client;
                        _clientForm.login_client = string.Empty;
                    }
                    outputClientInfo(_login);
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
        private void UpdateClientInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidUpdatePrivateDataClient(_clientForm.lastName_client, _clientForm.firstName_client, 
                    _clientForm.patronymic_client,  _clientForm.phoneNumber_client))
                {
                    bool res = _clientService.UpdateClientPersonalInfo(_login, new ClientMember
                    {
                        Login = _login,
                        LastName = _clientForm.lastName_client,
                        FirstName = _clientForm.firstName_client,
                        Patronymic = _clientForm.patronymic_client,
                        PhoneNumber = _clientForm.phoneNumber_client
                    });

                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        MessageBox.Show("Данные успешно обновлены!");
                    }
                    outputClientInfo(_login);
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
