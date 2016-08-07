using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mp4Parser;
using System.Text.RegularExpressions;
using System.Net;

namespace mp4Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex reg = new Regex(@"^[a-zA-Z]:/");
            Console.WriteLine("MP4 Parser by Pavel Klochkov");
            Console.WriteLine("Enter local path or url to your file");
            Console.WriteLine("For example: Disc:/path/to/file.mp4 or http://url.to/file.mp4");
            string path = Console.ReadLine();
            Parser parser = new Parser();
            if (path.Contains("http"))
            {
                Console.WriteLine("It may take a long time");
                Uri link = new Uri(path);
                WebClient wc = new WebClient();
                wc.DownloadFile(link, "downloaded.mp4");
                parser.parserFunction("downloaded.mp4");

            }else if(reg.IsMatch(path)){
                parser.parserFunction(path);
            }else{
                Console.WriteLine("Incorrect path");
            }
            Console.ReadLine();
        }
    }
}
