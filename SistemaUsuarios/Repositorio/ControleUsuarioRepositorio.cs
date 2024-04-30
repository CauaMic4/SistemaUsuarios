using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaUsuarios.Data;
using SistemaUsuarios.Models;

namespace SistemaUsuarios.Repositorio
{
    public class ControleUsuarioRepositorio : IControleUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ControleUsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ControleUsersModel ListarPorId(int id)
        {
            return _bancoContext.ControleUsers.FirstOrDefault(x => x.Id == id);
        }

        public List<ControleUsersModel> BuscarTodos()
        {
            return _bancoContext.ControleUsers.ToList();
        }



        public ControleUsersModel Adicionar(ControleUser controleUser)
        {
            //Gravar no Banco

            _bancoContext.Usuarios.Add(controleUser);
            _bancoContext.SaveChanges();

            return controleUser;
        }

        public ControleUsers Atualizar(ControleUsers controleUser)
        {
           UsuarioModel usuarioDb = ListarPorId(controleUser.Id);

            if (usuarioDb == null) throw new Exception("Houve um erro na atualização do Usuario!");

            usuarioDb.Name = controleUser.Name;
            usuarioDb.Email = controleUser.Email;
            usuarioDb.Phone = controleUser.Phone;

            _bancoContext.Usuarios.Update(usuarioDb);
            _bancoContext.SaveChanges();

            return usuarioDb;
        }

        public ControleUsersModel Adicionar(ControleUsersModel ControleUsuario)
        {
            throw new NotImplementedException();
        }

        public ControleUsersModel Atualizar(ControleUsersModel ControleUsuario)
        {
            throw new NotImplementedException();
        }

        public bool Apagar(int id)
        {
            throw new NotImplementedException();
        }

        //public bool Apagar(int id)
        //{
        //    var parameter = new SqlParameter("@Id", id);
        //    _bancoContext.Database.ExecuteSqlRaw("EXEC ApagarUsuario @Id", parameter);

        //    return true;
        //}


    }
}
