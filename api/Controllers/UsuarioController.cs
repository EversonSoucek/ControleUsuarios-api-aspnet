using CadastroUsuario.application.Dtos.Usuario;
using CadastroUsuario.application.mappers;
using CadastroUsuario.domain.Models;
using CadastroUsuario.infrastructure.data.repositories.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.api.Controllers
{
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepo;
        public UsuarioController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        [HttpGet("{IdUsuario:int}")]
        public async Task<IActionResult> GetById([FromRoute] int IdUsuario)
        {
            var usuarioResult = await _usuarioRepo.GetById(IdUsuario);
            if (usuarioResult.IsFailed)
            {
                return NotFound($"Não existe usuário de id:{IdUsuario}");
            }

            var usuarioDto = usuarioResult.Value.ToUsuarioDto();
            return Ok(usuarioDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuariosResult = await _usuarioRepo.GetAll();

            if (usuariosResult.IsFailed)
            {
                return NotFound(usuariosResult.Errors);
            }

            var usuariosDto = usuariosResult.Value.Select(u => u.ToUsuarioDto()).ToList();
            return Ok(usuariosDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUsuarioDto createUsuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = createUsuarioDto.ToCreateUsuarioDto();
            var result = await _usuarioRepo.CreateAsync(usuario);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }

            var usuarioDto = usuario.ToUsuarioDto();
            return CreatedAtAction(nameof(GetById), new { IdUsuario = usuario.IdUsuario }, usuarioDto);
        }

        [HttpPut("{IdUsuario:int}")]
        public async Task<IActionResult> Update([FromRoute] int IdUsuario, [FromBody] UpdateUsuarioDto updateUsuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _usuarioRepo.UpdateAsync(updateUsuarioDto, IdUsuario);
            if (result.IsFailed)
            {
                return NotFound(result.Errors);
            }

            var usuarioDto = result.Value.ToUsuarioDto();
            return Ok(usuarioDto);
        }
    }
}
