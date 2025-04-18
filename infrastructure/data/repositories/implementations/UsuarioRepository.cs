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

        public async Task<Result<List<Usuario>>> GetAll(bool ativo)
        {
            var query = _context.Usuario.AsQueryable();

            if (ativo)
            {
                query = query.Where(u => u.Status == true);
            }

            var usuarios = await query.ToListAsync();
            return Result.Ok(usuarios);
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

        public async Task<Result<Usuario>> InativaUsuario(int idUsuario)
        {
            var usuario = await GetById(idUsuario);
            if (usuario.IsFailed)
            {
                return Result.Fail($"Não existe usuário de id:{idUsuario}");
            }
            var usuarioValor = usuario.Value;
            usuarioValor.Status = false;
            _context.Usuario.Update(usuarioValor);
            await _context.SaveChangesAsync();
            return Result.Ok(usuarioValor);
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
            _context.Usuario.Update(usuarioValor);
            await _context.SaveChangesAsync();
            return Result.Ok(usuarioValor);
        }
    }
}