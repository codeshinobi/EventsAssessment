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
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly EventsAssessmentContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(EventsAssessmentContext context) : base()
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<int> Add(T entity)
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

        public virtual async Task<int> Delete(object id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                _dbSet.Remove(entity);

                return 1;
            }
            catch (Exception)
            {
                // log errors
                return -1;
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<int> Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
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
