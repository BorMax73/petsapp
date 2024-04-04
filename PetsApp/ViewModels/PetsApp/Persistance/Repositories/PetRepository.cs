using Microsoft.EntityFrameworkCore;
using PetsApp.Domain;
using PetsApp.Interfaces;

namespace PetsApp.Persistance.Repositories;

public class PetRepository : IPetRepository
{
	private readonly DataContext _context;

	public PetRepository(DataContext context)
	{
		_context = context;
	}

	public List<Pet> GetAll()
	{
		return _context.Pets.Include(x => x.Images).ToList();
	}

	public List<Pet> GetByType(string type)
	{
		return _context.Pets.Where(p => p.Type == type).Include(x=>x.Images).ToList();
	}

	public Pet GetById(int id)
	{
		return _context.Pets.Include(x=>x.Images).FirstOrDefault(p => p.Id == id);
	}

	public void Add(Pet pet)
	{
		_context.Pets.Add(pet);
		_context.SaveChanges();
	}

	public void Update(Pet pet)
	{
		_context.Pets.Update(pet);
		_context.SaveChanges();
	}

	public void Delete(Pet pet)
	{
		_context.Pets.Remove(pet);
		_context.SaveChanges();
	}

	public void DeleteById(int id)
	{
		var pet = GetById(id);
		Delete(pet);
	}
	
}