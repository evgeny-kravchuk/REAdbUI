using System;
using System.Windows.Forms;
using Interface.Controllers;
using Objects.Validation;

namespace Interface.Forms
{
    public partial class StaffForm : Form
    {
        public StaffForm()
        {
            InitializeComponent();
        }
        #region Обработчик инициализация формы
        private void StaffForm_Load(object sender, EventArgs e) { }
        #endregion

        #region Flat
        #region TextBox
        public string idObject_flat { get { return textBoxFlatId.Text; } set { textBoxFlatId.Text = string.Empty; textBoxFlatId.Text = value; } }
        public string idOwner_flat { get { return textBoxFlatIdOwner.Text; } set { textBoxFlatIdOwner.Text = string.Empty; textBoxFlatIdOwner.Text = value; } }

        public string PostCode_flat { get { return textBoxFlatPostCode.Text; } set { textBoxFlatPostCode.Text = string.Empty; textBoxFlatPostCode.Text = value; } }
        public string City_flat { get { return Functions.FirstUpper(textBoxFlatCity.Text); } set { textBoxFlatCity.Text = string.Empty; textBoxFlatCity.Text = value; } }
        public string Hood_flat { get { return comboBoxFlatHood.Text; } set { comboBoxFlatHood.Text = string.Empty; comboBoxFlatHood.Text = value; } }
        public string Street_flat { get { return Functions.FirstUpper(textBoxFlatStreet.Text); } set { textBoxFlatStreet.Text = string.Empty; textBoxFlatStreet.Text = value; } }
        public string HouseNumber_flat { get { return textBoxFlatHouseNumber.Text; } set { textBoxFlatHouseNumber.Text = string.Empty; textBoxFlatHouseNumber.Text = value; } }
        public string FlatNumber_flat { get { return textBoxFlatFlatNumber.Text; } set { textBoxFlatFlatNumber.Text = string.Empty; textBoxFlatFlatNumber.Text = value; } }

        public string Type_flat { get { return comboBoxFlatType.Text; } set { comboBoxFlatType.Text = string.Empty; comboBoxFlatType.Text = value; } }
        public string Area_flat { get { return textBoxFlatArea.Text; } set { textBoxFlatArea.Text = string.Empty; textBoxFlatArea.Text = value; } }
        public string Status_flat { get { return comboBoxFlatStatus.Text; } set { comboBoxFlatStatus.Text = string.Empty; comboBoxFlatStatus.Text = value; } }
        public string Floor_flat { get { return comboBoxFlatFloor.Text; } set { comboBoxFlatFloor.Text = string.Empty; comboBoxFlatFloor.Text = value; } }
        public string Room_flat { get { return comboBoxFlatRoom.Text; } set { comboBoxFlatRoom.Text = string.Empty; comboBoxFlatRoom.Text = value; } }
        public string Price_flat { get { return textBoxFlatPrice.Text; } set { textBoxFlatPrice.Text = string.Empty; textBoxFlatPrice.Text = value; } }
        #endregion

        #region Buttons 
        public Button addFlat { get { return btnAddFlat; } }
        public Button updateFlat { get { return btnUpdateFlat; } }
        public Button deleteFlat { get { return btnDeleteFlat; } }
        #endregion

        #region DataGrid
        public DataGridView datagridviewFlat { get { return dgvFlat; } }
        #endregion

        #region Обработка события нажатия ячейки DataGrid и заполнения TextBox
        private void dgv_Flat_CellClick(object sender, DataGridViewCellEventArgs e) { }
        #endregion

