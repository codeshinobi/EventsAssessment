using EventsAssessment.Data.Models;
using EventsAssessment.Domain.Events.Models;
using EventsAssessment.Domain.ShowTickets.Models;
using EventsAssessment.Extensions;
using Nelibur.ObjectMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();

var app = builder.Build();

TinyMapper.Bind<EventDTO, Event>();
TinyMapper.Bind<ShowTicketDTO, Showticket>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.AddEndpoints();
app.UseHttpsRedirection();

app.Run();
