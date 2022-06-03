using AutoMapper;
using FluentResults;
using System.Threading.Tasks;
using System.Web;
using UsuariosApi.Dto;
using UsuariosApi.Interfaces;
using UsuariosApi.Models;
using UsuariosApi.Requests;

namespace UsuariosApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmailService _emailService;

        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _emailService = emailService;
        }

        public async Task<Result> AtivarConta(AtivaContaRequest request)
        {
            var id = request.UsuarioId;
            var codigoAtivacao = request.CodigoAtivacao;
            var identityUser = await _usuarioRepository.GetUser(id);
            var identityResult = _usuarioRepository.ConfirmEmail(identityUser, codigoAtivacao);
            if (identityResult.Succeeded) return Result.Ok().WithSuccess("conta ativada!");
            return Result.Fail("falha ao ativar conta de usuário");
        }

        public async Task<Result> CreateAsync(UsuarioDTO usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var usuarioIdentity = _mapper.Map<ApplicationUser>(usuario);
            var senha = usuarioDto.Senha;
            var result = await _usuarioRepository.CreateAsync(usuarioIdentity, senha);

            if (result.IsSuccess)
            {
                var code = await _usuarioRepository.GerarTokenConfirmacaoEmail(usuarioIdentity);
                var encodedCode = HttpUtility.UrlEncode(code);
                var email = usuarioIdentity.Email;
                var id = usuarioIdentity.Id;
                var usuarios = new string[] { email };
                var assunto = "LinkAtivacao";
                _emailService.EnviarEmail(usuarios, assunto, id, encodedCode);
                return Result.Ok().WithSuccess(encodedCode);
            }
            return Result.Fail("cadastro falhou");
        }
    }
}