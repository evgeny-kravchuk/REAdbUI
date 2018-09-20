using System;
using System.Windows.Forms;
using BusinessLogic.Interfaces;
using BusinessLogic.BLObjects;
using Objects.Validation;
using Interface.Forms;

namespace Interface.Controllers
{
    public class ClientObjectController
    {
        private string _login { get; set; }
        private ClientForm _clientForm;
        private Validators _validators;
        private IClientService _clientService;    

        #region Flat
        private IFlatService _flatService;
        private DataGridView _dataGridViewFlat;

        private Button _findFlatButton;
        #endregion

        #region House
        private IHouseService _houseService;
        private DataGridView _dataGridViewHouse;

        private Button _findHouseButton;
        #endregion

        #region Plot
        private IPlotService _plotService;
        private DataGridView _dataGridViewPlot;

        private Button _findPlotButton;
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

        public ClientObjectController() { }

        public ClientObjectController(ClientForm clientForm, IFlatService flatService, IHouseService houseService, IPlotService plotService,
            IDesiredFlatService desiredFlatService, IDesiredHouseService desiredHouseService, IDesiredPlotService desiredPlotService, IClientService clientService, string login, Validators validators)
        {
            _login = login;

            _validators = validators;
            _clientService = clientService;

            _clientForm = clientForm;
            _clientForm.Load += clientFormLoad;

            _flatService = flatService;
            _houseService = houseService;
            _plotService = plotService;

            _desiredFlatService = desiredFlatService;
            _desiredHouseService = desiredHouseService;
            _desiredPlotService = desiredPlotService;

            #region Flat
            #region Flat button
            _findFlatButton = clientForm.findFlat;
            _findFlatButton.Click += FindFlat;
            #endregion

            _dataGridViewFlat = clientForm.datagridviewFlat;
            _dataGridViewFlat.CellClick += dgv_Flat_CellClick;
            #endregion

            #region House
            #region House button
            _findHouseButton = clientForm.findHouse;
            _findHouseButton.Click += FindHouse;
            #endregion

            _dataGridViewHouse = clientForm.datagridviewHouse;
            _dataGridViewHouse.CellClick += dgv_House_CellClick;
            #endregion

            #region Plot
            #region Plot button
            _findPlotButton = clientForm.findPlot;
            _findPlotButton.Click += FindPlot;
            #endregion

            _dataGridViewPlot = clientForm.datagridviewPlot;
            _dataGridViewPlot.CellClick += dgv_Plot_CellClick;
            #endregion

            #region DesiredFlat
            #region DesiredFlat's buttons
            _addDesiredFlatButton = clientForm.addDesiredFlat;
            //_addDesiredFlatButton.Click += AddDesiredFlat;

            _updateDesiredFlatButton = clientForm.updateDesiredFlat;
            //_updateDesiredFlatButton.Click += EditDesiredFlat;

            _deleteDesiredFlatButton = clientForm.deleteDesiredFlat;
            //_deleteDesiredFlatButton.Click += DeleteDesiredFlat;
            #endregion

            _dataGridViewDesiredFlat = clientForm.datagridviewDesiredFlat;
            _dataGridViewDesiredFlat.CellClick += dgv_DesiredFlat_CellClick;
            #endregion

            #region DesiredHouse
            #region DesiredHouse's buttons
            _addDesiredHouseButton = clientForm.addDesiredHouse;
            //_addDesiredHouseButton.Click += AddDesiredHouse;

            _updateDesiredHouseButton = clientForm.updateDesiredHouse;
            //_updateDesiredHouseButton.Click += EditDesiredHouse;

            _deleteDesiredHouseButton = clientForm.deleteDesiredHouse;
            //_deleteDesiredHouseButton.Click += DeleteDesiredHouse;
            #endregion

            _dataGridViewDesiredHouse = clientForm.datagridviewDesiredHouse;
            _dataGridViewDesiredHouse.CellClick += dgv_DesiredHouse_CellClick;
            #endregion

            #region DesiredPlot
            #region DesiredPlot's buttons
            _addDesiredPlotButton = clientForm.addDesiredPlot;
            //_addDesiredPlotButton.Click += AddDesiredPlot;

            _updateDesiredPlotButton = clientForm.updateDesiredPlot;
            //_updateDesiredPlotButton.Click += EditDesiredPlot;

            _deleteDesiredPlotButton = clientForm.deleteDesiredPlot;
            //_deleteDesiredPlotButton.Click += DeleteDesiredPlot;
            #endregion

            _dataGridViewDesiredPlot = clientForm.datagridviewDesiredPlot;
            _dataGridViewDesiredPlot.CellClick += dgv_DesiredPlot_CellClick;
            #endregion
        }

