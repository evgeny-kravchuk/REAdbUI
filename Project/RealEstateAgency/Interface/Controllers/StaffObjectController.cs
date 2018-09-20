using System;
using System.Windows.Forms;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Interface.Forms;

namespace Interface.Controllers
{
    public class StaffObjectController
    {
        private StaffForm _staffForm;
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

        public StaffObjectController() { }

        public StaffObjectController(StaffForm staffForm, IFlatService flatService, IHouseService houseService, IPlotService plotService,
            IDesiredFlatService desiredFlatService, IDesiredHouseService desiredHouseService, IDesiredPlotService desiredPlotService, Validators validators)
        {
            _validators = validators;

            _staffForm = staffForm;
            _staffForm.Load += staffFormLoad;

            _flatService = flatService;
            _houseService = houseService;
            _plotService = plotService;

            _desiredFlatService = desiredFlatService;
            _desiredHouseService = desiredHouseService;
            _desiredPlotService = desiredPlotService;

            #region Flat
            #region Flat's buttons
            _addFlatButton = staffForm.addFlat;
            _addFlatButton.Click += AddFlat;

            _updateFlatButton = staffForm.updateFlat;
            _updateFlatButton.Click += EditFlat;

            _deleteFlatButton = staffForm.deleteFlat;
            _deleteFlatButton.Click += DeleteFlat;
            #endregion

            _dataGridViewFlat = staffForm.datagridviewFlat;
            _dataGridViewFlat.CellClick += dgv_Flat_CellClick;
            #endregion

            #region House
            #region House's buttons
            _addHouseButton = staffForm.addHouse;
            _addHouseButton.Click += AddHouse;

            _updateHouseButton = staffForm.updateHouse;
            _updateHouseButton.Click += EditHouse;

            _deleteHouseButton = staffForm.deleteHouse;
            _deleteHouseButton.Click += DeleteHouse;
            #endregion

            _dataGridViewHouse = staffForm.datagridviewHouse;
            _dataGridViewHouse.CellClick += dgv_House_CellClick;
            #endregion

            #region Plot
            #region Plot's buttons
            _addPlotButton = staffForm.addPlot;
            _addPlotButton.Click += AddPlot;

            _updatePlotButton = staffForm.updatePlot;
            _updatePlotButton.Click += EditPlot;

            _deletePlotButton = staffForm.deletePlot;
            _deletePlotButton.Click += DeletePlot;
            #endregion

            _dataGridViewPlot = staffForm.datagridviewPlot;
            _dataGridViewPlot.CellClick += dgv_Plot_CellClick;
            #endregion

            #region DesiredFlat
            #region DesiredFlat's buttons
            _addDesiredFlatButton = staffForm.addDesiredFlat;
            _addDesiredFlatButton.Click += AddDesiredFlat;

            _updateDesiredFlatButton = staffForm.updateDesiredFlat;
            _updateDesiredFlatButton.Click += EditDesiredFlat;

            _deleteDesiredFlatButton = staffForm.deleteDesiredFlat;
            _deleteDesiredFlatButton.Click += DeleteDesiredFlat;
            #endregion

            _dataGridViewDesiredFlat = staffForm.datagridviewDesiredFlat;
            _dataGridViewDesiredFlat.CellClick += dgv_DesiredFlat_CellClick;
            #endregion

            #region DesiredHouse
            #region DesiredHouse's buttons
            _addDesiredHouseButton = staffForm.addDesiredHouse;
            _addDesiredHouseButton.Click += AddDesiredHouse;

            _updateDesiredHouseButton = staffForm.updateDesiredHouse;
            _updateDesiredHouseButton.Click += EditDesiredHouse;

            _deleteDesiredHouseButton = staffForm.deleteDesiredHouse;
            _deleteDesiredHouseButton.Click += DeleteDesiredHouse;
            #endregion

            _dataGridViewDesiredHouse = staffForm.datagridviewDesiredHouse;
            _dataGridViewDesiredHouse.CellClick += dgv_DesiredHouse_CellClick;
            #endregion

            #region DesiredPlot
            #region DesiredPlot's buttons
            _addDesiredPlotButton = staffForm.addDesiredPlot;
            _addDesiredPlotButton.Click += AddDesiredPlot;

            _updateDesiredPlotButton = staffForm.updateDesiredPlot;
            _updateDesiredPlotButton.Click += EditDesiredPlot;

            _deleteDesiredPlotButton = staffForm.deleteDesiredPlot;
            _deleteDesiredPlotButton.Click += DeleteDesiredPlot;
            #endregion

            _dataGridViewDesiredPlot = staffForm.datagridviewDesiredPlot;
            _dataGridViewDesiredPlot.CellClick += dgv_DesiredPlot_CellClick;
            #endregion
        }

