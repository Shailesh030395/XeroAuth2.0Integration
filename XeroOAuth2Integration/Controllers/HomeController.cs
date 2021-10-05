using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xero.NetStandard.OAuth2.Api;
using Xero.NetStandard.OAuth2.Client.API;
using Xero.NetStandard.OAuth2.Client.Model;
using Xero.NetStandard.OAuth2.Model;
using System.Threading.Tasks;
using XeroOAuth2Integration.Models;

namespace XeroOAuth2Integration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateContact(string tenantId)
        {
            if (string.IsNullOrEmpty(tenantId))
            {
                return RedirectToAction("Index");
            }
            ViewBag.tenantId = tenantId;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateContact(ContactViewModel model)
        {
            try
            {
                var objXeroClientHelper = new XeroHelper();
                var objAccountingApi = new AccountingApi();

                //Get AccessToken from json file
                string FilePath = Server.MapPath("../AccessToken/AccessToken.json");
                XeroAccessToken AccessToken = new XeroAccessToken();
                using (StreamReader r = new StreamReader(FilePath))
                {
                    string json = r.ReadToEnd();
                    AccessToken = JsonConvert.DeserializeObject<XeroAccessToken>(json);
                }

                //Check access token is expire or not if expire than generate new  access token
                if (AccessToken.ExpiresAtUtc < DateTime.UtcNow)
                {
                    AccessToken = objXeroClientHelper.ReGenerateTokenFromRefreshToken(AccessToken.refresh_token);
                    //Save new token in json file
                    AccessToken.ExpiresAtUtc = DateTime.UtcNow.AddSeconds(AccessToken.expires_in);
                    string jsondata = JsonConvert.SerializeObject(AccessToken);
                    if (System.IO.File.Exists(FilePath))
                        System.IO.File.Delete(FilePath);
                    System.IO.File.WriteAllText(FilePath, jsondata);
                }

                var objXeroContact = new Contact();
                objXeroContact.Name = model.ContactName;
                objXeroContact.EmailAddress = model.ContactEmail;

                var Response = await objAccountingApi.CreateContactAsync(AccessToken.access_token, model.tenantId, objXeroContact);
                ViewBag.ContactId = Response._Contacts.FirstOrDefault().ContactID;
                ViewBag.tenantId = model.tenantId;
            }
            catch (Exception ex)
            {
                //check api exception here
            }

            return View();
        }
    }
}