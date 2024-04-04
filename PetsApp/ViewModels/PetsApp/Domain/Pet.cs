namespace PetsApp.Domain;

public class Pet : BaseModel
{
	public string Name { get; set; }
	public string Type { get; set; }
	public string Description { get; set; }
	public List<PetImage> Images { get; set; }
}