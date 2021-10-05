using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Xero.NetStandard.OAuth2.Client.API;
using Xero.NetStandard.OAuth2.Api;
using Xero.NetStandard.OAuth2.Client.Model;
using Newtonsoft.Json;

namespace XeroOAuth2Integration.Controllers
{
    public class CallbackController : Controller
    {
        /// <summary>
        /// Organization connected with xero app than call this method
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        // GET: Callback
        [Route("CallBack")]
        public async Task<ActionResult> Index(string code)
        {
            var XeroTenants = new List<XeroTenants>();
            try
            {
                var objXeroClientHelper = new XeroHelper();
                var objAccountingApi = new AccountingApi();
                var XeroAccesstoken = objXeroClientHelper.GetAccessToken(code);
                if (XeroAccesstoken != null)
                {
                    //You can write code for Stored access token details, currently i am store access token in json file
                    XeroAccesstoken.ExpiresAtUtc = DateTime.UtcNow.AddSeconds(XeroAccesstoken.expires_in);
                    string jsondata = JsonConvert.SerializeObject(XeroAccesstoken);
                    string FilePath = Server.MapPath("AccessToken/AccessToken.json");
                    if (System.IO.File.Exists(FilePath))
                        System.IO.File.Delete(FilePath);
                    System.IO.File.WriteAllText(FilePath, jsondata);

                    //Get Xero app connected organization list using by access token.
                    var ConectionList = objXeroClientHelper.ConnectionLists(XeroAccesstoken.access_token);
                    XeroTenants = ConectionList;
                    foreach (var conection in ConectionList)
                    {
                        //Get organization details
                        var OrganizationDetail = await objAccountingApi.GetOrganisationsAsync(XeroAccesstoken.access_token, conection.tenantId);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return View(XeroTenants);
        }
    }
}