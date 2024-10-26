using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
   public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(50,MinimumLength =3)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
