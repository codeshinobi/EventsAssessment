using EventsAssessment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAssessment.Repository.Interfaces
{
    public interface IShowTicketRepository
    {
        Task<Showticket> GetById(string id);
        Task<IEnumerable<Showticket>> GetAll();
        Task<IEnumerable<Showticket>> GetEventTickets(int eventShowId);
        Task<int> Add(Showticket entity);
        Task<int> Update(Showticket entity);
        Task<int> Delete(string id);
        Task<int> CountCurrentTickets(int eventShowId);
    }
}
