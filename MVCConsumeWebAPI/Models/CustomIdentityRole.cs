using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCConsumeWebAPI.Models
{
    public class CustomIdentityRole : IdentityRole
    {
        public CustomIdentityRole() : base() { }
        public CustomIdentityRole(string name) : base(name) { }
    }
}