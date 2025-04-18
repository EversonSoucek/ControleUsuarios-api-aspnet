using CadastroUsuario.application.Dtos.Usuario;
using CadastroUsuario.domain.Models;
using FluentResults;

namespace CadastroUsuario.infrastructure.data.repositories.interfaces
{
    public interface IUsuarioRepository
    {
        Task<Result<Usuario>> CreateAsync(Usuario usuario);
        Task<Result<Usuario>> GetById(int idUsuario);
        Task<Result<List<Usuario>>> GetAll(bool ativo);
        Task<Result<Usuario>> UpdateAsync(UpdateUsuarioDto updateUsuarioDto, int IdUsuario);
        Task<Result<Usuario>> InativaUsuario(int idUsuario);
    }
}