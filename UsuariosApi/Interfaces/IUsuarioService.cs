﻿using FluentResults;
using System.Threading.Tasks;
using UsuariosApi.Dto;
using UsuariosApi.Services;

namespace UsuariosApi.Interfaces
{
    public interface IUsuarioService
    {
        public Task<Result> CreateAsync(UsuarioDTO usuarioDto);
        public Task<Result> AtivarConta(AtivaContaRequest request);
    }
}
