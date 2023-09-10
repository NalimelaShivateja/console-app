namespace UserModel;
public class UserDetails
{
	public string FirstName{get; set;}
	public string LastName{get; set;}
	public DateOnly DateOfBirth{get; set;}
	public string EmailAddress{get; set;}
	public DateOnly GDYear{get; set;}
	public DateOnly DateOfJoining{get; set;}
	public string Department{get; set;}
	public decimal PastExperience{get; set;} 
}