using DarkSky.Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;



namespace DarkSky
{
    
    public sealed partial class LoginPage : Page
    {
		//private LoginViewModel ViewModel 
        //    = App.Current.Services.GetService<LoginViewModel>();

		public LoginPage()
        {
            this.InitializeComponent();
            this.DataContext = App.Current.Services.GetService<LoginViewModel>();
        }
    }
}