        #region Инициализация формы
        public void clientFormLoad(object sender, EventArgs e)
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
                        dgvFlat.Rows.Add(v.PostCode, v.City, v.Hood, v.Street, v.HouseNumber, v.FlatNumber, v.Type, v.Area, v.Status, v.Floor, v.Room, v.Price);
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
                    _clientForm.PostCode_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[0].Value.ToString();
                    _clientForm.City_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[1].Value.ToString();
                    _clientForm.Hood_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[2].Value.ToString();
                    _clientForm.Street_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[3].Value.ToString();
                    _clientForm.HouseNumber_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[4].Value.ToString();
                    _clientForm.FlatNumber_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[5].Value.ToString();

                    _clientForm.Type_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[6].Value.ToString();
                    _clientForm.Area_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[7].Value.ToString();
                    _clientForm.Status_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[8].Value.ToString();
                    _clientForm.Floor_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[9].Value.ToString();
                    _clientForm.Room_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[10].Value.ToString();
                    _clientForm.Price_flat = _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Cells[11].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion                    

        #region  Метод события кнопки Найти Квартиру
        public void FindFlat(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidFindFlat(_clientForm.City_flat, _clientForm.Hood_flat, _clientForm.Street_flat,
                    _clientForm.Type_flat, _clientForm.Area_flat, _clientForm.Status_flat,
                    _clientForm.Floor_flat, _clientForm.Room_flat, _clientForm.Price_flat))
                {
                    _flatService.FindFlat(new FlatMember
                    {
                        City = _clientForm.City_flat,
                        Hood = _clientForm.Hood_flat,
                        Street = _clientForm.Street_flat,

                        Type = _clientForm.Type_flat,
                        Area = _clientForm.Area_flat,
                        Status = _clientForm.Status_flat,
                        Floor = _clientForm.Floor_flat,
                        Room = _clientForm.Room_flat,
                        Price = _clientForm.Price_flat
                    });
                    
                    _clientForm.PostCode_flat = string.Empty;
                    _clientForm.City_flat = string.Empty;
                    _clientForm.Hood_flat = string.Empty;
                    _clientForm.Street_flat = string.Empty;
                    _clientForm.HouseNumber_flat = string.Empty;
                    _clientForm.FlatNumber_flat = string.Empty;

                    _clientForm.Type_flat = string.Empty;
                    _clientForm.Area_flat = string.Empty;
                    _clientForm.Status_flat = string.Empty;
                    _clientForm.Floor_flat = string.Empty;
                    _clientForm.Room_flat = string.Empty;
                    _clientForm.Price_flat = string.Empty;
                }
                /*
                outputFlat(_dataGridViewFlat);
                if (_dataGridViewFlat.CurrentRow != null)
                {
                    _dataGridViewFlat.Rows[_dataGridViewFlat.CurrentRow.Index].Selected = false;
                }*/
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
                        dgvHouse.Rows.Add(v.PostCode, v.City, v.Hood, v.Street, v.HouseNumber, v.Type, v.Area, v.Status, v.NumberOfStoreys, v.Room, v.Price);
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
                    _clientForm.PostCode_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[0].Value.ToString();
                    _clientForm.City_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[1].Value.ToString();
                    _clientForm.Hood_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[2].Value.ToString();
                    _clientForm.Street_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[3].Value.ToString();
                    _clientForm.HouseNumber_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[4].Value.ToString();
                    
