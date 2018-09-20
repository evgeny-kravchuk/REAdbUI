using System;
using System.Windows.Forms;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Interface.Forms;

namespace Interface.Controllers
{
    public class StaffContractController
    {
        private IContractService _contractService;
        private StaffForm _staffForm;
        private Validators _validators;

        private Button _addContractButton;
        private Button _updateContractButton;
        private DataGridView _dataGridViewContract;

        public StaffContractController() { }

        public StaffContractController(StaffForm staffForm, IContractService contractService, Validators validators)
        {
            _validators = validators;

            _staffForm = staffForm;
            _staffForm.Load += staffFormLoad;

            _contractService = contractService;

            #region Contract
            #region Contract's buttons
            _addContractButton = staffForm.addContract;
            _addContractButton.Click += AddContract;

            _updateContractButton = staffForm.updateContract;
            _updateContractButton.Click += EditContract;
            #endregion

            _dataGridViewContract = staffForm.datagridviewContract;
            _dataGridViewContract.CellClick += dgv_Contract_CellClick;
            #endregion
        }

        #region Инициализация формы
        public void staffFormLoad(object sender, EventArgs e)
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
                    _staffForm.id_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[0].Value.ToString();
                    _staffForm.idClient_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[1].Value.ToString();
                    _staffForm.idEmployee_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[2].Value.ToString();
                    _staffForm.idObject_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[3].Value.ToString();
                    _staffForm.idOwner_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[4].Value.ToString();

                    _staffForm.ContractType_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[5].Value.ToString();
                    _staffForm.StartDate_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[6].Value.ToString();
                    _staffForm.FinishDate_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[7].Value.ToString();
                    _staffForm.Price_contract = _dataGridViewContract.Rows[_dataGridViewContract.CurrentRow.Index].Cells[8].Value.ToString();
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
                if (_validators.ValidAddUpdateContract(_staffForm.idClient_contract, _staffForm.idEmployee_contract, _staffForm.idObject_contract,
                    _staffForm.idOwner_contract, _staffForm.ContractType_contract, _staffForm.StartDate_contract, _staffForm.FinishDate_contract, _staffForm.Price_contract))
                {

                    _contractService.AddContractMember(new ContractMember
                    {
                        id_client = _staffForm.idClient_contract,
                        id_employee = _staffForm.idEmployee_contract,
                        id_object = _staffForm.idObject_contract,
                        id_owner = _staffForm.idOwner_contract,

                        ContractType = _staffForm.ContractType_contract,
                        StartDate = _staffForm.StartDate_contract,
                        FinishDate = _staffForm.FinishDate_contract,
                        Price = _staffForm.Price_contract
                    });

                    _staffForm.id_contract = string.Empty;
                    _staffForm.idClient_contract = string.Empty;
                    _staffForm.idEmployee_contract = string.Empty;
                    _staffForm.idObject_contract = string.Empty;
                    _staffForm.idOwner_contract = string.Empty;

                    _staffForm.ContractType_contract = string.Empty;
                    _staffForm.StartDate_contract = string.Empty;
                    _staffForm.FinishDate_contract = string.Empty;
                    _staffForm.Price_contract = string.Empty;
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
                if (_validators.ValidAddUpdateContract(_staffForm.idClient_contract, _staffForm.idEmployee_contract, _staffForm.idObject_contract,
                    _staffForm.idOwner_contract, _staffForm.ContractType_contract, _staffForm.StartDate_contract, _staffForm.FinishDate_contract, _staffForm.Price_contract))
                {
                    _contractService.UpdateContractMember(new ContractMember
                    {
                        id_contract = _staffForm.id_contract,
                        id_client = _staffForm.idClient_contract,
                        id_employee = _staffForm.idEmployee_contract,
                        id_object = _staffForm.idObject_contract,
                        id_owner = _staffForm.idOwner_contract,

                        ContractType = _staffForm.ContractType_contract,
                        StartDate = _staffForm.StartDate_contract,
                        FinishDate = _staffForm.FinishDate_contract,
                        Price = _staffForm.Price_contract
                    });

                    _staffForm.id_contract = string.Empty;
                    _staffForm.idClient_contract = string.Empty;
                    _staffForm.idEmployee_contract = string.Empty;
                    _staffForm.idObject_contract = string.Empty;
                    _staffForm.idOwner_contract = string.Empty;

                    _staffForm.ContractType_contract = string.Empty;
                    _staffForm.StartDate_contract = string.Empty;
                    _staffForm.FinishDate_contract = string.Empty;
                    _staffForm.Price_contract = string.Empty;
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
