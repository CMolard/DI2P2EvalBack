using DI2P2EvalBack.Models;
using DI2P2EvalBack.Services.Contracts.DTO.Up;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI2P2EvalBack.Services.Contracts
{
	public interface IEventsService
	{
		Task<Event> AddEvent(EventDtoUp newEvent);

		Task<List<Event>> GetAllEvents();
	}
}
