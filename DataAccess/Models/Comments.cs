using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Comments:CommentIDs
    {
        public string CommentDetails { get; set; }
        public DateTime TimeStamp { get; set; }
    }
    public class CommentIDs
    {
        public int CID { get; set; }
        public int PID { get; set; }
        public int UID { get; set; }
    }
}


