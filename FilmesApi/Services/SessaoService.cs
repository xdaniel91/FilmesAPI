using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Interfaces;
using FilmesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesApi.Services
{
    public class SessaoService : ISessaoService
    {
        private readonly IMapper _mapper;
        private readonly ISessaoRepository _sessaoRepository;

        public SessaoService(IMapper mapper, ISessaoRepository sessaoRepositoy)
        {
            _mapper = mapper;
            _sessaoRepository = sessaoRepositoy;
        }

        public async Task AddAsync(Sessao sessao)
        {
            await _sessaoRepository.AddAsync(sessao);
        }

        public void Delete(SessaoDTO sessaoDto)
        {
            var sessao = _mapper.Map<Sessao>(sessaoDto);
            _sessaoRepository.Delete(sessao);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _sessaoRepository.DeleteByIdAsync(id);
        }

        public async Task<List<SessaoDTO>> GetAll()
        {
            var _sessoes = await _sessaoRepository.GetAll();
            var sessoes = _mapper.Map<List<SessaoDTO>>(_sessoes);
            return sessoes;
        }

        public async Task<SessaoDTO> GetByIdAsync(int id)
        {
            var sessao = await _sessaoRepository.GetByIdAsync(id);
            var sessaoDto = _mapper.Map<SessaoDTO>(sessao);
            return sessaoDto;
        }

        public void Update(SessaoDTO sessaoDto)
        {
            var sessao = _mapper.Map<Sessao>(sessaoDto);
            _sessaoRepository.Update(sessao);
        }
    }
}