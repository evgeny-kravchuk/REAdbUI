using System;
using System.Windows.Forms;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Interface.Forms;

namespace Interface.Controllers
{
    public class AdminContractController
    {
        private IContractService _contractService;
        private AdminForm _adminForm;
        private Validators _validators;

        private Button _addContractButton;
        private Button _updateContractButton;
        private Button _deleteContractButton;
        private DataGridView _dataGridViewContract;

        public AdminContractController() { }

        public AdminContractController(AdminForm adminForm, IContractService contractService, Validators validators)
        {
            _validators = validators;

            _adminForm = adminForm;
            _adminForm.Load += adminFormLoad;

            _contractService = contractService;

            #region Contract
            #region Contract's buttons
            _addContractButton = adminForm.addContract;
            _addContractButton.Click += AddContract;

            _updateContractButton = adminForm.updateContract;
            _updateContractButton.Click += EditContract;

            _deleteContractButton = adminForm.deleteContract;
            _deleteContractButton.Click += DeleteContract;
            #endregion

            _dataGridViewContract = adminForm.datagridviewContract;
            _dataGridViewContract.CellClick += dgv_Contract_CellClick;
            #endregion
        }

        #region Инициализация формы
        public void adminFormLoad(object sender, EventArgs e)
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
                var result = _contractService.SelectContract();
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        dgvContract.Rows.Add(v.id_contract, v.id_client, v.id_employee, v.id_object, v.id_owner, v.ContractType, v.StartDate, v.FinishDate, v.Price);
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
        public void dgv_Contract_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridViewContract.CurrentRow != null)
                {
                    _adminForm.id_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[0].Value.ToString();
                    _adminForm.idClient_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[1].Value.ToString();
                    _adminForm.idEmployee_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[2].Value.ToString();
                    _adminForm.idObject_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[3].Value.ToString();
                    _adminForm.idOwner_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[4].Value.ToString();

                    _adminForm.ContractType_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[5].Value.ToString();
                    _adminForm.StartDate_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[6].Value.ToString();
                    _adminForm.FinishDate_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[7].Value.ToString();
                    _adminForm.Price_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[8].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion

        #region Метод события кнопки Добавить Контракт
        public void AddContract(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateContract(_adminForm.idClient_contract, _adminForm.idEmployee_contract, _adminForm.idObject_contract,
                    _adminForm.idOwner_contract, _adminForm.ContractType_contract, _adminForm.StartDate_contract, _adminForm.FinishDate_contract, _adminForm.Price_contract))
                {

                    _contractService.AddContractMember(new ContractMember
                    {
                        id_client = _adminForm.idClient_contract,
                        id_employee = _adminForm.idEmployee_contract,
                        id_object = _adminForm.idObject_contract,
                        id_owner = _adminForm.idOwner_contract,

                        ContractType = _adminForm.ContractType_contract,
                        StartDate = _adminForm.StartDate_contract,
                        FinishDate = _adminForm.FinishDate_contract,
                        Price = _adminForm.Price_contract
                    });

                    _adminForm.id_contract = string.Empty;
                    _adminForm.idClient_contract = string.Empty;
                    _adminForm.idEmployee_contract = string.Empty;
                    _adminForm.idObject_contract = string.Empty;
                    _adminForm.idOwner_contract = string.Empty;

                    _adminForm.ContractType_contract = string.Empty;
                    _adminForm.StartDate_contract = string.Empty;
                    _adminForm.FinishDate_contract = string.Empty;
                    _adminForm.Price_contract = string.Empty;
                }
                outputContract(_dataGridViewContract);
                if (_dataGridViewContract.CurrentRow != null)
                {
                    _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Обновить Контракт
        public void EditContract(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateContract(_adminForm.idClient_contract, _adminForm.idEmployee_contract, _adminForm.idObject_contract,
                    _adminForm.idOwner_contract, _adminForm.ContractType_contract, _adminForm.StartDate_contract, _adminForm.FinishDate_contract, _adminForm.Price_contract))
                {
                    _contractService.UpdateContractMember(new ContractMember
                    {
                        id_contract = _adminForm.id_contract,
                        id_client = _adminForm.idClient_contract,
                        id_employee = _adminForm.idEmployee_contract,
                        id_object = _adminForm.idObject_contract,
                        id_owner = _adminForm.idOwner_contract,

                        ContractType = _adminForm.ContractType_contract,
                        StartDate = _adminForm.StartDate_contract,
                        FinishDate = _adminForm.FinishDate_contract,
                        Price = _adminForm.Price_contract
                    });

                    _adminForm.id_contract = string.Empty;
                    _adminForm.idClient_contract = string.Empty;
                    _adminForm.idEmployee_contract = string.Empty;
                    _adminForm.idObject_contract = string.Empty;
                    _adminForm.idOwner_contract = string.Empty;

                    _adminForm.ContractType_contract = string.Empty;
                    _adminForm.StartDate_contract = string.Empty;
                    _adminForm.FinishDate_contract = string.Empty;
                    _adminForm.Price_contract = string.Empty;
                }

                outputContract(_dataGridViewContract);
                if (_dataGridViewContract.CurrentRow != null)
                {
                    _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Удалить Контракт
        public void DeleteContract(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidDeleteContract(_adminForm.id_contract))
                {
                    _contractService.DeleteContractMember(new ContractMember
                    {
                        id_contract = _adminForm.id_contract
                    });

                    _adminForm.id_contract = string.Empty;
                    _adminForm.idClient_contract = string.Empty;
                    _adminForm.idEmployee_contract = string.Empty;
                    _adminForm.idObject_contract = string.Empty;
                    _adminForm.idOwner_contract = string.Empty;

                    _adminForm.ContractType_contract = string.Empty;
                    _adminForm.StartDate_contract = string.Empty;
                    _adminForm.FinishDate_contract = string.Empty;
                    _adminForm.Price_contract = string.Empty;
                }

                outputContract(_dataGridViewContract);
                if (_dataGridViewContract.CurrentRow != null)
                {
                    _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Selected = false;
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
