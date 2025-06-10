using EventsAssessment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAssessment.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task<T?> GetById(object id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(object id);
    }
}
