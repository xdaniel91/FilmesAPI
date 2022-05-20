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

        public void Add(CinemaDTO cinemaDto )
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);
            _cinemaRepository.AddAsync(cinema);
        }

        public void DeleteById(int id)
        {
            _cinemaRepository.DeleteByIdAsync(id);
        }

        public async Task<List<CinemaDTO>> GetAllAsync()
        {
            var cinemas = await _cinemaRepository.GetAllAsync();
            var cinemasDto = new List<CinemaDTO>();
            foreach (var cinema in cinemas)
            {
                var cinemaDto = _mapper.Map<CinemaDTO>(cinema);
                cinemasDto.Add(cinemaDto);
            }
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
