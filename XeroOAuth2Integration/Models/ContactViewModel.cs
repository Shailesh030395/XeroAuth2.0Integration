using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XeroOAuth2Integration.Models
{
    public class ContactViewModel
    {
        public string tenantId { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
    }
}