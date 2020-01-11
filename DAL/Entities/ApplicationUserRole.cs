using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        
        //public virtual ApplicationUser User { get; set; }
        //public virtual ApplicationRole Role { get; set; }

    }
}
