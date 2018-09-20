using System;
using System.Windows.Forms;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Interface.Forms;

namespace Interface.Controllers
{
    public class AdminObjectController
    {
        private AdminForm _adminForm;
        private Validators _validators;

        #region Flat
        private IFlatService _flatService;
        private DataGridView _dataGridViewFlat;

        private Button _addFlatButton;
        private Button _updateFlatButton;
        private Button _deleteFlatButton;
        #endregion

        #region House
        private IHouseService _houseService;
        private DataGridView _dataGridViewHouse;

        private Button _addHouseButton;
        private Button _updateHouseButton;
        private Button _deleteHouseButton;
        #endregion

        #region Plot
        private IPlotService _plotService;
        private DataGridView _dataGridViewPlot;

        private Button _addPlotButton;
        private Button _updatePlotButton;
        private Button _deletePlotButton;
        #endregion

        #region DesiredFlat
        private IDesiredFlatService _desiredFlatService;
        private DataGridView _dataGridViewDesiredFlat;

        private Button _addDesiredFlatButton;
        private Button _updateDesiredFlatButton;
        private Button _deleteDesiredFlatButton;
        #endregion

        #region DesiredHouse
        private IDesiredHouseService _desiredHouseService;
        private DataGridView _dataGridViewDesiredHouse;

        private Button _addDesiredHouseButton;
        private Button _updateDesiredHouseButton;
        private Button _deleteDesiredHouseButton;
        #endregion

        #region DesiredPlot
        private IDesiredPlotService _desiredPlotService;
        private DataGridView _dataGridViewDesiredPlot;

        private Button _addDesiredPlotButton;
        private Button _updateDesiredPlotButton;
        private Button _deleteDesiredPlotButton;
        #endregion

        public AdminObjectController() { }

        public AdminObjectController(AdminForm adminForm, IFlatService flatService, IHouseService houseService, IPlotService plotService,
            IDesiredFlatService desiredFlatService, IDesiredHouseService desiredHouseService, IDesiredPlotService desiredPlotService, Validators validators)
        {
            _validators = validators;

            _adminForm = adminForm;
            _adminForm.Load += adminFormLoad;

            _flatService = flatService;
            _houseService = houseService;
            _plotService = plotService;

            _desiredFlatService = desiredFlatService;
            _desiredHouseService = desiredHouseService;
            _desiredPlotService = desiredPlotService;

            #region Flat
            #region Flat's buttons
            _addFlatButton = adminForm.addFlat;
            _addFlatButton.Click += AddFlat;

            _updateFlatButton = adminForm.updateFlat;
            _updateFlatButton.Click += EditFlat;

            _deleteFlatButton = adminForm.deleteFlat;
            _deleteFlatButton.Click += DeleteFlat;
            #endregion

            _dataGridViewFlat = adminForm.datagridviewFlat;
            _dataGridViewFlat.CellClick += dgv_Flat_CellClick;
            #endregion

            #region House
            #region House's buttons
            _addHouseButton = adminForm.addHouse;
            _addHouseButton.Click += AddHouse;

            _updateHouseButton = adminForm.updateHouse;
            _updateHouseButton.Click += EditHouse;

            _deleteHouseButton = adminForm.deleteHouse;
            _deleteHouseButton.Click += DeleteHouse;
            #endregion

            _dataGridViewHouse = adminForm.datagridviewHouse;
            _dataGridViewHouse.CellClick += dgv_House_CellClick;
            #endregion

            #region Plot
            #region Plot's buttons
            _addPlotButton = adminForm.addPlot;
            _addPlotButton.Click += AddPlot;

            _updatePlotButton = adminForm.updatePlot;
            _updatePlotButton.Click += EditPlot;

            _deletePlotButton = adminForm.deletePlot;
            _deletePlotButton.Click += DeletePlot;
            #endregion

            _dataGridViewPlot = adminForm.datagridviewPlot;
            _dataGridViewPlot.CellClick += dgv_Plot_CellClick;
            #endregion

            #region DesiredFlat
            #region DesiredFlat's buttons
            _addDesiredFlatButton = adminForm.addDesiredFlat;
            _addDesiredFlatButton.Click += AddDesiredFlat;

            _updateDesiredFlatButton = adminForm.updateDesiredFlat;
            _updateDesiredFlatButton.Click += EditDesiredFlat;

            _deleteDesiredFlatButton = adminForm.deleteDesiredFlat;
            _deleteDesiredFlatButton.Click += DeleteDesiredFlat;
            #endregion

            _dataGridViewDesiredFlat = adminForm.datagridviewDesiredFlat;
            _dataGridViewDesiredFlat.CellClick += dgv_DesiredFlat_CellClick;
            #endregion

            #region DesiredHouse
            #region DesiredHouse's buttons
            _addDesiredHouseButton = adminForm.addDesiredHouse;
            _addDesiredHouseButton.Click += AddDesiredHouse;

            _updateDesiredHouseButton = adminForm.updateDesiredHouse;
            _updateDesiredHouseButton.Click += EditDesiredHouse;

            _deleteDesiredHouseButton = adminForm.deleteDesiredHouse;
            _deleteDesiredHouseButton.Click += DeleteDesiredHouse;
            #endregion

            _dataGridViewDesiredHouse = adminForm.datagridviewDesiredHouse;
            _dataGridViewDesiredHouse.CellClick += dgv_DesiredHouse_CellClick;
            #endregion

            #region DesiredPlot
            #region DesiredPlot's buttons
            _addDesiredPlotButton = adminForm.addDesiredPlot;
            _addDesiredPlotButton.Click += AddDesiredPlot;

            _updateDesiredPlotButton = adminForm.updateDesiredPlot;
            _updateDesiredPlotButton.Click += EditDesiredPlot;

            _deleteDesiredPlotButton = adminForm.deleteDesiredPlot;
            _deleteDesiredPlotButton.Click += DeleteDesiredPlot;
            #endregion

            _dataGridViewDesiredPlot = adminForm.datagridviewDesiredPlot;
            _dataGridViewDesiredPlot.CellClick += dgv_DesiredPlot_CellClick;
            #endregion
        }

