using EventsAssessment.Data.Models;
using EventsAssessment.Domain.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAssessment.Services.Interfaces
{
    public interface IEventService
    {
        Task<int> AddEventAsync(EventDTO entity);
        Task<int> UpdateEventAsync(EventDTO entity);
        Task<int> DeleteEventAsync(int id);
        Task<EventDTO> GetEventByIdAsync(int id);
        Task<IEnumerable<EventDTO>> GetAllEventsAsync();
    }
}
