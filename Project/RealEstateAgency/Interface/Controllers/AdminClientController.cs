using System;
using System.Windows.Forms;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Interface.Forms;
using Objects.Encrypting;

namespace Interface.Controllers
{
    public class AdminClientController
    {
        private IClientService _clientService;
        private AdminForm _adminForm;
        private Validators _validators;

        private Button _addClientButton;
        private Button _updateClientButton;
        private Button _deleteClientButton;
        private DataGridView _dataGridViewClient;

        public AdminClientController() { }

        public AdminClientController(AdminForm adminForm, IClientService clientService, Validators validators)
        {
            _validators = validators;

            _adminForm = adminForm;
            _adminForm.Load += adminFormLoad;

            _clientService = clientService;

            #region Client
            #region Client's buttons
            _addClientButton = adminForm.addClient;
            _addClientButton.Click += AddClient;

            _updateClientButton = adminForm.updateClient;
            _updateClientButton.Click += EditClient;

            _deleteClientButton = adminForm.deleteClient;
            _deleteClientButton.Click += DeleteClient;
            #endregion

            _dataGridViewClient = adminForm.datagridviewClient;
            _dataGridViewClient.CellClick += dgv_Client_CellClick;
            #endregion
        }

        #region Инициализация формы
        public void adminFormLoad(object sender, EventArgs e)
        {
            outputClient(_dataGridViewClient);
        }
        #endregion

        #region Client
        #region Метод для заполнения DataGrid
        public void outputClient(DataGridView dgvClient)
        {
            dgvClient.Rows.Clear();
            try
            {
                var result = _clientService.SelectClient();
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        dgvClient.Rows.Add(v.id_client, v.Login, v.LastName, v.FirstName, v.Patronymic, v.PhoneNumber);
                    }
                }
                else
                {
                    MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + result.Errors);
                }
            }
            catch
            {
                MessageBox.Show(@"Произошла ошибка на уровне контроллера");
            }

        }
        #endregion

        #region Метод для нажатия ячейки DataGrid и заполнения TextBox
        public void dgv_Client_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridViewClient.CurrentRow != null)
                {
                    _adminForm.id_client = _dataGridViewClient.Rows[_dataGridViewClient.CurrentRow.Index].Cells[0].Value.ToString();
                    _adminForm.login_client = _dataGridViewClient.Rows[_dataGridViewClient.CurrentRow.Index].Cells[1].Value.ToString();

                    _adminForm.lastName_client = _dataGridViewClient.Rows[_dataGridViewClient.CurrentRow.Index].Cells[2].Value.ToString();
                    _adminForm.firstName_client = _dataGridViewClient.Rows[_dataGridViewClient.CurrentRow.Index].Cells[3].Value.ToString();
                    _adminForm.patronymic_client = _dataGridViewClient.Rows[_dataGridViewClient.CurrentRow.Index].Cells[4].Value.ToString();

                    _adminForm.phoneNumber_client = _dataGridViewClient.Rows[_dataGridViewClient.CurrentRow.Index].Cells[5].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion

        #region Метод события кнопки Добавить Сотрудника
        public void AddClient(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateClient(_adminForm.lastName_client, _adminForm.firstName_client,
                    _adminForm.patronymic_client, _adminForm.phoneNumber_client))
                {

                    _clientService.AddClientMember(new ClientMember
                    {
                        Login = _adminForm.login_client,
                        NewPassword = MD5.GetHashMD5(_adminForm.password_client),

                        LastName = _adminForm.lastName_client,
                        FirstName = _adminForm.firstName_client,
                        Patronymic = _adminForm.patronymic_client,

                        PhoneNumber = _adminForm.phoneNumber_client
                    });

                    _adminForm.id_client = string.Empty;
                    _adminForm.login_client = string.Empty;
                    _adminForm.password_client = string.Empty;

                    _adminForm.lastName_client = string.Empty;
                    _adminForm.firstName_client = string.Empty;
                    _adminForm.patronymic_client = string.Empty;

                    _adminForm.phoneNumber_client = string.Empty;
                }
                outputClient(_dataGridViewClient);
                if (_dataGridViewClient.CurrentRow != null)
                {
                    _dataGridViewClient.Rows[_dataGridViewClient.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Обновить Сотрудника
        public void EditClient(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateClient(_adminForm.lastName_client, _adminForm.firstName_client,
                    _adminForm.patronymic_client, _adminForm.phoneNumber_client))
                {
                    _clientService.UpdateClientMember(new ClientMember
                    {
                        id_client = _adminForm.id_client,

                        LastName = _adminForm.lastName_client,
                        FirstName = _adminForm.firstName_client,
                        Patronymic = _adminForm.patronymic_client,

                        PhoneNumber = _adminForm.phoneNumber_client
                    });

                    _adminForm.id_client = string.Empty;
                    _adminForm.login_client = string.Empty;

                    _adminForm.lastName_client = string.Empty;
                    _adminForm.firstName_client = string.Empty;
                    _adminForm.patronymic_client = string.Empty;

                    _adminForm.phoneNumber_client = string.Empty;
                }

                outputClient(_dataGridViewClient);
                if (_dataGridViewClient.CurrentRow != null)
                {
                    _dataGridViewClient.Rows[_dataGridViewClient.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Удалить Сотрудника
        public void DeleteClient(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidDeleteClient(_adminForm.id_client))
                {
                    _clientService.DeleteClientMember(new ClientMember
                    {
                        id_client = _adminForm.id_client
                    });

                    _adminForm.id_client = string.Empty;
                    _adminForm.login_client = string.Empty;

                    _adminForm.lastName_client = string.Empty;
                    _adminForm.firstName_client = string.Empty;
                    _adminForm.patronymic_client = string.Empty;

                    _adminForm.phoneNumber_client = string.Empty;
                }

                outputClient(_dataGridViewClient);
                if (_dataGridViewClient.CurrentRow != null)
                {
                    _dataGridViewClient.Rows[_dataGridViewClient.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion
        #endregion
    }
}
