using System.ComponentModel.DataAnnotations;

namespace MF.TokenAuthenticationWithJwtWithoutIdentity01.Api.Models
{
    public class LoginDTO
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
