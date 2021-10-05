using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero.NetStandard.OAuth2.Client.Model
{
    public class XeroTenants
    {
        public string id { get; set; }
        public string authEventId { get; set; }
        public string tenantId { get; set; }
        public string tenantType { get; set; }
        public string tenantName { get; set; }        
        public DateTime createdDateUtc { get; set; }
        public DateTime updatedDateUtc { get; set; }

    }
}
