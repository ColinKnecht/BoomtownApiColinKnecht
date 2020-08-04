using System;
using System.Collections.Generic;
using System.Text;

namespace BoomtownApiColinKnecht
{
    public class Event
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public Actor Actor { get; set; }
        public Repo Repo { get; set; }
        public Payload Payload { get; set; }
        public bool Public { get; set; }
        public DateTime Created_At { get; set; }
        public Organization Organization { get; set; }
    }
}
