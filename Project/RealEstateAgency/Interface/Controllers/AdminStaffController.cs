using System;
using System.Windows.Forms;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Interface.Forms;
using Objects.Encrypting;

namespace Interface.Controllers
{
    public class AdminStaffController
    {
        private IStaffService _staffService;
        private IPositionService _positionService;
        private AdminForm _adminForm;
        private Validators _validators;

        private Button _addStaffButton;
        private Button _updateStaffButton;
        private Button _deleteStaffButton;
        private DataGridView _dataGridViewStaff;

        private Button _updatePositionButton;
        private DataGridView _dataGridViewPosition;

        public AdminStaffController() { }

        public AdminStaffController(AdminForm adminForm, IStaffService staffService, IPositionService positionService, Validators validators)
        {
            _validators = validators;

            _adminForm = adminForm;
            _adminForm.Load += adminFormLoad;

            _staffService = staffService;
            _positionService = positionService;

            #region Сотрудники
            #region Кнопки Сотрудников
            _addStaffButton = adminForm.addStaff;
            _addStaffButton.Click += AddStaff;

            _updateStaffButton = adminForm.updateStaff;
            _updateStaffButton.Click += EditStaff;

            _deleteStaffButton = adminForm.deleteStaff;
            _deleteStaffButton.Click += DeleteStaff;
            #endregion
            
            _dataGridViewStaff = adminForm.datagridviewStaff;
            _dataGridViewStaff.CellClick += dgv_Crew_CellClick;
            #endregion

            #region Должность
            #region Кнопки Должности
            _updatePositionButton = adminForm.updatePosition;
            _updatePositionButton.Click += UpdatePosition;
            #endregion

            _dataGridViewPosition = adminForm.datagridviewPosition;
            _dataGridViewPosition.CellClick += dgv_Position_CellClick;
            #endregion
        }

        #region Инициализация формы
        public void adminFormLoad(object sender, EventArgs e)
        {
            outputStaff(_dataGridViewStaff);
            outputPosition(_dataGridViewPosition);
        }
        #endregion

        #region Сотрудники
        #region Метод для заполнения DataGrid
        public void outputStaff(DataGridView dgvStaff)
        {
            dgvStaff.Rows.Clear();
            try
            {
                var result = _staffService.SelectStaff();
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        dgvStaff.Rows.Add(v.id_employee, v.Login, v.LastName, v.FirstName, v.Patronymic, v.DateOfBirth, v.Sex, v.Position, v.PhoneNumber);
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
        public void dgv_Crew_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridViewStaff.CurrentRow != null)
                {
                    _adminForm.id_staff = _dataGridViewStaff.Rows[_dataGridViewStaff.CurrentRow.Index].Cells[0].Value.ToString();
                    _adminForm.login_staff = _dataGridViewStaff.Rows[_dataGridViewStaff.CurrentRow.Index].Cells[1].Value.ToString();

                    _adminForm.lastName_staff = _dataGridViewStaff.Rows[_dataGridViewStaff.CurrentRow.Index].Cells[2].Value.ToString();
                    _adminForm.firstName_staff = _dataGridViewStaff.Rows[_dataGridViewStaff.CurrentRow.Index].Cells[3].Value.ToString();
                    _adminForm.patronymic_staff = _dataGridViewStaff.Rows[_dataGridViewStaff.CurrentRow.Index].Cells[4].Value.ToString();

                    _adminForm.dateOfBirth_staff = _dataGridViewStaff.Rows[_dataGridViewStaff.CurrentRow.Index].Cells[5].Value.ToString();
                    _adminForm.sex_staff = _dataGridViewStaff.Rows[_dataGridViewStaff.CurrentRow.Index].Cells[6].Value.ToString();
                    _adminForm.position_staff = _dataGridViewStaff.Rows[_dataGridViewStaff.CurrentRow.Index].Cells[7].Value.ToString();
                    _adminForm.phoneNumber_staff = _dataGridViewStaff.Rows[_dataGridViewStaff.CurrentRow.Index].Cells[8].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");                
            }
        }
        #endregion

