using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Actionstep.API.WebClient.Domain_Models;
using Actionstep.API.WebClient.View_Models;
using Actionstep.API.WebClient.Paging;
using Actionstep.API.WebClient.Data_Transfer_Objects.Responses;

namespace ActionstepApiClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        #region UI Event Handlers
        private void cmdGo_Click(object sender, EventArgs e)
        {
            Task.Run(async () => await this.GetMattersAsync());

        }

        private async Task GetMattersAsync()
        {
            // set httpClient, App Config and App State

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");

            AppConfiguration appConfig = new AppConfiguration();
            appConfig.ClientId = "LPNAUIS5PHCKDEWAH5WFHLJNHSQU76HZITKHJQJ7XISC1YXQW";
            appConfig.ClientSecret = "4B3SPDE4O45MRWY7PLYE1KNFDDBQYAMPZ455UCXGO3ALP4PSUG";
            appConfig.Scopes = "all";
            appConfig.AuthorizeUrl = "https://api.actionstepstaging.com/api/oauth/authorize";
            appConfig.AccessTokenUrl = "https://api.actionstepstaging.com/api/oauth/token";
            appConfig.RedirectUrl = "https://f164d484eeee.au.ngrok.io/signin";

            AppState appState = new AppState();

            appState.ApiEndpoint = "https://ap-southeast-2.actionstepstaging.com/api/";
            appState.AccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhIjoiTW1JeU1EbGxaRGxrWmpZNE1qUXdZalJqWVdJMU1UQTVabVF6WmpsbFpqaG1ZbVptWldVNU1URXpNRGczIiwiYiI6ImJsc3RhZ2luZyIsImMiOiIxMC42MC4zLjE2MSIsImciOiJUMTAwMC0xMzA2Mi0xIiwiZSI6IkYiLCJmIjoiUGFjaWZpY1wvQXVja2xhbmQiLCJoIjoiYiIsImQiOiIiLCJuYmYiOjE2MDMzNTQwNTQsImV4cCI6MTYwMzM4Mjg2NH0.LWszVeB-koNnuoGEz0Crhs5sCnPdJY9HoHykiN6TEK-y1b5705OKGUROQMLO9rdneoBywfCQxc1lhHnrvjAi2lC3EobDfxHI8vYaMU168wQBjlAXZK37ruM_FRA62R5l-QXnwtrfGH_U4IQdV09wMm9Vn6gFxEHcigQ3hNnKPDDxgfU_F20hGCiJYn3avkaU39h9s08dyFsa_XxNfSxr8gJN5-fZ6gi4i635iABU2VRvu5kW2_651T8pg4Qq4qFWECS8bkmjgv41EEXkMuLlVuFu1RAmx9WnrU7rCRsEunBfhlNnBTagxMNVP1t0HzuhMDB7TAIjXonfFd3oXnfdkQ";
            appState.TokenType = "bearer";
            appState.ExpiresIn = 28800;
            appState.Orgkey = "blstaging";
            appState.RefreshToken = "YTc2ZTUxMmYxOTNjNzY5NDc3ZjA3M2FmMWU1ZTY1MTY3NDUyYTgxMTQ5MDE0";


            RestClient rClient = new RestClient(httpClient, appConfig, appState);

            MattersViewModel ViewModel = new MattersViewModel();
            ViewModel.Loading = true;
            ViewModel.PageNumber = 1;
            //

            var mattersDto = await rClient.GetMattersAsync(ViewModel.PageNumber, ViewModel.PageSize, ViewModel.FilterByMatterType);

            ViewModel.MatterPagedData = new Page<MatterViewModel>(mattersDto.PageMetaDataDto.PageNumber, mattersDto.PageMetaDataDto.PageSize,
                                                                  mattersDto.PageMetaDataDto.PageCount, mattersDto.PageMetaDataDto.RecordCount,
                                                                  ConversionFactory.ConvertToDomainModel(mattersDto));

            if (ViewModel.MatterPagedData.TotalRowCount > 0 && ViewModel.FilterByMatterType > 0)
            {
                var matterList = ViewModel.MatterPagedData.DataCollection.Select(x => x.MatterId).ToList();
                /*var customDataRecords = await rClient.GetDataCollectionRecordValuesAsync(matterList, ViewModel.FilterByMatterType);

                //ViewModel.CustomData.Clear();

                foreach (var dataCollectionRecordValue in customDataRecords.DataCollectionRecordValues)
                {
                    if (ViewModel.CustomData.ContainsKey(dataCollectionRecordValue.Links.MatterId))
                    {
                        ViewModel.CustomData[dataCollectionRecordValue.Links.MatterId].Add(dataCollectionRecordValue.Links.DataCollectionFieldId, dataCollectionRecordValue.Value);
                    }
                    else
                    {
                        ViewModel.CustomData.Add(dataCollectionRecordValue.Links.MatterId,
                            new Dictionary<string, string> { { dataCollectionRecordValue.Links.DataCollectionFieldId, dataCollectionRecordValue.Value } });
                    }
                }*/
            }

            ViewModel.Loading = false;

            debugOutput("Rest Client Created");


            debugOutput(mattersDto.ToString());
        }

        #endregion

        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }

        private void rdoBearer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoNetCred_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoRollYourOwn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoOAuth2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoNTLM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoBasic_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}