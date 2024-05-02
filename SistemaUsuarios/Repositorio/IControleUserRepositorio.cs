using SistemaUsuarios.Models;

namespace SistemaUsuarios.Repositorio
{
    public interface IControleUserRepositorio
    {
        ControleUsersModel ListarPorId(int id);
        List<ControleUsersModel> BuscarTodos();
        ControleUsersModel Adicionar(ControleUsersModel ControleUsuario);
        ControleUsersModel Atualizar(ControleUsersModel ControleUsuario);
        bool Apagar(int id);
    }
}
