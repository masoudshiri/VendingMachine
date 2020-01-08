using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VendoreMachine.Views;
using Unity;
using VendoreMachine.ViewModels;
using VendoreMachine.Common;
using VendoreMachine.Data;
using VendoreMachine.Domain;
using AutoMapper;
using VendoreMachine.Dto;

namespace VendoreMachine
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BeverageMakingStep, BeverageMakingStepDTO > ();
                cfg.CreateMap<Beverage, BeverageDTO > ();
            });

            IMapper mapper = config.CreateMapper();
            UnityHelper.InjectStub(mapper);

            UnityHelper.Register<IProccessBuilder, ProccessBuilder>();
            UnityHelper.Register<ISampleData<Beverage>, BeverageDbSet>();
            UnityHelper.Register<ISampleData<BeverageMakingStep>, BeverageMakingStepDbSet>();
            UnityHelper.Register(typeof(IRepository<>), typeof(Repository<>));
            UnityHelper.Register<IBeverageMakingStepRepository, BeverageMakingStepRepository>();
            UnityHelper.Register<MainViewModel>();
            UnityHelper.InjectStub(new User {Id=1,FirstName="Masoud",LastName="Shiri",PassWord="****",UserName="shiri.masoud@yahoo.com" });

            var mainWindowViewModel = UnityHelper.Retrieve<MainViewModel>();
            var window = new MainWindow { DataContext = mainWindowViewModel };
            window.Show();
        }
    }
}
