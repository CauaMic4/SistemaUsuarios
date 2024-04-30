using Microsoft.EntityFrameworkCore;
using SistemaUsuarios.Models;

namespace SistemaUsuarios.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options)
            : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ControleUsersModel> ControleUsers { get; set; }
    }
}
