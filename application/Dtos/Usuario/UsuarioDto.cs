namespace CadastroUsuario.application.Dtos.Usuario
{
    public class UsuarioDto
    {
        public int IdUsuario {get;set;}
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Cidade { get; set; }
    }
}