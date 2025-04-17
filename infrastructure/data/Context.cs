using CadastroUsuario.domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.infrastructure.data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public required DbSet<Usuario> Usuario { get; set; }
    }
}