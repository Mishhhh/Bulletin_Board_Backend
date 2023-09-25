using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Posts:PostIDs
    {

        public string PostTitle { get; set; }
        public string PostDetails { get; set; }
        public int Likes { get; set; }
        public int PostViews { get; set; }

        public string Category { get; set; }

        public DateTime TimeStamp { get; set; }
        public int IsApproved { get; set; }
        public string ImageUrl { get; set; }
    }
    public class PostIDs
    {
        public int UID { get; set; }
        public int PID { get; set; }
    }
}

