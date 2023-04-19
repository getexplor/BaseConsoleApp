using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Models
{
    public class Users
    {
        public Guid Id { get; set; }
        public string username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }


        public override string ToString()
        {
            return "Id: " + Id + "\n" + "Name: " + username + "\n" + "Email: " + Email + "\n" + "Address: " + Address;
        }
    }
}
