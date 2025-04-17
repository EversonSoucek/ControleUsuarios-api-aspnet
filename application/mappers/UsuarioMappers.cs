using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuario.application.Dtos.Usuario;
using CadastroUsuario.domain.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CadastroUsuario.application.mappers
{
    public static class UsuarioMappers
    {
        public static Usuario ToCreateUsuarioDto(this CreateUsuarioDto createUsuarioDto)
        {
            return new Usuario
            {
                Cidade = createUsuarioDto.Cidade,
                Email = createUsuarioDto.Email,
                Nome = createUsuarioDto.Nome,
            };
        }

        public static UsuarioDto ToUsuarioDto(this Usuario usuario)
        {
            return new UsuarioDto
            {
                Cidade = usuario.Cidade,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }
    }
}