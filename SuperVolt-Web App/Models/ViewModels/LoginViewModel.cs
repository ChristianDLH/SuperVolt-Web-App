using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperVolt_Web_App.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*El correo es obligatorio*")]
        [EmailAddress]
        public string mail { get; set; }

        [Required(ErrorMessage = "*La contraseña es obligatoria*")]
        public string password { get; set; }
    }
}