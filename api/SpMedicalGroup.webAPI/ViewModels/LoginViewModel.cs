using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webAPI.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "é necessário que você digite um email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "é necessário que você digite a senha do usuário.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }


    }

}