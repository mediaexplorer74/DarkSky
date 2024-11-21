using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DarkSky.Core.Services;
using FishyFlip.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DarkSky.Core.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        private ATProtoService atProtoService;

        [ObservableProperty]
        private FeedProfile currentProfile;

        [ObservableProperty]
        private string errorMessage;

        public IRelayCommand LoginCommand { get; }

        public ProfileViewModel(ATProtoService atProtoService)
        {
            this.atProtoService = atProtoService;
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
                
                //setup();                
            }

            setup();

            LoginCommand = new RelayCommand(OnSome);

        }//

        private async void setup()
        {
            Result<FeedProfile> profiles = default;

            try
            {
                profiles = await this.atProtoService.ATProtocolClient.Actor.GetProfileAsync(
                            atProtoService.Session.Did);

                CurrentProfile = profiles.AsT0;
            }
            catch (Exception ex) 
            {
                Debug.WriteLine("[ex] ProfileViewModel bug: " + ex.Message);
                ErrorMessage = ex.Message;
            }
        }

        private async void OnSome()
        {
            //
        }
    }
}
