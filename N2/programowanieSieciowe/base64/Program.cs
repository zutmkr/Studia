using System;
using System.IO;
using System.Security.Cryptography;

namespace Csharp
{
    class Program
    {
        private static string GetCipherText(MemoryStream memoryStream)
        {
            byte[] buffer  = memoryStream.ToArray();
            return Convert.ToBase64String(buffer, 0, buffer.Length);
        }

        private static string DecryptString(string cipherText, byte[] key, byte[] iv)
        {
            var serviceProvider = new TripleDESCryptoServiceProvider();

            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))

            using (var cryptoStream = 
                new CryptoStream(memoryStream,
                    serviceProvider.CreateDecryptor(key, iv),
                    CryptoStreamMode.Read))
            
            using (StreamReader reader = new StreamReader(cryptoStream))
            {
                return reader.ReadToEnd();
            }
            
        }
        static void Main(string[] args)
        {
            using (var ms = new MemoryStream())
    {
        var sw = new StreamWriter(ms);
        sw.WriteLine("Hello World");

        sw.Flush();

        var myStr = GetCipherText(ms);

        ms.Position = 0;
        var sr = new StreamReader(ms);
        //var myStr = sr.ReadToEnd();
        Console.WriteLine(myStr);
    }

    Console.WriteLine("Press any key to continue.");
    Console.Read();
        }
    }
}
