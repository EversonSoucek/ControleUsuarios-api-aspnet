namespace CadastroUsuario.application.Dtos.Usuario
{
    public class CreateUsuarioDto
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Cidade { get; set; }
    }
}