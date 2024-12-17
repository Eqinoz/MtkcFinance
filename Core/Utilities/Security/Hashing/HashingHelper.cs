﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(
            string password, out byte[] pswHash, out byte[] pswSalt)
        {
            using (var hmac= new System.Security.Cryptography.HMACSHA512())
            {
                pswSalt = hmac.Key;
                pswHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password,  byte[] pswHash,  byte[] pswSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(pswSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != pswHash[i])
                    {
                        return false;
                    }

                }
            }
            return true;
        }
    }
}
