using DI2P2EvalBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI2P2EvalBack.DAL.Contracts
{
	public interface IEventsRepository
	{
		Task<Event> AddEvent(Event newEvent);

		Task<List<Event>> GetAllEvents();

		Task<Event> UpdateEvent(Event updatedEvent);

		Task<Event?> GetEventById(int id);

		Task DeleteEvent(Event removedEvent);
	}
}
