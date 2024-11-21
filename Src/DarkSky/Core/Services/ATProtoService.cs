﻿using DarkSky.Core.Classes;
using DarkSky.Core.ViewModels;
using FishyFlip;
using FishyFlip.Models;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DarkSky.Core.Services
{
	public class ATProtoService
	{
		public ATProtocol ATProtocolClient = new ATProtocolBuilder().Build();
		public Session? Session;

		private INavigationService navigationService;
		private ICredentialService credentialService;
		public ATProtoService(INavigationService navigationService, 
			ICredentialService credentialService)
		{
			this.navigationService = navigationService;
			this.credentialService = credentialService;

			if (credentialService.Count() == 0)
			{
                //navigationService.NavigateTo<LoginViewModel>();
                navigationService.NavigateTo<MainViewModel>();
            }
			else
			{
				setup();
			}
		}

		private async void setup()
		{
			Credential credentials = credentialService.GetCredential();
			await LoginAsync(credentials.username, credentials.password);
			navigationService.NavigateTo<MainViewModel>();
		}

        public async Task LoginAsync(string username, string password)
        {
			Session = await ATProtocolClient.AuthenticateWithPasswordAsync(username, password)
              ?? null;
        }
    }
}