        #region Обработка события кнопки Добавить Квартиру
        private void AddFlat_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Обновить Квартиру
        private void UpdateFlat_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Удалить Квартиру
        private void DeleteFlat_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Очистить поля
        private void ClearField_Flat(object sender, EventArgs e)
        {
            textBoxFlatId.Text = string.Empty;
            textBoxFlatIdOwner.Text = string.Empty;

            textBoxFlatPostCode.Text = string.Empty;
            comboBoxFlatHood.Text = string.Empty;
            textBoxFlatStreet.Text = string.Empty;
            textBoxFlatHouseNumber.Text = string.Empty;
            textBoxFlatFlatNumber.Text = string.Empty;
            
            textBoxFlatArea.Text = string.Empty;
            comboBoxFlatStatus.Text = string.Empty;
            comboBoxFlatFloor.Text = string.Empty;
            comboBoxFlatRoom.Text = string.Empty;
            textBoxFlatPrice.Text = string.Empty;
        }
        #endregion
        #endregion

        #region House
        #region TextBox
        public string idObject_house { get { return textBoxHouseId.Text; } set { textBoxHouseId.Text = string.Empty; textBoxHouseId.Text = value; } }
        public string idOwner_house { get { return textBoxHouseIdOwner.Text; } set { textBoxHouseIdOwner.Text = string.Empty; textBoxHouseIdOwner.Text = value; } }

        public string PostCode_house { get { return textBoxHousePostCode.Text; } set { textBoxHousePostCode.Text = string.Empty; textBoxHousePostCode.Text = value; } }
        public string City_house { get { return Functions.FirstUpper(textBoxHouseCity.Text); } set { textBoxHouseCity.Text = string.Empty; textBoxHouseCity.Text = value; } }
        public string Hood_house { get { return comboBoxHouseHood.Text; } set { comboBoxHouseHood.Text = string.Empty; comboBoxHouseHood.Text = value; } }
        public string Street_house { get { return Functions.FirstUpper(textBoxHouseStreet.Text); } set { textBoxHouseStreet.Text = string.Empty; textBoxHouseStreet.Text = value; } }
        public string HouseNumber_house { get { return textBoxHouseHouseNumber.Text; } set { textBoxHouseHouseNumber.Text = string.Empty; textBoxHouseHouseNumber.Text = value; } }
        
        public string Type_house { get { return comboBoxHouseType.Text; } set { comboBoxHouseType.Text = string.Empty; comboBoxHouseType.Text = value; } }
        public string Area_house { get { return textBoxHouseArea.Text; } set { textBoxHouseArea.Text = string.Empty; textBoxHouseArea.Text = value; } }
        public string Status_house { get { return comboBoxHouseStatus.Text; } set { comboBoxHouseStatus.Text = string.Empty; comboBoxHouseStatus.Text = value; } }
        public string NumberOfStoreys_house { get { return comboBoxHouseNumberOfStoreys.Text; } set { comboBoxHouseNumberOfStoreys.Text = string.Empty; comboBoxHouseNumberOfStoreys.Text = value; } }
        public string Room_house { get { return comboBoxHouseRoom.Text; } set { comboBoxHouseRoom.Text = string.Empty; comboBoxHouseRoom.Text = value; } }
        public string Price_house { get { return textBoxHousePrice.Text; } set { textBoxHousePrice.Text = string.Empty; textBoxHousePrice.Text = value; } }
        #endregion

        #region Buttons 
        public Button addHouse { get { return btnAddHouse; } }
        public Button updateHouse { get { return btnUpdateHouse; } }
        public Button deleteHouse { get { return btnDeleteHouse; } }
        #endregion

        #region DataGrid
        public DataGridView datagridviewHouse { get { return dgvHouse; } }
        #endregion

        #region Обработка события нажатия ячейки DataGrid и заполнения TextBox
        private void dgv_House_CellClick(object sender, DataGridViewCellEventArgs e) { }
        #endregion

