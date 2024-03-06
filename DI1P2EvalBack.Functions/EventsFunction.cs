using System.Net;
using System.Text;
using System.Text.Json;
using Azure;
using DI2P2EvalBack.Models;
using DI2P2EvalBack.Services.Contracts;
using DI2P2EvalBack.Services.Contracts.DTO.Up;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace DI1P2EvalBack.Functions
{
    public class EventsFunction
    {
        private readonly ILogger logger;
        private readonly IEventsService eventsService;

        public EventsFunction(ILoggerFactory loggerFactory, IEventsService eventsService)
        {
            logger = loggerFactory.CreateLogger<EventsFunction>();
            this.eventsService = eventsService;
        }

        [Function("AddFunctions")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Events")] HttpRequestData req)
        {
            logger.LogInformation("C# HTTP trigger function processed a add event request.");

            try
            {
                EventDtoUp newEvent = null;

				using (var reader = new StreamReader(req.Body, Encoding.UTF8))
				{
					string requestBody = await reader.ReadToEndAsync();

					newEvent = JsonSerializer.Deserialize<EventDtoUp>(requestBody, new JsonSerializerOptions()
					{
						PropertyNameCaseInsensitive = true,
					});

				}

                Event savedEvent = await eventsService.AddEvent(newEvent);

				HttpResponseData response = req.CreateResponse(HttpStatusCode.Created);
                await response.WriteAsJsonAsync(savedEvent);

                return response;
			}
            catch (Exception ex)
            {
				this.logger.LogError("Error : {ex.Message}", ex.Message);

				HttpResponseData response = req.CreateResponse(HttpStatusCode.InternalServerError);
				response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
				response.Body = new MemoryStream(Encoding.UTF8.GetBytes($"Error {ex.Message}"));

				return response;
			}
        }

		[Function("GetEventsFunction")]
		public async Task<HttpResponseData> GetEvents([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Events")] HttpRequestData req)
		{
			logger.LogInformation("C# HTTP trigger function processed a get all events request.");

			try
			{
				List<Event> events = await eventsService.GetAllEvents();

				HttpResponseData response = req.CreateResponse(HttpStatusCode.Created);
				await response.WriteAsJsonAsync(events);

				return response;
			}
			catch (Exception ex)
			{
				this.logger.LogError("Error : {ex.Message}", ex.Message);

				HttpResponseData response = req.CreateResponse(HttpStatusCode.InternalServerError);
				response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
				response.Body = new MemoryStream(Encoding.UTF8.GetBytes($"Error {ex.Message}"));

				return response;
			}
		}
	}
}
