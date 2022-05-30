using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UsuariosApi.Dto;
using UsuariosApi.Interfaces;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;


        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Result> AtivarConta(AtivaContaRequest request)
        {
            var id = request.UsuarioId;
            var codigoAtivacao = request.CodigoAtivacao;
            var identityUser = await _usuarioRepository.GetUser(id);
            var identityResult =  _usuarioRepository.ConfirmEmailAsync(identityUser, codigoAtivacao).Result;
            if (identityResult.Succeeded) return Result.Ok();
            return Result.Fail("falha ao ativar conta de usuário");
        }

        public async Task<Result> CreateAsync(UsuarioDTO usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            var senha = usuarioDto.Senha;
            var result = await _usuarioRepository.CreateAsync(usuarioIdentity, senha);
            if (result.IsSuccess)
            {
                var code = await _usuarioRepository.GerarTokenConfirmacaoEmail(usuarioIdentity);
                return Result.Ok().WithSuccess(code);
            } 
            return Result.Fail("cadastro falhou");
        }

        

    }
}
