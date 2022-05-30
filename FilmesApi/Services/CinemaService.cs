using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Interfaces;
using FilmesApi.Models;

namespace FilmesApi.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly IMapper _mapper;

        public CinemaService(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(Cinema cinema)
        {
            await _cinemaRepository.AddAsync(cinema);
        }

        public void DeleteById(int id)
        {
            _cinemaRepository.DeleteByIdAsync(id);
        }

        public async Task<List<CinemaDTO>> GetAllAsync()
        {
            var cinemas = await _cinemaRepository.GetAllAsync();
            var cinemasDto = _mapper.Map<List<CinemaDTO>>(cinemas);
            return cinemasDto;
        }

        public async Task<CinemaDTO> GetByIdAsync(int id)
        {
            var cinema = await _cinemaRepository.GetByIdAsync(id);
            var cinemaDto = _mapper.Map<CinemaDTO>(cinema);
            return cinemaDto;
        }

        public void Remove(CinemaDTO cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);
            _cinemaRepository.Remove(cinema);
        }

        public void Update(CinemaDTO cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);
            _cinemaRepository.Update(cinema);
        }
    }
}