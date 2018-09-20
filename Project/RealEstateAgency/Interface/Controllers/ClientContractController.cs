using System;
using System.Windows.Forms;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Interface.Forms;
using Objects.Encrypting;

namespace Interface.Controllers
{
    public class ClientContractController
    {
        private string _login { get; set; }
        private IClientService _clientService;
        private ClientForm _clientForm;
        private Validators _validators;

        //private Button _findContractButton;
        private DataGridView _dataGridViewContract;

        public ClientContractController() { }

        public ClientContractController(ClientForm clientForm, IClientService clientService, string login, Validators validators)
        {
            _login = login;

            _validators = validators;

            _clientForm = clientForm;
            _clientForm.Load += clientFormLoad;

            _clientService = clientService;

            #region Contract
            #region Contract's buttons
            //_findContractButton = clientForm.findContract;
            //_findContractButton.Click += FindContract;
            #endregion

            _dataGridViewContract = clientForm.datagridviewContract;
            _dataGridViewContract.CellClick += dgv_Contract_CellClick;
            #endregion
        }

        #region Инициализация формы
        public void clientFormLoad(object sender, EventArgs e)
        {            
            outputContract(_dataGridViewContract);
        }
        #endregion

        #region Contract
        #region Метод для заполнения DataGrid
        public void outputContract(DataGridView dgvContract)
        {
            dgvContract.Rows.Clear();
            try
            {
                var result = _clientService.SelectContractClient(_login);
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        dgvContract.Rows.Add(v.City, v.Street, v.HouseNumber, v.FlatNumber, v.ContractType, v.StartDate, v.FinishDate, v.Price);
                    }
                }
                else
                {
                    MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + result.Errors);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region Метод для нажатия ячейки DataGrid и заполнения TextBox
        public void dgv_Contract_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridViewContract.CurrentRow != null)
                {
                    _clientForm.city_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[0].Value.ToString();
                    _clientForm.street_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[1].Value.ToString();
                    _clientForm.houseNumber_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[2].Value.ToString();
                    _clientForm.flatNumber_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[3].Value.ToString();

                    _clientForm.ContractType_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[4].Value.ToString();
                    _clientForm.StartDate_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[5].Value.ToString();
                    _clientForm.FinishDate_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[6].Value.ToString();
                    _clientForm.Price_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[7].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion
        #endregion
    }
}
