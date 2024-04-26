using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SistemaUsuarios.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o Email do usuario")]
        [EmailAddress(ErrorMessage = "O email informado não é valido")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Digite o Numero do usuario")]
        [Phone(ErrorMessage = "O Numero informado não é valido")]
         public string Phone { get; set; }
        public bool IsDeleted { get; set; }

    }
}
