﻿using DI2P2EvalBack.DAL.Contracts;
using DI2P2EvalBack.Models;

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
	}
}