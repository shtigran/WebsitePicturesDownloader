# 
# Website Pictures Downloader
# C#6.0  .NET FRAMEWORK 4.6

----

### Test and Result

### Purpose
This program allow You download all images from any URL.

----

### Program class implementation
```c#
 public static class Program
    {
        static void Main(string[] args)
        {

            // Welcome message
            Console.WriteLine("\n    |---------------------------------|");
            Console.WriteLine("    |Welcome Website Images Downloader|");
            Console.WriteLine("    |---------------------------------|\n\n");
            Console.Write("Please enter the Website path: ");
            string path = Console.ReadLine();

            // Checking URL validity          
            if (!Uri.IsWellFormedUriString(path, UriKind.RelativeOrAbsolute))
            { Console.WriteLine("Wrong URL path!!!"); }
             
            else
            {   // Creating strings for operations
                string all = string.Empty;
                string htmlCode = string.Empty;

                using (WebClient client = new WebClient()) // WebClient class inherits IDisposable 
                {
                    htmlCode = client.DownloadString(path);
                    all = showMatch(htmlCode, @"<(img)\b[^>]*>"); 
                    Console.WriteLine("-------------");
                    Console.WriteLine("\nThere are the following images: ");
                    string[] split = all.Split(new Char[] { '"', '?' });
                    Console.WriteLine("-------------");
                    string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    WebClient client1;

                    int flag = 1;

                    foreach (var item in split)
                    {

                        if (item.Contains(".jpg"))
                        {
                            client1 = new WebClient();
                            Uri uri = new Uri(path + item);
                            client1.DownloadFileAsync(uri, $"{dir}\\Picture{flag}.jpg");
                            flag++;
                            Console.WriteLine(item);
                        }

                        if (item.Contains(".png"))
                        {
                            client1 = new WebClient();
                            Uri uri = new Uri(path + item);
                            client1.DownloadFileAsync(uri, $"{dir}\\Picture{flag}.png");
                            flag++;
                            Console.WriteLine(item);
                        }

                        if (item.Contains(".svg"))
                        {
                            client1 = new WebClient();
                            Uri uri = new Uri(path + item);
                            client1.DownloadFileAsync(uri, $"{dir}\\Picture{flag}.svg");
                            flag++;
                            Console.WriteLine(item);
                        }
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
```
----

### Description of Program class
The Program class recieve the path of url, then copy html code to the string. After that from html code the program defines the images path and download them. For defining the picture program uses showMatch() method with regular expression.
