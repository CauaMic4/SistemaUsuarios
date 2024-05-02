using SistemaUsuarios.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaUsuarios.Models
{
    public class ControleUsersModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Digite o Login do usuario")]
        public string? Login { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuario")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Digite o Email do usuario")]
        [EmailAddress(ErrorMessage = "O email informado não é valido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Selecione o perfil do usuario")]
        public PerfilEnum Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualização { get; set; }
    }
}
