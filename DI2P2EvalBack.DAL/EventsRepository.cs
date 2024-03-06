using DI2P2EvalBack.DAL.Contracts;
using DI2P2EvalBack.Models;
using Microsoft.EntityFrameworkCore;

namespace DI2P2EvalBack.DAL
{
	public class EventsRepository : IEventsRepository
	{
		private readonly DbContextModels contextModels;

		public EventsRepository(DbContextModels contextModels)
		{
			this.contextModels = contextModels;
		}

		public async Task<Event> AddEvent(Event newEvent)
		{
			var eventEntry = contextModels.Events.Add(newEvent);
			await contextModels.SaveChangesAsync();

			return eventEntry.Entity;
		}

		public async Task<List<Event>> GetAllEvents()
		{
			return await contextModels.Events.ToListAsync();
		}

		public async Task<Event?> GetEventById(int id)
		{
			return await contextModels.Events.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
		}

		public async Task<Event> UpdateEvent(Event updatedEvent)
		{
			var eventEntry = contextModels.Events.Update(updatedEvent);
			await contextModels.SaveChangesAsync();

			return eventEntry.Entity;
		}
	}
}
