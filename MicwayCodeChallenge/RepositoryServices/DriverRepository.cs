using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MicwayCodeChallenge.DbContexts;
using MicwayCodeChallenge.Entities;

namespace MicwayCodeChallenge.RepositoryServices
{
    public class DriverRepository : IDriverRepository
    {
        private readonly Context _context;

        public DriverRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            
        }

        public async Task<Driver> AddDriverAsync(Driver newDriver)
        {
             await  _context.Drivers.AddAsync(newDriver);
             await _context.SaveChangesAsync();
            return newDriver;
                    

        }

        public async Task  DeleteDriverAsync(Guid id)
        {
            var driver = await GetDriverByIdAsync(id);
            if(driver!=null)
            {
                 _context.Drivers.Remove(driver);
                _context.SaveChanges();
            }
        }

        public async  Task<Driver> GetDriverByIdAsync(Guid id)
        {
            var driver =  await _context.Drivers.FindAsync(id);
            return driver;
        }

        public async  Task<IEnumerable<Driver>> GetDriverListAsync()
        {
              var drivers =  await _context.Drivers.ToListAsync();
              return drivers;
        }

        public async Task UpdateDriverAsync(Driver updateDriver)
        {
            var entity =   _context.Drivers.Attach(updateDriver);
            entity.State = EntityState.Modified;
            await _context.SaveChangesAsync();

           
        }
    }
}