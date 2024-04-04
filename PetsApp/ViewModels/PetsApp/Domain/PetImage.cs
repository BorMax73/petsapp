namespace PetsApp.Domain;

public class PetImage : BaseModel
{ 
	public int PetId { get; set; }
	public Pet Pet { get; set; }
	public string ImagePath { get; set; }
}