using SistemaUsuarios.Data;
using SistemaUsuarios.Models;

namespace SistemaUsuarios.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //Gravar no Banco

            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;
        }

       
    }
}
