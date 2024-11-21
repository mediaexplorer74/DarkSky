using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DarkSky.Core.Services;
using FishyFlip;
using FishyFlip.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;


namespace DarkSky.Core.ViewModels
{
	public partial class MainViewModel : ObservableObject
	{

		private INavigationService navigationService;

        private ATProtoService atProtoService;

        [ObservableProperty]
        private string errorMessage;

        [ObservableProperty]
		private FeedProfile currentProfile;

		public MainViewModel(ATProtoService atProtoService, INavigationService navigationService)
		{
			this.atProtoService = atProtoService;
			this.navigationService = navigationService;
            SomeCommand = new RelayCommand(OnSome);

            if (this.atProtoService.Session is null)
			{
                //navigationService.NavigateTo<LoginViewModel>();

                //try to recover Session
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

              

                if (this.atProtoService.Session is null)
                {
                    //navigationService.NavigateTo<LoginViewModel>();
                    
                    ErrorMessage = "Session is empty.";
                    return;
                }
                setup();
            }
			else
			{
				setup();
			}
		}

        public IRelayCommand SomeCommand { get; }


        private async void OnSome()
        {

            // simplest username/pass validation
            if (currentProfile == null)
            {
                ErrorMessage = "Current Profile is empty!";
                return;
            }
           
        }//OnSome

        private async void setup()
		{
            ATDid did = this.atProtoService.Session.Did;
            Result<FeedProfile?> profiles = 
				await this.atProtoService.ATProtocolClient
				  .Actor.GetProfileAsync(did);

			CurrentProfile = profiles.AsT0;
		}
	}
}
