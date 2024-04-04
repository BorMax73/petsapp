using PetsApp.Domain;

namespace PetsApp.Interfaces;

public interface IPetRepository
{
	List<Pet> GetAll();
	List<Pet> GetByType(string type);
	Pet GetById(int id);
	void Add(Pet pet);
	void Update(Pet pet);
	void Delete(Pet pet);
	void DeleteById(int id);

}