        #region Обработка события кнопки Добавить Дом
        private void AddHouse_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Обновить Дом
        private void UpdateHouse_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Удалить Дом
        private void DeleteHouse_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Очистить поля
        private void ClearField_House(object sender, EventArgs e)
        {
            textBoxHouseId.Text = string.Empty;
            textBoxHouseIdOwner.Text = string.Empty;

            textBoxHousePostCode.Text = string.Empty;
            comboBoxHouseHood.Text = string.Empty;
            textBoxHouseStreet.Text = string.Empty;
            textBoxHouseHouseNumber.Text = string.Empty;
            
            textBoxHouseArea.Text = string.Empty;
            comboBoxHouseStatus.Text = string.Empty;
            comboBoxHouseNumberOfStoreys.Text = string.Empty;
            comboBoxHouseRoom.Text = string.Empty;
            textBoxHousePrice.Text = string.Empty;
        }
        #endregion
        #endregion

        #region Plot
        #region TextBox
        public string idObject_plot { get { return textBoxPlotId.Text; } set { textBoxPlotId.Text = string.Empty; textBoxPlotId.Text = value; } }
        public string idOwner_plot { get { return textBoxPlotIdOwner.Text; } set { textBoxPlotIdOwner.Text = string.Empty; textBoxPlotIdOwner.Text = value; } }

        public string PostCode_plot { get { return textBoxPlotPostCode.Text; } set { textBoxPlotPostCode.Text = string.Empty; textBoxPlotPostCode.Text = value; } }
        public string City_plot { get { return Functions.FirstUpper(textBoxPlotCity.Text); } set { textBoxPlotCity.Text = string.Empty; textBoxPlotCity.Text = value; } }
        public string Hood_plot { get { return comboBoxPlotHood.Text; } set { comboBoxPlotHood.Text = string.Empty; comboBoxPlotHood.Text = value; } }
        public string Street_plot { get { return Functions.FirstUpper(textBoxPlotStreet.Text); } set { textBoxPlotStreet.Text = string.Empty; textBoxPlotStreet.Text = value; } }
        public string HouseNumber_plot { get { return textBoxPlotHouseNumber.Text; } set { textBoxPlotHouseNumber.Text = string.Empty; textBoxPlotHouseNumber.Text = value; } }
        
        public string Type_plot { get { return comboBoxPlotType.Text; } set { comboBoxPlotType.Text = string.Empty; comboBoxPlotType.Text = value; } }
        public string Area_plot { get { return textBoxPlotArea.Text; } set { textBoxPlotArea.Text = string.Empty; textBoxPlotArea.Text = value; } }
        public string Status_plot { get { return comboBoxPlotStatus.Text; } set { comboBoxPlotStatus.Text = string.Empty; comboBoxPlotStatus.Text = value; } }
        public string Price_plot { get { return textBoxPlotPrice.Text; } set { textBoxPlotPrice.Text = string.Empty; textBoxPlotPrice.Text = value; } }
        #endregion

        #region Buttons 
        public Button addPlot { get { return btnAddPlot; } }
        public Button updatePlot { get { return btnUpdatePlot; } }
        public Button deletePlot { get { return btnDeletePlot; } }
        #endregion

        #region DataGrid
        public DataGridView datagridviewPlot { get { return dgvPlot; } }
        #endregion

        #region Обработка события нажатия ячейки DataGrid и заполнения TextBox
        private void dgv_Plot_CellClick(object sender, DataGridViewCellEventArgs e) { }
        #endregion

        #region Обработка события кнопки Добавить Участок
        private void AddPlot_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Обновить Участок
        private void UpdatePlot_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Удалить Участок
        private void DeletePlot_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Очистить поля
        private void ClearField_Plot(object sender, EventArgs e)
        {
            textBoxPlotId.Text = string.Empty;
            textBoxPlotIdOwner.Text = string.Empty;

            textBoxPlotPostCode.Text = string.Empty;
            comboBoxPlotHood.Text = string.Empty;
            textBoxPlotStreet.Text = string.Empty;
            textBoxPlotHouseNumber.Text = string.Empty;
            
            textBoxPlotArea.Text = string.Empty;
            comboBoxPlotStatus.Text = string.Empty;
            textBoxPlotPrice.Text = string.Empty;
        }
        #endregion
        #endregion

