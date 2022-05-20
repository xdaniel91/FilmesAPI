﻿using AutoMapper;
using FilmesApi.Data.DTO;
using FilmesApi.Interfaces;
using FilmesApi.Models;

namespace FilmesApi.Services
{
    public class GerenteService : IGerenteService
    {

        private readonly IGerenteRepository _gerenteRepository;
        private readonly IMapper _mapper;

        public GerenteService(IGerenteRepository gerenteRepository, IMapper mapper)
        {
            _gerenteRepository = gerenteRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(GerenteDTO gerenteDto)
        {
            var gerente = _mapper.Map<Gerente>(gerenteDto);
            await _gerenteRepository.AddAsync(gerente);
        }

        public void Delete(GerenteDTO gerenteDto)
        {
            var gerente = _mapper.Map<Gerente>(gerenteDto);
            _gerenteRepository.Delete(gerente);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _gerenteRepository.DeleteByIdAsync(id);
        }

        public async Task<List<GerenteDTO>> GetAll()
        {
            var gerentes = await _gerenteRepository.GetAll();
            var gerentesDto = new List<GerenteDTO>();
            foreach (var gerente in gerentes)
            {
                var gerenteDto = _mapper.Map<GerenteDTO>(gerente);
                gerentesDto.Add(gerenteDto);
            }
            return gerentesDto;
        }

        public async Task<GerenteDTO> GetByIdAsync(int id)
        {
            var gerente = await _gerenteRepository.GetByIdAsync(id);
            var gerenteDto = _mapper.Map<GerenteDTO>(gerente);
            return gerenteDto;
        }

        public void Update(GerenteDTO gerenteDto)
        {
            var gerente = _mapper.Map<Gerente>(gerenteDto);
            _gerenteRepository.Update(gerente);
        }
    }
}