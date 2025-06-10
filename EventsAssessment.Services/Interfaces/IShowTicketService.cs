using EventsAssessment.Domain.ShowTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAssessment.Services.Interfaces
{
    public interface IShowTicketService
    {
        Task<ShowTicketDTO> Get(string ticketId);
        Task<IEnumerable<ShowTicketDTO>> GetAll(int eventId);
        Task<int> Add(ShowTicketDTO ticket);
        Task<int> Delete(string ticketId);
    }
}
