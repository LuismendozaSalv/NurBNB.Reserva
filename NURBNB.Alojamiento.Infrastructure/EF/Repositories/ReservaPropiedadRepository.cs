using Microsoft.EntityFrameworkCore;
using NURBNB.Alojamiento.Domain.Model.Reserva;
using NURBNB.Alojamiento.Domain.Repositories;
using NURBNB.Alojamiento.Infrastructure.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.Repositories
{
    public class ReservaPropiedadRepository : IReservaPropiedadRepository
    {
        private readonly WriteDbContext _context;

        public ReservaPropiedadRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ReservaPropiedad obj)
        {
            await _context.ReservaPropiedad.AddAsync(obj);
        }

        public async Task<List<ReservaPropiedad>> FindAll()
        {
           return await _context.ReservaPropiedad.ToListAsync();
        }

        public async Task<ReservaPropiedad?> FindByIdAsync(Guid id)
        {
            return await _context.ReservaPropiedad
                .Where(x => x.Id == id).AsSplitQuery().FirstOrDefaultAsync();
        }

        public Task UpdateAsync(ReservaPropiedad reservaPropiedad)
        {
            _context.ReservaPropiedad.Update(reservaPropiedad);
            return Task.CompletedTask;
        }
    }
}
