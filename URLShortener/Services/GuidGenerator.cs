﻿using System.Security.Cryptography;
using System.Text;

namespace URLShortener.Services
{
    public class GuidGenerator
    {
        private static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static Guid Create(string input)
        {
            Guid result;

            using (MD5 mdHash = MD5.Create())
            {
                string hash = GuidGenerator.GetMd5Hash(mdHash, input);
                result = new Guid(hash);
            }
            return result;
        }


    }
}