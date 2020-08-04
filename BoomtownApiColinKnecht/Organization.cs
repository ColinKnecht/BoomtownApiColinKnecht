using System;
using System.Collections.Generic;
using System.Text;

namespace BoomtownApiColinKnecht
{
    public class Organization
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public string Node_Id { get; set; }
        public string Url { get; set; }
        public string Repos_Url { get; set; }
        public string Events_Url { get; set; }
        public string Hooks_Url { get; set; }
        public string Issues_Url { get; set; }
        public string Members_Url { get; set; }
        public string Public_Members_Url { get; set; }
        public string Avatar_Url { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Blog { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Twitter_Username { get; set; }
        public bool Is_Verified { get; set; }
        public bool Has_Organization_Projects { get; set; }
        public bool Has_Repository_Projects { get; set; }
        public int Public_Repos { get; set; }
        public int Public_Gists { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public string Html_Url { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public string Type { get; set; }
    }
}
