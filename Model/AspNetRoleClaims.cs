using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Model
{
    public partial class AspNetRoleClaims: IdentityRoleClaim<string>
    {

        public virtual AspNetRoles Role { get; set; }
    }
}
