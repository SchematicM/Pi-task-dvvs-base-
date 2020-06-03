using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Model
{
    public partial class AspNetUsers : IdentityUser
    {
        public AspNetUsers()
        {
            Dbbc = new HashSet<Dbbc>();
            Dbbctouser = new HashSet<Dbbctouser>();
        }
        public string Surname { get; set; }
        public string Credit { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual ICollection<Dbbc> Dbbc { get; set; }
        public virtual ICollection<Dbbctouser> Dbbctouser { get; set; }
    }
}
