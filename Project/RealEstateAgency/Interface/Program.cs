using System;
using System.Windows.Forms;
using DatabaseLayer.Repositories;
using BusinessLogic.Services;
using Objects.Validation;
using Objects.Encrypting;
using Interface.Controllers;
using Interface.Forms;

namespace Interface
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Validators validators = new Validators();
            
            SignInForm signInForm = new SignInForm();
            SignUpForm signUpForm = new SignUpForm();

            string connectionStringLogin =
                String.Format("Server={0}; Port={1};" + "User Id={2}; Password={3}; Database={4};",
                DES.Decrypt("YoxAOxKdOqglsLulno11ew==", true),
                DES.Decrypt("OdmJZCmSBYQ=", true),
                DES.Decrypt("DqJB3wjN7j/TWKLBAK15xg==", true),
                DES.Decrypt("42JjUroTh4w=", true),
                DES.Decrypt("IL5kSQdF1h4=", true)
                );

            SignInRepository signInRepository = new SignInRepository(connectionStringLogin);
            SignInService signInService = new SignInService(signInRepository);

            SignUpRepository signUpRepository = new SignUpRepository(connectionStringLogin);
            SignUpService signUpService = new SignUpService(signUpRepository);
            
            SignInController signInController = new SignInController(signInForm, signUpForm, signInService, validators);
            SignUpController signUpController = new SignUpController(signUpForm, signUpService, validators);

            Application.Run(signInForm);
            
            if (DES.Decrypt("GKzXQPUYmkLTWKLBAK15xg==", true) == DES.Decrypt(signInController.Vacant, true))
            {

                AdminForm adminForm = new AdminForm();

                string connectionString = String.Format("Server={0}; Port={1};" + "User Id={2}; Password={3}; Database={4};",
                   DES.Decrypt("YoxAOxKdOqglsLulno11ew==", true),
                   DES.Decrypt("OdmJZCmSBYQ=", true),
                   DES.Decrypt("GKzXQPUYmkLTWKLBAK15xg==", true),
                   DES.Decrypt("UfLaMeyA8i4=", true),
                   DES.Decrypt("IL5kSQdF1h4=", true)
                   );

                StaffRepository staffRepository = new StaffRepository(connectionString);
                StaffService staffService = new StaffService(staffRepository);
                PositionRepository positionRepository = new PositionRepository(connectionString);
                PositionService positionService = new PositionService(positionRepository);

                AdminStaffController adminStaffController = new AdminStaffController(adminForm, staffService, positionService, validators);

                FlatRepository flatRepository = new FlatRepository(connectionString);
                FlatService flatService = new FlatService(flatRepository);
                HouseRepository houseRepository = new HouseRepository(connectionString);
                HouseService houseService = new HouseService(houseRepository);
                PlotRepository plotRepository = new PlotRepository(connectionString);
                PlotService plotService = new PlotService(plotRepository);

                DesiredFlatRepository desiredFlatRepository = new DesiredFlatRepository(connectionString);
                DesiredFlatService desiredFlatService = new DesiredFlatService(desiredFlatRepository);
                DesiredHouseRepository desiredHouseRepository = new DesiredHouseRepository(connectionString);
                DesiredHouseService desiredHouseService = new DesiredHouseService(desiredHouseRepository);
                DesiredPlotRepository desiredPlotRepository = new DesiredPlotRepository(connectionString);
                DesiredPlotService desiredPlotService = new DesiredPlotService(desiredPlotRepository);

                AdminObjectController adminObjectController = new AdminObjectController(adminForm, flatService, houseService, plotService, desiredFlatService, desiredHouseService, desiredPlotService, validators);

                ClientRepository clientRepository = new ClientRepository(connectionString);
                ClientService clientService = new ClientService(clientRepository);

                AdminClientController adminClientController = new AdminClientController(adminForm, clientService, validators);

                ContractRepository contractRepository = new ContractRepository(connectionString);
                ContractService contractService = new ContractService(contractRepository);

                AdminContractController adminContractController = new AdminContractController(adminForm, contractService, validators);

                Application.Run(adminForm);

            }
            else
            {
                if (DES.Decrypt(signInController.Vacant, true) == DES.Decrypt("uPv8EKCkZahrf7Zb1AJIrg==", true))
                {
                    ClientForm clientForm = new ClientForm();

                    string connectionString = String.Format("Server={0}; Port={1};" + "User Id={2}; Password={3}; Database={4};",
                    DES.Decrypt("YoxAOxKdOqglsLulno11ew==", true),
                    DES.Decrypt("OdmJZCmSBYQ=", true),
                    DES.Decrypt("uPv8EKCkZahrf7Zb1AJIrg==", true),
                    DES.Decrypt("Przqv06aDPE=", true),
                    DES.Decrypt("IL5kSQdF1h4=", true)
                    );

                    FlatRepository flatRepository = new FlatRepository(connectionString);
                    FlatService flatService = new FlatService(flatRepository);
                    HouseRepository houseRepository = new HouseRepository(connectionString);
                    HouseService houseService = new HouseService(houseRepository);
                    PlotRepository plotRepository = new PlotRepository(connectionString);
                    PlotService plotService = new PlotService(plotRepository);

                    DesiredFlatRepository desiredFlatRepository = new DesiredFlatRepository(connectionString);
                    DesiredFlatService desiredFlatService = new DesiredFlatService(desiredFlatRepository);
                    DesiredHouseRepository desiredHouseRepository = new DesiredHouseRepository(connectionString);
                    DesiredHouseService desiredHouseService = new DesiredHouseService(desiredHouseRepository);
                    DesiredPlotRepository desiredPlotRepository = new DesiredPlotRepository(connectionString);
                    DesiredPlotService desiredPlotService = new DesiredPlotService(desiredPlotRepository);

                    ClientRepository clientRepository = new ClientRepository(connectionString);
                    ClientService clientService = new ClientService(clientRepository);

                    ClientObjectController clientObjectController = new ClientObjectController(clientForm, flatService, houseService, plotService, desiredFlatService, desiredHouseService, desiredPlotService, clientService, signInController.Login, validators);
                    ClientInfoController clientInfoController = new ClientInfoController(clientForm, clientService, signInController.Login, validators);
                    ClientContractController clientContractController = new ClientContractController(clientForm, clientService, signInController.Login, validators);
                    
                    Application.Run(clientForm);

                }

                else
                {
                    if (DES.Decrypt(signInController.Vacant, true) == DES.Decrypt("cP/kazIB0rbTWKLBAK15xg==", true))
                    {
                        StaffForm staffForm = new StaffForm();

                        string connectionString = String.Format("Server={0}; Port={1};" + "User Id={2}; Password={3}; Database={4};",
                        DES.Decrypt("YoxAOxKdOqglsLulno11ew==", true),
                        DES.Decrypt("OdmJZCmSBYQ=", true),
                        DES.Decrypt("cP/kazIB0rbTWKLBAK15xg==", true),
                        DES.Decrypt("2Qkz2dHO4Rw=", true),
                        DES.Decrypt("IL5kSQdF1h4=", true)
                        );

                        StaffRepository staffRepository = new StaffRepository(connectionString);
                        StaffService staffService = new StaffService(staffRepository);

                        StaffInfoController staffInfoController = new StaffInfoController(staffForm, staffService, signInController.Login, validators);

                        FlatRepository flatRepository = new FlatRepository(connectionString);
                        FlatService flatService = new FlatService(flatRepository);
                        HouseRepository houseRepository = new HouseRepository(connectionString);
                        HouseService houseService = new HouseService(houseRepository);
                        PlotRepository plotRepository = new PlotRepository(connectionString);
                        PlotService plotService = new PlotService(plotRepository);

                        DesiredFlatRepository desiredFlatRepository = new DesiredFlatRepository(connectionString);
                        DesiredFlatService desiredFlatService = new DesiredFlatService(desiredFlatRepository);
                        DesiredHouseRepository desiredHouseRepository = new DesiredHouseRepository(connectionString);
                        DesiredHouseService desiredHouseService = new DesiredHouseService(desiredHouseRepository);
                        DesiredPlotRepository desiredPlotRepository = new DesiredPlotRepository(connectionString);
                        DesiredPlotService desiredPlotService = new DesiredPlotService(desiredPlotRepository);
                        
                        StaffObjectController staffObjectController = new StaffObjectController(staffForm, flatService, houseService, plotService, desiredFlatService, desiredHouseService, desiredPlotService, validators);

                        ClientRepository clientRepository = new ClientRepository(connectionString);
                        ClientService clientService = new ClientService(clientRepository);

                        StaffClientController staffClientController = new StaffClientController(staffForm, clientService, validators);
                        
                        ContractRepository contractRepository = new ContractRepository(connectionString);
                        ContractService contractService = new ContractService(contractRepository);

                        StaffContractController staffContractController = new StaffContractController(staffForm, contractService, validators);
                        
                        Application.Run(staffForm);
                    }
                }
            }
        }
    }
}
