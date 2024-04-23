using SistemaUsuarios.Models;

namespace SistemaUsuarios.Repositorio
{
    public interface IUsuarioRepositorio
    {
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
    }
}
