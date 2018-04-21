using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ftp
{
    class Program
    {
        public static string FtpUri = @"xxx", User = @"xxx", Pass = @"xxx";

        public static String[] FTPListTree(String FtpUri, String User, String Pass)
        {

            List<String> files = new List<String>();
            Queue<String> folders = new Queue<String>();
            folders.Enqueue(FtpUri);

            while (folders.Count > 0)
            {
                String fld = folders.Dequeue();
                List<String> newFiles = new List<String>();

                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(fld);
                ftp.Credentials = new NetworkCredential(User, Pass);
                ftp.UsePassive = false;
                ftp.Method = WebRequestMethods.Ftp.ListDirectory;
                using (StreamReader resp = new StreamReader(ftp.GetResponse().GetResponseStream()))
                {
                    String line = resp.ReadLine();
                    while (line != null)
                    {
                        newFiles.Add(line.Trim());
                        line = resp.ReadLine();
                    }
                }

                ftp = (FtpWebRequest)FtpWebRequest.Create(fld);
                ftp.Credentials = new NetworkCredential(User, Pass);
                ftp.UsePassive = false;
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                using (StreamReader resp = new StreamReader(ftp.GetResponse().GetResponseStream()))
                {
                    String line = resp.ReadLine();
                    while (line != null)
                    {
                        if (line.Trim().ToLower().StartsWith("d") || line.Contains(" <DIR> "))
                        {
                            String dir = newFiles.First(x => line.EndsWith(x));
                            newFiles.Remove(dir);
                            folders.Enqueue(fld + dir + "/");
                        }
                        line = resp.ReadLine();
                    }
                }
                files.AddRange(from f in newFiles select fld + f);
            }
            return files.ToArray();
        }


        static void Main(string[] args)
        {

            try
            {   
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FtpUri);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;


                request.Credentials = new NetworkCredential(User, Pass);
                request.KeepAlive = false;
                request.UseBinary = true;
                request.UsePassive = false;


                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                Console.WriteLine(reader.ReadToEnd());

                Console.WriteLine(@"Lista glownego katalogu <root>, status {0}", response.StatusDescription);
                Console.ReadLine();

                
                reader.Close();
                response.Close();
                Console.WriteLine(FTPListTree(FtpUri, User, Pass));
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.ReadLine();
            }
        }
    }
}
