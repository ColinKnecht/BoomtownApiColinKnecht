using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BoomtownApiColinKnecht
{
    public class HttpService
    {
        public string Get(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                //Server gives me a 403 if I don't have the user agent below
                request.UserAgent = "johnSmith";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //response.Headers.Add("X-Total-Count");

                Stream stream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream);
                string result = streamReader.ReadToEnd();

                return result;
            }
            catch (WebException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error Raised at Url: " + url + ".....Error Message:" + e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
                return "";
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Exception Raised!!" + e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
                return "";
            }
        }
    }
}
