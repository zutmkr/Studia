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
        // The string is currently stored in the 
        // StreamWriters buffer. Flushing the stream will 
        // force the string into the MemoryStream.
        sw.Flush();

        var myStr = GetCipherText(ms);

        // If we dispose the StreamWriter now, it will close 
        // the BaseStream (which is our MemoryStream) which 
        // will prevent us from reading from our MemoryStream
        //DON'T DO THIS - sw.Dispose();

        // The StreamReader will read from the current 
        // position of the MemoryStream which is currently 
        // set at the end of the string we just wrote to it. 
        // We need to set the position to 0 in order to read 
        // from the beginning.
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
