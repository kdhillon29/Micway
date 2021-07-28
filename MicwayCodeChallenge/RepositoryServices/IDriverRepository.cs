using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicwayCodeChallenge.Entities;

namespace MicwayCodeChallenge.RepositoryServices
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetDriverListAsync();
        Task<Driver> GetDriverByIdAsync(Guid id);
        Task<Driver> AddDriverAsync(Driver newDriver);
        Task UpdateDriverAsync(Driver updateDriver);
        Task DeleteDriverAsync(Guid id);
    }
}