using EventsAssessment.Domain.Shared;
using EventsAssessment.Repository;
using EventsAssessment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAssessment.Services.Implementation
{
    public class LookupsService : ILookupsService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public async Task<GenericResponse> GetLookups()
        {
            var genericResponse = new GenericResponse();

            try
            {
                var eventStatuses = await unitOfWork.EventStatusRepository.GetAll();
                var eventTypes = await unitOfWork.EventTypeRespository.GetAll();
                var ticketStatuses = await unitOfWork.TicketStatusRepository.GetAll();
                var venueTypes = await unitOfWork.VenueTypeRepository.GetAll();

                genericResponse.Success = true;
                genericResponse.Data = new
                {
                    eventStatuses,
                    eventTypes,
                    ticketStatuses,
                    venueTypes
                };
            }
            catch (Exception)
            {
                genericResponse.Success = false;
            }            

            return genericResponse;
        }
    }
}
