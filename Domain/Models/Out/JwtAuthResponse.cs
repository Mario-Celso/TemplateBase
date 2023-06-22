using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Out
{
    [Serializable]
    public class JwtAuthResponse
    {
        public string token { get; set; }
        public string user_name { get; set; }
        public int expires_in { get; set; }
    }
}
