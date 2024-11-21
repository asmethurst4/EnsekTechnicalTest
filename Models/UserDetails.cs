namespace EnsekTechnicalTest.Models;

internal class UserDetails
{
	public required string Username { get; set; }
	public required string Password { get; set; }

	public static UserDetails AuthorisedUser => new()
	{
		Username = "test",
		Password = "testing"
	};

	public static UserDetails UnauthorisedUser => new()
	{
		Username = "not",
		Password = "allowed"
	};
}