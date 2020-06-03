using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Model
{
    public partial class AspNetUserLogins: IdentityUserLogin<string>
    {
        public string Id { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
