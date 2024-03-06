using DI2P2EvalBack.DAL.Contracts;
using DI2P2EvalBack.Models;
using DI2P2EvalBack.Services.Contracts;
using DI2P2EvalBack.Services.Contracts.DTO.Up;

namespace DI2P2EvalBack.Services
{
	public class EventsService : IEventsService
	{
		private readonly IEventsRepository eventsRepository;

		public EventsService(IEventsRepository eventsRepository)
		{
			this.eventsRepository = eventsRepository;
		}

		public async Task<Event> AddEvent(EventDtoUp newEvent)
		{
			if(newEvent == null) throw new ArgumentNullException(nameof(newEvent));

			if(string.IsNullOrEmpty(newEvent.Title)) throw new ArgumentNullException(nameof(newEvent.Title));
			if(string.IsNullOrEmpty(newEvent.Description)) throw new ArgumentNullException(nameof(newEvent.Description));
			if(string.IsNullOrEmpty(newEvent.Location)) throw new ArgumentNullException(nameof(newEvent.Location));
			if(newEvent.Date == null) throw new ArgumentNullException(nameof(newEvent.Date));

			Event eventToSaved = new Event()
			{
				Date = newEvent.Date.Value,
				Title = newEvent.Title,
				Description = newEvent.Description,
				Location = newEvent.Location,
			};

			return await eventsRepository.AddEvent(eventToSaved);
		}
	}
}
