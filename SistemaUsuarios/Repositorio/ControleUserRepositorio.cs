using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaUsuarios.Data;
using SistemaUsuarios.Models;

namespace SistemaUsuarios.Repositorio
{
    public class ControleUserRepositorio : IControleUserRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ControleUserRepositorio(BancoContext bancoContext)
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



        public ControleUsersModel Adicionar(ControleUsersModel controleUser)
        {
            controleUser.DataCadastro = DateTime.Now;


            //Gravar no Banco
            _bancoContext.ControleUsers.Add(controleUser);
            _bancoContext.SaveChanges();

            return controleUser;
        }

        public ControleUsersModel Atualizar(ControleUsersModel controleUser)
        {
           ControleUsersModel ControleusuarioDb = ListarPorId(controleUser.Id);

            if (ControleusuarioDb == null) throw new Exception("Houve um erro na atualização do Usuario!");

            ControleusuarioDb.Name = controleUser.Name;
            ControleusuarioDb.Email = controleUser.Email;
            ControleusuarioDb.Login = controleUser.Login;
            ControleusuarioDb.Perfil = controleUser.Perfil;
            ControleusuarioDb.DataAtualização = DateTime.Now;

            _bancoContext.ControleUsers.Update(ControleusuarioDb);
            _bancoContext.SaveChanges();

            return ControleusuarioDb;
        }



        public bool Apagar(int id)
        {
            var parameter = new SqlParameter("@Id", id);
            _bancoContext.Database.ExecuteSqlRaw("EXEC ApagarControleUser @Id", parameter);

            return true;
        }


    }
}
