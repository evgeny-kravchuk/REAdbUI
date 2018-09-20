using System;
using System.Collections.Generic;

namespace Objects.Validation
{
    public class Validators
    {
        private bool ValidKey;
        public List<string> ErrorStrings { get; set; }
        private string ErrorString { get; set; }


        public Validators()
        {
            ErrorStrings = new List<string>();
            ValidKey = true;
            ErrorString = "--- Введите корректные значения ---\n" +
                          "-----------------------------------\n";
        }

        /*==============================================================================*/

        #region Admin
        #region Add Update client
        public bool ValidAddUpdateClient(string lastName, string firstName, string patronymic, string phoneNumber)
        {
            try
            {
                if (lastName == string.Empty)
                {
                    ErrorString += "-- Поле Фамилия не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(lastName) == true)
                    {
                        ErrorString += "-- В поле Фамилия введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (firstName == string.Empty)
                {
                    ErrorString += "-- Поле Имя не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(firstName) == true)
                    {
                        ErrorString += "-- В поле Имя введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (patronymic == string.Empty)
                {
                    ErrorString += "-- Поле Отчество не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(patronymic) == true)
                    {
                        ErrorString += "-- В поле Отчество введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (phoneNumber.Length < 15)
                {
                    ErrorString += "-- Поле Номер телефона не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion

        #region Delete client
        public bool ValidDeleteClient(string id_client)
        {
            try
            {
                if (id_client == string.Empty)
                {
                    ErrorString += "-- Поле ID не может быть пустым\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }

            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion

        #region Add Update contract
        public bool ValidAddUpdateContract(string idClient, string idEmployee, string idObject, string idOwner,
            string ContractType, string StartDate, string FinishDate, string Price)
        {
            try
            {
                if (idClient == string.Empty)
                {
                    ErrorString += "-- Поле id Клиента не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(idClient) == true)
                    {
                        ErrorString += "-- В поле id Клиента введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(idClient) <= 0)
                        {
                            ErrorString += "-- В поле id Клиента не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (idEmployee == string.Empty)
                {
                    ErrorString += "-- Поле id Сотрудника не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(idEmployee) == true)
                    {
                        ErrorString += "-- В поле id Сотрудника введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(idEmployee) <= 0)
                        {
                            ErrorString += "-- В поле id Сотрудника не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (idObject == string.Empty)
                {
                    ErrorString += "-- Поле id Объекта не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(idObject) == true)
                    {
                        ErrorString += "-- В поле id Объекта введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(idObject) <= 0)
                        {
                            ErrorString += "-- В поле id Объекта не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (idOwner == string.Empty)
                {
                    ErrorString += "-- Поле id Владельца не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(idOwner) == true)
                    {
                        ErrorString += "-- В поле id Владельца введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(idOwner) <= 0)
                        {
                            ErrorString += "-- В поле id Владельца не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (StartDate == string.Empty)
                {
                    ErrorString += "-- Поле Дата начала контракта не может быть пустым\n";
                    ValidKey = false;
                }

                if (FinishDate == string.Empty)
                {
                    ErrorString += "-- Поле Дата окончания контракта не может быть пустым\n";
                    ValidKey = false;
                }

                if (Convert.ToDateTime(StartDate) > DateTime.Now)
                {
                    ErrorString += "-- Поле Дата начала контракта не должно быть больше сегодняшнего дня!\n";
                    ValidKey = false;
                }

                if (Convert.ToDateTime(StartDate) >= Convert.ToDateTime(FinishDate))
                {
                    ErrorString += "-- Поле Дата начала контракта не должно быть больше или равно Дате окончания контракта!\n";
                    ValidKey = false;
                }

                if (Convert.ToDateTime(FinishDate) < Convert.ToDateTime(StartDate))
                {
                    ErrorString += "-- Поле Дата окончания контракта не должно быть меньше или равно Дате начале контракта!\n";
                    ValidKey = false;
                }

                if (Price == string.Empty)
                {
                    ErrorString += "-- Поле Цена не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Price) == true)
                    {
                        ErrorString += "-- В поле Цена введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Price) <= 0)
                        {
                            ErrorString += "-- В поле Цена не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }

            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "------------------------------------\n";
            }
        }
        #endregion

        #region Delete contract
        public bool ValidDeleteContract(string id_contract)
        {
            try
            {
                if (id_contract == string.Empty)
                {
                    ErrorString += "-- Поле ID не может быть пустым\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }

            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion

        #region Add Update flat
        public bool ValidAddUpdateFlat(string idOwner, string PostCode, string City, string Hood, string Street, string HouseNumber,
            string FlatNumber, string Type, string Area, string Status, string Floor, string Room, string Price)
        {
            try
            {
                if (idOwner == string.Empty)
                {
                    ErrorString += "-- Поле id Владельца не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(idOwner) == true)
                    {
                        ErrorString += "-- В поле id Владельца введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(idOwner) <= 0)
                        {
                            ErrorString += "-- В поле id Владельца не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (PostCode == string.Empty)
                {
                    ErrorString += "-- Поле Почтовый индекс не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(PostCode) == true)
                    {
                        ErrorString += "-- В поле Почтовый индекс введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(PostCode) <= 0)
                        {
                            ErrorString += "-- В поле Почтовый индекс не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (City == string.Empty)
                {
                    ErrorString += "-- Поле Город не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(City) == true)
                    {
                        ErrorString += "-- В поле Город введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Hood == string.Empty)
                {
                    ErrorString += "-- Поле Район не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Hood) == true)
                    {
                        ErrorString += "-- В поле Район введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Street == string.Empty)
                {
                    ErrorString += "-- Поле Улица не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Street) == true)
                    {
                        ErrorString += "-- В поле Улица введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (HouseNumber == string.Empty)
                {
                    ErrorString += "-- Поле Номер дома не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(HouseNumber) == true)
                    {
                        ErrorString += "-- В поле Номер дома введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(HouseNumber) <= 0)
                        {
                            ErrorString += "-- В поле Номер дома не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (FlatNumber == string.Empty)
                {
                    ErrorString += "-- Поле Номер дома не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(FlatNumber) == true)
                    {
                        ErrorString += "-- В поле Номер дома введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(FlatNumber) <= 0)
                        {
                            ErrorString += "-- В поле Номер дома не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Type == string.Empty)
                {
                    ErrorString += "-- Поле Тип не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Type) == true)
                    {
                        ErrorString += "-- В поле Тип введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Area == string.Empty)
                {
                    ErrorString += "-- Поле Площадь не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Area) == true)
                    {
                        ErrorString += "-- В поле Площадь введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Area) <= 0)
                        {
                            ErrorString += "-- В поле Площадь не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Status == string.Empty)
                {
                    ErrorString += "-- Поле Статус не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Status) == true)
                    {
                        ErrorString += "-- В поле Статус введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Floor == string.Empty)
                {
                    ErrorString += "-- Поле Этаж не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Floor) == true)
                    {
                        ErrorString += "-- В поле Этаж введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Floor) <= 0)
                        {
                            ErrorString += "-- В поле Этаж не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Room == string.Empty)
                {
                    ErrorString += "-- Поле Комнаты не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Room) == true)
                    {
                        ErrorString += "-- В поле Комнаты введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Room) <= 0)
                        {
                            ErrorString += "-- В поле Комнаты не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Price == string.Empty)
                {
                    ErrorString += "-- Поле Цена не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Price) == true)
                    {
                        ErrorString += "-- В поле Цена введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Price) <= 0)
                        {
                            ErrorString += "-- В поле Цена не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }

            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion

        #region Add Update house
        public bool ValidAddUpdateHouse(string idOwner, string PostCode, string City, string Hood, string Street,
            string HouseNumber, string Type, string Area, string Status, string NumberOfStoreys, string Room, string Price)
        {
            try
            {
                if (idOwner == string.Empty)
                {
                    ErrorString += "-- Поле id Владельца не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(idOwner) == true)
                    {
                        ErrorString += "-- В поле id Владельца введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(idOwner) <= 0)
                        {
                            ErrorString += "-- В поле id Владельца не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (PostCode == string.Empty)
                {
                    ErrorString += "-- Поле Почтовый индекс не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(PostCode) == true)
                    {
                        ErrorString += "-- В поле Почтовый индекс введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(PostCode) <= 0)
                        {
                            ErrorString += "-- В поле Почтовый индекс не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (City == string.Empty)
                {
                    ErrorString += "-- Поле Город не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(City) == true)
                    {
                        ErrorString += "-- В поле Город введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Hood == string.Empty)
                {
                    ErrorString += "-- Поле Район не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Hood) == true)
                    {
                        ErrorString += "-- В поле Район введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Street == string.Empty)
                {
                    ErrorString += "-- Поле Улица не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Street) == true)
                    {
                        ErrorString += "-- В поле Улица введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (HouseNumber == string.Empty)
                {
                    ErrorString += "-- Поле Номер дома не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(HouseNumber) == true)
                    {
                        ErrorString += "-- В поле Номер дома введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(HouseNumber) <= 0)
                        {
                            ErrorString += "-- В поле Номер дома не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Type == string.Empty)
                {
                    ErrorString += "-- Поле Тип не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Type) == true)
                    {
                        ErrorString += "-- В поле Тип введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Area == string.Empty)
                {
                    ErrorString += "-- Поле Площадь не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Area) == true)
                    {
                        ErrorString += "-- В поле Площадь введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Area) <= 0)
                        {
                            ErrorString += "-- В поле Площадь не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Status == string.Empty)
                {
                    ErrorString += "-- Поле Статус не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Status) == true)
                    {
                        ErrorString += "-- В поле Статус введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (NumberOfStoreys == string.Empty)
                {
                    ErrorString += "-- Поле Этажность не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(NumberOfStoreys) == true)
                    {
                        ErrorString += "-- В поле Этажность введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(NumberOfStoreys) <= 0)
                        {
                            ErrorString += "-- В поле Этажность не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Room == string.Empty)
                {
                    ErrorString += "-- Поле Комнаты не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Room) == true)
                    {
                        ErrorString += "-- В поле Комнаты введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Room) <= 0)
                        {
                            ErrorString += "-- В поле Комнаты не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Price == string.Empty)
                {
                    ErrorString += "-- Поле Цена не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Price) == true)
                    {
                        ErrorString += "-- В поле Цена введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Price) <= 0)
                        {
                            ErrorString += "-- В поле Цена не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }

            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "------------------------------------\n";
            }
        }
        #endregion

        #region Add Update plot
        public bool ValidAddUpdatePlot(string idOwner, string PostCode, string City, string Hood, string Street,
            string HouseNumber, string Type, string Area, string Status, string Price)
        {
            try
            {
                if (idOwner == string.Empty)
                {
                    ErrorString += "-- Поле id Владельца не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(idOwner) == true)
                    {
                        ErrorString += "-- В поле id Владельца введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(idOwner) <= 0)
                        {
                            ErrorString += "-- В поле id Владельца не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (PostCode == string.Empty)
                {
                    ErrorString += "-- Поле Почтовый индекс не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(PostCode) == true)
                    {
                        ErrorString += "-- В поле Почтовый индекс введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(PostCode) <= 0)
                        {
                            ErrorString += "-- В поле Почтовый индекс не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (City == string.Empty)
                {
                    ErrorString += "-- Поле Город не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(City) == true)
                    {
                        ErrorString += "-- В поле Город введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Hood == string.Empty)
                {
                    ErrorString += "-- Поле Район не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Hood) == true)
                    {
                        ErrorString += "-- В поле Район введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Street == string.Empty)
                {
                    ErrorString += "-- Поле Улица не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Street) == true)
                    {
                        ErrorString += "-- В поле Улица введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (HouseNumber == string.Empty)
                {
                    ErrorString += "-- Поле Номер дома не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(HouseNumber) == true)
                    {
                        ErrorString += "-- В поле Номер дома введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(HouseNumber) <= 0)
                        {
                            ErrorString += "-- В поле Номер дома не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Type == string.Empty)
                {
                    ErrorString += "-- Поле Тип не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Type) == true)
                    {
                        ErrorString += "-- В поле Тип введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Area == string.Empty)
                {
                    ErrorString += "-- Поле Площадь не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Area) == true)
                    {
                        ErrorString += "-- В поле Площадь введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Area) <= 0)
                        {
                            ErrorString += "-- В поле Площадь не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Status == string.Empty)
                {
                    ErrorString += "-- Поле Статус не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Status) == true)
                    {
                        ErrorString += "-- В поле Статус введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Price == string.Empty)
                {
                    ErrorString += "-- Поле Цена не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Price) == true)
                    {
                        ErrorString += "-- В поле Цена введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Price) <= 0)
                        {
                            ErrorString += "-- В поле Цена не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }

            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "------------------------------------\n";
            }
        }
        #endregion

        #region Add Update desiredFlat
        public bool ValidAddUpdateDesiredFlat(string idClient, string City, string Hood, string Street,
            string Type, string Area, string Status, string Floor, string Room, string Price)
        {
            try
            {
                if (idClient == string.Empty)
                {
                    ErrorString += "-- Поле id Клиента не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(idClient) == true)
                    {
                        ErrorString += "-- В поле id Клиента введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(idClient) <= 0)
                        {
                            ErrorString += "-- В поле id Клиента не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Functions.valid(City) == true)
                {
                    ErrorString += "-- В поле Город введен не коректный символ\n";
                    ValidKey = false;
                }

                if (idClient == string.Empty)
                {
                    ErrorString += "-- Поле id Клиента не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Hood) == true)
                    {
                        ErrorString += "-- В поле Район введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Functions.valid(Street) == true)
                {
                    ErrorString += "-- В поле Улица введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Type == string.Empty)
                {
                    ErrorString += "-- Поле Тип не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Type) == true)
                    {
                        ErrorString += "-- В поле Тип введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (idClient == string.Empty)
                {
                    ErrorString += "-- Поле id Клиента не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Area) == true)
                    {
                        ErrorString += "-- В поле Площадь введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (idClient == string.Empty)
                {
                    ErrorString += "-- Поле id Клиента не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Status) == true)
                    {
                        ErrorString += "-- В поле Статус введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (idClient == string.Empty)
                {
                    ErrorString += "-- Поле id Клиента не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Floor) == true)
                    {
                        ErrorString += "-- В поле Этаж введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (idClient == string.Empty)
                {
                    ErrorString += "-- Поле id Клиента не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Room) == true)
                    {
                        ErrorString += "-- В поле Комнаты введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (idClient == string.Empty)
                {
                    ErrorString += "-- Поле id Клиента не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Price) == true)
                    {
                        ErrorString += "-- В поле Цена введен не коректный символ\n";
                        ValidKey = false;
                    }
                }
                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }

            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion

        #region Add Update desiredHouse
        public bool ValidAddUpdateDesiredHouse(string idClient, string City, string Hood, string Street,
            string Type, string Area, string Status, string NumberOfStoreys, string Room, string Price)
        {
            try
            {
                if (idClient == string.Empty)
                {
                    ErrorString += "-- Поле id Клиента не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(idClient) == true)
                    {
                        ErrorString += "-- В поле id Клиента введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(idClient) <= 0)
                        {
                            ErrorString += "-- В поле id Клиента не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (City == string.Empty)
                {
                    ErrorString += "-- Поле Город не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(City) == true)
                    {
                        ErrorString += "-- В поле Город введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Hood == string.Empty)
                {
                    ErrorString += "-- Поле Район не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Hood) == true)
                    {
                        ErrorString += "-- В поле Район введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Street == string.Empty)
                {
                    ErrorString += "-- Поле Улица не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Street) == true)
                    {
                        ErrorString += "-- В поле Улица введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Type == string.Empty)
                {
                    ErrorString += "-- Поле Тип не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Type) == true)
                    {
                        ErrorString += "-- В поле Тип введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Area == string.Empty)
                {
                    ErrorString += "-- Поле Площадь не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Area) == true)
                    {
                        ErrorString += "-- В поле Площадь введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Area) <= 0)
                        {
                            ErrorString += "-- В поле Площадь не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Status == string.Empty)
                {
                    ErrorString += "-- Поле Статус не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Status) == true)
                    {
                        ErrorString += "-- В поле Статус введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (NumberOfStoreys == string.Empty)
                {
                    ErrorString += "-- Поле Этажность не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(NumberOfStoreys) == true)
                    {
                        ErrorString += "-- В поле Этажность введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(NumberOfStoreys) <= 0)
                        {
                            ErrorString += "-- В поле Этажность не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Room == string.Empty)
                {
                    ErrorString += "-- Поле Комнаты не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Room) == true)
                    {
                        ErrorString += "-- В поле Комнаты введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Room) <= 0)
                        {
                            ErrorString += "-- В поле Комнаты не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Price == string.Empty)
                {
                    ErrorString += "-- Поле Цена не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Price) == true)
                    {
                        ErrorString += "-- В поле Цена введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Price) <= 0)
                        {
                            ErrorString += "-- В поле Цена не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }

            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "------------------------------------\n";
            }
        }
        #endregion

        #region Add Update desiredPlot
        public bool ValidAddUpdateDesiredPlot(string idClient, string City, string Hood,
            string Street, string Type, string Area, string Status, string Price)
        {
            try
            {
                if (idClient == string.Empty)
                {
                    ErrorString += "-- Поле id Клиента не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(idClient) == true)
                    {
                        ErrorString += "-- В поле id Клиента введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(idClient) <= 0)
                        {
                            ErrorString += "-- В поле id Клиента не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (City == string.Empty)
                {
                    ErrorString += "-- Поле Город не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(City) == true)
                    {
                        ErrorString += "-- В поле Город введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Hood == string.Empty)
                {
                    ErrorString += "-- Поле Район не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Hood) == true)
                    {
                        ErrorString += "-- В поле Район введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Street == string.Empty)
                {
                    ErrorString += "-- Поле Улица не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Street) == true)
                    {
                        ErrorString += "-- В поле Улица введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Type == string.Empty)
                {
                    ErrorString += "-- Поле Тип не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Type) == true)
                    {
                        ErrorString += "-- В поле Тип введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Area == string.Empty)
                {
                    ErrorString += "-- Поле Площадь не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Area) == true)
                    {
                        ErrorString += "-- В поле Площадь введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Area) <= 0)
                        {
                            ErrorString += "-- В поле Площадь не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Status == string.Empty)
                {
                    ErrorString += "-- Поле Статус не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Status) == true)
                    {
                        ErrorString += "-- В поле Статус введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Price == string.Empty)
                {
                    ErrorString += "-- Поле Цена не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Price) == true)
                    {
                        ErrorString += "-- В поле Цена введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Price) <= 0)
                        {
                            ErrorString += "-- В поле Цена не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }

            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "------------------------------------\n";
            }
        }
        #endregion

        #region Delete flat / house / plot / desiredFlat / desiredHouse / desiredPlot
        public bool ValidDeleteObject(string idObject)
        {
            try
            {
                if (idObject == string.Empty)
                {
                    ErrorString += "-- Поле ID не может быть пустым\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion

        #region Add Update Staff
        public bool ValidAddUpdateStaff(string login, string lastName, string firstName, string patronymic,
            string phoneNumber, string position, string sex, string dateOfBirth)
        {
            try
            {
                if (login == string.Empty)
                {
                    ErrorString += "-- Поле Логин не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(login) == true)
                    {
                        ErrorString += "-- В поле Логин введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (lastName == string.Empty)
                {
                    ErrorString += "-- Поле Фамилия не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(lastName) == true)
                    {
                        ErrorString += "-- В поле Фамилия введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (firstName == string.Empty)
                {
                    ErrorString += "-- Поле Имя не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(firstName) == true)
                    {
                        ErrorString += "-- В поле Имя введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (patronymic == string.Empty)
                {
                    ErrorString += "-- Поле Отчество не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(patronymic) == true)
                    {
                        ErrorString += "-- В поле Отчество введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (phoneNumber.Length < 15)
                {
                    ErrorString += "-- Поле Номер телефона не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (position == string.Empty)
                {
                    ErrorString += "-- Поле Должность не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(position) == true)
                    {
                        ErrorString += "-- В поле Должность введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (sex == string.Empty)
                {
                    ErrorString += "-- Поле Пол не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(sex) == true)
                    {
                        ErrorString += "-- В поле Пол введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (dateOfBirth == string.Empty)
                {
                    ErrorString += "-- Поле Дата рождения не может быть пустым\n";
                    ValidKey = false;
                }

                if (Convert.ToDateTime(dateOfBirth) > DateTime.Now)
                {
                    ErrorString += "-- Поле Дата рождения не должно быть больше сегодняшнего дня!\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion

        #region Delete Staff
        public bool ValidDeleteStaff(string id_staff)
        {
            try
            {
                if (id_staff == string.Empty)
                {
                    ErrorString += "-- Поле ID не может быть пустым\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion

        #region Update Position
        public bool ValidUpdatePosition(string positionName, string salary)
        {
            try
            {
                if (positionName == string.Empty)
                {
                    ErrorString += "-- Поле Название должности не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(positionName) == true)
                    {
                        ErrorString += "-- В поле Название должности не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (salary == string.Empty)
                {
                    ErrorString += "-- Поле Зарплата не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(salary) == true)
                    {
                        ErrorString += "-- В поле Зарплата введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(salary) <= 0)
                        {
                            ErrorString += "-- В поле Зарплата не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion
        #endregion

        #region Client
        #region Update Login
        public bool ValidUpdateNewLogin(string login)
        {
            try
            {
                if (login == string.Empty)
                {
                    ErrorString += "-- Поле Логин не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(login) == true)
                    {
                        ErrorString += "-- В поле Логин введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion

        #region Update Password
        public bool ValidUpdateNewPassword(string oldPassword, string newPassword)
        {
            try
            {
                if (oldPassword == string.Empty)
                {
                    ErrorString += "-- Поле Страрый пароль не должно быть пустым!\n";
                    ValidKey = false;
                }


                if (newPassword == string.Empty)
                {
                    ErrorString += "-- Поле Новый пароль не должно быть пустым!\n";
                    ValidKey = false;
                }


                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion

        #region Update privatData
        public bool ValidUpdatePrivateDataClient(string lastName, string firstName, string patronymic, string phoneNumber)
        {
            try
            {

                if (lastName == string.Empty)
                {
                    ErrorString += "-- Поле Фамилия не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(lastName) == true)
                    {
                        ErrorString += "-- В поле Фамилия введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (firstName == string.Empty)
                {
                    ErrorString += "-- Поле Имя не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(firstName) == true)
                    {
                        ErrorString += "-- В поле Имя введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (patronymic == string.Empty)
                {
                    ErrorString += "-- Поле Отчество не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(patronymic) == true)
                    {
                        ErrorString += "-- В поле Отчество введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (phoneNumber.Length < 15)
                {
                    ErrorString += "-- Поле Номер телефона не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion

        #region Find flat
        public bool ValidFindFlat(string City, string Hood, string Street, string Type, string Area, string Status,
            string Floor, string Room, string Price)
        {
            try
            {
                if (Functions.valid(City) == true)
                {
                    ErrorString += "-- В поле Город введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Functions.valid(Hood) == true)
                {
                    ErrorString += "-- В поле Район введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Functions.valid(Street) == true)
                {
                    ErrorString += "-- В поле Улица введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Functions.valid(Type) == true)
                {
                    ErrorString += "-- В поле Тип введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Functions.valid(Area) == true)
                {
                    ErrorString += "-- В поле Площадь введен не коректный символ\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(Area) <= 0)
                    {
                        ErrorString += "-- В поле Площадь не может быть меньше или равно 0\n";
                        ValidKey = false;
                    }
                }

                if (Functions.valid(Status) == true)
                {
                    ErrorString += "-- В поле Статус введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Functions.valid(Floor) == true)
                {
                    ErrorString += "-- В поле Этаж введен не коректный символ\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(Floor) <= 0)
                    {
                        ErrorString += "-- В поле Этаж не может быть меньше или равно 0\n";
                        ValidKey = false;
                    }
                }

                if (Functions.valid(Room) == true)
                {
                    ErrorString += "-- В поле Комнаты введен не коректный символ\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(Room) <= 0)
                    {
                        ErrorString += "-- В поле Комнаты не может быть меньше или равно 0\n";
                        ValidKey = false;
                    }
                }

                if (Functions.valid(Price) == true)
                {
                    ErrorString += "-- В поле Цена введен не коректный символ\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(Price) <= 0)
                    {
                        ErrorString += "-- В поле Цена не может быть меньше или равно 0\n";
                        ValidKey = false;
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }

            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion

        #region Find house
        public bool ValidFindHouse(string City, string Hood, string Street, string Type, string Area, string Status,
            string NumberOfStoreys, string Room, string Price)
        {
            try
            {
                if (Functions.valid(City) == true)
                {
                    ErrorString += "-- В поле Город введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Functions.valid(Hood) == true)
                {
                    ErrorString += "-- В поле Район введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Functions.valid(Street) == true)
                {
                    ErrorString += "-- В поле Улица введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Functions.valid(Type) == true)
                {
                    ErrorString += "-- В поле Тип введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Functions.valid(Area) == true)
                {
                    ErrorString += "-- В поле Площадь введен не коректный символ\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(Area) <= 0)
                    {
                        ErrorString += "-- В поле Площадь не может быть меньше или равно 0\n";
                        ValidKey = false;
                    }
                }

                if (Functions.valid(Status) == true)
                {
                    ErrorString += "-- В поле Статус введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Functions.valid(NumberOfStoreys) == true)
                {
                    ErrorString += "-- В поле Этажность введен не коректный символ\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(NumberOfStoreys) <= 0)
                    {
                        ErrorString += "-- В поле Этажность не может быть меньше или равно 0\n";
                        ValidKey = false;
                    }
                }

                if (Functions.valid(Room) == true)
                {
                    ErrorString += "-- В поле Комнаты введен не коректный символ\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(Room) <= 0)
                    {
                        ErrorString += "-- В поле Комнаты не может быть меньше или равно 0\n";
                        ValidKey = false;
                    }
                }

                if (Functions.valid(Price) == true)
                {
                    ErrorString += "-- В поле Цена введен не коректный символ\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(Price) <= 0)
                    {
                        ErrorString += "-- В поле Цена не может быть меньше или равно 0\n";
                        ValidKey = false;
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }

            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "------------------------------------\n";
            }
        }
        #endregion

        #region Find plot
        public bool ValidFindPlot(string City, string Hood, string Street, string Type, string Area, string Status, string Price)
        {
            try
            {
                if (Functions.valid(City) == true)
                {
                    ErrorString += "-- В поле Город введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Functions.valid(Hood) == true)
                {
                    ErrorString += "-- В поле Район введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Functions.valid(Street) == true)
                {
                    ErrorString += "-- В поле Улица введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Functions.valid(Type) == true)
                {
                    ErrorString += "-- В поле Тип введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Functions.valid(Area) == true)
                {
                    ErrorString += "-- В поле Площадь введен не коректный символ\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(Area) <= 0)
                    {
                        ErrorString += "-- В поле Площадь не может быть меньше или равно 0\n";
                        ValidKey = false;
                    }
                }

                if (Functions.valid(Status) == true)
                {
                    ErrorString += "-- В поле Статус введен не коректный символ\n";
                    ValidKey = false;
                }

                if (Functions.valid(Price) == true)
                {
                    ErrorString += "-- В поле Цена введен не коректный символ\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(Price) <= 0)
                    {
                        ErrorString += "-- В поле Цена не может быть меньше или равно 0\n";
                        ValidKey = false;
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }

            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "------------------------------------\n";
            }
        }
        #endregion
        #endregion

        #region Staff
        #region Update privatData
        public bool ValidUpdatePrivateDataStaff(string lastName, string firstName, string patronymic,
            string sex, string dateOfBirth, string position, string phoneNumber)
        {
            try
            {

                if (lastName == string.Empty)
                {
                    ErrorString += "-- Поле Фамилия не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(lastName) == true)
                    {
                        ErrorString += "-- В поле Фамилия введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (firstName == string.Empty)
                {
                    ErrorString += "-- Поле Имя не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(firstName) == true)
                    {
                        ErrorString += "-- В поле Имя введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (patronymic == string.Empty)
                {
                    ErrorString += "-- Поле Отчество не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(patronymic) == true)
                    {
                        ErrorString += "-- В поле Отчество введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (sex == string.Empty)
                {
                    ErrorString += "-- Поле Пол не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(sex) == true)
                    {
                        ErrorString += "-- В поле Пол введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (position == string.Empty)
                {
                    ErrorString += "-- Поле Должность не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(position) == true)
                    {
                        ErrorString += "-- В поле Должность введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (dateOfBirth == string.Empty)
                {
                    ErrorString += "-- Поле Дата рождения не может быть пустым\n";
                    ValidKey = false;
                }

                if (Convert.ToDateTime(dateOfBirth) > DateTime.Now)
                {
                    ErrorString += "-- Поле Дата рождения не должно быть больше сегодняшнего дня!\n";
                    ValidKey = false;
                }

                if (phoneNumber.Length < 15)
                {
                    ErrorString += "-- Поле Номер телефона не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion
        #endregion

        #region SignIn
        public bool ValidSignIn(string Login, string Password)
        {
            try
            {
                if (Login == string.Empty)
                {
                    ErrorString += "-- Поле Логин не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Login) == true)
                    {
                        ErrorString += "-- В поле Логин введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Password == string.Empty)
                {
                    ErrorString += "-- Поле Пароль не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion

        #region SignUp
        public bool ValidSignUp(string Login, string Password, string LastName, string FirstName, string Patronymic, string PhoneNumber)
        {
            try
            {
                if (Login == string.Empty)
                {
                    ErrorString += "-- Поле Логин не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Login) == true)
                    {
                        ErrorString += "-- В поле Логин введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Password == string.Empty)
                {
                    ErrorString += "-- Поле Пароль не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (LastName == string.Empty)
                {
                    ErrorString += "-- Поле Фамилия не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(LastName) == true)
                    {
                        ErrorString += "-- В поле Фамилия введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (FirstName == string.Empty)
                {
                    ErrorString += "-- Поле Имя не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(FirstName) == true)
                    {
                        ErrorString += "-- В поле Имя введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Patronymic == string.Empty)
                {
                    ErrorString += "-- Поле Отчество не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Functions.valid(Patronymic) == true)
                    {
                        ErrorString += "-- В поле Отчество введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (PhoneNumber.Length < 15)
                {
                    ErrorString += "-- Поле Номер телефона не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------\n";
            }
        }
        #endregion

    }
}
