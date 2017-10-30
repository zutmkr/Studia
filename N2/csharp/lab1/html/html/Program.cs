using System.IO;
using System.Linq;
using System.Text;
using System;

namespace html
{

    public class HtmlTab
    {
        public int row, col;
        public string data_str;
        string path = "index.html";

        public HtmlTab(int row, int col, string data_str)
        {
            this.row = row;
            this.col = col;
            this.data_str = data_str; //to do wyswietlania w menu przykladowej tabeli        
        }

        public HtmlTab()
        {
            //Czytam plik tekstowy i rozbijam go na tablice podstringow
            string[] param = File.ReadLines("param.txt").First().Split(' ');

            this.row = int.Parse(param[0]);
            this.col = int.Parse(param[1]);
            this.data_str = String.Join(" ", param.Skip(2));
        }

        public void GenerateHtml()
        {
            StringBuilder sb = new StringBuilder(); //tu bede budowal swoj kod html do wygenerowania
            int count = 0;     

            sb.Append("<html><table>");

            for (int i = 0; i < this.col; i++)
            {
                sb.Append("<th>" + "Naglowek " + (i + 1).ToString() + "</th>");
            }

            int j = 0;
            for (int i = 0; i < this.row; i++)
            {
                sb.Append("<tr>");
                for (int k = 0; k < this.col; k++)
                {
                    sb.Append("<td>" + this.data_str.Split(' ')[j] + "</td>");
                    j++;
                }
                sb.Append("</tr>");
            }

            sb.Append("</table>");
            sb.Append("<footer>" + "Wygenerowano przez: Mateusz Krusinski" + "</footer></html>");
            File.WriteAllText(this.path, sb.ToString());
            
        }

        public void AddRow(HtmlTab ntable)
        {
            if (ntable.data_str == "No_Parameters_To_Show")
            {
                ntable.row = 0;
                ntable.col = 1;
                ntable.data_str = "";
            }

            ntable.row++;
            for(int i = 0; i < ntable.col; i++)
            {
                Console.Clear();
                Console.Write("Enter data (" + (i+1) + "/" + ntable.col + "): ");

                if (ntable.row == 1)
                    ntable.data_str = ntable.data_str + Console.ReadLine();
                else
                    ntable.data_str = ntable.data_str + " " + Console.ReadLine();
            }
        }

        public void AddCol(HtmlTab ntable)
        {
            
            string[] param = ntable.data_str.Split(' ');
            

            if (ntable.data_str == "No_Parameters_To_Show")
            {
                ntable.row = 1;
                ntable.col = 0;
                ntable.data_str = "";
            }

            ntable.col++;
            string[] temp = new String[ntable.row];
            for (int i = 0; i < ntable.row; i++)
            {
                Console.Clear();                                                          //odseparowac kod od interfejsu
                Console.Write("Enter data (" + (i + 1) + "/" + ntable.row + "): ");       //odseparowac kod od interfejsu
                temp[i] = Console.ReadLine();                                                //odseparowac kod od interfejsu
            }

            ntable.data_str = "";
            int k = 0,h = 0;
            for (int i = 1; i <= ntable.row * ntable.col; i++)
            {
                if (i % ntable.col == 0)
                {
                    ntable.data_str = ntable.data_str + temp[k] + " ";
                    k++;
                }
                else
                {
                    ntable.data_str = ntable.data_str + param[h] + " ";
                    h++;
                }
                
            }
            ntable.data_str = ntable.data_str.TrimEnd(' ');


        }

        public void WriteTable(HtmlTab ntable)
        {
            string[] param = ntable.data_str.Split(' ');


            for (int i = 1; i <= param.Length; i++)
            {
                Console.Write("\t\t" + param[i-1] + " ");

                if (i % ntable.col == 0)
                    Console.Write("\n");
            }   
        }
    }

    class Program
    {
        static int Main(string[] args)
        {

            // ma wczytywac dane z pliku.txt i tworzyc na jego podstawie plik html
            // dane wczytujemy na dwa sposoby albo konstruktor, albo za pomoca metod
            // i na koncu generujemy plik html gotowy do otwarcia w przegladarce
            int choice = 0;
            HtmlTab ntable = new HtmlTab(1, 1, "No_Parameters_To_Show");
            
            while (choice != 6)
            {
                
                Console.Clear();
                Console.WriteLine("\n\n\n\t\t\tHTML TABLE GENERATOR\n");
                Console.WriteLine("\t1. Generate HTML from file.");
                Console.WriteLine("\t2. Generate default HTML (using constructor).");
                Console.WriteLine("\t3. Add row.");
                Console.WriteLine("\t4. Add column.");
                Console.WriteLine("\t5. Generate HTML as seen in TABLE PREVIEW.");
                Console.WriteLine("\t6. Exit.");
                //Console.WriteLine(ntable.data_str); wlacz dla debugowania


                Console.Write("\n\t>>> ");
                Console.WriteLine("\n\n\t\t ----TABLE PREVIEW----");
                ntable.WriteTable(ntable);

                Console.SetCursorPosition(12, 12);
                choice = int.Parse(Console.ReadLine());
                
                if (choice == 1)
                {
                    HtmlTab html_from_file = new HtmlTab();
                    html_from_file.GenerateHtml();
                    Console.WriteLine("\n\t\t>>> HTML generated successfully! <<<");
                    ntable = html_from_file;
                    System.Threading.Thread.Sleep(2000);
                }
                else if (choice == 2)
                {
                    HtmlTab html_from_constructor = new HtmlTab(2, 2, "2 15 13 45");
                    html_from_constructor.GenerateHtml();
                    Console.WriteLine("\n\t\t>>> HTML generated successfully! <<<");
                    ntable = html_from_constructor;
                    System.Threading.Thread.Sleep(2000);
                }
                else if (choice == 3)
                {
                    ntable.AddRow(ntable);
                }
                else if (choice == 4)
                {
                    ntable.AddCol(ntable);
                }
                else if (choice == 5)
                {
                    HtmlTab html_from_generator = new HtmlTab(ntable.row, ntable.col, ntable.data_str);
                    html_from_generator.GenerateHtml();
                    Console.WriteLine("\n\t\t>>> HTML generated successfully! <<<");
                    ntable = html_from_generator;
                    System.Threading.Thread.Sleep(2000);
                }
                else if (choice == 6)
                {
                    Console.WriteLine("\n\t\t        >>> Bye bye! <<<");
                    System.Threading.Thread.Sleep(2000);
                }
            }            
            return 0;
        }
    }
}
