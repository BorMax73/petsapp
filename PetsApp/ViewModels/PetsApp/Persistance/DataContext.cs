using Microsoft.EntityFrameworkCore;
using PetsApp.Domain;

namespace PetsApp.Persistance;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
		Database.EnsureCreated();
	}

	public DbSet<Pet> Pets { get; set; }
	public DbSet<PetImage> PetImages { get; set; }
	public DbSet<Admin> Admins { get; set; }
	
}