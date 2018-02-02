using System;
using System.Text;

namespace base64
{
    class Program
    {
        public static string text;
        public static string coded;

        public static void encode()
        {
            Console.Write("Podaj string do zakodowania: ");

            text = Console.ReadLine();

            var text_byte = Encoding.UTF8.GetBytes(text);

            coded = Convert.ToBase64String(text_byte);

            Console.WriteLine("Zakodowany string: {0}", coded);
        }

        public static void decode()
        {
            var encoded_text = Convert.FromBase64String(text);

            text = Encoding.UTF8.GetString(encoded_text);

            
            Console.WriteLine("Odkodowany string: {0}", text);
        }

        static void Main(string[] args)
        {
            int wybor = 0;

            while (true)
            {

                Console.WriteLine("Co chcesz zrobic?");
                Console.WriteLine("1. Zakodowac wiaomosc \n2. Odkodowac wiadomosc");
                wybor = Int32.Parse(Console.ReadLine());
                if (wybor == 1)
                {
                    encode();
                    Console.WriteLine("///////////////////////////////////////////////////////////");
                }
                else if (wybor == 2)
                {
                    Console.Write("Podaj string do zdekodowania: ");
                    text = Console.ReadLine();
                    decode();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
