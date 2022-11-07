using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppScrum.Models
{
    public class LoginViewModel
    {

        public int PersoneelslidAccountId { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Emailadres { get; set; }

        [Required(ErrorMessage = "Paswoord required")]
        public string Paswoord { get; set; }
    }
}
