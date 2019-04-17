using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace JustMyResumeApi.Data
{
    public class DBSecurity
    {
        static internal string hashPassword(string password)
        {
            byte[] salt = Encoding.ASCII.GetBytes("a0a3b103803b4ef99a3b759c9d63504b");

            string hashed = Convert.ToBase64String(
                    KeyDerivation.Pbkdf2(
                        password: password,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 10000,
                        numBytesRequested: 256 / 8
                    )
            );

            return hashed;
        }
    }
}
