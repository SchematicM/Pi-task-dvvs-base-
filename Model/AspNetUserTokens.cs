using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Model
{
    public partial class AspNetUserTokens: IdentityUserToken<string>
    {
        public virtual AspNetUsers User { get; set; }
    }
}
