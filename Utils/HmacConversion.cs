using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SecureAPI.Utils
{
    public class HmacConversion
    {
        public static string CreateToken(string message, string secret)
        {
            secret ??= "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                var x = Convert.ToBase64String(hashmessage);
                return x;
            }
        }
    }
}
