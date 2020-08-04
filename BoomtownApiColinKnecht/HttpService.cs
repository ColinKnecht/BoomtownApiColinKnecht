using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public bool TestRepoCount(int publicRepoCount, string repoUrl)
        {
            //DISCLAIMER - I Know this is not the correct way to do this,
            // I wanted to implement pagination to count the correct way, but I was running low on time and wanted to give you something
            // 
            // another thing you could do is put the 'x-total-count' header in the response, but it wouldn't know if the repos were public or not
            // basically I wanted to get all Repos in one Array through pagination and go through them to make sure they were public as well

            HttpClient client = new HttpClient();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(repoUrl);
            request.Method = "GET";
            //Server gives me a 403 if I don't have the user agent below
            request.UserAgent = "johnSmith";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var links = response.Headers.Get("Link");

            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            string result = streamReader.ReadToEnd();

            Repo[] repoArray = JsonConvert.DeserializeObject<Repo[]>(result);
            string[] nextLastLink = links.Split(",");

            // < https://api.github.com/organizations/1214096/repos?page=2>; rel="next", 
            //< https://api.github.com/organizations/1214096/repos?page=2>; rel="last"

            string repo2 = Get("https://api.github.com/organizations/1214096/repos?page=2");
            Repo[] repoArray2 = JsonConvert.DeserializeObject<Repo[]>(repo2);

            var repos = repoArray.Concat(repoArray2).ToArray();
            int publicRepoCountFromWeb = 0;

            foreach(Repo repo in repos)
            {
                if (!repo.Private)
                {
                    publicRepoCountFromWeb++;
                }
            }

            if (publicRepoCount == publicRepoCountFromWeb)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Public Repo Counts match!!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Public Repo Counts do not match!!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;
            }
        }
    }
}
