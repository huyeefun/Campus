using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Campus.Utility
{
    public class MD5Hash
    {
        public static string Create(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                return Encoding.ASCII.GetString(result);
            }
        }
    }
}
