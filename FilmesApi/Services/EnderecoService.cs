using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Interfaces;
using FilmesApi.Models;

namespace FilmesApi.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public EnderecoService(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public void Add(Endereco endereco)
        {
            _enderecoRepository.AddAsync(endereco);
        }

        public void DeleteById(int id)
        {
            _enderecoRepository.DeleteByIdAsync(id);
        }

        public async Task<List<EnderecoDTO>> GetAll()
        {
            var enderecos = await _enderecoRepository.GetAllAsync();
            var enderecosDto = _mapper.Map<List<EnderecoDTO>>(enderecos);
            return enderecosDto;
        }

        public async Task<EnderecoDTO> GetByIdAsync(int id)
        {
            var endereco = await _enderecoRepository.GetByIdAsync(id);
            var enderecoDto = _mapper.Map<EnderecoDTO>(endereco);
            return enderecoDto;
        }

        public void Remove(EnderecoDTO enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            _enderecoRepository.Remove(endereco);
        }

        public void Update(EnderecoDTO enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            _enderecoRepository.Update(endereco);
        }
    }
}