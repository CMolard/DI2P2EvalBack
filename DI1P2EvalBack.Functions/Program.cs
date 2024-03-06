using DI2P2EvalBack.DAL;
using DI2P2EvalBack.DAL.Contracts;
using DI2P2EvalBack.Services;
using DI2P2EvalBack.Services.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
	.ConfigureFunctionsWorkerDefaults()
	.ConfigureServices(services =>
	{
		services.AddDbContext<DbContextModels>(options =>
		{
			options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString"));
		});

		services.AddScoped<IEventsService, EventsService>();
		services.AddScoped<IEventsRepository, EventsRepository>();
	})
	.Build();

host.Run();
