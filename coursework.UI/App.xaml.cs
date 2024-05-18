using CommunityToolkit.Mvvm.ComponentModel;
using coursework.Data.Repository;
using coursework.Data.RepositoryImpl;
using coursework.Domain.Repository;
using coursework.Domain.UseCase;
using coursework.EntityFramework.Mapper;
using coursework.EntityFramework.Model;
using coursework.EntityFramework.RepositoryImpl;
using coursework.EntityFramework.Utils;
using coursework.UI.Dialog.ViewModel;
using coursework.UI.Service.Impl;
using coursework.UI.Utils;
using coursework.UI.View;
using coursework.UI.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace coursework.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        readonly ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new();

            services.AddSingleton(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<RegistrationViewModel>();
            services.AddSingleton<MainViewVM>();
            services.AddSingleton<ProductsViewModel>();
            services.AddSingleton<AccountViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<EmpAccountViewModel>();
            services.AddSingleton<DashboardViewModel>();
            services.AddSingleton<ProdViewModel>();
            services.AddSingleton<WorkshopViewModel>();
            services.AddSingleton<TimetableViewModel>();
            services.AddSingleton<ClientsViewModel>();
            services.AddSingleton<SuppliersViewModel>();
            services.AddSingleton<EmployeesViewModel>();
            services.AddSingleton<IngredsViewModel>();
            services.AddSingleton<OrdersViewModel>();
            services.AddSingleton<AddOrderViewModel>();
            services.AddSingleton<EmpProdsViewModel>();
            services.AddSingleton<AddEmployeeViewModel>();
            services.AddSingleton<ProductComposViewModel>();
            services.AddSingleton<IngredsOnWarehouseViewModel>();
            services.AddSingleton<IngredExpenseViewModel>();

            services.AddSingleton<AddProductViewModel>();
            services.AddSingleton<UpdateProductViewModel>();
            services.AddSingleton<AddWorkshopViewModel>();
            services.AddSingleton<UpdateWorkshopViewModel>();
            services.AddSingleton<AddTimesheetViewModel>();
            services.AddSingleton<AddSupplierViewModel>();
            services.AddSingleton<UpdateSupplierViewModel>();
            services.AddSingleton<AddProdComposViewModel>();
            services.AddSingleton<UpdateProdComposViewModel>();
            services.AddSingleton<AddIngredViewModel>();
            services.AddSingleton<UpdateIngredViewModel>();
            services.AddSingleton<UpdateEmployeeViewModel>();
            services.AddSingleton<AddIngredOnWarehouseViewModel>();
            services.AddSingleton<UpdateEmpAccViewModel>();
            services.AddSingleton<UpdateClientAccViewModel>();

            services.AddSingleton<Service.Interface.INavigationService, NavigationService>();
            services.AddSingleton<Service.Interface.IDialogService, DialogService>();

            services.AddTransient<GetUserUseCase>();
            services.AddTransient<GetEmployeeUseCase>();
            services.AddTransient<GetClientUseCase>();
            services.AddTransient<GetProductsUseCase>();
            services.AddTransient<AddClientUseCase>();
            services.AddTransient<GetOrdersUseCase>();
            services.AddTransient<GetClientsUseCase>();
            services.AddTransient<GetOrderStatusesUseCase>();
            services.AddTransient<FilterOrdersByStatus>();
            services.AddTransient<GetClientByIdUseCase>();
            services.AddTransient<GetOrderStatusByIdUseCase>();
            services.AddTransient<GetIngredsUseCase>();
            services.AddTransient<GetEmployeesUseCase>();
            services.AddTransient<GetSuppliersUseCase>();
            services.AddTransient<GetWorkshopsUseCase>();
            services.AddTransient<GetEmployeeByIdUseCase>();
            services.AddTransient<GetTimesheetUseCase>();
            services.AddTransient<GetOrderCartUseCase>();
            services.AddTransient<GetProductByIdUseCase>();
            services.AddTransient<FilterClientsByBirthdayUseCase>();
            services.AddTransient<FilterClientsByFioUseCase>();
            services.AddTransient<FilterEmployeesByFioUseCase>();
            services.AddTransient<FilterEmployeesByBirthdayUseCase>();
            services.AddTransient<GetPaytypesUseCase>();
            services.AddTransient<AddEmployeeUseCase>();
            services.AddTransient<GetPositionsUseCase>();
            services.AddTransient<AddOrderUseCase>();
            services.AddTransient<FilterProductsByNameUseCase>();
            services.AddTransient<FilterProductsByPriceUseCase>();
            services.AddTransient<AddProductUseCase>();
            services.AddTransient<DeleteEmployeeUseCase>();
            services.AddTransient<DeleteTimesheetUseCase>();
            services.AddSingleton<GetIngredTypeByIdUseCase>();
            services.AddTransient<GetIngredientByIdUseCase>();
            services.AddTransient<GetComposByProdIdUseCase>();
            services.AddTransient<GetWorkshopByIdUseCase>();
            services.AddTransient<GetPositionByIdUseCase>();
            services.AddTransient<GetIngredsOnWarehouseUseCase>();
            services.AddTransient<GetSupplierByIdUseCase>();
            services.AddTransient<GetIngredTypesUseCase>();
            services.AddTransient<FilterIngredsByNameUseCase>();
            services.AddTransient<FilterIngredsByTypeIdUseCase>();
            services.AddTransient<GetIngredientExpenseByProductsIdUseCase>();
            services.AddTransient<FilterTimesheetByEmployeeUseCase>();
            services.AddTransient<AddWorkshopUseCase>();
            services.AddTransient<UpdateWorkshopUseCase>();
            services.AddTransient<DeleteWorkshopUseCase>();
            services.AddTransient<GetUserByLoginUseCase>();
            services.AddTransient<AddIngredUseCase>();
            services.AddTransient<UpdateIngredUseCase>();
            services.AddTransient<DeleteIngredUseCase>();
            services.AddTransient<AddProdComposUseCase>();
            services.AddTransient<UpdateProdComposUseCase>();
            services.AddTransient<DeleteProdComposUseCase>();
            services.AddTransient<DeleteProductUseCase>();
            services.AddTransient<UpdateProductUseCase>();
            services.AddTransient<AddSupplierUseCase>();
            services.AddTransient<DeleteSupplierUseCase>();
            services.AddTransient<UpdateSupplierUseCase>();
            services.AddTransient<AddTimesheetUseCase>();
            services.AddTransient<UpdateEmployeeUseCase>();
            services.AddTransient<DeleteClientUseCase>();
            services.AddTransient<AddIngredOnWarehouseUseCase>();
            services.AddTransient<UpdateClientUseCase>();
            services.AddTransient<AddCartOrderUseCase>();
            services.AddTransient<GetOrderByIdUseCase>();
            services.AddTransient<UpdateOrderStatusUseCase>();
            services.AddTransient<UpdateEmployeeInCartOrderUseCase>();

            services.AddSingleton<UserRepository, UserRepositoryImpl>();
            services.AddSingleton<UserDbRepository, UserDbRepositoryImpl>();
            services.AddSingleton<EmployeeRepository, EmployeeRepositoryImpl>();
            services.AddSingleton<ClientRepository, ClientRepositoryImpl>();
            services.AddSingleton<EmployeeDbRepository, EmployeeDbRepositoryImpl>();
            services.AddSingleton<ClientDbRepository, ClientDbRepositoryImpl>();
            services.AddSingleton<ProductRepository, ProductRepositoryImpl>();
            services.AddSingleton<ProductDbRepository, ProductDbRepositoryImpl>();
            services.AddSingleton<OrderRepository, OrderRepositoryImpl>();
            services.AddSingleton<OrderDbRepository, OrderDbRepositoryImpl>();
            services.AddSingleton<StatusRepository, StatusRepositoryImpl>();
            services.AddSingleton<StatusDbRepository, StatusDbRepositoryImpl>();
            services.AddSingleton<IngredsRepository, IngredsRepositoryImpl>();
            services.AddSingleton<IngredsDbRepository, IngredsDbRepositoryImpl>();
            services.AddSingleton<EmployeeRepository, EmployeeRepositoryImpl>();
            services.AddSingleton<EmployeeDbRepository, EmployeeDbRepositoryImpl>();
            services.AddSingleton<SupplierRepository, SupplierRepositoryImpl>();
            services.AddSingleton<SupplierDbRepository, SupplierDbRepositoryImpl>();
            services.AddSingleton<WorkshopRepository, WorkhopRepositoryImpl>();
            services.AddSingleton<WorkshopDbRepository, WorkshopDbRepositoryImpl>();
            services.AddSingleton<TimesheetRepository, TimesheetRepositoryImpl>();
            services.AddSingleton<TimesheetDbRepository, TimesheetDbRepositoryImpl>();
            services.AddSingleton<PaytypeRepository, PaytypeRepositoryImpl>();
            services.AddSingleton<PaytypeDbRepository, PaytypeDbRepositoryImpl>();
            services.AddSingleton<PositionRepository, PositionRepositoryImpl>();
            services.AddSingleton<PositionDbRepository, PositionDbRepositoryImpl>();
            services.AddSingleton<TypeRepository, TypeRepositoryImpl>();
            services.AddSingleton<TypeDbRepository, TypeDbRepositoryImpl>();
            services.AddSingleton<ProdComposRepository, ProdComposRepositoryImpl>();
            services.AddSingleton<ProdComposDbRepository, ProdComposDbRepositoryImpl>();
            services.AddSingleton<IngredientOnWarehouseRepository, IngredientOnWarehouseRepositoryImpl>();
            services.AddSingleton<IngredientOnWarehouseDbRepository, IngredientOnWarehouseDbRepositoryImpl>();
            services.AddSingleton<IngredientExpenseRepository, IngredientExpenseRepositoryImpl>();
            services.AddSingleton<IngredientExpenseDbRepository, IngredientExpenseDbRepositoryImpl>();
            services.AddSingleton<CartOrderRepository, CartOrderRepositoryImpl>();
            services.AddSingleton<CartOrderDbRepository, CartOrderDbRepositoryImpl>();

            services.AddSingleton<TbUserMapper>();
            services.AddSingleton<TbClientMapper>();
            services.AddSingleton<TbEmployeeMapper>();
            services.AddSingleton<TbProductMapper>();
            services.AddSingleton<GetProdMapper>();
            services.AddSingleton<GetOrderMapper>();
            services.AddSingleton<GetClientsMapper>();
            services.AddSingleton<GetOrderStatusMapper>();
            services.AddSingleton<TbOrderMapper>();
            services.AddSingleton<TbOrderStatusMapper>();
            services.AddSingleton<GetIngredsMapper>();
            services.AddSingleton<GetEmpsMapper>();
            services.AddSingleton<GetSuppliersMapper>();
            services.AddSingleton<GetWorkshopsMapper>();
            services.AddSingleton<GetTimesheetMapper>();
            services.AddSingleton<GetCartOrderMapper>();
            services.AddSingleton<GetPayTypeMapper>();
            services.AddSingleton<GetPoseMapper>();
            services.AddSingleton<TbIngredientMapper>();
            services.AddSingleton<TbIngredientTypeMapper>();
            services.AddSingleton<TbProductCompositionMapper>();
            services.AddSingleton<TbPositionMapper>();
            services.AddSingleton<TbWorkshopMapper>();
            services.AddSingleton<TbSupplierMapper>();
            services.AddSingleton<GetIngredsOnWarehouseMapper>();
            services.AddSingleton<GetIngredTypeMapper>();
            services.AddSingleton<GetIngredExpenseMapper>();

            services.AddSingleton<Func<Type, ObservableObject>>(serviceProvider => viewModelType => (ObservableObject)serviceProvider.GetRequiredService(viewModelType));
            services.AddSingleton<UVerification>();
            services.AddSingleton<EVerification>();

            services.AddPooledDbContextFactory<KursovaiaContext>(options => options.UseNpgsql("Host=172.20.105.123;Port=5432;Database=practice_9po12_21_16;Username=9po12-21-16;Password=ki9boh3Y"));
            //services.AddPooledDbContextFactory<KursovaiaContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=kursovaia_v3;Username=postgres;Password=Dtkjcbgtl2016"));

            serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }
    }

}
