using EventsAssessment.Data.Models;
using EventsAssessment.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAssessment.Repository
{
    public class UnitOfWork
    {
        private EventsAssessmentContext context = new EventsAssessmentContext();

        private GenericRepository<Event> eventRepository;
        private GenericRepository<Eventtype> eventTypeRepository;
        private GenericRepository<Eventstatus> eventStatusRepository;
        private GenericRepository<Ticketstatus> ticketStatusRepository;
        private GenericRepository<Venuetype> venueTypeRepository;
        private GenericRepository<Venue> venueRepository;
        private GenericRepository<Eventshow> eventShowRepository;

        public GenericRepository<Event> EventRepository {  get { 
                if (eventRepository == null)
                {
                    eventRepository = new GenericRepository<Event>(context);
                }
                return eventRepository; } 
        }

        public GenericRepository<Eventtype> EventTypeRespository
        {
            get
            {
                if (eventTypeRepository == null)
                {
                    eventTypeRepository = new GenericRepository<Eventtype>(context);
                }

                return eventTypeRepository;
            }
        }

        public GenericRepository<Eventstatus> EventStatusRepository
        {
            get
            {
                if (eventStatusRepository == null)
                {
                    eventStatusRepository = new GenericRepository<Eventstatus>(context);
                }
                return eventStatusRepository;
            }
        }

        public GenericRepository<Ticketstatus> TicketStatusRepository
        {
            get
            {
                if (ticketStatusRepository == null)
                {
                    ticketStatusRepository = new GenericRepository<Ticketstatus>(context);
                }
                return ticketStatusRepository;
            }
        }

        public GenericRepository<Venuetype> VenueTypeRepository
        {
            get
            {
                if(venueTypeRepository == null)
                {
                    venueTypeRepository = new GenericRepository<Venuetype>(context);
                }
                return venueTypeRepository;
            }
        }

        public GenericRepository<Eventshow> EventShowRepository
        {
            get
            {
                if (eventShowRepository == null)
                {
                    eventShowRepository = new GenericRepository<Eventshow>(context);
                }
                return eventShowRepository;
            }
        }

        public GenericRepository<Venue> VenueRepository
        {
            get
            {
                if (venueRepository == null)
                {
                    venueRepository = new GenericRepository<Venue>(context);
                }
                return venueRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
