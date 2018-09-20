using System;
using System.Windows.Forms;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Interface.Forms;

namespace Interface.Controllers
{
    public class StaffClientController
    {
        private IClientService _clientService;
        private StaffForm _staffForm;
        private Validators _validators;
        
        private Button _updateClientButton;
        private DataGridView _dataGridViewClient;

        public StaffClientController() { }

        public StaffClientController(StaffForm staffForm, IClientService clientService, Validators validators)
        {
            _validators = validators;

            _staffForm = staffForm;
            _staffForm.Load += staffFormLoad;

            _clientService = clientService;

            #region Client
            #region Client's button
            _updateClientButton = staffForm.updateClient;
            _updateClientButton.Click += EditClient;
            #endregion

            _dataGridViewClient = staffForm.datagridviewClient;
            _dataGridViewClient.CellClick += dgv_Client_CellClick;
            #endregion
        }

        #region Инициализация формы
        public void staffFormLoad(object sender, EventArgs e)
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
                        dgvClient.Rows.Add(v.id_client, v.LastName, v.FirstName, v.Patronymic, v.PhoneNumber);
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
                    _staffForm.id_client = _dataGridViewClient.Rows[_dataGridViewClient.CurrentRow.Index].Cells[0].Value.ToString();
                    
                    _staffForm.lastName_client = _dataGridViewClient.Rows[_dataGridViewClient.CurrentRow.Index].Cells[1].Value.ToString();
                    _staffForm.firstName_client = _dataGridViewClient.Rows[_dataGridViewClient.CurrentRow.Index].Cells[2].Value.ToString();
                    _staffForm.patronymic_client = _dataGridViewClient.Rows[_dataGridViewClient.CurrentRow.Index].Cells[3].Value.ToString();

                    _staffForm.phoneNumber_client = _dataGridViewClient.Rows[_dataGridViewClient.CurrentRow.Index].Cells[4].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion        

        #region  Метод события кнопки Обновить Клиента
        public void EditClient(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateClient(_staffForm.lastName_client, _staffForm.firstName_client,
                    _staffForm.patronymic_client, _staffForm.phoneNumber_client))
                {
                    _clientService.UpdateClientMember(new ClientMember
                    {
                        id_client = _staffForm.id_client,

                        LastName = _staffForm.lastName_client,
                        FirstName = _staffForm.firstName_client,
                        Patronymic = _staffForm.patronymic_client,

                        PhoneNumber = _staffForm.phoneNumber_client
                    });

                    _staffForm.id_client = string.Empty;

                    _staffForm.lastName_client = string.Empty;
                    _staffForm.firstName_client = string.Empty;
                    _staffForm.patronymic_client = string.Empty;

                    _staffForm.phoneNumber_client = string.Empty;
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