        #region DesiredFlat
        #region TextBox
        public string idDesiredObject_desiredFlat { get { return textBoxDesiredFlatId.Text; } set { textBoxDesiredFlatId.Text = string.Empty; textBoxDesiredFlatId.Text = value; } }
        public string idClient_desiredFlat { get { return textBoxDesiredFlatIdClient.Text; } set { textBoxDesiredFlatIdClient.Text = string.Empty; textBoxDesiredFlatIdClient.Text = value; } }

        public string City_desiredFlat { get { return Functions.FirstUpper(textBoxDesiredFlatCity.Text); } set { textBoxDesiredFlatCity.Text = string.Empty; textBoxDesiredFlatCity.Text = value; } }
        public string Hood_desiredFlat { get { return comboBoxDesiredFlatHood.Text; } set { comboBoxDesiredFlatHood.Text = string.Empty; comboBoxDesiredFlatHood.Text = value; } }
        public string Street_desiredFlat { get { return Functions.FirstUpper(textBoxDesiredFlatStreet.Text); } set { textBoxDesiredFlatStreet.Text = string.Empty; textBoxDesiredFlatStreet.Text = value; } }

        public string Type_desiredFlat { get { return comboBoxDesiredFlatType.Text; } set { comboBoxDesiredFlatType.Text = string.Empty; comboBoxDesiredFlatType.Text = value; } }
        public string Area_desiredFlat { get { return textBoxDesiredFlatArea.Text; } set { textBoxDesiredFlatArea.Text = string.Empty; textBoxDesiredFlatArea.Text = value; } }
        public string Status_desiredFlat { get { return comboBoxDesiredFlatStatus.Text; } set { comboBoxDesiredFlatStatus.Text = string.Empty; comboBoxDesiredFlatStatus.Text = value; } }
        public string Floor_desiredFlat { get { return comboBoxDesiredFlatFloor.Text; } set { comboBoxDesiredFlatFloor.Text = string.Empty; comboBoxDesiredFlatFloor.Text = value; } }
        public string Room_desiredFlat { get { return comboBoxDesiredFlatRoom.Text; } set { comboBoxDesiredFlatRoom.Text = string.Empty; comboBoxDesiredFlatRoom.Text = value; } }
        public string Price_desiredFlat { get { return textBoxDesiredFlatPrice.Text; } set { textBoxDesiredFlatPrice.Text = string.Empty; textBoxDesiredFlatPrice.Text = value; } }
        #endregion

        #region Buttons 
        public Button addDesiredFlat { get { return btnAddDesiredFlat; } }
        public Button updateDesiredFlat { get { return btnUpdateDesiredFlat; } }
        public Button deleteDesiredFlat { get { return btnDeleteDesiredFlat; } }
        #endregion

        #region DataGrid
        public DataGridView datagridviewDesiredFlat { get { return dgvDesiredFlat; } }
        #endregion

        #region Обработка события нажатия ячейки DataGrid и заполнения TextBox
        private void dgv_DesiredFlat_CellClick(object sender, DataGridViewCellEventArgs e) { }
        #endregion

        #region Обработка события кнопки Добавить Искомую Квартиру
        private void AddDesiredFlat_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Обновить Искомую Квартиру
        private void UpdateDesiredFlat_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Удалить Искомую Квартиру
        private void DeleteDesiredFlat_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Очистить поля
        private void ClearField_DesiredFlat(object sender, EventArgs e)
        {
            textBoxDesiredFlatId.Text = string.Empty;
            textBoxDesiredFlatIdClient.Text = string.Empty;
            
            comboBoxDesiredFlatHood.Text = string.Empty;
            textBoxDesiredFlatStreet.Text = string.Empty;
            
            textBoxDesiredFlatArea.Text = string.Empty;
            comboBoxDesiredFlatStatus.Text = string.Empty;
            comboBoxDesiredFlatFloor.Text = string.Empty;
            comboBoxDesiredFlatRoom.Text = string.Empty;
            textBoxDesiredFlatPrice.Text = string.Empty;
        }
        #endregion
        #endregion

