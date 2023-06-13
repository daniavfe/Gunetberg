﻿using Gunetberg.Port.Output;
using System.Security.Cryptography;
using System.Text;

namespace Gunetberg.Client.Hash
{
    public class Sha256HashClient : IHashClient
    {
        public string Hash(string text)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
