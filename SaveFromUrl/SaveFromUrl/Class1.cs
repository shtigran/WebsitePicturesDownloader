using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConsoleApplicationTest
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string all = string.Empty;
            string htmlCode = string.Empty;
            Console.WriteLine("____Welcome Website Images Downloader____\n");
            Console.Write("Please enter the website path: ");
            string path = Console.ReadLine();
            using (WebClient client = new WebClient() ) // WebClient class inherits IDisposable
            {
                htmlCode = client.DownloadString(path);
                Console.WriteLine(all);
                all = showMatch(htmlCode, @"<(img)\b[^>]*>");
                Console.WriteLine("-------------");
                Console.WriteLine("The program start finding images____");
                Console.WriteLine("There are the following images: ");
                string[] split = all.Split(new Char[] { '"', '?' });
                Console.WriteLine("-------------");
                WebClient client1;

                int flag = 1;
                
                foreach (var item in split)
                {
                    Console.WriteLine(item);
                    if (item.Contains(".jpg") )
                    {
                        client1 = new WebClient();
                        Console.WriteLine(path + item);
                        Uri uri = new Uri(path + item);
                        client1.DownloadFileAsync(uri, $"C:\\Users\\labuser13\\Desktop\\ShTigran\\Webimages\\picture{flag}.jpg");
                        flag++;
                    }

                    if (item.Contains(".png"))
                    {
                        client1 = new WebClient();
                        Console.WriteLine(path + item);
                        Uri uri = new Uri(path + item);
                        client1.DownloadFileAsync(uri, $"C:\\Users\\labuser13\\Desktop\\ShTigran\\Webimages\\picture{flag}.png");
                        flag++;
                    }

                    if (item.Contains(".svg"))
                    {
                        client1 = new WebClient();
                        Console.WriteLine(path + item);
                        Uri uri = new Uri(path + item);
                        client1.DownloadFileAsync(uri, $"C:\\Users\\labuser13\\Desktop\\ShTigran\\Webimages\\picture{flag}.svg");
                        flag++;
                    }

                 }

            }
                            
            Console.ReadKey();
        }

        private static string showMatch(string text, string expr)
        {
            MatchCollection mc = Regex.Matches(text, expr);
            string result ="";
            foreach (Match m in mc)
            {
                
                result += m.ToString() + "\n";
                

            }
            return result;
        }

    }
}