using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyAuthServer.Core.Models
{
    public class UserApp:IdentityUser
    {

        public string? City { get; set; }


        [Column(TypeName ="Date")]
        public DateTime? BirthDay { get; set; }
    }
}
