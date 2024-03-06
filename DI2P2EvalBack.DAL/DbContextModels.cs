using DI2P2EvalBack.Models;
using Microsoft.EntityFrameworkCore;

namespace DI2P2EvalBack.DAL
{
	public class DbContextModels : DbContext
	{
		public DbContextModels(DbContextOptions<DbContextModels> options) : base(options)
		{
		}

		public virtual DbSet<Event> Events { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Event>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.Title)
					.IsRequired();

				entity.Property(e => e.Description)
					.IsRequired();

				entity.Property(e => e.Date)
					.IsRequired();

				entity.Property(e => e.Location)
				.IsRequired();
			});

			SeedDataBase(modelBuilder);
		}

		private static void SeedDataBase(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Event>().HasData(new Event()
			{
				Id = 1,
				Title = "Event name",
				Description = "Description of the event",
				Date = new DateTime(2023,03,06),
				Location = "Dijon"
			});
		}
	}
}
