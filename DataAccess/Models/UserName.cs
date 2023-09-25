using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UserName : IUsers
    {
        public int UID { get; set ; }
        public string Name { get; set; }
    }
}
