using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DarkSky.Core.Services;
using Newtonsoft.Json;
//using Google.Protobuf.WellKnownTypes;



namespace DarkSky.Core.ViewModels
{
	public partial class LoginViewModel : ObservableObject
	{
        private INavigationService navigationService;

        private ATProtoService atProtoService;
        
        [ObservableProperty]
		private string usernameBox;

		[ObservableProperty]
		private string passwordBox;

        [ObservableProperty]
        private string errorMessage;


		public LoginViewModel(ATProtoService atProtoService, INavigationService navigationService)
		{
            this.atProtoService = atProtoService;
            this.navigationService = navigationService;
            LoginCommand = new RelayCommand(OnLogin);
        }

       
        public IRelayCommand LoginCommand { get; }

        private async void OnLogin()
        {

            // simplest username/pass validation
            if (string.IsNullOrWhiteSpace(UsernameBox) || string.IsNullOrWhiteSpace(PasswordBox))
            {
                ErrorMessage = "Username is empty (or password is empty).";
                return;
            }

           
            await this.atProtoService.LoginAsync(usernameBox, passwordBox);

            if (this.atProtoService.Session is not null)
            {
                //success

                ErrorMessage = string.Empty;

                //TODO - try to save session
                StorageManager.Init();

                string json1 = JsonConvert.SerializeObject(
                    this.atProtoService.ATProtocolClient.AuthSession);
                string json2 = JsonConvert.SerializeObject(this.atProtoService.Session);
                StorageManager.WriteSimpleSetting("ProtoServiceState", json1);
                StorageManager.WriteSimpleSetting("Session", json2);
                //StorageManager.WriteSimpleSetting("SessionHandle", this.atProtoService.Session.Handle);

                //StorageManager.WriteSimpleSetting("SessionAccessJwt", this.atProtoService.Session.AccessJwt);
                //StorageManager.WriteSimpleSetting("SessionRefreshJwt", this.atProtoService.Session.RefreshJwt);

                //StorageManager.WriteSimpleSetting("SessionDidDoc", this.atProtoService.Session.DidDoc);
                //StorageManager.WriteSimpleSetting("SessionDid", this.atProtoService.Session.Did);
                //StorageManager.WriteSimpleSetting("SessionEmail", this.atProtoService.Session.Email);

                navigationService.NavigateTo<MainViewModel>();

            }
            else
            {
                // no success

                ErrorMessage = "Wrong username or password.";
            }
		}//OnLogin
	}
}
