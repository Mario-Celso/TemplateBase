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
    }
}
