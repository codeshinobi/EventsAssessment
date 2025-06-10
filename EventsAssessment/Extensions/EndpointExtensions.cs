using EventsAssessment.Domain.Events.Models;
using EventsAssessment.Domain.Shared;
using EventsAssessment.Domain.ShowTickets.Models;
using EventsAssessment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.Design;

namespace EventsAssessment.Extensions
{
    public static class EndpointExtensions
    {
        public static WebApplication AddEndpoints(this WebApplication app)
        {
            app.Use(next => context =>
            {
                context.Request.EnableBuffering();
                return next(context);
            });

            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapGet("/events", async Task<GenericResponse> (IEventService service) =>
            {
                var events = await service.GetAllEventsAsync();
                return new GenericResponse
                {
                    Success = true,
                    Data = events
                };
            });

            app.MapGet("/lookups", async Task<GenericResponse> (ILookupsService service) =>
            {
                var lookups = await service.GetLookups();
                return lookups;
            });

            app.MapGet("/events/get", async Task<GenericResponse> (IEventService service) =>
            {
                var events = await service.GetAllEventsAsync();

                return new GenericResponse()
                {
                    Success = true,
                    Data = events
                };
            });

            app.MapPost("/events/create", async Task<GenericResponse> (IEventService service, EventDTO data, [FromHeader] string xAuthToken) =>
            {
                // Perform jwt token scrutiny (xAuthToken) for security
                // Example is Keycloak token introspection
                // http://localhost:8080/auth/realms/<realm-id>/protocol/openid-connect/token/introspect

                var result = await service.AddEventAsync(data);
                if (result > 0)
                {
                    return new GenericResponse()
                    {
                        Success = true,
                        Message = "Successfully created!"
                    };
                }

                return new GenericResponse()
                {
                    Success = false,
                    Message = "Failed to create event!"
                };
            });

            app.MapPost("/tickets/create", async Task<GenericResponse> (IShowTicketService service, ShowTicketDTO data, [FromHeader] string xAuthToken) =>
            {
                // Perform jwt token scrutiny (xAuthToken) for security
                // Example is Keycloak token introspection
                // http://localhost:8080/auth/realms/<realm-id>/protocol/openid-connect/token/introspect

                var result = await service.Add(data);
                if (result > 0)
                {
                    return new GenericResponse()
                    {
                        Success = true,
                        Message = "Successfully created!"
                    };
                }

                return new GenericResponse()
                {
                    Success = false,
                    Message = "Failed to create ticket!"
                };
            });

            return app;
        }
    }
}