        #region DesiredHouse
        #region TextBox
        public string idDesiredObject_desiredHouse { get { return textBoxDesiredHouseId.Text; } set { textBoxDesiredHouseId.Text = string.Empty; textBoxDesiredHouseId.Text = value; } }
        public string idClient_desiredHouse { get { return textBoxDesiredHouseIdClient.Text; } set { textBoxDesiredHouseIdClient.Text = string.Empty; textBoxDesiredHouseIdClient.Text = value; } }

        public string City_desiredHouse { get { return Functions.FirstUpper(textBoxDesiredHouseCity.Text); } set { textBoxDesiredHouseCity.Text = string.Empty; textBoxDesiredHouseCity.Text = value; } }
        public string Hood_desiredHouse { get { return comboBoxDesiredHouseHood.Text; } set { comboBoxDesiredHouseHood.Text = string.Empty; comboBoxDesiredHouseHood.Text = value; } }
        public string Street_desiredHouse { get { return Functions.FirstUpper(textBoxDesiredHouseStreet.Text); } set { textBoxDesiredHouseStreet.Text = string.Empty; textBoxDesiredHouseStreet.Text = value; } }

        public string Type_desiredHouse { get { return comboBoxDesiredHouseType.Text; } set { comboBoxDesiredHouseType.Text = string.Empty; comboBoxDesiredHouseType.Text = value; } }
        public string Area_desiredHouse { get { return textBoxDesiredHouseArea.Text; } set { textBoxDesiredHouseArea.Text = string.Empty; textBoxDesiredHouseArea.Text = value; } }
        public string Status_desiredHouse { get { return comboBoxDesiredHouseStatus.Text; } set { comboBoxDesiredHouseStatus.Text = string.Empty; comboBoxDesiredHouseStatus.Text = value; } }
        public string NumberOfStoreys_desiredHouse { get { return comboBoxDesiredHouseNumberOfStoreys.Text; } set { comboBoxDesiredHouseNumberOfStoreys.Text = string.Empty; comboBoxDesiredHouseNumberOfStoreys.Text = value; } }
        public string Room_desiredHouse { get { return comboBoxDesiredHouseRoom.Text; } set { comboBoxDesiredHouseRoom.Text = string.Empty; comboBoxDesiredHouseRoom.Text = value; } }
        public string Price_desiredHouse { get { return textBoxDesiredHousePrice.Text; } set { textBoxDesiredHousePrice.Text = string.Empty; textBoxDesiredHousePrice.Text = value; } }
        #endregion

        #region Buttons 
        public Button addDesiredHouse { get { return btnAddDesiredHouse; } }
        public Button updateDesiredHouse { get { return btnUpdateDesiredHouse; } }
        public Button deleteDesiredHouse { get { return btnDeleteDesiredHouse; } }
        #endregion

        #region DataGrid
        public DataGridView datagridviewDesiredHouse { get { return dgvDesiredHouse; } }
        #endregion

        #region Обработка события нажатия ячейки DataGrid и заполнения TextBox
        private void dgv_DesiredHouse_CellClick(object sender, DataGridViewCellEventArgs e) { }
        #endregion

