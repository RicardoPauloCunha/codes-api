using System.ComponentModel.DataAnnotations;

namespace Standard.InLock.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Senha Inválida, deve conter mais de 3 caracteres")]
        public string Senha { get; set; }
    }
}
