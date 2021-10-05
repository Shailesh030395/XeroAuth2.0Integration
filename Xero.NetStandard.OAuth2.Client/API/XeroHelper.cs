using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using Xero.NetStandard.OAuth2.Client.Model;

namespace Xero.NetStandard.OAuth2.Client.API
{
    public class XeroHelper
    {
        private string XeroClientId = ConfigurationSettings.AppSettings["XeroClientId"];
        private string XeroClientSecret = ConfigurationSettings.AppSettings["XeroClientSecret"];
        private string XeroCallbackUri = ConfigurationSettings.AppSettings["XeroCallbackUri"];

        /// <summary>
        /// Get access token by redirect url code.
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public XeroAccessToken GetAccessToken(string Code)
        {
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(this.XeroClientId + ":" + this.XeroClientSecret);
            var BasicAuthorizeString = "Basic " + System.Convert.ToBase64String(data);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient("https://identity.xero.com/connect/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", BasicAuthorizeString);
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("code", Code);
            request.AddParameter("redirect_uri", XeroCallbackUri);
            var response = client.Execute<XeroAccessToken>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                throw new Exception(response.Content);
            }
        }

        /// <summary>
        /// Get Xero auth2.0 app with connected organization list
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <returns></returns>
        public List<XeroTenants> ConnectionLists(string AccessToken)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var BearerAuthorizeString = "Bearer  " + AccessToken;
            var client = new RestClient("https://api.xero.com/connections");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", BearerAuthorizeString);
            var response = client.Execute<List<XeroTenants>>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                throw new Exception(response.Content);
            }
        }
        /// <summary>
        /// Re-Generate Access token by Refresh Token
        /// Access tokens expire after 30 minutes so we need to refresh token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public XeroAccessToken ReGenerateTokenFromRefreshToken(string refreshToken)
        {
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(this.XeroClientId + ":" + this.XeroClientSecret);
            var BasicAuthorizeString = "Basic " + System.Convert.ToBase64String(data);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient("https://identity.xero.com/connect/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("grant_type", "refresh_token");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", BasicAuthorizeString);
            request.AddParameter("refresh_token", refreshToken);
            var response = client.Execute<XeroAccessToken>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                throw new Exception(response.Content);
            }
        }
        /// <summary>
        /// Remove organization Connection from Xero auth2.0 app
        /// </summary>
        /// <param name="conectionId"></param>
        /// <param name="AuthorizeToken"></param>
        /// <returns></returns>
        public bool RemoveConnection(string conectionId, String AuthorizeToken)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var BearerAuthorizeString = "Bearer  " + AuthorizeToken;
            var client = new RestClient("https://api.xero.com/connections/" + conectionId + "");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", BearerAuthorizeString);
            var response = client.Execute<List<XeroTenants>>(request);
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