        #region Инициализация формы
        public void staffFormLoad(object sender, EventArgs e)
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
                    _staffForm.idObject_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[0].Value.ToString();
                    _staffForm.idOwner_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[1].Value.ToString();

                    _staffForm.PostCode_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[2].Value.ToString();
                    _staffForm.City_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[3].Value.ToString();
                    _staffForm.Hood_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[4].Value.ToString();
                    _staffForm.Street_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[5].Value.ToString();
                    _staffForm.HouseNumber_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[6].Value.ToString();
                    _staffForm.FlatNumber_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[7].Value.ToString();

                    _staffForm.Type_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[8].Value.ToString();
                    _staffForm.Area_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[9].Value.ToString();
                    _staffForm.Status_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[10].Value.ToString();
                    _staffForm.Floor_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[11].Value.ToString();
                    _staffForm.Room_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[12].Value.ToString();
                    _staffForm.Price_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[13].Value.ToString();
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
                if (_validators.ValidAddUpdateFlat(_staffForm.idOwner_flat, _staffForm.PostCode_flat, _staffForm.City_flat, _staffForm.Hood_flat,
                    _staffForm.Street_flat, _staffForm.HouseNumber_flat, _staffForm.FlatNumber_flat, _staffForm.Type_flat,
                    _staffForm.Area_flat, _staffForm.Status_flat, _staffForm.Floor_flat, _staffForm.Room_flat, _staffForm.Price_flat))
                {

                    _flatService.AddFlatMember(new FlatMember
                    {
                        id_owner = _staffForm.idOwner_flat,

                        PostCode = _staffForm.PostCode_flat,
                        City = _staffForm.City_flat,
                        Hood = _staffForm.Hood_flat,
                        Street = _staffForm.Street_flat,
                        HouseNumber = _staffForm.HouseNumber_flat,
                        FlatNumber = _staffForm.FlatNumber_flat,

                        Type = _staffForm.Type_flat,
                        Area = _staffForm.Area_flat,
                        Status = _staffForm.Status_flat,
                        Floor = _staffForm.Floor_flat,
                        Room = _staffForm.Room_flat,
                        Price = _staffForm.Price_flat
                    });

                    _staffForm.idObject_flat = string.Empty;
                    _staffForm.idOwner_flat = string.Empty;

                    _staffForm.PostCode_flat = string.Empty;
                    _staffForm.Hood_flat = string.Empty;
                    _staffForm.Street_flat = string.Empty;
                    _staffForm.HouseNumber_flat = string.Empty;
                    _staffForm.FlatNumber_flat = string.Empty;
                    
                    _staffForm.Area_flat = string.Empty;
                    _staffForm.Status_flat = string.Empty;
                    _staffForm.Floor_flat = string.Empty;
                    _staffForm.Room_flat = string.Empty;
                    _staffForm.Price_flat = string.Empty;
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
                if (_validators.ValidAddUpdateFlat(_staffForm.idOwner_flat, _staffForm.PostCode_flat, _staffForm.City_flat, _staffForm.Hood_flat,
                    _staffForm.Street_flat, _staffForm.HouseNumber_flat, _staffForm.FlatNumber_flat, _staffForm.Type_flat,
                    _staffForm.Area_flat, _staffForm.Status_flat, _staffForm.Floor_flat, _staffForm.Room_flat, _staffForm.Price_flat))
                {
                    _flatService.UpdateFlatMember(new FlatMember
                    {
                        id_object = _staffForm.idObject_flat,
                        id_owner = _staffForm.idOwner_flat,

                        PostCode = _staffForm.PostCode_flat,
                        City = _staffForm.City_flat,
                        Hood = _staffForm.Hood_flat,
                        Street = _staffForm.Street_flat,
                        HouseNumber = _staffForm.HouseNumber_flat,
                        FlatNumber = _staffForm.FlatNumber_flat,

                        Type = _staffForm.Type_flat,
                        Area = _staffForm.Area_flat,
                        Status = _staffForm.Status_flat,
                        Floor = _staffForm.Floor_flat,
                        Room = _staffForm.Room_flat,
                        Price = _staffForm.Price_flat
                    });

                    _staffForm.idObject_flat = string.Empty;
                    _staffForm.idOwner_flat = string.Empty;

                    _staffForm.PostCode_flat = string.Empty;
                    _staffForm.Hood_flat = string.Empty;
                    _staffForm.Street_flat = string.Empty;
                    _staffForm.HouseNumber_flat = string.Empty;
                    _staffForm.FlatNumber_flat = string.Empty;
                    
                    _staffForm.Area_flat = string.Empty;
                    _staffForm.Status_flat = string.Empty;
                    _staffForm.Floor_flat = string.Empty;
                    _staffForm.Room_flat = string.Empty;
                    _staffForm.Price_flat = string.Empty;
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
                if (_validators.ValidDeleteObject(_staffForm.idObject_flat))
                {
                    _flatService.DeleteFlatMember(new FlatMember
                    {
                        id_object = _staffForm.idObject_flat
                    });

                    _staffForm.idObject_flat = string.Empty;
                    _staffForm.idOwner_flat = string.Empty;

                    _staffForm.PostCode_flat = string.Empty;
                    _staffForm.Hood_flat = string.Empty;
                    _staffForm.Street_flat = string.Empty;
                    _staffForm.HouseNumber_flat = string.Empty;
                    _staffForm.FlatNumber_flat = string.Empty;
                    
                    _staffForm.Area_flat = string.Empty;
                    _staffForm.Status_flat = string.Empty;
                    _staffForm.Floor_flat = string.Empty;
                    _staffForm.Room_flat = string.Empty;
                    _staffForm.Price_flat = string.Empty;
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
                    _staffForm.idObject_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[0].Value.ToString();
                    _staffForm.idOwner_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[1].Value.ToString();

                    _staffForm.PostCode_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[2].Value.ToString();
                    _staffForm.City_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[3].Value.ToString();
                    _staffForm.Hood_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[4].Value.ToString();
                    _staffForm.Street_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[5].Value.ToString();
                    _staffForm.HouseNumber_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[6].Value.ToString();

                    _staffForm.Type_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[7].Value.ToString();
                    _staffForm.Area_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[8].Value.ToString();
                    _staffForm.Status_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[9].Value.ToString();
                    _staffForm.NumberOfStoreys_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[10].Value.ToString();
                    _staffForm.Room_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[11].Value.ToString();
                    _staffForm.Price_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[12].Value.ToString();
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
                if (_validators.ValidAddUpdateHouse(_staffForm.idOwner_house, _staffForm.PostCode_house, _staffForm.City_house, _staffForm.Hood_house,
                    _staffForm.Street_house, _staffForm.HouseNumber_house, _staffForm.Type_house, _staffForm.Area_house,
                    _staffForm.Status_house, _staffForm.NumberOfStoreys_house, _staffForm.Room_house, _staffForm.Price_house))
                {

                    _houseService.AddHouseMember(new HouseMember
                    {
                        id_owner = _staffForm.idOwner_house,

                        PostCode = _staffForm.PostCode_house,
                        City = _staffForm.City_house,
                        Hood = _staffForm.Hood_house,
                        Street = _staffForm.Street_house,
                        HouseNumber = _staffForm.HouseNumber_house,

                        Type = _staffForm.Type_house,
                        Area = _staffForm.Area_house,
                        Status = _staffForm.Status_house,
                        NumberOfStoreys = _staffForm.NumberOfStoreys_house,
                        Room = _staffForm.Room_house,
                        Price = _staffForm.Price_house
                    });

                    _staffForm.idObject_house = string.Empty;
                    _staffForm.idOwner_house = string.Empty;

                    _staffForm.PostCode_house = string.Empty;
                    _staffForm.Hood_house = string.Empty;
                    _staffForm.Street_house = string.Empty;
                    _staffForm.HouseNumber_house = string.Empty;
                    
                    _staffForm.Area_house = string.Empty;
                    _staffForm.Status_house = string.Empty;
                    _staffForm.NumberOfStoreys_house = string.Empty;
                    _staffForm.Room_house = string.Empty;
                    _staffForm.Price_house = string.Empty;
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
                if (_validators.ValidAddUpdateHouse(_staffForm.idOwner_house, _staffForm.PostCode_house, _staffForm.City_house,
                    _staffForm.Hood_house, _staffForm.Street_house, _staffForm.HouseNumber_house, _staffForm.Type_house, _staffForm.Area_house,
                    _staffForm.Status_house, _staffForm.NumberOfStoreys_house, _staffForm.Room_house, _staffForm.Price_house))
                {
                    _houseService.UpdateHouseMember(new HouseMember
                    {
                        id_object = _staffForm.idObject_house,
                        id_owner = _staffForm.idOwner_house,

                        PostCode = _staffForm.PostCode_house,
                        City = _staffForm.City_house,
                        Hood = _staffForm.Hood_house,
                        Street = _staffForm.Street_house,
                        HouseNumber = _staffForm.HouseNumber_house,

                        Type = _staffForm.Type_house,
                        Area = _staffForm.Area_house,
                        Status = _staffForm.Status_house,
                        NumberOfStoreys = _staffForm.NumberOfStoreys_house,
                        Room = _staffForm.Room_house,
                        Price = _staffForm.Price_house
                    });

                    _staffForm.idObject_house = string.Empty;
                    _staffForm.idOwner_house = string.Empty;

                    _staffForm.PostCode_house = string.Empty;
                    _staffForm.Hood_house = string.Empty;
                    _staffForm.Street_house = string.Empty;
                    _staffForm.HouseNumber_house = string.Empty;
                    
                    _staffForm.Area_house = string.Empty;
                    _staffForm.Status_house = string.Empty;
                    _staffForm.NumberOfStoreys_house = string.Empty;
                    _staffForm.Room_house = string.Empty;
                    _staffForm.Price_house = string.Empty;
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
                if (_validators.ValidDeleteObject(_staffForm.idObject_house))
                {
                    _houseService.DeleteHouseMember(new HouseMember
                    {
                        id_object = _staffForm.idObject_house
                    });

                    _staffForm.idObject_house = string.Empty;
                    _staffForm.idOwner_house = string.Empty;

                    _staffForm.PostCode_house = string.Empty;
                    _staffForm.Hood_house = string.Empty;
                    _staffForm.Street_house = string.Empty;
                    _staffForm.HouseNumber_house = string.Empty;
                    
                    _staffForm.Area_house = string.Empty;
                    _staffForm.Status_house = string.Empty;
                    _staffForm.NumberOfStoreys_house = string.Empty;
                    _staffForm.Room_house = string.Empty;
                    _staffForm.Price_house = string.Empty;
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
                    _staffForm.idObject_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[0].Value.ToString();
                    _staffForm.idOwner_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[1].Value.ToString();

                    _staffForm.PostCode_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[2].Value.ToString();
                    _staffForm.City_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[3].Value.ToString();
                    _staffForm.Hood_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[4].Value.ToString();
                    _staffForm.Street_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[5].Value.ToString();
                    _staffForm.HouseNumber_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[6].Value.ToString();

                    _staffForm.Type_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[7].Value.ToString();
                    _staffForm.Area_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[8].Value.ToString();
                    _staffForm.Status_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[9].Value.ToString();
                    _staffForm.Price_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[10].Value.ToString();
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
                if (_validators.ValidAddUpdatePlot(_staffForm.idOwner_plot, _staffForm.PostCode_plot, _staffForm.City_plot,
                    _staffForm.Hood_plot, _staffForm.Street_plot, _staffForm.HouseNumber_plot,
                    _staffForm.Type_plot, _staffForm.Area_plot, _staffForm.Status_plot, _staffForm.Price_plot))
                {

                    _plotService.AddPlotMember(new PlotMember
                    {
                        id_owner = _staffForm.idOwner_plot,

                        PostCode = _staffForm.PostCode_plot,
                        City = _staffForm.City_plot,
                        Hood = _staffForm.Hood_plot,
                        Street = _staffForm.Street_plot,
                        HouseNumber = _staffForm.HouseNumber_plot,

                        Type = _staffForm.Type_plot,
                        Area = _staffForm.Area_plot,
                        Status = _staffForm.Status_plot,
                        Price = _staffForm.Price_plot
                    });

                    _staffForm.idObject_plot = string.Empty;
                    _staffForm.idOwner_plot = string.Empty;

                    _staffForm.PostCode_plot = string.Empty;
                    _staffForm.Hood_plot = string.Empty;
                    _staffForm.Street_plot = string.Empty;
                    _staffForm.HouseNumber_plot = string.Empty;
                    
                    _staffForm.Area_plot = string.Empty;
                    _staffForm.Status_plot = string.Empty;
                    _staffForm.Price_plot = string.Empty;
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
                if (_validators.ValidAddUpdatePlot(_staffForm.idOwner_plot, _staffForm.PostCode_plot, _staffForm.City_plot,
                    _staffForm.Hood_plot, _staffForm.Street_plot, _staffForm.HouseNumber_plot,
                    _staffForm.Type_plot, _staffForm.Area_plot, _staffForm.Status_plot, _staffForm.Price_plot))
                {
                    _plotService.UpdatePlotMember(new PlotMember
                    {
                        id_object = _staffForm.idObject_plot,
                        id_owner = _staffForm.idOwner_plot,

                        PostCode = _staffForm.PostCode_plot,
                        City = _staffForm.City_plot,
                        Hood = _staffForm.Hood_plot,
                        Street = _staffForm.Street_plot,
                        HouseNumber = _staffForm.HouseNumber_plot,

                        Type = _staffForm.Type_plot,
                        Area = _staffForm.Area_plot,
                        Status = _staffForm.Status_plot,
                        Price = _staffForm.Price_plot
                    });

                    _staffForm.idObject_plot = string.Empty;
                    _staffForm.idOwner_plot = string.Empty;

                    _staffForm.PostCode_plot = string.Empty;
                    _staffForm.Hood_plot = string.Empty;
                    _staffForm.Street_plot = string.Empty;
                    _staffForm.HouseNumber_plot = string.Empty;
                    
                    _staffForm.Area_plot = string.Empty;
                    _staffForm.Status_plot = string.Empty;
                    _staffForm.Price_plot = string.Empty;
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
                if (_validators.ValidDeleteObject(_staffForm.idObject_plot))
                {
                    _plotService.DeletePlotMember(new PlotMember
                    {
                        id_object = _staffForm.idObject_plot
                    });

                    _staffForm.idObject_plot = string.Empty;
                    _staffForm.idOwner_plot = string.Empty;

                    _staffForm.PostCode_plot = string.Empty;
                    _staffForm.Hood_plot = string.Empty;
                    _staffForm.Street_plot = string.Empty;
                    _staffForm.HouseNumber_plot = string.Empty;
                    
                    _staffForm.Area_plot = string.Empty;
                    _staffForm.Status_plot = string.Empty;
                    _staffForm.Price_plot = string.Empty;
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
                    _staffForm.idDesiredObject_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[0].Value.ToString();
                    _staffForm.idClient_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[1].Value.ToString();

                    _staffForm.City_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[2].Value.ToString();
                    _staffForm.Hood_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[3].Value.ToString();
                    _staffForm.Street_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[4].Value.ToString();

                    _staffForm.Type_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[5].Value.ToString();
                    _staffForm.Area_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[6].Value.ToString();
                    _staffForm.Status_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[7].Value.ToString();
                    _staffForm.Floor_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[8].Value.ToString();
                    _staffForm.Room_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[9].Value.ToString();
                    _staffForm.Price_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[10].Value.ToString();
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
                if (_validators.ValidAddUpdateDesiredFlat(_staffForm.idClient_desiredFlat, _staffForm.City_desiredFlat, _staffForm.Hood_desiredFlat,
                    _staffForm.Street_desiredFlat, _staffForm.Type_desiredFlat, _staffForm.Area_desiredFlat, _staffForm.Status_desiredFlat,
                    _staffForm.Floor_desiredFlat, _staffForm.Room_desiredFlat, _staffForm.Price_desiredFlat))
                {

                    _desiredFlatService.AddDesiredFlatMember(new DesiredFlatMember
                    {
                        id_client = _staffForm.idClient_desiredFlat,

                        City = _staffForm.City_desiredFlat,
                        Hood = _staffForm.Hood_desiredFlat,
                        Street = _staffForm.Street_desiredFlat,

                        Type = _staffForm.Type_desiredFlat,
                        Area = _staffForm.Area_desiredFlat,
                        Status = _staffForm.Status_desiredFlat,
                        Floor = _staffForm.Floor_desiredFlat,
                        Room = _staffForm.Room_desiredFlat,
                        Price = _staffForm.Price_desiredFlat
                    });

                    _staffForm.idDesiredObject_desiredFlat = string.Empty;
                    _staffForm.idClient_desiredFlat = string.Empty;

                    _staffForm.City_desiredFlat = string.Empty;
                    _staffForm.Hood_desiredFlat = string.Empty;
                    _staffForm.Street_desiredFlat = string.Empty;

                    _staffForm.Type_desiredFlat = string.Empty;
                    _staffForm.Area_desiredFlat = string.Empty;
                    _staffForm.Status_desiredFlat = string.Empty;
                    _staffForm.Floor_desiredFlat = string.Empty;
                    _staffForm.Room_desiredFlat = string.Empty;
                    _staffForm.Price_desiredFlat = string.Empty;
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
                if (_validators.ValidAddUpdateDesiredFlat(_staffForm.idClient_desiredFlat, _staffForm.City_desiredFlat, _staffForm.Hood_desiredFlat,
                    _staffForm.Street_desiredFlat, _staffForm.Type_desiredFlat, _staffForm.Area_desiredFlat, _staffForm.Status_desiredFlat,
                    _staffForm.Floor_desiredFlat, _staffForm.Room_desiredFlat, _staffForm.Price_desiredFlat))
                {
                    _desiredFlatService.UpdateDesiredFlatMember(new DesiredFlatMember
                    {
                        id_desiredObject = _staffForm.idObject_flat,
                        id_client = _staffForm.idClient_desiredFlat,

                        City = _staffForm.City_desiredFlat,
                        Hood = _staffForm.Hood_desiredFlat,
                        Street = _staffForm.Street_desiredFlat,

                        Type = _staffForm.Type_desiredFlat,
                        Area = _staffForm.Area_desiredFlat,
                        Status = _staffForm.Status_desiredFlat,
                        Floor = _staffForm.Floor_desiredFlat,
                        Room = _staffForm.Room_desiredFlat,
                        Price = _staffForm.Price_desiredFlat
                    });

                    _staffForm.idDesiredObject_desiredFlat = string.Empty;
                    _staffForm.idClient_desiredFlat = string.Empty;

                    _staffForm.City_desiredFlat = string.Empty;
                    _staffForm.Hood_desiredFlat = string.Empty;
                    _staffForm.Street_desiredFlat = string.Empty;

                    _staffForm.Type_desiredFlat = string.Empty;
                    _staffForm.Area_desiredFlat = string.Empty;
                    _staffForm.Status_desiredFlat = string.Empty;
                    _staffForm.Floor_desiredFlat = string.Empty;
                    _staffForm.Room_desiredFlat = string.Empty;
                    _staffForm.Price_desiredFlat = string.Empty;
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
                if (_validators.ValidDeleteObject(_staffForm.idDesiredObject_desiredFlat))
                {
                    _desiredFlatService.DeleteDesiredFlatMember(new DesiredFlatMember
                    {
                        id_desiredObject = _staffForm.idDesiredObject_desiredFlat
                    });

                    _staffForm.idDesiredObject_desiredFlat = string.Empty;
                    _staffForm.idClient_desiredFlat = string.Empty;

                    _staffForm.City_desiredFlat = string.Empty;
                    _staffForm.Hood_desiredFlat = string.Empty;
                    _staffForm.Street_desiredFlat = string.Empty;

                    _staffForm.Type_desiredFlat = string.Empty;
                    _staffForm.Area_desiredFlat = string.Empty;
                    _staffForm.Status_desiredFlat = string.Empty;
                    _staffForm.Floor_desiredFlat = string.Empty;
                    _staffForm.Room_desiredFlat = string.Empty;
                    _staffForm.Price_desiredFlat = string.Empty;
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
                    _staffForm.idDesiredObject_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[0].Value.ToString();
                    _staffForm.idClient_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[1].Value.ToString();

                    _staffForm.City_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[2].Value.ToString();
                    _staffForm.Hood_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[3].Value.ToString();
                    _staffForm.Street_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[4].Value.ToString();

                    _staffForm.Type_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[5].Value.ToString();
                    _staffForm.Area_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[6].Value.ToString();
                    _staffForm.Status_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[7].Value.ToString();
                    _staffForm.NumberOfStoreys_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[8].Value.ToString();
                    _staffForm.Room_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[9].Value.ToString();
                    _staffForm.Price_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[10].Value.ToString();
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
                if (_validators.ValidAddUpdateDesiredHouse(_staffForm.idClient_desiredHouse, _staffForm.City_desiredHouse, _staffForm.Hood_desiredHouse,
                    _staffForm.Street_desiredHouse, _staffForm.Type_desiredHouse, _staffForm.Area_desiredHouse, _staffForm.Status_desiredHouse,
                    _staffForm.NumberOfStoreys_desiredHouse, _staffForm.Room_desiredHouse, _staffForm.Price_desiredHouse))
                {

                    _desiredHouseService.AddDesiredHouseMember(new DesiredHouseMember
                    {
                        id_client = _staffForm.idClient_desiredHouse,

                        City = _staffForm.City_desiredHouse,
                        Hood = _staffForm.Hood_desiredHouse,
                        Street = _staffForm.Street_desiredHouse,

                        Type = _staffForm.Type_desiredHouse,
                        Area = _staffForm.Area_desiredHouse,
                        Status = _staffForm.Status_desiredHouse,
                        NumberOfStoreys = _staffForm.NumberOfStoreys_desiredHouse,
                        Room = _staffForm.Room_desiredHouse,
                        Price = _staffForm.Price_desiredHouse
                    });

                    _staffForm.idDesiredObject_desiredHouse = string.Empty;
                    _staffForm.idClient_desiredHouse = string.Empty;

                    _staffForm.City_desiredHouse = string.Empty;
                    _staffForm.Hood_desiredHouse = string.Empty;
                    _staffForm.Street_desiredHouse = string.Empty;

                    _staffForm.Type_desiredHouse = string.Empty;
                    _staffForm.Area_desiredHouse = string.Empty;
                    _staffForm.Status_desiredHouse = string.Empty;
                    _staffForm.NumberOfStoreys_desiredHouse = string.Empty;
                    _staffForm.Room_desiredHouse = string.Empty;
                    _staffForm.Price_desiredHouse = string.Empty;
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
                if (_validators.ValidAddUpdateDesiredHouse(_staffForm.idClient_desiredHouse, _staffForm.City_desiredHouse, _staffForm.Hood_desiredHouse,
                    _staffForm.Street_desiredHouse, _staffForm.Type_desiredHouse, _staffForm.Area_desiredHouse, _staffForm.Status_desiredHouse,
                    _staffForm.NumberOfStoreys_desiredHouse, _staffForm.Room_desiredHouse, _staffForm.Price_desiredHouse))
                {
                    _desiredHouseService.UpdateDesiredHouseMember(new DesiredHouseMember
                    {
                        id_desiredObject = _staffForm.idDesiredObject_desiredHouse,
                        id_client = _staffForm.idClient_desiredHouse,

                        City = _staffForm.City_desiredHouse,
                        Hood = _staffForm.Hood_desiredHouse,
                        Street = _staffForm.Street_desiredHouse,

                        Type = _staffForm.Type_desiredHouse,
                        Area = _staffForm.Area_desiredHouse,
                        Status = _staffForm.Status_desiredHouse,
                        NumberOfStoreys = _staffForm.NumberOfStoreys_desiredHouse,
                        Room = _staffForm.Room_desiredHouse,
                        Price = _staffForm.Price_desiredHouse
                    });

                    _staffForm.idDesiredObject_desiredHouse = string.Empty;
                    _staffForm.idClient_desiredHouse = string.Empty;

                    _staffForm.City_desiredHouse = string.Empty;
                    _staffForm.Hood_desiredHouse = string.Empty;
                    _staffForm.Street_desiredHouse = string.Empty;

                    _staffForm.Type_desiredHouse = string.Empty;
                    _staffForm.Area_desiredHouse = string.Empty;
                    _staffForm.Status_desiredHouse = string.Empty;
                    _staffForm.NumberOfStoreys_desiredHouse = string.Empty;
                    _staffForm.Room_desiredHouse = string.Empty;
                    _staffForm.Price_desiredHouse = string.Empty;
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
                if (_validators.ValidDeleteObject(_staffForm.idDesiredObject_desiredHouse))
                {
                    _desiredHouseService.DeleteDesiredHouseMember(new DesiredHouseMember
                    {
                        id_desiredObject = _staffForm.idDesiredObject_desiredHouse
                    });

                    _staffForm.idDesiredObject_desiredHouse = string.Empty;
                    _staffForm.idClient_desiredHouse = string.Empty;

                    _staffForm.City_desiredHouse = string.Empty;
                    _staffForm.Hood_desiredHouse = string.Empty;
                    _staffForm.Street_desiredHouse = string.Empty;

                    _staffForm.Type_desiredHouse = string.Empty;
                    _staffForm.Area_desiredHouse = string.Empty;
                    _staffForm.Status_desiredHouse = string.Empty;
                    _staffForm.NumberOfStoreys_desiredHouse = string.Empty;
                    _staffForm.Room_desiredHouse = string.Empty;
                    _staffForm.Price_desiredHouse = string.Empty;
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
                    _staffForm.idDesiredObject_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[0].Value.ToString();
                    _staffForm.idClient_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[1].Value.ToString();

                    _staffForm.City_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[2].Value.ToString();
                    _staffForm.Hood_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[3].Value.ToString();
                    _staffForm.Street_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[4].Value.ToString();

                    _staffForm.Type_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[5].Value.ToString();
                    _staffForm.Area_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[6].Value.ToString();
                    _staffForm.Status_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[7].Value.ToString();
                    _staffForm.Price_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[8].Value.ToString();
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
                if (_validators.ValidAddUpdateDesiredPlot(_staffForm.idClient_desiredPlot, _staffForm.City_desiredPlot,
                    _staffForm.Hood_desiredPlot, _staffForm.Street_desiredPlot, _staffForm.Type_desiredPlot,
                    _staffForm.Area_desiredPlot, _staffForm.Status_desiredPlot, _staffForm.Price_desiredPlot))
                {

                    _desiredPlotService.AddDesiredPlotMember(new DesiredPlotMember
                    {
                        id_client = _staffForm.idClient_desiredPlot,

                        City = _staffForm.City_desiredPlot,
                        Hood = _staffForm.Hood_desiredPlot,
                        Street = _staffForm.Street_desiredPlot,

                        Type = _staffForm.Type_desiredPlot,
                        Area = _staffForm.Area_desiredPlot,
                        Status = _staffForm.Status_desiredPlot,
                        Price = _staffForm.Price_desiredPlot
                    });

                    _staffForm.idDesiredObject_desiredPlot = string.Empty;
                    _staffForm.idClient_desiredPlot = string.Empty;

                    _staffForm.City_desiredPlot = string.Empty;
                    _staffForm.Hood_desiredPlot = string.Empty;
                    _staffForm.Street_desiredPlot = string.Empty;

                    _staffForm.Type_desiredPlot = string.Empty;
                    _staffForm.Area_desiredPlot = string.Empty;
                    _staffForm.Status_desiredPlot = string.Empty;
                    _staffForm.Price_desiredPlot = string.Empty;
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
                if (_validators.ValidAddUpdateDesiredPlot(_staffForm.idClient_desiredPlot, _staffForm.City_desiredPlot,
                    _staffForm.Hood_desiredPlot, _staffForm.Street_desiredPlot, _staffForm.Type_desiredPlot,
                    _staffForm.Area_desiredPlot, _staffForm.Status_desiredPlot, _staffForm.Price_desiredPlot))
                {
                    _desiredPlotService.UpdateDesiredPlotMember(new DesiredPlotMember
                    {
                        id_desiredObject = _staffForm.idDesiredObject_desiredPlot,
                        id_client = _staffForm.idClient_desiredPlot,

                        City = _staffForm.City_desiredPlot,
                        Hood = _staffForm.Hood_desiredPlot,
                        Street = _staffForm.Street_desiredPlot,

                        Type = _staffForm.Type_desiredPlot,
                        Area = _staffForm.Area_desiredPlot,
                        Status = _staffForm.Status_desiredPlot,
                        Price = _staffForm.Price_desiredPlot
                    });

                    _staffForm.idDesiredObject_desiredPlot = string.Empty;
                    _staffForm.idClient_desiredPlot = string.Empty;

                    _staffForm.City_desiredPlot = string.Empty;
                    _staffForm.Hood_desiredPlot = string.Empty;
                    _staffForm.Street_desiredPlot = string.Empty;

                    _staffForm.Type_desiredPlot = string.Empty;
                    _staffForm.Area_desiredPlot = string.Empty;
                    _staffForm.Status_desiredPlot = string.Empty;
                    _staffForm.Price_desiredPlot = string.Empty;
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
                if (_validators.ValidDeleteObject(_staffForm.idDesiredObject_desiredPlot))
                {
                    _desiredPlotService.DeleteDesiredPlotMember(new DesiredPlotMember
                    {
                        id_desiredObject = _staffForm.idDesiredObject_desiredPlot
                    });

                    _staffForm.idDesiredObject_desiredPlot = string.Empty;
                    _staffForm.idClient_desiredPlot = string.Empty;

                    _staffForm.City_desiredPlot = string.Empty;
                    _staffForm.Hood_desiredPlot = string.Empty;
                    _staffForm.Street_desiredPlot = string.Empty;

                    _staffForm.Type_desiredPlot = string.Empty;
                    _staffForm.Area_desiredPlot = string.Empty;
                    _staffForm.Status_desiredPlot = string.Empty;
                    _staffForm.Price_desiredPlot = string.Empty;
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
