using EventsAssessment.Data.Models;
using EventsAssessment.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAssessment.Repository.Implementation
{
    public class ShowTicketRepository : IShowTicketRepository
    {
        private readonly EventsAssessmentContext _context;
        private readonly DbSet<Showticket> _dbSet;

        public ShowTicketRepository(EventsAssessmentContext context)
        {
            _context = context;
            _dbSet = context.Set<Showticket>();
        }
        public async Task<int> Add(Showticket entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                return 1;
            }
            catch (Exception)
            {
                // log errors
                return -1;
            }
        }

        public async Task<int> Delete(string id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return -1;
            }
            else
            {
                _dbSet.Remove(entity);
                return 1;
            }
        }

        public async Task<IEnumerable<Showticket>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> CountCurrentTickets(int eventShowId)
        {
            var allTickets = await _dbSet.Where(item => item.EventShowId == eventShowId).ToListAsync();
            return allTickets.Count();
        }

        public async Task<IEnumerable<Showticket>> GetEventTickets(int eventShowId)
        {
            return await _dbSet.Where(item => item.EventShowId == eventShowId).ToListAsync();
        }

        public async Task<Showticket> GetById(string id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task<int> Update(Showticket entity)
        {
            try
            {
                _dbSet.Entry(entity).State = EntityState.Modified;
                return 1;
            }
            catch (Exception)
            {
                // log errors
                return -1;
            }
        }
    }
}
