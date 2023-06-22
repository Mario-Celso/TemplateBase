using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Base
{
    public class Hash
    {
        //private static string CreateSalt()
        //{
        //    var randomNumber = new byte[32];
        //    var rng = RandomNumberGenerator.Create();
        //    rng.GetBytes(randomNumber);

        //    return Convert.ToBase64String(randomNumber);
        //}

        public string CryptString(string text)
        {
            return BCrypt.Net.BCrypt.HashPassword(text);
        }

        public bool DecryptString(string text, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(text, hash);
        }
    }
}
