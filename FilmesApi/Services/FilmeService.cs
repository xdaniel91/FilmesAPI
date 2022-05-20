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

        public async Task AddAsync(FilmeDTO filme)
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
            var filmesDto = new List<FilmeDTO>();
            foreach (var filme in filmes)
            {
                var filmeDto = _mapper.Map<FilmeDTO>(filme);
                filmesDto.Add(filmeDto);
            }
            return filmesDto;
        }

        public async Task<FilmeDTO> GetByIdAsync(int id)
        {
            var filme = await _repository.GetByIdAsync(id);
            var filmeDto = _mapper.Map<FilmeDTO>(filme);
            return filmeDto;
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
