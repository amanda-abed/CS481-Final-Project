using System.Diagnostics;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using CS481Final.Views;
using CS481Final.ViewModels;

namespace CS481Final
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnInitialized)}");
            InitializeComponent();

            NavigationService.NavigateAsync(nameof(CS481FinalPage));
        }

        protected override void RegisterTypes(Prism.Ioc.IContainerRegistry containerRegistry)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RegisterTypes)}");

            containerRegistry.RegisterForNavigation<CS481FinalPage, CS481FinalPageViewModel>();
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
