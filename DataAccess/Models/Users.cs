using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Users : IUsers, ILogin
    { 
        public int PhoneNo { get; set; }
        public int IsActive { get; set; }
        public string Email { get ; set ; }
        public string Password { get; set ; }
        public int UID { get; set; }
        public string Name { get; set ; }
    }
    public interface IUsers
    {
        public int UID { get; set; }
        public string Name { get; set; }

    }
    public interface ILogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
}