        #region Метод события кнопки Добавить Сотрудника
        public void AddStaff(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateStaff(_adminForm.login_staff, _adminForm.lastName_staff, _adminForm.firstName_staff, _adminForm.patronymic_staff,
                    _adminForm.phoneNumber_staff, _adminForm.position_staff, _adminForm.sex_staff, _adminForm.dateOfBirth_staff))
                {

                    _staffService.AddStaffMember(new StaffMember
                    {
                        Login = _adminForm.login_staff,
                        NewPassword = MD5.GetHashMD5(_adminForm.password_staff),

                        LastName = _adminForm.lastName_staff,
                        FirstName = _adminForm.firstName_staff,
                        Patronymic = _adminForm.patronymic_staff,

                        PhoneNumber = _adminForm.phoneNumber_staff,
                        Position = _adminForm.position_staff,
                        Sex = _adminForm.sex_staff,
                        DateOfBirth = _adminForm.dateOfBirth_staff
                    });

                    _adminForm.id_staff = string.Empty;
                    _adminForm.login_staff = string.Empty;
                    _adminForm.password_staff = string.Empty;

                    _adminForm.lastName_staff = string.Empty;
                    _adminForm.firstName_staff = string.Empty;
                    _adminForm.patronymic_staff = string.Empty;

                    _adminForm.phoneNumber_staff = string.Empty;
                    _adminForm.position_staff = string.Empty;
                    _adminForm.sex_staff = string.Empty;
                    _adminForm.dateOfBirth_staff = string.Empty;
                }
                outputStaff(_dataGridViewStaff);
                if (_dataGridViewStaff.CurrentRow != null)
                {
                    _dataGridViewStaff.Rows[_dataGridViewStaff.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Обновить Сотрудника
        public void EditStaff(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateStaff(_adminForm.login_staff, _adminForm.lastName_staff, _adminForm.firstName_staff, _adminForm.patronymic_staff,
                    _adminForm.phoneNumber_staff, _adminForm.position_staff, _adminForm.sex_staff, _adminForm.dateOfBirth_staff))
                {
                    _staffService.UpdateStaffMember(new StaffMember
                    {
                        id_employee = _adminForm.id_staff,

                        LastName = _adminForm.lastName_staff,
                        FirstName = _adminForm.firstName_staff,
                        Patronymic = _adminForm.patronymic_staff,

                        PhoneNumber = _adminForm.phoneNumber_staff,
                        Position = _adminForm.position_staff,
                        Sex = _adminForm.sex_staff,
                        DateOfBirth = _adminForm.dateOfBirth_staff
                    });

                    _adminForm.id_staff = string.Empty;
                    _adminForm.login_staff = string.Empty;

                    _adminForm.lastName_staff = string.Empty;
                    _adminForm.firstName_staff = string.Empty;
                    _adminForm.patronymic_staff = string.Empty;

                    _adminForm.phoneNumber_staff = string.Empty;
                    _adminForm.position_staff = string.Empty;
                    _adminForm.sex_staff = string.Empty;
                    _adminForm.dateOfBirth_staff = string.Empty;
                }

                outputStaff(_dataGridViewStaff);
                if (_dataGridViewStaff.CurrentRow != null)
                {
                    _dataGridViewStaff.Rows[_dataGridViewStaff.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Удалить Сотрудника
        public void DeleteStaff(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidDeleteStaff(_adminForm.id_staff))
                {
                    _staffService.DeleteStaffMember(new StaffMember
                    {
                        id_employee = _adminForm.id_staff
                    });

                    _adminForm.id_staff = string.Empty;
                    _adminForm.login_staff = string.Empty;

                    _adminForm.lastName_staff = string.Empty;
                    _adminForm.firstName_staff = string.Empty;
                    _adminForm.patronymic_staff = string.Empty;

                    _adminForm.phoneNumber_staff = string.Empty;
                    _adminForm.position_staff = string.Empty;
                    _adminForm.sex_staff = string.Empty;
                    _adminForm.dateOfBirth_staff = string.Empty;
                }

                outputStaff(_dataGridViewStaff);
                if (_dataGridViewStaff.CurrentRow != null)
                {
                    _dataGridViewStaff.Rows[_dataGridViewStaff.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion
        #endregion

        #region Должность
        #region  Метод для заполнения DataGrid
        public void outputPosition(DataGridView dgvPosition)
        {
            dgvPosition.Rows.Clear();
            try
            {
                var result = _positionService.SelectPosition();
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        dgvPosition.Rows.Add(v.Position, v.Salary);
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
        public void dgv_Position_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridViewPosition.CurrentRow != null)
                {
                    _adminForm.positionName_position = _dataGridViewPosition.Rows[_dataGridViewPosition.CurrentRow.Index].Cells[0].Value.ToString();
                    _adminForm.salary_position = _dataGridViewPosition.Rows[_dataGridViewPosition.CurrentRow.Index].Cells[1].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion

        #region Метод события кнопки Обновить Должность
        public void UpdatePosition(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidUpdatePosition(_adminForm.positionName_position, _adminForm.salary_position))
                {
                    _positionService.UpdatePositionMember(new PositionMember
                    {
                        Position = _adminForm.positionName_position,
                        Salary = _adminForm.salary_position

                    });

                    _adminForm.positionName_position = string.Empty;
                    _adminForm.salary_position = string.Empty;

                }
                outputPosition(_dataGridViewPosition);
                if (_dataGridViewPosition.CurrentRow != null)
                {
                    _dataGridViewPosition.Rows[_dataGridViewPosition.CurrentRow.Index].Selected = false;
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
