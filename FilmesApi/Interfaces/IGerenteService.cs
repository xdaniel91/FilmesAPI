﻿using FilmesApi.Data.DTO;

namespace FilmesApi.Interfaces
{
    public interface IGerenteService
    {
        public Task AddAsync(GerenteDTO gerente);
        public Task<GerenteDTO> GetByIdAsync(int id);
        public Task<List<GerenteDTO>> GetAll();
        public void Delete(GerenteDTO gerente);
        public Task DeleteByIdAsync(int id);
        public void Update(GerenteDTO gerente);
    }
}
