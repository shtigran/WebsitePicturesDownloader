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
            string htmlCode = string.Empty; ;
            string path = "http://mic.am";
            using (WebClient client = new WebClient() ) // WebClient class inherits IDisposable
            {

                htmlCode = client.DownloadString(path);
                all = showMatch(htmlCode, @"<(img)\b[^>]*>");
                Console.WriteLine("-------------");
                Console.WriteLine(all);
                string[] split = all.Split(new Char[] { '"', '?' });
                Console.WriteLine("-------------");
                int flag = 1;
                
                foreach (var item in split)
                {
                    if (item.Contains(".jpg") )
                    {
                        WebClient client1 = new WebClient();
                        Console.WriteLine(path + item);
                        Uri uri = new Uri(path + item);
                        client1.DownloadFileAsync(uri, $"C:\\Users\\labuser13\\Desktop\\ShTigran\\picture{flag}.jpg");
                        flag++;
                    }

                    if (item.Contains(".png"))
                    {
                        WebClient client1 = new WebClient();
                        Console.WriteLine(path + item);
                        Uri uri = new Uri(path + item);
                        client1.DownloadFileAsync(uri, $"C:\\Users\\labuser13\\Desktop\\ShTigran\\picture{flag}.png");
                        flag++;
                    }

                    if (item.Contains(".svg"))
                    {
                        WebClient client1 = new WebClient();
                        Console.WriteLine(path + item);
                        Uri uri = new Uri(path + item);
                        client1.DownloadFileAsync(uri, $"C:\\Users\\labuser13\\Desktop\\ShTigran\\picture{flag}.svg");
                        flag++;
                    }

                 }

            }
                            
            Console.ReadKey();
        }

        private static string showMatch(string text, string expr)
        {
            Console.WriteLine("The Expression: " + expr);
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