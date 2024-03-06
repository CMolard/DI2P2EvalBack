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

		public async Task<List<Event>> GetAllEvents()
		{
			return await eventsRepository.GetAllEvents();
		}

		public async Task DeleteEvent(int id)
		{
			Event deletedEvent = await GetEventById(id);

			await eventsRepository.DeleteEvent(deletedEvent);
		}

		public async Task<Event> UpdateEvent(Event updatedEvent)
		{
			if (updatedEvent == null) throw new ArgumentNullException(nameof(updatedEvent));

			if (updatedEvent.Id == null) throw new ArgumentNullException(nameof(updatedEvent.Id));
			if (string.IsNullOrEmpty(updatedEvent.Title)) throw new ArgumentNullException(nameof(updatedEvent.Title));
			if (string.IsNullOrEmpty(updatedEvent.Description)) throw new ArgumentNullException(nameof(updatedEvent.Description));
			if (string.IsNullOrEmpty(updatedEvent.Location)) throw new ArgumentNullException(nameof(updatedEvent.Location));
			if (updatedEvent.Date == null) throw new ArgumentNullException(nameof(updatedEvent.Date));
			await GetEventById(updatedEvent.Id.Value);

			return await eventsRepository.UpdateEvent(updatedEvent);
		}

		private async Task<Event> GetEventById(int id)
		{
			Event? existingEvent = await eventsRepository.GetEventById(id);

			if (existingEvent is null) throw new Exception("The event does not exist");

			return existingEvent;
		}
	}
}
