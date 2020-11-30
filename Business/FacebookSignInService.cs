using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using SSG_API.Models.External;
using Microsoft.AspNetCore.Identity;
using SSG_API.Domain;
using System;
using SSG_API.Models;
using System.Security.Claims;
using SSG_API.Security;

namespace SSG_API.Business
{
    public class FacebookSignInService
    {
        private string _accessToken;
        private string _appId;
        private UserManager<ApplicationUser> _userManager;
        private AccessManager _accessManager;

        public FacebookSignInService(
            UserManager<ApplicationUser> userManager,
            AccessManager accessManager,
            FacebookConfigurations facebookConfigurations)
        {
            _accessToken = facebookConfigurations.AcessToken;
            _appId = facebookConfigurations.AppId;
            _userManager = userManager;
            _accessManager = accessManager;
        }

        private async Task<bool> IsValidAccessToken(string inputToken)
        {
            using (var client = new HttpClient())
            {
                string url = $@"https://graph.facebook.com/debug_token?input_token={inputToken}&access_token={_accessToken}";

                var resultContent = await (await client.GetAsync(url)).Content.ReadAsStringAsync();

                var resultContentObject = JsonConvert.DeserializeObject<FacebookTokenValidationResult>(resultContent);


                bool isValid = resultContentObject?.Data?.IsValid == null ? false : resultContentObject.Data.IsValid;
                bool isSsgGenerated = resultContentObject?.Data?.AppId == null ? false : resultContentObject.Data.AppId == _appId;

                return isValid && isSsgGenerated;
            }
        }

        private async Task<FacebookUserInfoResult> GetUserData(string inputToken)
        {
            using (var client = new HttpClient())
            {
                string url = $@"https://graph.facebook.com/v9.0/me?fields=name,email,picture&access_token={inputToken}";

                var resultContent = await (await client.GetAsync(url)).Content.ReadAsStringAsync();

                var resultContentObject = JsonConvert.DeserializeObject<FacebookUserInfoResult>(resultContent);

                return resultContentObject;
            }
        }

        public async Task<object> LogIn(string userAccessToken)
        {
            var isValidToken = await IsValidAccessToken(userAccessToken);

            if (!isValidToken)
            {
                return new
                {
                    Authenticated = false,
                    Message = "Falha ao autenticar"
                };
            }

            var userData = await GetUserData(userAccessToken);

            var user = await _userManager.FindByEmailAsync(userData.Email);

            if (user == null)
            {
                var appUser = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = userData.Email,
                    UserName = userData.Email,
                    NomeCompleto = userData.Name,
                    LinkFoto = userData.FacebookPicture.Data.Url.AbsoluteUri
                };

                var creationResult = await _userManager.CreateAsync(appUser);

                if (!creationResult.Succeeded)
                {
                    return new
                    {
                        Authenticated = false,
                        Message = "Falha ao criar o usuário"
                    };
                }

                return new
                {
                    Authenticated = false,
                    Message = "Usuário criado com sucesso",
                    User = new
                    {
                        Id = appUser.Id,
                        Email = appUser.Email,
                        NomeCompleto = appUser.NomeCompleto,
                        LinkFoto = appUser.LinkFoto
                    }
                };
            }

            return _accessManager.GenerateToken(user);
        }
    }
}
