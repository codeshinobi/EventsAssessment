using EventsAssessment.Data.Models;
using EventsAssessment.Domain.ShowTickets.Models;
using EventsAssessment.Repository;
using EventsAssessment.Repository.Interfaces;
using EventsAssessment.Services.Interfaces;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAssessment.Services.Implementation
{
    public class ShowTicketService : IShowTicketService
    {
        private readonly IShowTicketRepository _showTicketRepository;
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public ShowTicketService(IShowTicketRepository showTicketRepository)
        {
            _showTicketRepository = showTicketRepository;
        }

        public async Task<int> Add(ShowTicketDTO ticket)
        {
            // confirm capacity for event has not been reached
            var eventShowEntity = await _unitOfWork.EventShowRepository.GetById(ticket.EventShowId);
            var venueEntity = await _unitOfWork.VenueRepository.GetById(eventShowEntity.VenueId);
            var ticketCount = await _showTicketRepository.CountCurrentTickets(ticket.EventShowId);

            if(ticketCount >= venueEntity.Capacity)
            {
                return -1;
            }

            var ticketEntity = TinyMapper.Map<Showticket>(ticket);
            return await _showTicketRepository.Add(ticketEntity);
        }

        public async Task<int> Delete(string ticketId)
        {
            return await _showTicketRepository.Delete(ticketId);
        }

        public async Task<ShowTicketDTO> Get(string ticketId)
        {
            var ticketEntity = _showTicketRepository.GetById(ticketId);
            var ticket = TinyMapper.Map<ShowTicketDTO>(ticketEntity);

            return ticket;
        }

        public async Task<IEnumerable<ShowTicketDTO>> GetAll(int eventId)
        {
            var ticketEntities = await _showTicketRepository.GetEventTickets(eventId);
            var tickets = ticketEntities.Select(item => TinyMapper.Map<ShowTicketDTO>(item));

            return tickets;
        }
    }
}
