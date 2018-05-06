using System.Diagnostics;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using CS481Final.Views;
using CS481Final.ViewModels;
using Xamarin.Forms.Xaml;
using CS481Final.Services;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CS481Final
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnInitialized)}");
            InitializeComponent();

            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(CS481FinalPage)}"); 

        }

        protected override void RegisterTypes(Prism.Ioc.IContainerRegistry containerRegistry)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RegisterTypes)}");

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<CS481FinalPage, CS481FinalPageViewModel>();
            containerRegistry.RegisterForNavigation<LogPage, LogPageViewModel>();
            containerRegistry.RegisterForNavigation<AddItemPage, AddItemPageViewModel>();
            containerRegistry.RegisterForNavigation<AboutPage, AboutPageViewModel>();
            containerRegistry.RegisterForNavigation<CreatorsPage, CreatorsPageViewModel>();
            containerRegistry.RegisterSingleton<IRepository, Repository>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
