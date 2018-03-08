using System;
using System.Text;
using OpenPop.Pop3;
using OpenPop.Mime;



namespace pop3
{
    class Program
    {
        static Pop3Client client = new Pop3Client();

        public static string  username = @"recent:xxx", password = @"xxx"; //dla Google
        static StringBuilder builder = new StringBuilder();

        static void Main(string[] args)
        {
            client.Connect("pop.gmail.com", 995, true);
            client.Authenticate(username, password);

            Console.WriteLine("Sprawdzam skrzynke");
            var count = client.GetMessageCount();
            Console.WriteLine("Ilosc maili na skrzynce: {0}", count);
            Console.WriteLine("Zostanie wypisany ostani otrzymany email, nacisnik klawisz by kontynuowac");
            Console.ReadKey();

            Message message = client.GetMessage(count);
            MessagePart plainText = message.FindFirstPlainTextVersion();

            string header = message.Headers.Subject;
            header = "TEMAT WIADOMOSCI:\t" + header + "\n";
            string from = message.Headers.From.ToString();
            from = "OD KOGO:\t\t" + from + "\n\n\n";

            builder.Append(header);
            builder.Append(from);
            builder.Append(plainText.GetBodyAsText());

            Console.WriteLine();
            Console.WriteLine(builder.ToString());
            Console.ReadKey();

        }
    }
}
