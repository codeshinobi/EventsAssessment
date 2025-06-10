using EventsAssessment.Data.Models;
using EventsAssessment.Domain.Events.Models;
using EventsAssessment.Repository;
using EventsAssessment.Repository.Interfaces;
using EventsAssessment.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAssessment.Services.Implementation
{
    public class EventService : IEventService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public async Task<int> AddEventAsync(EventDTO entityDTO)
        {

            var entity = TinyMapper.Map<Event>(entityDTO);
            return await unitOfWork.EventRepository.Add(entity);
        }

        public async Task<int> UpdateEventAsync(EventDTO entityDTO)
        {
            var entity = TinyMapper.Map<Event>(entityDTO);
            return await unitOfWork.EventRepository.Update(entity);
        }

        public async Task<int> DeleteEventAsync(int id)
        {
            return await unitOfWork.EventRepository.Delete(id);
        }

        public async Task<EventDTO> GetEventByIdAsync(int id)
        {
            var entity = await unitOfWork.EventRepository.GetById(id);
            return TinyMapper.Map<EventDTO>(entity);
        }

        public async Task<IEnumerable<EventDTO>> GetAllEventsAsync()
        {
            var entities = await unitOfWork.EventRepository.GetAll();
            var entityDTOs = entities.Select(item => TinyMapper.Map<EventDTO>(item));

            return entityDTOs;
        }
    }
}
