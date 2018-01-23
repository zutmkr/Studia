using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Text.RegularExpressions;


namespace resize
{
    class Program
    {
        public static List<int> resolution = new List<int>();
        public static string inputdir = Environment.CurrentDirectory;
        public static string outputdir;
        public static bool outb = false;
        public static string[] jpg_files;
        public static Bitmap bmp;


        public static void get_args(string[] args)
        {
            foreach (string arg in args)
            {
                if (arg.Contains("-res"))
                {
                    for (Match match = Regex.Match(arg, @"\d+"); match.Success; match = match.NextMatch())
                    {
                        resolution.Add(int.Parse(match.Value, NumberFormatInfo.InvariantInfo));

                    }
                }
                else if (arg.Contains("-inputdir"))
                {
                    inputdir = arg.Substring(arg.LastIndexOf("=") + 1);
                }
                else if (arg.Contains("-outputdir"))
                {
                    outputdir = arg.Substring(arg.LastIndexOf("=") + 1);
                    outb = true;

                }
            }
            if (!outb)
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\output");
                outputdir = Environment.CurrentDirectory + @"\output";
            }
        }

        public static void get_images()
        {
            jpg_files = Directory.GetFiles(inputdir, "*.jpg").Select(Path.GetFileName).ToArray();
        }

        public static Bitmap resize_image(Image imgToResize, Size size)
        {
            return (new Bitmap(imgToResize, size));
        }


        static void Main(string[] args)
        {
            get_args(args);
            get_images();
            
            foreach (string img in jpg_files)
            {
                int i = 1;
                var image = Image.FromFile(inputdir + @"\" + img);
                bmp = resize_image(image, new Size(resolution[0], resolution[1]));
                if (File.Exists(outputdir + @"\" + Path.GetFileNameWithoutExtension(img) + ".ext"))
                {
                    string[] temp;
                    temp = Directory.GetFiles(outputdir).Select(Path.GetFileName).ToArray();
                    for (int k = 0; k < temp.Length; k++)
                    {
                        if (temp[k].Contains(Path.GetFileNameWithoutExtension(img) + "_"))
                            i++;
                    }
                    bmp.Save(outputdir + @"\" + Path.GetFileNameWithoutExtension(img) + "_" + i.ToString() + ".ext");
                }
                else
                {
                    bmp.Save(outputdir + @"\" + Path.GetFileNameWithoutExtension(img) + ".ext");
                }
            }
        }
    }
}
