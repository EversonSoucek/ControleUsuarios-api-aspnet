using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.application.Dtos.Usuario
{
    public class UpdateUsuarioDto
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Cidade { get; set; }
        public bool Status { get; set; }
    }
}