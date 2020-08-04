using System;
using System.Collections.Generic;
using System.Text;

namespace BoomtownApiColinKnecht
{
    public class Repo
    {
        public int Id { get; set; }
        public string Node_Id { get; set; }
        public string Name { get; set; }
        public string Full_Name { get; set; }
        public bool Private { get; set; }
        public Owner Owner { get; set; }
        public string Html_Url { get; set; }
        public string Description { get; set; }
        public bool Fork { get; set; }
        public string Url { get; set; }
        public string Forks_Url { get; set; }
        public string Keys_Url { get; set; }
        public string Collaborators_Url { get; set; }
        public string Teams_Url { get; set; }
        public string Hooks_Url { get; set; }
        public string Issue_Events_Url { get; set; }
        public string Events_Url { get; set; }
        public string Assignees_Url { get; set; }
        public string Branches_Url { get; set; }
        public string Tags_Url { get; set; }
        public string Blobs_Url { get; set; }
        public string Git_Tags_Url { get; set; }
        public string Git_Refs_Url { get; set; }
        public string Trees_Url { get; set; }
        public string Statuses_Url { get; set; }
        public string Languages_Url { get; set; }
        public string Stargazers_Url { get; set; }
        public string Contributors_Url { get; set; }
        public string Subscribers_Url { get; set; }
        public string Subscription_Url { get; set; }
        public string Commits_Url { get; set; }
        public string Git_Commits_Url { get; set; }
        public string Comments_Url { get; set; }
        public string Issue_Comment_Url { get; set; }
        public string Contents_Url { get; set; }
        public string Compare_Url { get; set; }
        public string Merges_Url { get; set; }
        public string Archive_Url { get; set; }
        public string Downloads_Url { get; set; }
        public string Issues_Url { get; set; }
        public string Pulls_Url { get; set; }
        public string Milestones_Url { get; set; }
        public string Notifications_Url { get; set; }
        public string Labels_Url { get; set; }
        public string Releases_Url { get; set; }
        public string Deployments_Url { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public DateTime Pushed_At { get; set; }
        public string Git_Url { get; set; }
        public string Ssh_Url { get; set; }
        public string Clone_Url { get; set; }
        public string Svn_Url { get; set; }
        public string Homepage { get; set; }
        public int Size { get; set; }
        public int Stargazers_Count { get; set; }
        public int Watchers_Count { get; set; }
        public string Language { get; set; }
        public bool Has_Issues { get; set; }
        public bool Has_Projects { get; set; }
        public bool Has_Downloads { get; set; }
        public bool Has_Wiki { get; set; }
        public bool Has_Pages { get; set; }
        public int Forks_Count { get; set; }
        public object Mirror_Url { get; set; }
        public bool Archived { get; set; }
        public bool Disabled { get; set; }
        public int Open_Issues_Count { get; set; }
        public object License { get; set; }
        public int Forks { get; set; }
        public int Open_Issues { get; set; }
        public int Watchers { get; set; }
        public string Default_Branch { get; set; }
        public Permissions Permissions { get; set; }
    }
}
