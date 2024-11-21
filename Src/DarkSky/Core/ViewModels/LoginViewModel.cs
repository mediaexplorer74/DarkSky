using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DarkSky.Core.Services;
using FishyFlip.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System;
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

            StorageManager.Init();

            string json1 = "";
            string json2 = "";

            try
            {
                json1 = StorageManager.ReadSimpleSetting("ProtoServiceState")
                    .ToString();
                json2 = StorageManager.ReadSimpleSetting("Session")
                    .ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[ex]StorageManager.ReadSimpleSetting(Session).ToString" +
                    " exception: " + ex.Message);
            }

            // Plan A - check stored session
            try
            {
                this.atProtoService.ATProtocolClient.AuthSession
                    = JsonConvert.DeserializeObject<AuthSession>(json1);
                this.atProtoService.Session = JsonConvert.DeserializeObject<Session>(json2);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[ex] JsonConvert.DeserializeObject<Session>(json) exception: "
                    + ex.Message);
            }

            if (this.atProtoService.Session is not null)
            {
                ErrorMessage = string.Empty;
                navigationService.NavigateTo<MainViewModel>();
            }

            // Plan B - do login

            LoginCommand = new RelayCommand(OnLogin);
        }

       
        public IRelayCommand LoginCommand { get; }

        private async void OnLogin()
        {
           
            StorageManager.Init();

            string json1 = "";
            string json2 = "";

           
            // simplest username/pass validation
            if (string.IsNullOrWhiteSpace(UsernameBox) || string.IsNullOrWhiteSpace(PasswordBox))
            {
                ErrorMessage = "Username is empty (or password is empty).";
                return;
            }


            await this.atProtoService.LoginAsync(usernameBox, passwordBox);
         
            // auth ok?
            if (this.atProtoService.Session is not null)
            {
                //success

                ErrorMessage = string.Empty;

                // save session
                
                json1 = JsonConvert.SerializeObject(
                    this.atProtoService.ATProtocolClient.AuthSession);
                json2 = JsonConvert.SerializeObject(this.atProtoService.Session);
                StorageManager.WriteSimpleSetting("ProtoServiceState", json1);
                StorageManager.WriteSimpleSetting("Session", json2);
                /*
                StorageManager.WriteSimpleSetting("SessionHandle", this.atProtoService.Session.Handle);

                StorageManager.WriteSimpleSetting("SessionAccessJwt", this.atProtoService.Session.AccessJwt);
                StorageManager.WriteSimpleSetting("SessionRefreshJwt", this.atProtoService.Session.RefreshJwt);

                StorageManager.WriteSimpleSetting("SessionDidDoc", this.atProtoService.Session.DidDoc);
                StorageManager.WriteSimpleSetting("SessionDid", this.atProtoService.Session.Did);
                StorageManager.WriteSimpleSetting("SessionEmail", this.atProtoService.Session.Email);
                */

                navigationService.NavigateTo<MainViewModel>();

            }
            else
            {
                // no success
                ErrorMessage = "Wrong username or password (or BlueSky service not available...)";
            }
		}//OnLogin
	}
}