        #region Инициализация формы
        public void adminFormLoad(object sender, EventArgs e)
        {
            outputFlat(_dataGridViewFlat);
            outputHouse(_dataGridViewHouse);
            outputPlot(_dataGridViewPlot);

            outputDesiredFlat(_dataGridViewDesiredFlat);
            outputDesiredHouse(_dataGridViewDesiredHouse);
            outputDesiredPlot(_dataGridViewDesiredPlot);
        }
        #endregion

        #region Flat
        #region Метод для заполнения DataGrid
        public void outputFlat(DataGridView dgvFlat)
        {
            dgvFlat.Rows.Clear();
            try
            {
                var result = _flatService.SelectFlat();
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        dgvFlat.Rows.Add(v.id_object, v.id_owner, v.PostCode, v.City, v.Hood, v.Street, v.HouseNumber, v.FlatNumber, v.Type, v.Area, v.Status, v.Floor, v.Room, v.Price);
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
        public void dgv_Flat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridViewFlat.CurrentRow != null)
                {
                    _adminForm.idObject_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[0].Value.ToString();
                    _adminForm.idOwner_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[1].Value.ToString();

                    _adminForm.PostCode_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[2].Value.ToString();
                    _adminForm.City_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[3].Value.ToString();
                    _adminForm.Hood_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[4].Value.ToString();
                    _adminForm.Street_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[5].Value.ToString();
                    _adminForm.HouseNumber_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[6].Value.ToString();
                    _adminForm.FlatNumber_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[7].Value.ToString();

                    _adminForm.Type_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[8].Value.ToString();
                    _adminForm.Area_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[9].Value.ToString();
                    _adminForm.Status_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[10].Value.ToString();
                    _adminForm.Floor_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[11].Value.ToString();
                    _adminForm.Room_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[12].Value.ToString();
                    _adminForm.Price_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[13].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion

        #region Метод события кнопки Добавить Квартиру
        public void AddFlat(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateFlat(_adminForm.idOwner_flat, _adminForm.PostCode_flat, _adminForm.City_flat, _adminForm.Hood_flat,
                    _adminForm.Street_flat, _adminForm.HouseNumber_flat, _adminForm.FlatNumber_flat, _adminForm.Type_flat,
                    _adminForm.Area_flat, _adminForm.Status_flat, _adminForm.Floor_flat, _adminForm.Room_flat, _adminForm.Price_flat))
                {

                    _flatService.AddFlatMember(new FlatMember
                    {
                        id_owner = _adminForm.idOwner_flat,

                        PostCode = _adminForm.PostCode_flat,
                        City = _adminForm.City_flat,
                        Hood = _adminForm.Hood_flat,
                        Street = _adminForm.Street_flat,
                        HouseNumber = _adminForm.HouseNumber_flat,
                        FlatNumber = _adminForm.FlatNumber_flat,

                        Type = _adminForm.Type_flat,
                        Area = _adminForm.Area_flat,
                        Status = _adminForm.Status_flat,
                        Floor = _adminForm.Floor_flat,
                        Room = _adminForm.Room_flat,
                        Price = _adminForm.Price_flat
                    });

                    _adminForm.idObject_flat = string.Empty;
                    _adminForm.idOwner_flat = string.Empty;

                    _adminForm.PostCode_flat = string.Empty;
                    _adminForm.City_flat = string.Empty;
                    _adminForm.Hood_flat = string.Empty;
                    _adminForm.Street_flat = string.Empty;
                    _adminForm.HouseNumber_flat = string.Empty;
                    _adminForm.FlatNumber_flat = string.Empty;

                    _adminForm.Type_flat = string.Empty;
                    _adminForm.Area_flat = string.Empty;
                    _adminForm.Status_flat = string.Empty;
                    _adminForm.Floor_flat = string.Empty;
                    _adminForm.Room_flat = string.Empty;
                    _adminForm.Price_flat = string.Empty;
                }
                outputFlat(_dataGridViewFlat);
                if (_dataGridViewFlat.CurrentRow != null)
                {
                    _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Обновить Квартиру
        public void EditFlat(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateFlat(_adminForm.idOwner_flat, _adminForm.PostCode_flat, _adminForm.City_flat, _adminForm.Hood_flat,
                    _adminForm.Street_flat, _adminForm.HouseNumber_flat, _adminForm.FlatNumber_flat, _adminForm.Type_flat,
                    _adminForm.Area_flat, _adminForm.Status_flat, _adminForm.Floor_flat, _adminForm.Room_flat, _adminForm.Price_flat))
                {
                    _flatService.UpdateFlatMember(new FlatMember
                    {
                        id_object = _adminForm.idObject_flat,
                        id_owner = _adminForm.idOwner_flat,

                        PostCode = _adminForm.PostCode_flat,
                        City = _adminForm.City_flat,
                        Hood = _adminForm.Hood_flat,
                        Street = _adminForm.Street_flat,
                        HouseNumber = _adminForm.HouseNumber_flat,
                        FlatNumber = _adminForm.FlatNumber_flat,

                        Type = _adminForm.Type_flat,
                        Area = _adminForm.Area_flat,
                        Status = _adminForm.Status_flat,
                        Floor = _adminForm.Floor_flat,
                        Room = _adminForm.Room_flat,
                        Price = _adminForm.Price_flat
                    });

                    _adminForm.idObject_flat = string.Empty;
                    _adminForm.idOwner_flat = string.Empty;

                    _adminForm.PostCode_flat = string.Empty;
                    _adminForm.City_flat = string.Empty;
                    _adminForm.Hood_flat = string.Empty;
                    _adminForm.Street_flat = string.Empty;
                    _adminForm.HouseNumber_flat = string.Empty;
                    _adminForm.FlatNumber_flat = string.Empty;

                    _adminForm.Type_flat = string.Empty;
                    _adminForm.Area_flat = string.Empty;
                    _adminForm.Status_flat = string.Empty;
                    _adminForm.Floor_flat = string.Empty;
                    _adminForm.Room_flat = string.Empty;
                    _adminForm.Price_flat = string.Empty;
                }

                outputFlat(_dataGridViewFlat);
                if (_dataGridViewFlat.CurrentRow != null)
                {
                    _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Удалить Квартиру
        public void DeleteFlat(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidDeleteObject(_adminForm.idObject_flat))
                {
                    _flatService.DeleteFlatMember(new FlatMember
                    {
                        id_object = _adminForm.idObject_flat
                    });

                    _adminForm.idObject_flat = string.Empty;
                    _adminForm.idOwner_flat = string.Empty;

                    _adminForm.PostCode_flat = string.Empty;
                    _adminForm.City_flat = string.Empty;
                    _adminForm.Hood_flat = string.Empty;
                    _adminForm.Street_flat = string.Empty;
                    _adminForm.HouseNumber_flat = string.Empty;
                    _adminForm.FlatNumber_flat = string.Empty;

                    _adminForm.Type_flat = string.Empty;
                    _adminForm.Area_flat = string.Empty;
                    _adminForm.Status_flat = string.Empty;
                    _adminForm.Floor_flat = string.Empty;
                    _adminForm.Room_flat = string.Empty;
                    _adminForm.Price_flat = string.Empty;
                }

                outputFlat(_dataGridViewFlat);
                if (_dataGridViewFlat.CurrentRow != null)
                {
                    _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion
        #endregion

        #region House
        #region Метод для заполнения DataGrid
        public void outputHouse(DataGridView dgvHouse)
        {
            dgvHouse.Rows.Clear();
            try
            {
                var result = _houseService.SelectHouse();
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        dgvHouse.Rows.Add(v.id_object, v.id_owner, v.PostCode, v.City, v.Hood, v.Street, v.HouseNumber, v.Type, v.Area, v.Status, v.NumberOfStoreys, v.Room, v.Price);
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
        public void dgv_House_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridViewHouse.CurrentRow != null)
                {
                    _adminForm.idObject_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[0].Value.ToString();
                    _adminForm.idOwner_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[1].Value.ToString();

                    _adminForm.PostCode_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[2].Value.ToString();
                    _adminForm.City_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[3].Value.ToString();
                    _adminForm.Hood_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[4].Value.ToString();
                    _adminForm.Street_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[5].Value.ToString();
                    _adminForm.HouseNumber_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[6].Value.ToString();

                    _adminForm.Type_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[7].Value.ToString();
                    _adminForm.Area_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[8].Value.ToString();
                    _adminForm.Status_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[9].Value.ToString();
                    _adminForm.NumberOfStoreys_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[10].Value.ToString();
                    _adminForm.Room_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[11].Value.ToString();
                    _adminForm.Price_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[12].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion

        #region Метод события кнопки Добавить Дом
        public void AddHouse(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateHouse(_adminForm.idOwner_house, _adminForm.PostCode_house, _adminForm.City_house, _adminForm.Hood_house,
                    _adminForm.Street_house, _adminForm.HouseNumber_house, _adminForm.Type_house,
                    _adminForm.Area_house, _adminForm.Status_house, _adminForm.NumberOfStoreys_house, _adminForm.Room_house, _adminForm.Price_house))
                {

                    _houseService.AddHouseMember(new HouseMember
                    {
                        id_owner = _adminForm.idOwner_house,

                        PostCode = _adminForm.PostCode_house,
                        City = _adminForm.City_house,
                        Hood = _adminForm.Hood_house,
                        Street = _adminForm.Street_house,
                        HouseNumber = _adminForm.HouseNumber_house,

                        Type = _adminForm.Type_house,
                        Area = _adminForm.Area_house,
                        Status = _adminForm.Status_house,
                        NumberOfStoreys = _adminForm.NumberOfStoreys_house,
                        Room = _adminForm.Room_house,
                        Price = _adminForm.Price_house
                    });

                    _adminForm.idObject_house = string.Empty;
                    _adminForm.idOwner_house = string.Empty;

                    _adminForm.PostCode_house = string.Empty;
                    _adminForm.City_house = string.Empty;
                    _adminForm.Hood_house = string.Empty;
                    _adminForm.Street_house = string.Empty;
                    _adminForm.HouseNumber_house = string.Empty;

                    _adminForm.Type_house = string.Empty;
                    _adminForm.Area_house = string.Empty;
                    _adminForm.Status_house = string.Empty;
                    _adminForm.NumberOfStoreys_house = string.Empty;
                    _adminForm.Room_house = string.Empty;
                    _adminForm.Price_house = string.Empty;
                }
                outputHouse(_dataGridViewHouse);
                if (_dataGridViewHouse.CurrentRow != null)
                {
                    _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Обновить Дом
        public void EditHouse(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateHouse(_adminForm.idOwner_house, _adminForm.PostCode_house, _adminForm.City_house, _adminForm.Hood_house,
                    _adminForm.Street_house, _adminForm.HouseNumber_house, _adminForm.Type_house,
                    _adminForm.Area_house, _adminForm.Status_house, _adminForm.NumberOfStoreys_house, _adminForm.Room_house, _adminForm.Price_house))
                {
                    _houseService.UpdateHouseMember(new HouseMember
                    {
                        id_object = _adminForm.idObject_house,
                        id_owner = _adminForm.idOwner_house,

                        PostCode = _adminForm.PostCode_house,
                        City = _adminForm.City_house,
                        Hood = _adminForm.Hood_house,
                        Street = _adminForm.Street_house,
                        HouseNumber = _adminForm.HouseNumber_house,

                        Type = _adminForm.Type_house,
                        Area = _adminForm.Area_house,
                        Status = _adminForm.Status_house,
                        NumberOfStoreys = _adminForm.NumberOfStoreys_house,
                        Room = _adminForm.Room_house,
                        Price = _adminForm.Price_house
                    });

                    _adminForm.idObject_house = string.Empty;
                    _adminForm.idOwner_house = string.Empty;

                    _adminForm.PostCode_house = string.Empty;
                    _adminForm.City_house = string.Empty;
                    _adminForm.Hood_house = string.Empty;
                    _adminForm.Street_house = string.Empty;
                    _adminForm.HouseNumber_house = string.Empty;

                    _adminForm.Type_house = string.Empty;
                    _adminForm.Area_house = string.Empty;
                    _adminForm.Status_house = string.Empty;
                    _adminForm.NumberOfStoreys_house = string.Empty;
                    _adminForm.Room_house = string.Empty;
                    _adminForm.Price_house = string.Empty;
                }

                outputHouse(_dataGridViewHouse);
                if (_dataGridViewHouse.CurrentRow != null)
                {
                    _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Удалить Дом
        public void DeleteHouse(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidDeleteObject(_adminForm.idObject_house))
                {
                    _houseService.DeleteHouseMember(new HouseMember
                    {
                        id_object = _adminForm.idObject_house
                    });

                    _adminForm.idObject_house = string.Empty;
                    _adminForm.idOwner_house = string.Empty;

                    _adminForm.PostCode_house = string.Empty;
                    _adminForm.City_house = string.Empty;
                    _adminForm.Hood_house = string.Empty;
                    _adminForm.Street_house = string.Empty;
                    _adminForm.HouseNumber_house = string.Empty;

                    _adminForm.Type_house = string.Empty;
                    _adminForm.Area_house = string.Empty;
                    _adminForm.Status_house = string.Empty;
                    _adminForm.NumberOfStoreys_house = string.Empty;
                    _adminForm.Room_house = string.Empty;
                    _adminForm.Price_house = string.Empty;
                }

                outputHouse(_dataGridViewHouse);
                if (_dataGridViewHouse.CurrentRow != null)
                {
                    _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion
        #endregion

        #region Plot
        #region Метод для заполнения DataGrid
        public void outputPlot(DataGridView dgvPlot)
        {
            dgvPlot.Rows.Clear();
            try
            {
                var result = _plotService.SelectPlot();
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        dgvPlot.Rows.Add(v.id_object, v.id_owner, v.PostCode, v.City, v.Hood, v.Street, v.HouseNumber, v.Type, v.Area, v.Status, v.Price);
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
        public void dgv_Plot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridViewPlot.CurrentRow != null)
                {
                    _adminForm.idObject_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[0].Value.ToString();
                    _adminForm.idOwner_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[1].Value.ToString();

                    _adminForm.PostCode_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[2].Value.ToString();
                    _adminForm.City_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[3].Value.ToString();
                    _adminForm.Hood_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[4].Value.ToString();
                    _adminForm.Street_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[5].Value.ToString();
                    _adminForm.HouseNumber_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[6].Value.ToString();

                    _adminForm.Type_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[7].Value.ToString();
                    _adminForm.Area_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[8].Value.ToString();
                    _adminForm.Status_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[9].Value.ToString();
                    _adminForm.Price_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[10].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion

        #region Метод события кнопки Добавить Участок
        public void AddPlot(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdatePlot(_adminForm.idOwner_plot, _adminForm.PostCode_plot, _adminForm.City_plot,
                    _adminForm.Hood_plot, _adminForm.Street_plot, _adminForm.HouseNumber_plot,
                    _adminForm.Type_plot, _adminForm.Area_plot, _adminForm.Status_plot, _adminForm.Price_plot))
                {

                    _plotService.AddPlotMember(new PlotMember
                    {
                        id_owner = _adminForm.idOwner_plot,

                        PostCode = _adminForm.PostCode_plot,
                        City = _adminForm.City_plot,
                        Hood = _adminForm.Hood_plot,
                        Street = _adminForm.Street_plot,
                        HouseNumber = _adminForm.HouseNumber_plot,

                        Type = _adminForm.Type_plot,
                        Area = _adminForm.Area_plot,
                        Status = _adminForm.Status_plot,
                        Price = _adminForm.Price_plot
                    });

                    _adminForm.idObject_plot = string.Empty;
                    _adminForm.idOwner_plot = string.Empty;

                    _adminForm.PostCode_plot = string.Empty;
                    _adminForm.City_plot = string.Empty;
                    _adminForm.Hood_plot = string.Empty;
                    _adminForm.Street_plot = string.Empty;
                    _adminForm.HouseNumber_plot = string.Empty;

                    _adminForm.Type_plot = string.Empty;
                    _adminForm.Area_plot = string.Empty;
                    _adminForm.Status_plot = string.Empty;
                    _adminForm.Price_plot = string.Empty;
                }
                outputPlot(_dataGridViewPlot);
                if (_dataGridViewPlot.CurrentRow != null)
                {
                    _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Обновить Участок
        public void EditPlot(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdatePlot(_adminForm.idOwner_plot, _adminForm.PostCode_plot, _adminForm.City_plot,
                    _adminForm.Hood_plot, _adminForm.Street_plot, _adminForm.HouseNumber_plot,
                    _adminForm.Type_plot, _adminForm.Area_plot, _adminForm.Status_plot, _adminForm.Price_plot))
                {
                    _plotService.UpdatePlotMember(new PlotMember
                    {
                        id_object = _adminForm.idObject_plot,
                        id_owner = _adminForm.idOwner_plot,

                        PostCode = _adminForm.PostCode_plot,
                        City = _adminForm.City_plot,
                        Hood = _adminForm.Hood_plot,
                        Street = _adminForm.Street_plot,
                        HouseNumber = _adminForm.HouseNumber_plot,

                        Type = _adminForm.Type_plot,
                        Area = _adminForm.Area_plot,
                        Status = _adminForm.Status_plot,
                        Price = _adminForm.Price_plot
                    });

                    _adminForm.idObject_plot = string.Empty;
                    _adminForm.idOwner_plot = string.Empty;

                    _adminForm.PostCode_plot = string.Empty;
                    _adminForm.City_plot = string.Empty;
                    _adminForm.Hood_plot = string.Empty;
                    _adminForm.Street_plot = string.Empty;
                    _adminForm.HouseNumber_plot = string.Empty;

                    _adminForm.Type_plot = string.Empty;
                    _adminForm.Area_plot = string.Empty;
                    _adminForm.Status_plot = string.Empty;
                    _adminForm.Price_plot = string.Empty;
                }

                outputPlot(_dataGridViewPlot);
                if (_dataGridViewPlot.CurrentRow != null)
                {
                    _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Удалить Участок
        public void DeletePlot(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidDeleteObject(_adminForm.idObject_plot))
                {
                    _plotService.DeletePlotMember(new PlotMember
                    {
                        id_object = _adminForm.idObject_plot
                    });

                    _adminForm.idObject_plot = string.Empty;
                    _adminForm.idOwner_plot = string.Empty;

                    _adminForm.PostCode_plot = string.Empty;
                    _adminForm.City_plot = string.Empty;
                    _adminForm.Hood_plot = string.Empty;
                    _adminForm.Street_plot = string.Empty;
                    _adminForm.HouseNumber_plot = string.Empty;

                    _adminForm.Type_plot = string.Empty;
                    _adminForm.Area_plot = string.Empty;
                    _adminForm.Status_plot = string.Empty;
                    _adminForm.Price_plot = string.Empty;
                }

                outputPlot(_dataGridViewPlot);
                if (_dataGridViewPlot.CurrentRow != null)
                {
                    _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion
        #endregion

        #region DesiredFlat
        #region Метод для заполнения DataGrid
        public void outputDesiredFlat(DataGridView dgvDesiredFlat)
        {
            dgvDesiredFlat.Rows.Clear();
            try
            {
                var result = _desiredFlatService.SelectDesiredFlat();
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        dgvDesiredFlat.Rows.Add(v.id_desiredObject, v.id_client, v.City, v.Hood, v.Street, v.Type, v.Area, v.Status, v.Floor, v.Room, v.Price);
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
        public void dgv_DesiredFlat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridViewDesiredFlat.CurrentRow != null)
                {
                    _adminForm.idDesiredObject_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[0].Value.ToString();
                    _adminForm.idClient_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[1].Value.ToString();

                    _adminForm.City_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[2].Value.ToString();
                    _adminForm.Hood_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[3].Value.ToString();
                    _adminForm.Street_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[4].Value.ToString();
                    
                    _adminForm.Type_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[5].Value.ToString();
                    _adminForm.Area_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[6].Value.ToString();
                    _adminForm.Status_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[7].Value.ToString();
                    _adminForm.Floor_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[8].Value.ToString();
                    _adminForm.Room_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[9].Value.ToString();
                    _adminForm.Price_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[10].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion

        #region Метод события кнопки Добавить Искомую Квартиру
        public void AddDesiredFlat(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateDesiredFlat(_adminForm.idClient_desiredFlat, _adminForm.City_desiredFlat, _adminForm.Hood_desiredFlat,
                    _adminForm.Street_desiredFlat, _adminForm.Type_desiredFlat, _adminForm.Area_desiredFlat, _adminForm.Status_desiredFlat,
                    _adminForm.Floor_desiredFlat, _adminForm.Room_desiredFlat, _adminForm.Price_desiredFlat))
                {

                    _desiredFlatService.AddDesiredFlatMember(new DesiredFlatMember
                    {
                        id_client = _adminForm.idClient_desiredFlat,

                        City = _adminForm.City_desiredFlat,
                        Hood = _adminForm.Hood_desiredFlat,
                        Street = _adminForm.Street_desiredFlat,

                        Type = _adminForm.Type_desiredFlat,
                        Area = _adminForm.Area_desiredFlat,
                        Status = _adminForm.Status_desiredFlat,
                        Floor = _adminForm.Floor_desiredFlat,
                        Room = _adminForm.Room_desiredFlat,
                        Price = _adminForm.Price_desiredFlat
                    });

                    _adminForm.idDesiredObject_desiredFlat = string.Empty;
                    _adminForm.idClient_desiredFlat = string.Empty;
                    
                    _adminForm.Hood_desiredFlat = string.Empty;
                    _adminForm.Street_desiredFlat = string.Empty;
                    
                    _adminForm.Area_desiredFlat = string.Empty;
                    _adminForm.Status_desiredFlat = string.Empty;
                    _adminForm.Floor_desiredFlat = string.Empty;
                    _adminForm.Room_desiredFlat = string.Empty;
                    _adminForm.Price_desiredFlat = string.Empty;
                }
                outputDesiredFlat(_dataGridViewDesiredFlat);
                if (_dataGridViewDesiredFlat.CurrentRow != null)
                {
                    _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Обновить Искомую Квартиру
        public void EditDesiredFlat(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateDesiredFlat(_adminForm.idClient_desiredFlat, _adminForm.City_desiredFlat, _adminForm.Hood_desiredFlat,
                    _adminForm.Street_desiredFlat, _adminForm.Type_desiredFlat, _adminForm.Area_desiredFlat, _adminForm.Status_desiredFlat,
                    _adminForm.Floor_desiredFlat, _adminForm.Room_desiredFlat, _adminForm.Price_desiredFlat))
                {
                    _desiredFlatService.UpdateDesiredFlatMember(new DesiredFlatMember
                    {
                        id_desiredObject = _adminForm.idObject_flat,
                        id_client = _adminForm.idClient_desiredFlat,

                        City = _adminForm.City_desiredFlat,
                        Hood = _adminForm.Hood_desiredFlat,
                        Street = _adminForm.Street_desiredFlat,

                        Type = _adminForm.Type_desiredFlat,
                        Area = _adminForm.Area_desiredFlat,
                        Status = _adminForm.Status_desiredFlat,
                        Floor = _adminForm.Floor_desiredFlat,
                        Room = _adminForm.Room_desiredFlat,
                        Price = _adminForm.Price_desiredFlat
                    });

                    _adminForm.idDesiredObject_desiredFlat = string.Empty;
                    _adminForm.idClient_desiredFlat = string.Empty;

                    _adminForm.City_desiredFlat = string.Empty;
                    _adminForm.Hood_desiredFlat = string.Empty;
                    _adminForm.Street_desiredFlat = string.Empty;

                    _adminForm.Type_desiredFlat = string.Empty;
                    _adminForm.Area_desiredFlat = string.Empty;
                    _adminForm.Status_desiredFlat = string.Empty;
                    _adminForm.Floor_desiredFlat = string.Empty;
                    _adminForm.Room_desiredFlat = string.Empty;
                    _adminForm.Price_desiredFlat = string.Empty;
                }

                outputDesiredFlat(_dataGridViewDesiredFlat);
                if (_dataGridViewDesiredFlat.CurrentRow != null)
                {
                    _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Удалить Искомую Квартиру
        public void DeleteDesiredFlat(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidDeleteObject(_adminForm.idDesiredObject_desiredFlat))
                {
                    _desiredFlatService.DeleteDesiredFlatMember(new DesiredFlatMember
                    {
                        id_desiredObject = _adminForm.idDesiredObject_desiredFlat
                    });

                    _adminForm.idDesiredObject_desiredFlat = string.Empty;
                    _adminForm.idClient_desiredFlat = string.Empty;

                    _adminForm.City_desiredFlat = string.Empty;
                    _adminForm.Hood_desiredFlat = string.Empty;
                    _adminForm.Street_desiredFlat = string.Empty;

                    _adminForm.Type_desiredFlat = string.Empty;
                    _adminForm.Area_desiredFlat = string.Empty;
                    _adminForm.Status_desiredFlat = string.Empty;
                    _adminForm.Floor_desiredFlat = string.Empty;
                    _adminForm.Room_desiredFlat = string.Empty;
                    _adminForm.Price_desiredFlat = string.Empty;
                }

                outputDesiredFlat(_dataGridViewDesiredFlat);
                if (_dataGridViewDesiredFlat.CurrentRow != null)
                {
                    _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion
        #endregion

        #region DesiredHouse
        #region Метод для заполнения DataGrid
        public void outputDesiredHouse(DataGridView dgvDesiredHouse)
        {
            dgvDesiredHouse.Rows.Clear();
            try
            {
                var result = _desiredHouseService.SelectDesiredHouse();
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        dgvDesiredHouse.Rows.Add(v.id_desiredObject, v.id_client, v.City, v.Hood, v.Street, v.Type, v.Area, v.Status, v.NumberOfStoreys, v.Room, v.Price);
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
        public void dgv_DesiredHouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridViewDesiredHouse.CurrentRow != null)
                {
                    _adminForm.idDesiredObject_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[0].Value.ToString();
                    _adminForm.idClient_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[1].Value.ToString();

                    _adminForm.City_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[2].Value.ToString();
                    _adminForm.Hood_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[3].Value.ToString();
                    _adminForm.Street_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[4].Value.ToString();

                    _adminForm.Type_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[5].Value.ToString();
                    _adminForm.Area_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[6].Value.ToString();
                    _adminForm.Status_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[7].Value.ToString();
                    _adminForm.NumberOfStoreys_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[8].Value.ToString();
                    _adminForm.Room_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[9].Value.ToString();
                    _adminForm.Price_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[10].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion

        #region Метод события кнопки Добавить Искомый Дом
        public void AddDesiredHouse(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateDesiredHouse(_adminForm.idClient_desiredHouse, _adminForm.City_desiredHouse, _adminForm.Hood_desiredHouse,
                    _adminForm.Street_desiredHouse, _adminForm.Type_desiredHouse, _adminForm.Area_desiredHouse, _adminForm.Status_desiredHouse,
                    _adminForm.NumberOfStoreys_desiredHouse, _adminForm.Room_desiredHouse, _adminForm.Price_desiredHouse))
                {

                    _desiredHouseService.AddDesiredHouseMember(new DesiredHouseMember
                    {
                        id_client = _adminForm.idClient_desiredHouse,

                        City = _adminForm.City_desiredHouse,
                        Hood = _adminForm.Hood_desiredHouse,
                        Street = _adminForm.Street_desiredHouse,

                        Type = _adminForm.Type_desiredHouse,
                        Area = _adminForm.Area_desiredHouse,
                        Status = _adminForm.Status_desiredHouse,
                        NumberOfStoreys = _adminForm.NumberOfStoreys_desiredHouse,
                        Room = _adminForm.Room_desiredHouse,
                        Price = _adminForm.Price_desiredHouse
                    });

                    _adminForm.idDesiredObject_desiredHouse = string.Empty;
                    _adminForm.idClient_desiredHouse = string.Empty;

                    _adminForm.City_desiredHouse = string.Empty;
                    _adminForm.Hood_desiredHouse = string.Empty;
                    _adminForm.Street_desiredHouse = string.Empty;

                    _adminForm.Type_desiredHouse = string.Empty;
                    _adminForm.Area_desiredHouse = string.Empty;
                    _adminForm.Status_desiredHouse = string.Empty;
                    _adminForm.NumberOfStoreys_desiredHouse = string.Empty;
                    _adminForm.Room_desiredHouse = string.Empty;
                    _adminForm.Price_desiredHouse = string.Empty;
                }
                outputDesiredHouse(_dataGridViewDesiredHouse);
                if (_dataGridViewDesiredHouse.CurrentRow != null)
                {
                    _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Обновить Искомый Дом
        public void EditDesiredHouse(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateDesiredHouse(_adminForm.idClient_desiredHouse, _adminForm.City_desiredHouse, _adminForm.Hood_desiredHouse,
                    _adminForm.Street_desiredHouse, _adminForm.Type_desiredHouse, _adminForm.Area_desiredHouse, _adminForm.Status_desiredHouse,
                    _adminForm.NumberOfStoreys_desiredHouse, _adminForm.Room_desiredHouse, _adminForm.Price_desiredHouse))
                {
                    _desiredHouseService.UpdateDesiredHouseMember(new DesiredHouseMember
                    {
                        id_desiredObject = _adminForm.idDesiredObject_desiredHouse,
                        id_client = _adminForm.idClient_desiredHouse,

                        City = _adminForm.City_desiredHouse,
                        Hood = _adminForm.Hood_desiredHouse,
                        Street = _adminForm.Street_desiredHouse,

                        Type = _adminForm.Type_desiredHouse,
                        Area = _adminForm.Area_desiredHouse,
                        Status = _adminForm.Status_desiredHouse,
                        NumberOfStoreys = _adminForm.NumberOfStoreys_desiredHouse,
                        Room = _adminForm.Room_desiredHouse,
                        Price = _adminForm.Price_desiredHouse
                    });

                    _adminForm.idDesiredObject_desiredHouse = string.Empty;
                    _adminForm.idClient_desiredHouse = string.Empty;

                    _adminForm.City_desiredHouse = string.Empty;
                    _adminForm.Hood_desiredHouse = string.Empty;
                    _adminForm.Street_desiredHouse = string.Empty;

                    _adminForm.Type_desiredHouse = string.Empty;
                    _adminForm.Area_desiredHouse = string.Empty;
                    _adminForm.Status_desiredHouse = string.Empty;
                    _adminForm.NumberOfStoreys_desiredHouse = string.Empty;
                    _adminForm.Room_desiredHouse = string.Empty;
                    _adminForm.Price_desiredHouse = string.Empty;
                }

                outputDesiredHouse(_dataGridViewDesiredHouse);
                if (_dataGridViewDesiredHouse.CurrentRow != null)
                {
                    _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Удалить Искомый Дом
        public void DeleteDesiredHouse(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidDeleteObject(_adminForm.idDesiredObject_desiredHouse))
                {
                    _desiredHouseService.DeleteDesiredHouseMember(new DesiredHouseMember
                    {
                        id_desiredObject = _adminForm.idDesiredObject_desiredHouse
                    });

                    _adminForm.idDesiredObject_desiredHouse = string.Empty;
                    _adminForm.idClient_desiredHouse = string.Empty;

                    _adminForm.City_desiredHouse = string.Empty;
                    _adminForm.Hood_desiredHouse = string.Empty;
                    _adminForm.Street_desiredHouse = string.Empty;

                    _adminForm.Type_desiredHouse = string.Empty;
                    _adminForm.Area_desiredHouse = string.Empty;
                    _adminForm.Status_desiredHouse = string.Empty;
                    _adminForm.NumberOfStoreys_desiredHouse = string.Empty;
                    _adminForm.Room_desiredHouse = string.Empty;
                    _adminForm.Price_desiredHouse = string.Empty;
                }

                outputDesiredHouse(_dataGridViewDesiredHouse);
                if (_dataGridViewDesiredHouse.CurrentRow != null)
                {
                    _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion
        #endregion

        #region DesiredPlot
        #region Метод для заполнения DataGrid
        public void outputDesiredPlot(DataGridView dgvDesiredPlot)
        {
            dgvDesiredPlot.Rows.Clear();
            try
            {
                var result = _desiredPlotService.SelectDesiredPlot();
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        dgvDesiredPlot.Rows.Add(v.id_desiredObject, v.id_client, v.City, v.Hood, v.Street, v.Type, v.Area, v.Status, v.Price);
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
        public void dgv_DesiredPlot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridViewDesiredPlot.CurrentRow != null)
                {
                    _adminForm.idDesiredObject_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[0].Value.ToString();
                    _adminForm.idClient_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[1].Value.ToString();

                    _adminForm.City_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[2].Value.ToString();
                    _adminForm.Hood_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[3].Value.ToString();
                    _adminForm.Street_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[4].Value.ToString();

                    _adminForm.Type_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[5].Value.ToString();
                    _adminForm.Area_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[6].Value.ToString();
                    _adminForm.Status_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[7].Value.ToString();
                    _adminForm.Price_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[8].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion

        #region Метод события кнопки Добавить Искомый Участок
        public void AddDesiredPlot(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateDesiredPlot(_adminForm.idClient_desiredPlot, _adminForm.City_desiredPlot,
                    _adminForm.Hood_desiredPlot, _adminForm.Street_desiredPlot, _adminForm.Type_desiredPlot,
                    _adminForm.Area_desiredPlot, _adminForm.Status_desiredPlot, _adminForm.Price_desiredPlot))
                {

                    _desiredPlotService.AddDesiredPlotMember(new DesiredPlotMember
                    {
                        id_client = _adminForm.idClient_desiredPlot,

                        City = _adminForm.City_desiredPlot,
                        Hood = _adminForm.Hood_desiredPlot,
                        Street = _adminForm.Street_desiredPlot,

                        Type = _adminForm.Type_desiredPlot,
                        Area = _adminForm.Area_desiredPlot,
                        Status = _adminForm.Status_desiredPlot,
                        Price = _adminForm.Price_desiredPlot
                    });

                    _adminForm.idDesiredObject_desiredPlot = string.Empty;
                    _adminForm.idClient_desiredPlot = string.Empty;

                    _adminForm.City_desiredPlot = string.Empty;
                    _adminForm.Hood_desiredPlot = string.Empty;
                    _adminForm.Street_desiredPlot = string.Empty;

                    _adminForm.Type_desiredPlot = string.Empty;
                    _adminForm.Area_desiredPlot = string.Empty;
                    _adminForm.Status_desiredPlot = string.Empty;
                    _adminForm.Price_desiredPlot = string.Empty;
                }
                outputDesiredPlot(_dataGridViewDesiredPlot);
                if (_dataGridViewDesiredPlot.CurrentRow != null)
                {
                    _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Обновить Искомый Участок
        public void EditDesiredPlot(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddUpdateDesiredPlot(_adminForm.idClient_desiredPlot, _adminForm.City_desiredPlot,
                    _adminForm.Hood_desiredPlot, _adminForm.Street_desiredPlot, _adminForm.Type_desiredPlot,
                    _adminForm.Area_desiredPlot, _adminForm.Status_desiredPlot, _adminForm.Price_desiredPlot))
                {
                    _desiredPlotService.UpdateDesiredPlotMember(new DesiredPlotMember
                    {
                        id_desiredObject = _adminForm.idDesiredObject_desiredPlot,
                        id_client = _adminForm.idClient_desiredPlot,

                        City = _adminForm.City_desiredPlot,
                        Hood = _adminForm.Hood_desiredPlot,
                        Street = _adminForm.Street_desiredPlot,

                        Type = _adminForm.Type_desiredPlot,
                        Area = _adminForm.Area_desiredPlot,
                        Status = _adminForm.Status_desiredPlot,
                        Price = _adminForm.Price_desiredPlot
                    });

                    _adminForm.idDesiredObject_desiredPlot = string.Empty;
                    _adminForm.idClient_desiredPlot = string.Empty;

                    _adminForm.City_desiredPlot = string.Empty;
                    _adminForm.Hood_desiredPlot = string.Empty;
                    _adminForm.Street_desiredPlot = string.Empty;

                    _adminForm.Type_desiredPlot = string.Empty;
                    _adminForm.Area_desiredPlot = string.Empty;
                    _adminForm.Status_desiredPlot = string.Empty;
                    _adminForm.Price_desiredPlot = string.Empty;
                }

                outputDesiredPlot(_dataGridViewDesiredPlot);
                if (_dataGridViewDesiredPlot.CurrentRow != null)
                {
                    _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        #endregion

        #region  Метод события кнопки Удалить Искомый Участок
        public void DeleteDesiredPlot(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidDeleteObject(_adminForm.idDesiredObject_desiredPlot))
                {
                    _desiredPlotService.DeleteDesiredPlotMember(new DesiredPlotMember
                    {
                        id_desiredObject = _adminForm.idDesiredObject_desiredPlot
                    });

                    _adminForm.idDesiredObject_desiredPlot = string.Empty;
                    _adminForm.idClient_desiredPlot = string.Empty;

                    _adminForm.City_desiredPlot = string.Empty;
                    _adminForm.Hood_desiredPlot = string.Empty;
                    _adminForm.Street_desiredPlot = string.Empty;

                    _adminForm.Type_desiredPlot = string.Empty;
                    _adminForm.Area_desiredPlot = string.Empty;
                    _adminForm.Status_desiredPlot = string.Empty;
                    _adminForm.Price_desiredPlot = string.Empty;
                }

                outputDesiredPlot(_dataGridViewDesiredPlot);
                if (_dataGridViewDesiredPlot.CurrentRow != null)
                {
                    _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Selected = false;
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
