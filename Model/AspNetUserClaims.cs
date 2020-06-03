using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Model
{
    public partial class AspNetUserClaims: IdentityUserClaim<string>
    {

        public virtual AspNetUsers User { get; set; }
    }
}
