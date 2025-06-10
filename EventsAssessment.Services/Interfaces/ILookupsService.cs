using EventsAssessment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAssessment.Services.Interfaces
{
    public interface ILookupsService
    {
        Task<GenericResponse> GetLookups();
    }
}
