using HTB_Updates_Shared_Resources.Models;
using HTB_Updates_Shared_Resources.Models.Api;
using HTB_Updates_Shared_Resources.Models.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
//using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Serilog;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;

namespace HTB_Updates_Shared_Resources.Services
{
    public interface IHTBApiV1Service
    {
        Task<int> GetHTBUserIdByName(string username);
        // Task<int> GetHTBIdByAccountId(string accountId);
    }

    public class HTBApiV1Service : IHTBApiV1Service
    {
        //private readonly HttpClient _client;
        private readonly IConfigurationRoot _configuration;

        public HTBApiV1Service(IServiceProvider serviceProvider)
        {
            _configuration = serviceProvider.GetRequiredService<IConfigurationRoot>();
            //_client = new HttpClient { BaseAddress = new Uri("https://www.hackthebox.com") };
        }

        public async Task<int> GetHTBUserIdByName(string username)
        {
            int user = -1;
            var response = await MakeApiCall($"https://labs.hackthebox.com/api/v4/search/fetch?query={username}&tags=%5B%22users%22%5D");
            dynamic json = JsonConvert.DeserializeObject(response);

            if(json == null)
            {
                return -1;
            }

            var jArray = (JArray)json.users;

            foreach (var data in jArray) {
                var name = data["value"].ToString();
                if (String.Equals(username, name)) {
                    user = int.Parse(data["id"].ToString());
                    break;
                }
            }

            return user;
        }

        // public async Task<int> GetHTBIdByAccountId(string accountId) {
        //     if (!Regex.IsMatch(accountId, @"^[a-zA-Z0-9]+$")) return -1;
        //     var response = MakeApiCall($"/api/users/identifier/{accountId}");
        //     dynamic user = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
        //     return (int)user.user_id;
        // }
        private async Task<string> MakeApiCall(string url)
        {
            var client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
            
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration.GetValue<string>("V1ApiToken"));
            var response = await client.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