        #region Обработка события кнопки Добавить Искомый Дом
        private void AddDesiredHouse_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Обновить Искомый Дом
        private void UpdateDesiredHouse_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Удалить Искомый Дом
        private void DeleteDesiredHouse_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Очистить поля
        private void ClearField_DesiredHouse(object sender, EventArgs e)
        {
            textBoxDesiredHouseId.Text = string.Empty;
            textBoxDesiredHouseIdClient.Text = string.Empty;
            
            comboBoxDesiredHouseHood.Text = string.Empty;
            textBoxDesiredHouseStreet.Text = string.Empty;
            
            textBoxDesiredHouseArea.Text = string.Empty;
            comboBoxDesiredHouseStatus.Text = string.Empty;
            comboBoxDesiredHouseNumberOfStoreys.Text = string.Empty;
            comboBoxDesiredHouseRoom.Text = string.Empty;
            textBoxDesiredHousePrice.Text = string.Empty;
        }
        #endregion
        #endregion

        #region DesiredPlot
        #region TextBox
        public string idDesiredObject_desiredPlot { get { return textBoxDesiredPlotId.Text; } set { textBoxDesiredPlotId.Text = string.Empty; textBoxDesiredPlotId.Text = value; } }
        public string idClient_desiredPlot { get { return textBoxDesiredPlotIdClient.Text; } set { textBoxDesiredPlotIdClient.Text = string.Empty; textBoxDesiredPlotIdClient.Text = value; } }

        public string City_desiredPlot { get { return Functions.FirstUpper(textBoxDesiredPlotCity.Text); } set { textBoxDesiredPlotCity.Text = string.Empty; textBoxDesiredPlotCity.Text = value; } }
        public string Hood_desiredPlot { get { return comboBoxDesiredPlotHood.Text; } set { comboBoxDesiredPlotHood.Text = string.Empty; comboBoxDesiredPlotHood.Text = value; } }
        public string Street_desiredPlot { get { return Functions.FirstUpper(textBoxDesiredPlotStreet.Text); } set { textBoxDesiredPlotStreet.Text = string.Empty; textBoxDesiredPlotStreet.Text = value; } }

        public string Type_desiredPlot { get { return comboBoxDesiredPlotType.Text; } set { comboBoxDesiredPlotType.Text = string.Empty; comboBoxDesiredPlotType.Text = value; } }
        public string Area_desiredPlot { get { return textBoxDesiredPlotArea.Text; } set { textBoxDesiredPlotArea.Text = string.Empty; textBoxDesiredPlotArea.Text = value; } }
        public string Status_desiredPlot { get { return comboBoxDesiredPlotStatus.Text; } set { comboBoxDesiredPlotStatus.Text = string.Empty; comboBoxDesiredPlotStatus.Text = value; } }
        public string Price_desiredPlot { get { return textBoxDesiredPlotPrice.Text; } set { textBoxDesiredPlotPrice.Text = string.Empty; textBoxDesiredPlotPrice.Text = value; } }
        #endregion

        #region Buttons 
        public Button addDesiredPlot { get { return btnAddDesiredPlot; } }
        public Button updateDesiredPlot { get { return btnUpdateDesiredPlot; } }
        public Button deleteDesiredPlot { get { return btnDeleteDesiredPlot; } }
        #endregion

        #region DataGrid
        public DataGridView datagridviewDesiredPlot { get { return dgvDesiredPlot; } }
        #endregion

        #region Обработка события нажатия ячейки DataGrid и заполнения TextBox
        private void dgv_DesiredPlot_CellClick(object sender, DataGridViewCellEventArgs e) { }
        #endregion

        #region Обработка события кнопки Добавить Искомый Участок
        private void AddDesiredPlot_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Обновить Искомый Участок
        private void UpdateDesiredPlot_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Удалить Искомый Участок
        private void DeleteDesiredPlot_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Очистить поля
        private void ClearField_DesiredPlot(object sender, EventArgs e)
        {
            textBoxDesiredPlotId.Text = string.Empty;
            textBoxDesiredPlotIdClient.Text = string.Empty;
            
            comboBoxDesiredPlotHood.Text = string.Empty;
            textBoxDesiredPlotStreet.Text = string.Empty;
            
            textBoxDesiredPlotArea.Text = string.Empty;
            comboBoxDesiredPlotStatus.Text = string.Empty;
            textBoxDesiredPlotPrice.Text = string.Empty;
        }
        #endregion
        #endregion

