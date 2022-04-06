using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SimpleTokenGenerator
{
    public class SimpleTokenGenerator
    {
        /// <summary>
        ///  This function returns a signature[encrypted token] based upon provided timestamp, token and a secret key that is shared between the sender and a receiver.
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <param name="token"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static string GetTokenSignature(double timeStamp, string token, string secret)
        {
            var encryptedToken = GetHash(timeStamp.ToString() + token, secret);
            return encryptedToken;
        }

        /// <summary>
        ///  Returns a random string of length 50
        /// </summary>
        /// <returns></returns>
        public static string GetToken()
        {
            var plainToken = GetRandomString();
            return plainToken;
        }

        #region helper methods
        private static string GetRandomString()
        {
            var allChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var resultString = new string(
               Enumerable.Repeat(allChars, 50)
               .Select(str => str[random.Next(str.Length)]).ToArray());

            return resultString;
        }
        private static string GetHash(string userString, string signingKey)
        {
            var encoding = new UTF8Encoding();

            var textBytes = encoding.GetBytes(userString);
            var keyBytes = encoding.GetBytes(signingKey);

            byte[] hashBytes;

            using (var hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
        #endregion
    }
}
