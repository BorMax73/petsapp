namespace PetsApp.Domain;

public class Admin : BaseModel
{
	public string Username { get; set; }
	public string Password { get; set; }
	public string AccessType { get; set; }
}