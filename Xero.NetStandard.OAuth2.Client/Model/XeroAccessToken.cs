using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero.NetStandard.OAuth2.Client.Model
{
    public class XeroAccessToken
    {
        public string id_token { get; set; }
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
        public DateTime ExpiresAtUtc { get; set; }

    }
}
