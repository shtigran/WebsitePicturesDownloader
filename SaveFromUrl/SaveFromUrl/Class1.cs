using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string all = string.Empty;
            string htmlCode;
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {

                htmlCode = client.DownloadString("http://mic.am/");

               
            }
            Console.WriteLine("Matching words that image: ");

            all = showMatch(htmlCode, @"<(img)\b[^>]*>");
            Console.WriteLine(all);



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