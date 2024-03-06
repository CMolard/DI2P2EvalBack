using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI2P2EvalBack.Services.Contracts.DTO.Up
{
	public class EventDtoUp
	{
		public string? Title { get; set; }
		public string? Description { get; set; }
		public DateTime? Date { get; set; }
		public string? Location { get; set; }
	}
}
