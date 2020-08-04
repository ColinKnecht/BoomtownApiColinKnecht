using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Reflection;

namespace BoomtownApiColinKnecht
{
    class Program
    {
        private const string BOOMTOWN_GITHUB_URL = "https://api.github.com/orgs/BoomTownROI";
        private const string BOOMTOWN_URL_CONTAINING = "api.github.com/orgs/BoomTownROI/";
        public static HttpService webService = new HttpService();
        public static int PublicReposCount = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Github BoomTown Api - Colin Knecht");
            var organization = GetOrganization();
            ListAllIds(organization);
            IsUpdatedDateGreaterThanCreatedDate(organization);

            Console.WriteLine("Program Complete, Press Enter to exit");
            Console.ReadLine();
        }

        public static Organization GetOrganization()
        {
            var organization = JsonConvert.DeserializeObject<Organization>(webService.Get(BOOMTOWN_GITHUB_URL));
            PublicReposCount = organization.Public_Repos;
            webService.TestRepoCount(PublicReposCount, organization.Repos_Url);

            return organization;
        }

        public static void ListAllIds(Organization organization)
        {
            //loop through organization elements
            Type type = typeof(Organization);
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var propertyValue = property.GetValue(organization, null) ?? "";
                if (propertyValue.ToString().Contains(BOOMTOWN_URL_CONTAINING))
                {
                    string url = propertyValue.ToString();
                    if ((propertyValue.ToString().Contains("{/member}")))
                    {
                        url = propertyValue.ToString().Replace("{/member}", "");
                    }
                    GetRequestFromUrl(url);
                }
            }
        }

        public static void GetRequestFromUrl(string url)
        {
            try
            {
                string result = webService.Get(url);

                string type = url.Replace("https://api.github.com/orgs/BoomTownROI/", "");
                Object[] data = null;
                switch (type)
                {
                    case "repos":
                        data = JsonConvert.DeserializeObject<Repo[]>(result);
                        if (data != null)
                        {
                            PrintRepoTypeIds(data);
                        }
                        break;
                    case "events":
                        data = JsonConvert.DeserializeObject<Event[]>(result);
                        if (data != null)
                        {
                            PrintEventTypeIds(data);
                        }
                        break;
                    case "hooks":
                        data = JsonConvert.DeserializeObject<Hook[]>(result);
                        if (data != null)
                        {
                            PrintHookTypeIds(data);
                        }
                        break;
                    case "issues":
                        data = JsonConvert.DeserializeObject<Issue[]>(result);
                        if (data != null)
                        {
                            PrintIssueTypeIds(data);
                        }
                        break;
                    case "members":
                        data = JsonConvert.DeserializeObject<Member[]>(result);
                        if (data != null)
                        {
                            PrintMemberTypeIds(data);
                        }
                        break;
                    case "public_members":
                        data = JsonConvert.DeserializeObject<PublicMember[]>(result);
                        if (data != null)
                        {
                            PrintPublicMemberTypeIds(data);
                        }
                        break;
                    default:
                        throw new Exception("Parsing Error: Unknown Url Type");
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Exception caught: " + e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void PrintRepoTypeIds(Object[] data)
        {
            Console.WriteLine("============All Ids for the type of Repo==============");
            foreach (Repo repo in data)
            {
                Console.WriteLine("Repo Id = " + repo.Id + "----Can Be Found At: " + repo.Html_Url);
            }
        }

        public static void PrintEventTypeIds(Object[] data)
        {
            Console.WriteLine("============All Ids for the type of Event==============");
            foreach (Event evnt in data)
            {
                Console.WriteLine("Event Id = " + evnt.Id + "---- Type: " + evnt.Type + " --- Can Be Found At: " + evnt.Repo.Url);
            }
        }

        public static void PrintHookTypeIds(Object[] data)
        {
            Console.WriteLine("============All Ids for the type of Hook==============");
            foreach(Hook hook in data)
            {
                Console.WriteLine("Hook Id = " + hook.Id);
            }
        }

        public static void PrintIssueTypeIds(Object[] data)
        {
            Console.WriteLine("============All Ids for the type of Issue==============");
            foreach(Issue issue in data)
            {
                Console.WriteLine("Issue Id = " + issue.Id);
            }
        }

        public static void PrintMemberTypeIds(Object[] data)
        {
            Console.WriteLine("============All Ids for the type of Member==============");
            foreach (Member member in data)
            {
                Console.WriteLine("Member Id = " + member.Id + " ---- Can Be Found At: " + member.Url);
            }
        }

        public static void PrintPublicMemberTypeIds(Object[] data)
        {
            Console.WriteLine("============All Ids for the type of  Public Member==============");
            foreach (PublicMember publicMember in data)
            {
                Console.WriteLine("Id = " + publicMember.Id + " ---- Can Be Found At: " + publicMember.Url);
            }
        }

        public static bool IsUpdatedDateGreaterThanCreatedDate(Organization organization)
        {
            var updatedDate = organization.Updated_At.Date;
            var createdDate = organization.Created_At.Date;
            if (organization.Updated_At > organization.Created_At)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(organization.Name + "'s " + " Updated date(" + updatedDate+") is greater than created date("+ createdDate+ ").");
                Console.ForegroundColor = ConsoleColor.Gray;
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(organization.Name + "'s " + " Created date( "+ createdDate +") is greater than updated date("+ updatedDate + ").");
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;
            }
        }

    }
}
