using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureAPI.Models
{
    public class User
    {
        public string ClientId { get; set; }
        public string Token { get; set; }

        public bool Encrypted { get; set; }

    }
}