        #region Client
        #region TextBox
        public string id_client { get { return textBoxClientId.Text; } set { textBoxClientId.Text = string.Empty; textBoxClientId.Text = value; } }
        
        public string lastName_client { get { return Functions.FirstUpper(textBoxClientLastName.Text); } set { textBoxClientLastName.Text = string.Empty; textBoxClientLastName.Text = value; } }
        public string firstName_client { get { return Functions.FirstUpper(textBoxClientFirstName.Text); } set { textBoxClientFirstName.Text = string.Empty; textBoxClientFirstName.Text = value; } }
        public string patronymic_client { get { return Functions.FirstUpper(textBoxClientPatronymic.Text); } set { textBoxClientPatronymic.Text = string.Empty; textBoxClientPatronymic.Text = value; } }

        public string phoneNumber_client { get { return maskedTextBoxClientPhoneNumber.Text; } set { maskedTextBoxClientPhoneNumber.Text = string.Empty; maskedTextBoxClientPhoneNumber.Text = value; } }
        #endregion

        #region Button
        public Button updateClient { get { return btnUpdateClient; } }
        #endregion

        #region DataGrid
        public DataGridView datagridviewClient { get { return dgvClient; } }
        #endregion

        #region Обработка события нажатия ячейки DataGrid и заполнения TextBox
        private void dgv_Client_CellClick(object sender, DataGridViewCellEventArgs e) { }
        #endregion
        
        #region Обработка события кнопки Обновить Сотрудника
        private void UpdateClient_Click(object sender, EventArgs e) { }
        #endregion
        
        #region Обработка события кнопки Очистить поля
        private void ClearField_Client(object sender, EventArgs e)
        {
            textBoxClientId.Text = string.Empty;

            textBoxClientLastName.Text = string.Empty;
            textBoxClientFirstName.Text = string.Empty;
            textBoxClientPatronymic.Text = string.Empty;

            maskedTextBoxClientPhoneNumber.Text = string.Empty;
        }
        #endregion
        #endregion

        #region Contract
        #region TextBox
        public string id_contract { get { return textBoxContractId.Text; } set { textBoxContractId.Text = string.Empty; textBoxContractId.Text = value; } }
        public string idClient_contract { get { return textBoxContractIdClient.Text; } set { textBoxContractIdClient.Text = string.Empty; textBoxContractIdClient.Text = value; } }
        public string idEmployee_contract { get { return textBoxContractIdEmployee.Text; } set { textBoxContractIdEmployee.Text = string.Empty; textBoxContractIdEmployee.Text = value; } }
        public string idObject_contract { get { return textBoxContractIdObject.Text; } set { textBoxContractIdObject.Text = string.Empty; textBoxContractIdObject.Text = value; } }
        public string idOwner_contract { get { return textBoxContractIdOwner.Text; } set { textBoxContractIdOwner.Text = string.Empty; textBoxContractIdOwner.Text = value; } }

        public string ContractType_contract { get { return comboBoxContractType.Text; } set { comboBoxContractType.Text = string.Empty; comboBoxContractType.Text = value; } }
        public string StartDate_contract { get { return dtpContractStartDate.Text; } set { dtpContractStartDate.Text = string.Empty; dtpContractStartDate.Text = value; } }
        public string FinishDate_contract { get { return dtpContractFinishDate.Text; } set { dtpContractFinishDate.Text = string.Empty; dtpContractFinishDate.Text = value; } }
        public string Price_contract { get { return textBoxContractPrice.Text; } set { textBoxContractPrice.Text = string.Empty; textBoxContractPrice.Text = value; } }
        #endregion

        #region Buttons 
        public Button addContract { get { return btnAddContract; } }
        public Button updateContract { get { return btnUpdateContract; } }
        #endregion

