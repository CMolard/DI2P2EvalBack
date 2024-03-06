using DI2P2EvalBack.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI1P2EvalBack.Functions
{
	public class DbContextModelsFactory : IDesignTimeDbContextFactory<DbContextModels>
	{
		public DbContextModels CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<DbContextModels>();

			optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString"));

			return new DbContextModels(optionsBuilder.Options);
		}
	}
}