                    _clientForm.Type_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[5].Value.ToString();
                    _clientForm.Area_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[6].Value.ToString();
                    _clientForm.Status_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[7].Value.ToString();
                    _clientForm.NumberOfStoreys_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[8].Value.ToString();
                    _clientForm.Room_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[9].Value.ToString();
                    _clientForm.Price_house = _dataGridViewHouse.Rows[_dataGridViewHouse.CurrentRow.Index].Cells[10].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion

        #region  Метод события кнопки Найти Дом
        public void FindHouse(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidFindHouse(_clientForm.City_house, _clientForm.Hood_house, _clientForm.Street_house,
                    _clientForm.Type_house, _clientForm.Area_house, _clientForm.Status_house,
                    _clientForm.NumberOfStoreys_house, _clientForm.Room_house, _clientForm.Price_house))
                {
                    _houseService.FindHouse(new HouseMember
                    {
                        City = _clientForm.City_house,
                        Hood = _clientForm.Hood_house,
                        Street = _clientForm.Street_house,

                        Type = _clientForm.Type_house,
                        Area = _clientForm.Area_house,
                        Status = _clientForm.Status_house,
                        NumberOfStoreys = _clientForm.NumberOfStoreys_house,
                        Room = _clientForm.Room_house,
                        Price = _clientForm.Price_house
                    });

                    _clientForm.PostCode_house = string.Empty;
                    _clientForm.City_house = string.Empty;
                    _clientForm.Hood_house = string.Empty;
                    _clientForm.Street_house = string.Empty;
                    _clientForm.HouseNumber_house = string.Empty;

                    _clientForm.Type_house = string.Empty;
                    _clientForm.Area_house = string.Empty;
                    _clientForm.Status_house = string.Empty;
                    _clientForm.NumberOfStoreys_house = string.Empty;
                    _clientForm.Room_house = string.Empty;
                    _clientForm.Price_house = string.Empty;
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
                        dgvPlot.Rows.Add(v.PostCode, v.City, v.Hood, v.Street, v.HouseNumber, v.Type, v.Area, v.Status, v.Price);
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
                    _clientForm.PostCode_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[0].Value.ToString();
                    _clientForm.City_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[1].Value.ToString();
                    _clientForm.Hood_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[2].Value.ToString();
                    _clientForm.Street_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[3].Value.ToString();
                    _clientForm.HouseNumber_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[4].Value.ToString();

                    _clientForm.Type_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[5].Value.ToString();
                    _clientForm.Area_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[6].Value.ToString();
                    _clientForm.Status_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[7].Value.ToString();
                    _clientForm.Price_plot = _dataGridViewPlot.Rows[_dataGridViewPlot.CurrentRow.Index].Cells[8].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion

        #region  Метод события кнопки Найти Участок
        public void FindPlot(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidFindPlot(_clientForm.City_plot, _clientForm.Hood_plot, _clientForm.Street_plot,
                    _clientForm.Type_plot, _clientForm.Area_plot, _clientForm.Status_plot, _clientForm.Price_plot))
                {
                    _plotService.FindPlot(new PlotMember
                    {
                        City = _clientForm.City_plot,
                        Hood = _clientForm.Hood_plot,
                        Street = _clientForm.Street_plot,

                        Type = _clientForm.Type_plot,
                        Area = _clientForm.Area_plot,
                        Status = _clientForm.Status_plot,
                        Price = _clientForm.Price_plot
                    });

                    _clientForm.PostCode_plot = string.Empty;
                    _clientForm.City_plot = string.Empty;
                    _clientForm.Hood_plot = string.Empty;
                    _clientForm.Street_plot = string.Empty;
                    _clientForm.HouseNumber_plot = string.Empty;

                    _clientForm.Type_plot = string.Empty;
                    _clientForm.Area_plot = string.Empty;
                    _clientForm.Status_plot = string.Empty;
                    _clientForm.Price_plot = string.Empty;
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
                var result = _clientService.SelectDesiredFlatClient(_login);
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        dgvDesiredFlat.Rows.Add(v.City, v.Hood, v.Street, v.Type, v.Area, v.Status, v.Floor, v.Room, v.Price);
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
        public void dgv_DesiredFlat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridViewDesiredFlat.CurrentRow != null)
                {
                    _clientForm.City_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[0].Value.ToString();
                    _clientForm.Hood_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[1].Value.ToString();
                    _clientForm.Street_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[2].Value.ToString();

                    _clientForm.Type_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[3].Value.ToString();
                    _clientForm.Area_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[4].Value.ToString();
                    _clientForm.Status_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[5].Value.ToString();
                    _clientForm.Floor_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[6].Value.ToString();
                    _clientForm.Room_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[7].Value.ToString();
                    _clientForm.Price_desiredFlat = _dataGridViewDesiredFlat.Rows[_dataGridViewDesiredFlat.CurrentRow.Index].Cells[8].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion
        /*
        #region Метод события кнопки Добавить Искомую Квартиру
        public void AddDesiredFlat(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddDesiredFlat(_clientForm.idClient_desiredFlat, _clientForm.City_desiredFlat, _clientForm.Hood_desiredFlat,
                    _clientForm.Street_desiredFlat, _clientForm.Type_desiredFlat, _clientForm.Area_desiredFlat, _clientForm.Status_desiredFlat,
                    _clientForm.Floor_desiredFlat, _clientForm.Room_desiredFlat, _clientForm.Price_desiredFlat))
                {

                    _desiredFlatService.AddDesiredFlatMember(new DesiredFlatMember
                    {
                        id_client = _clientForm.idClient_desiredFlat,

                        City = _clientForm.City_desiredFlat,
                        Hood = _clientForm.Hood_desiredFlat,
                        Street = _clientForm.Street_desiredFlat,

                        Type = _clientForm.Type_desiredFlat,
                        Area = _clientForm.Area_desiredFlat,
                        Status = _clientForm.Status_desiredFlat,
                        Floor = _clientForm.Floor_desiredFlat,
                        Room = _clientForm.Room_desiredFlat,
                        Price = _clientForm.Price_desiredFlat
                    });
                    
                    _clientForm.City_desiredFlat = string.Empty;
                    _clientForm.Hood_desiredFlat = string.Empty;
                    _clientForm.Street_desiredFlat = string.Empty;

                    _clientForm.Type_desiredFlat = string.Empty;
                    _clientForm.Area_desiredFlat = string.Empty;
                    _clientForm.Status_desiredFlat = string.Empty;
                    _clientForm.Floor_desiredFlat = string.Empty;
                    _clientForm.Room_desiredFlat = string.Empty;
                    _clientForm.Price_desiredFlat = string.Empty;
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
                if (_validators.ValidUpdateDesiredFlat(_clientForm.idClient_desiredFlat, _clientForm.City_desiredFlat, _clientForm.Hood_desiredFlat,
                    _clientForm.Street_desiredFlat, _clientForm.Type_desiredFlat, _clientForm.Area_desiredFlat, _clientForm.Status_desiredFlat,
                    _clientForm.Floor_desiredFlat, _clientForm.Room_desiredFlat, _clientForm.Price_desiredFlat))
                {
                    _desiredFlatService.UpdateDesiredFlatMember(new DesiredFlatMember
                    {
                        id_desiredObject = _clientForm.idObject_flat,
                        id_client = _clientForm.idClient_desiredFlat,

                        City = _clientForm.City_desiredFlat,
                        Hood = _clientForm.Hood_desiredFlat,
                        Street = _clientForm.Street_desiredFlat,

                        Type = _clientForm.Type_desiredFlat,
                        Area = _clientForm.Area_desiredFlat,
                        Status = _clientForm.Status_desiredFlat,
                        Floor = _clientForm.Floor_desiredFlat,
                        Room = _clientForm.Room_desiredFlat,
                        Price = _clientForm.Price_desiredFlat
                    });
                    
                    _clientForm.City_desiredFlat = string.Empty;
                    _clientForm.Hood_desiredFlat = string.Empty;
                    _clientForm.Street_desiredFlat = string.Empty;

                    _clientForm.Type_desiredFlat = string.Empty;
                    _clientForm.Area_desiredFlat = string.Empty;
                    _clientForm.Status_desiredFlat = string.Empty;
                    _clientForm.Floor_desiredFlat = string.Empty;
                    _clientForm.Room_desiredFlat = string.Empty;
                    _clientForm.Price_desiredFlat = string.Empty;
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
                if (_validators.ValidDeleteDesiredFlat(_clientForm.idDesiredObject_desiredFlat))
                {
                    _desiredFlatService.DeleteDesiredFlatMember(new DesiredFlatMember
                    {
                        id_desiredObject = _clientForm.idDesiredObject_desiredFlat
                    });
                    
                    _clientForm.City_desiredFlat = string.Empty;
                    _clientForm.Hood_desiredFlat = string.Empty;
                    _clientForm.Street_desiredFlat = string.Empty;

                    _clientForm.Type_desiredFlat = string.Empty;
                    _clientForm.Area_desiredFlat = string.Empty;
                    _clientForm.Status_desiredFlat = string.Empty;
                    _clientForm.Floor_desiredFlat = string.Empty;
                    _clientForm.Room_desiredFlat = string.Empty;
                    _clientForm.Price_desiredFlat = string.Empty;
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
        */
        #endregion

        #region DesiredHouse
        #region Метод для заполнения DataGrid
        public void outputDesiredHouse(DataGridView dgvDesiredHouse)
        {
            dgvDesiredHouse.Rows.Clear();
            try
            {
                var result = _clientService.SelectDesiredHouseClient(_login);
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        dgvDesiredHouse.Rows.Add(v.City, v.Hood, v.Street, v.Type, v.Area, v.Status, v.NumberOfStoreys, v.Room, v.Price);
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
                    _clientForm.City_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[0].Value.ToString();
                    _clientForm.Hood_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[1].Value.ToString();
                    _clientForm.Street_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[2].Value.ToString();

                    _clientForm.Type_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[3].Value.ToString();
                    _clientForm.Area_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[4].Value.ToString();
                    _clientForm.Status_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[5].Value.ToString();
                    _clientForm.NumberOfStoreys_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[6].Value.ToString();
                    _clientForm.Room_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[7].Value.ToString();
                    _clientForm.Price_desiredHouse = _dataGridViewDesiredHouse.Rows[_dataGridViewDesiredHouse.CurrentRow.Index].Cells[8].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion
        /*
        #region Метод события кнопки Добавить Искомый Дом
        public void AddDesiredHouse(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddDesiredHouse(_clientForm.idClient_desiredHouse, _clientForm.City_desiredHouse, _clientForm.Hood_desiredHouse,
                    _clientForm.Street_desiredHouse, _clientForm.Type_desiredHouse, _clientForm.Area_desiredHouse, _clientForm.Status_desiredHouse,
                    _clientForm.NumberOfStoreys_desiredHouse, _clientForm.Room_desiredHouse, _clientForm.Price_desiredHouse))
                {

                    _desiredHouseService.AddDesiredHouseMember(new DesiredHouseMember
                    {
                        id_client = _clientForm.idClient_desiredHouse,
                        
                        City = _clientForm.City_desiredHouse,
                        Hood = _clientForm.Hood_desiredHouse,
                        Street = _clientForm.Street_desiredHouse,

                        Type = _clientForm.Type_desiredHouse,
                        Area = _clientForm.Area_desiredHouse,
                        Status = _clientForm.Status_desiredHouse,
                        NumberOfStoreys = _clientForm.NumberOfStoreys_desiredHouse,
                        Room = _clientForm.Room_desiredHouse,
                        Price = _clientForm.Price_desiredHouse
                    });
                    
                    _clientForm.City_desiredHouse = string.Empty;
                    _clientForm.Hood_desiredHouse = string.Empty;
                    _clientForm.Street_desiredHouse = string.Empty;

                    _clientForm.Type_desiredHouse = string.Empty;
                    _clientForm.Area_desiredHouse = string.Empty;
                    _clientForm.Status_desiredHouse = string.Empty;
                    _clientForm.NumberOfStoreys_desiredHouse = string.Empty;
                    _clientForm.Room_desiredHouse = string.Empty;
                    _clientForm.Price_desiredHouse = string.Empty;
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
                if (_validators.ValidUpdateDesiredHouse(_clientForm.idClient_desiredHouse, _clientForm.City_desiredHouse, _clientForm.Hood_desiredHouse,
                    _clientForm.Street_desiredHouse, _clientForm.Type_desiredHouse, _clientForm.Area_desiredHouse, _clientForm.Status_desiredHouse,
                    _clientForm.NumberOfStoreys_desiredHouse, _clientForm.Room_desiredHouse, _clientForm.Price_desiredHouse))
                {
                    _desiredHouseService.UpdateDesiredHouseMember(new DesiredHouseMember
                    {
                        id_desiredObject = _clientForm.idDesiredObject_desiredHouse,
                        id_client = _clientForm.idClient_desiredHouse,

                        City = _clientForm.City_desiredHouse,
                        Hood = _clientForm.Hood_desiredHouse,
                        Street = _clientForm.Street_desiredHouse,

                        Type = _clientForm.Type_desiredHouse,
                        Area = _clientForm.Area_desiredHouse,
                        Status = _clientForm.Status_desiredHouse,
                        NumberOfStoreys = _clientForm.NumberOfStoreys_desiredHouse,
                        Room = _clientForm.Room_desiredHouse,
                        Price = _clientForm.Price_desiredHouse
                    });
                    
                    _clientForm.City_desiredHouse = string.Empty;
                    _clientForm.Hood_desiredHouse = string.Empty;
                    _clientForm.Street_desiredHouse = string.Empty;

                    _clientForm.Type_desiredHouse = string.Empty;
                    _clientForm.Area_desiredHouse = string.Empty;
                    _clientForm.Status_desiredHouse = string.Empty;
                    _clientForm.NumberOfStoreys_desiredHouse = string.Empty;
                    _clientForm.Room_desiredHouse = string.Empty;
                    _clientForm.Price_desiredHouse = string.Empty;
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
                if (_validators.ValidDeleteDesiredHouse(_clientForm.idDesiredObject_desiredHouse))
                {
                    _desiredHouseService.DeleteDesiredHouseMember(new DesiredHouseMember
                    {
                        id_desiredObject = _clientForm.idDesiredObject_desiredHouse
                    });
                    
                    _clientForm.City_desiredHouse = string.Empty;
                    _clientForm.Hood_desiredHouse = string.Empty;
                    _clientForm.Street_desiredHouse = string.Empty;

                    _clientForm.Type_desiredHouse = string.Empty;
                    _clientForm.Area_desiredHouse = string.Empty;
                    _clientForm.Status_desiredHouse = string.Empty;
                    _clientForm.NumberOfStoreys_desiredHouse = string.Empty;
                    _clientForm.Room_desiredHouse = string.Empty;
                    _clientForm.Price_desiredHouse = string.Empty;
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
        */
        #endregion

        #region DesiredPlot
        #region Метод для заполнения DataGrid
        public void outputDesiredPlot(DataGridView dgvDesiredPlot)
        {
            dgvDesiredPlot.Rows.Clear();
            try
            {
                var result = _clientService.SelectDesiredPlotClient(_login);
                if (result.IsValid)
                {
                    foreach (var v in result.ResultObject)
                    {
                        dgvDesiredPlot.Rows.Add(v.City, v.Hood, v.Street, v.Type, v.Area, v.Status, v.Price);
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
        public void dgv_DesiredPlot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridViewDesiredPlot.CurrentRow != null)
                {
                    _clientForm.City_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[0].Value.ToString();
                    _clientForm.Hood_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[1].Value.ToString();
                    _clientForm.Street_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[2].Value.ToString();

                    _clientForm.Type_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[3].Value.ToString();
                    _clientForm.Area_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[4].Value.ToString();
                    _clientForm.Status_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[5].Value.ToString();
                    _clientForm.Price_desiredPlot = _dataGridViewDesiredPlot.Rows[_dataGridViewDesiredPlot.CurrentRow.Index].Cells[6].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка заполнения.");
            }
        }
        #endregion
        /*
        #region Метод события кнопки Добавить Искомый Участок
        public void AddDesiredPlot(object sender, EventArgs e)
        {
            try
            {
                if (_validators.ValidAddDesiredPlot(_clientForm.idClient_desiredPlot, _clientForm.City_desiredPlot,
                    _clientForm.Hood_desiredPlot, _clientForm.Street_desiredPlot, _clientForm.Type_desiredPlot,
                    _clientForm.Area_desiredPlot, _clientForm.Status_desiredPlot, _clientForm.Price_desiredPlot))
                {

                    _desiredPlotService.AddDesiredPlotMember(new DesiredPlotMember
                    {
                        id_client = _clientForm.idClient_desiredPlot,

                        City = _clientForm.City_desiredPlot,
                        Hood = _clientForm.Hood_desiredPlot,
                        Street = _clientForm.Street_desiredPlot,

                        Type = _clientForm.Type_desiredPlot,
                        Area = _clientForm.Area_desiredPlot,
                        Status = _clientForm.Status_desiredPlot,
                        Price = _clientForm.Price_desiredPlot
                    });
                    
                    _clientForm.City_desiredPlot = string.Empty;
                    _clientForm.Hood_desiredPlot = string.Empty;
                    _clientForm.Street_desiredPlot = string.Empty;

                    _clientForm.Type_desiredPlot = string.Empty;
                    _clientForm.Area_desiredPlot = string.Empty;
                    _clientForm.Status_desiredPlot = string.Empty;
                    _clientForm.Price_desiredPlot = string.Empty;
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
                if (_validators.ValidUpdateDesiredPlot(_clientForm.idClient_desiredPlot, _clientForm.City_desiredPlot,
                    _clientForm.Hood_desiredPlot, _clientForm.Street_desiredPlot, _clientForm.Type_desiredPlot,
                    _clientForm.Area_desiredPlot, _clientForm.Status_desiredPlot, _clientForm.Price_desiredPlot))
                {
                    _desiredPlotService.UpdateDesiredPlotMember(new DesiredPlotMember
                    {
                        id_desiredObject = _clientForm.idDesiredObject_desiredPlot,
                        id_client = _clientForm.idClient_desiredPlot,

                        City = _clientForm.City_desiredPlot,
                        Hood = _clientForm.Hood_desiredPlot,
                        Street = _clientForm.Street_desiredPlot,

                        Type = _clientForm.Type_desiredPlot,
                        Area = _clientForm.Area_desiredPlot,
                        Status = _clientForm.Status_desiredPlot,
                        Price = _clientForm.Price_desiredPlot
                    });
                    
                    _clientForm.City_desiredPlot = string.Empty;
                    _clientForm.Hood_desiredPlot = string.Empty;
                    _clientForm.Street_desiredPlot = string.Empty;

                    _clientForm.Type_desiredPlot = string.Empty;
                    _clientForm.Area_desiredPlot = string.Empty;
                    _clientForm.Status_desiredPlot = string.Empty;
                    _clientForm.Price_desiredPlot = string.Empty;
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
                if (_validators.ValidDeleteDesiredPlot(_clientForm.idDesiredObject_desiredPlot))
                {
                    _desiredPlotService.DeleteDesiredPlotMember(new DesiredPlotMember
                    {
                        id_desiredObject = _clientForm.idDesiredObject_desiredPlot
                    });
                    
                    _clientForm.City_desiredPlot = string.Empty;
                    _clientForm.Hood_desiredPlot = string.Empty;
                    _clientForm.Street_desiredPlot = string.Empty;

                    _clientForm.Type_desiredPlot = string.Empty;
                    _clientForm.Area_desiredPlot = string.Empty;
                    _clientForm.Status_desiredPlot = string.Empty;
                    _clientForm.Price_desiredPlot = string.Empty;
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
        */
        #endregion
    }
}