using CadastroUsuario.application.Dtos.Usuario;
using CadastroUsuario.domain.Models;
using CadastroUsuario.infrastructure.data.repositories.interfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.infrastructure.data.repositories.implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly Context _context;

        public UsuarioRepository(Context context)
        {
            _context = context;
        }

        public async Task<Result<Usuario>> CreateAsync(Usuario usuario)
        {
            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return Result.Ok(usuario);
        }

        public async Task<Result<List<Usuario>>> GetAll()
        {
            var servicos = await _context.Usuario.ToListAsync();
            return Result.Ok(servicos);
        }

        public async Task<Result<Usuario>> GetById(int idUsuario)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(usu => usu.IdUsuario == idUsuario);
            if (usuario == null)
            {
                return Result.Fail($"Não existe usuário de id: {idUsuario} ");
            }
            return Result.Ok(usuario);
        }

        public async Task<Result<Usuario>> UpdateAsync(UpdateUsuarioDto updateUsuarioDto, int IdUsuario)
        {
            var usuario = await GetById(IdUsuario);
            if (usuario.IsFailed)
            {
                return Result.Fail($"Não existe usuário de id:{IdUsuario} ");
            }
            var usuarioValor = usuario.Value;
            usuarioValor.Cidade = updateUsuarioDto.Cidade;
            usuarioValor.Email = updateUsuarioDto.Email;
            usuarioValor.Nome = updateUsuarioDto.Nome;
            usuarioValor.Status = updateUsuarioDto.Status;
            _context.Usuario.Update(usuarioValor);
            await _context.SaveChangesAsync();
            return Result.Ok(usuarioValor);
        }
    }
}