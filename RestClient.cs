using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Actionstep.API.WebClient.Data_Transfer_Objects.Responses;
using Actionstep.API.WebClient.Domain_Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polly;
using Polly.Retry;

namespace ActionstepApiClient
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public enum AuthenticationType
    {
        Basic,
        NTLM,
        OAuth2
    }

    public enum AuthenticationTechnique
    {
        RollYourOwn,
        NetworkCredential,
        PrivateKey
    }
    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public AuthenticationType authType { get; set; }
        public AuthenticationTechnique authTech { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }

        private readonly HttpClient _httpClient;
        private readonly AppConfiguration _appConfiguration;

        private AppState _appState;
        private AsyncRetryPolicy<HttpResponseMessage> _policy;

        private IDictionary<string, object> ContextData => new Dictionary<string, object> { };

        public RestClient(HttpClient httpClient, AppConfiguration appConfiguration, AppState appState)
        {

            _httpClient = httpClient;
            _appConfiguration = appConfiguration;
            _appState = appState;

            _httpClient.BaseAddress = new Uri(_appState.ApiEndpoint);

            _policy = Policy.HandleResult<HttpResponseMessage>(message => message.StatusCode == HttpStatusCode.Unauthorized)
                            .RetryAsync(1, async (result, retryCount, context) =>
                            {
                                var accessTokenDto = await RefreshAccessTokenAsync();
                                if (accessTokenDto != null)
                                    UpdateAppState(accessTokenDto);
                            });

        }

        #region Matters (Actions)
        public async Task<MattersResponseDto> GetMattersAsync(int pageNumber, int pageSize, int filterByMatterTypeId)
        {
            var mattersDto = new MattersResponseDto();

            var matterTypeFilter = filterByMatterTypeId == -1 ? String.Empty : $"&actionType_eq={filterByMatterTypeId}";

            var response = await _policy.ExecuteAsync(async context =>
            {
                var message = new HttpRequestMessage(HttpMethod.Get, $"/api/rest/actions?include=actionType,assignedTo&fields[actions]=id,name,status,modifiedTimestamp,actionType,assignedTo&fields[actiontypes]=id,name&fields[participants]=id,displayName&page={pageNumber}&pageSize={pageSize}&sort=-modifiedTimestamp{matterTypeFilter}");
                message = SetMessageDefaultHeaders(message);
                return await _httpClient.SendAsync(message);
            }, ContextData);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                if (!String.IsNullOrEmpty(responseContent))
                {
                    var data = JObject.Parse(responseContent);

                    mattersDto.PageMetaDataDto = data["meta"]["paging"]["actions"].ToObject<PageMetaDataResponseDto>();

                    if (mattersDto.PageMetaDataDto.DataRows == 1)
                    {
                        mattersDto.Matters.Add(data["actions"].ToObject<MattersResponseDto.MatterDto>());
                    }
                    else
                    {
                        foreach (JToken item in data["actions"].Children())
                        {
                            mattersDto.Matters.Add(item.ToObject<MattersResponseDto.MatterDto>());
                        }
                    }

                    foreach (JToken item in data["linked"]["actiontypes"].Children())
                    {
                        mattersDto.LinkedMatterTypes.Add(item.ToObject<MattersResponseDto.LinkedMatterTypeDto>());
                    }

                    foreach (JToken item in data["linked"]["participants"].Children())
                    {
                        mattersDto.LinkedParticipants.Add(item.ToObject<MattersResponseDto.LinkedParticipantDto>());
                    }
                }
            }
            return mattersDto;
        }


        public async Task<IEnumerable<MatterLookupResponseDto>> GetMatterLookupAsync()
        {
            var matters = new List<MatterLookupResponseDto>();

            var response = await _policy.ExecuteAsync(async context =>
            {
                var message = new HttpRequestMessage(HttpMethod.Get, "/api/rest/actions?fields=id,name&status_nteq=Closed");
                message = SetMessageDefaultHeaders(message);
                return await _httpClient.SendAsync(message);
            }, ContextData);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                if (!String.IsNullOrEmpty(responseContent))
                {
                    var data = JObject.Parse(responseContent);
                    foreach (JToken item in data["actions"])
                    {
                        matters.Add(item.ToObject<MatterLookupResponseDto>());
                    }
                }
            }
            return matters;
        }
        #endregion

        private HttpRequestMessage SetMessageDefaultHeaders(HttpRequestMessage message)
        {
            string blStagingToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhIjoiTW1JeU1EbGxaRGxrWmpZNE1qUXdZalJqWVdJMU1UQTVabVF6WmpsbFpqaG1ZbVptWldVNU1URXpNRGczIiwiYiI6ImJsc3RhZ2luZyIsImMiOiIxMC42MC4zLjE2MSIsImciOiJUMTAwMC0xMzA2Mi0xIiwiZSI6IkYiLCJmIjoiUGFjaWZpY1wvQXVja2xhbmQiLCJoIjoiYiIsImQiOiIiLCJuYmYiOjE2MDMzNTQwNTQsImV4cCI6MTYwMzM4Mjg2NH0.LWszVeB-koNnuoGEz0Crhs5sCnPdJY9HoHykiN6TEK-y1b5705OKGUROQMLO9rdneoBywfCQxc1lhHnrvjAi2lC3EobDfxHI8vYaMU168wQBjlAXZK37ruM_FRA62R5l-QXnwtrfGH_U4IQdV09wMm9Vn6gFxEHcigQ3hNnKPDDxgfU_F20hGCiJYn3avkaU39h9s08dyFsa_XxNfSxr8gJN5-fZ6gi4i635iABU2VRvu5kW2_651T8pg4Qq4qFWECS8bkmjgv41EEXkMuLlVuFu1RAmx9WnrU7rCRsEunBfhlNnBTagxMNVP1t0HzuhMDB7TAIjXonfFd3oXnfdkQ";
            message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", blStagingToken);
            message.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.api+json");
            message.Headers.TryAddWithoutValidation("Accept", "application/vnd.api+json");
            message.Headers.Add("User-Agent", "MyApp");
            return message;
        }

        private void UpdateAppState(AccessTokenResponseDto accessTokenDto)
        {
            _appState.AccessToken = accessTokenDto.access_token;
            _appState.TokenType = accessTokenDto.token_type;
            _appState.ExpiresIn = accessTokenDto.expires_in;
            _appState.ApiEndpoint = accessTokenDto.api_endpoint;
            _appState.Orgkey = accessTokenDto.orgkey;
            _appState.RefreshToken = accessTokenDto.refresh_token;
        }

        private async Task<AccessTokenResponseDto> RefreshAccessTokenAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");

            var kvCollection = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("refresh_token", _appState.RefreshToken),
                new KeyValuePair<string, string>("client_id", _appConfiguration.ClientId),
                new KeyValuePair<string, string>("client_secret", _appConfiguration.ClientSecret),
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("redirect_uri", _appConfiguration.RedirectUrl)
            };

            var body = new FormUrlEncodedContent(kvCollection);

            var response = await client.PostAsync(_appConfiguration.AccessTokenUrl, body);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<AccessTokenResponseDto>(data);
            }
            return null;
        }
    }

}
