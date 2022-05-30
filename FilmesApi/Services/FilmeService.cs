using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Interfaces;
using FilmesApi.Models;

namespace FilmesApi.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _repository;
        private readonly IMapper _mapper;

        public FilmeService(IFilmeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(Filme filme)
        {
            await _repository.AddAsync(filme);
        }

        public void DeleteById(int id)
        {
            _repository.DeleteByIdAsync(id);
        }

        public async Task<List<FilmeDTO>> GetAllAsync()
        {
            var filmes = await _repository.GetAll();
            var filmesDto = _mapper.Map<List<FilmeDTO>>(filmes);
            return filmesDto;
        }

        public async Task<FilmeDTO> GetByIdAsync(int id)
        {
            var filme = await _repository.GetByIdAsync(id);
            var filmeDto = _mapper.Map<FilmeDTO>(filme);
            return filmeDto;
        }

        public async Task<List<FilmeDTO>> GeyByClassificacao(int? idade)
        {
            var filmes = await _repository.GetByClassificacao(idade);
            var filmesDto = _mapper.Map<List<FilmeDTO>>(filmes);
            return filmesDto;
        }

        public void Remove(FilmeDTO filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);
            _repository.Delete(filme);
        }

        public void Update(FilmeDTO filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);
            _repository.Update(filme);
        }
    }
}