        #region DataGrid
        public DataGridView datagridviewContract { get { return dgvContract; } }
        #endregion

        #region Обработка события нажатия ячейки DataGrid и заполнения TextBox
        private void dgv_Contract_CellClick(object sender, DataGridViewCellEventArgs e) { }
        #endregion

        #region Обработка события кнопки Добавить контракт
        private void AddContract_Click(object sender, EventArgs e) { }
        #endregion

        #region Обработка события кнопки Обновить контракт
        private void UpdateContract_Click(object sender, EventArgs e) { }
        #endregion
        
        #region Обработка события кнопки Очистить поля
        private void ClearField_Contract(object sender, EventArgs e)
        {
            textBoxContractId.Text = string.Empty;
            textBoxContractIdClient.Text = string.Empty;
            textBoxContractIdEmployee.Text = string.Empty;
            textBoxContractIdObject.Text = string.Empty;
            textBoxContractIdOwner.Text = string.Empty;

            comboBoxContractType.Text = string.Empty;
            dtpContractStartDate.Text = string.Empty;
            dtpContractFinishDate.Text = string.Empty;
            textBoxContractPrice.Text = string.Empty;
        }
        #endregion
        #endregion

        #region Personal Info
        #region TextBox
        public string lastName_staff { get { return textBoxStaffLastName.Text; } set { textBoxStaffLastName.Text = string.Empty; textBoxStaffLastName.Text = value; } }
        public string firstName_staff { get { return textBoxStaffFirstName.Text; } set { textBoxStaffFirstName.Text = string.Empty; textBoxStaffFirstName.Text = value; } }
        public string patronymic_staff { get { return textBoxStaffPatronymic.Text; } set { textBoxStaffPatronymic.Text = string.Empty; textBoxStaffPatronymic.Text = value; } }
        public string sex_staff { get { return comboBoxStaffSex.Text; } set { comboBoxStaffSex.Text = string.Empty; comboBoxStaffSex.Text = value; } }
        public string dateOfBirth_staff { get { return dtpStaffDateOfBirth.Text; } set { dtpStaffDateOfBirth.Text = string.Empty; dtpStaffDateOfBirth.Text = value; } }
        public string position_staff { get { return textBoxStaffPosition.Text; } set { textBoxStaffPosition.Text = string.Empty; textBoxStaffPosition.Text = value; } }
        public string phoneNumber_staff { get { return maskedTextBoxStaffPhoneNumber.Text; } set { maskedTextBoxStaffPhoneNumber.Text = string.Empty; maskedTextBoxStaffPhoneNumber.Text = value; } }

        public string login_staff { get { return textBoxStaffLogin.Text; } set { textBoxStaffLogin.Text = string.Empty; textBoxStaffLogin.Text = value; } }
        public string oldPassword_staff { get { return textBoxStaffOldPassword.Text; } set { textBoxStaffOldPassword.Text = string.Empty; textBoxStaffOldPassword.Text = value; } }
        public string newPassword_staff { get { return textBoxStaffNewPassword.Text; } set { textBoxStaffNewPassword.Text = string.Empty; textBoxStaffNewPassword.Text = value; } }
        #endregion

        #region Buttons 
        public Button updateStaffInfo { get { return btnUpdateStaffInfo; } }
        public Button updateStaffLogin { get { return btnUpdateStaffLogin; } }
        public Button updateStaffPassword { get { return btnUpdateStaffPassword; } }
        public Button exitStaff { get { return btnExitStaff; } }
        #endregion
        
        #region Обработка событий кнопок
        private void updateInfo_Click(object sender, EventArgs e) { }
        private void updateLogin_Click(object sender, EventArgs e) { }
        private void updatePassword_Click(object sender, EventArgs e) { }
        private void exit_Click(object sender, EventArgs e) { }
        #endregion
        #endregion        
    }
}
