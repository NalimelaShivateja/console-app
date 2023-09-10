using ViewUserInfo;
using UserModel;
using ValidationServices;
using BusinessServices;
using System.Net.Mail;

namespace PresentationLayer;
 class PresentationLayerClass
{
	public static ViewUserInfoClass viewObj = new();
	public static DeleteUserInfoClass delObj = new();
	public static Validatation validationObj = new();
	public static void ReadUserInputs()
	{
		DateOnly dateOfBirth, gdYear, dateOfJoining;
		Console.WriteLine("------Please enter the following details------");
		Console.Write("First Name: ");
		string firstName = Console.ReadLine();
		Console.Write("Last Name: ");
		string lastName = Console.ReadLine();
		while(true)
		{
			try
			{
				Console.Write("Date Of Birth(dd/mm/yyyy): ");
				dateOfBirth = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
				break;
			}
			catch (Exception)
			{
				Console.WriteLine("Please enter the date in described format");
			}
		}
		
		Console.Write("Email Address: ");
		string emailAddress = Console.ReadLine();
		while(!validationObj.CheckValidEmail(emailAddress))
		{
			Console.Write("Email already exists or invalid, please enter a new email");
			emailAddress = Console.ReadLine();
		}
		//block to read correct gd year from user
		while(true)
		{
			try
			{
				Console.Write("Year Of Graduation(yyyy): ");
				gdYear = DateOnly.ParseExact(Console.ReadLine(), "yyyy", null);
				break;
			}
			catch (Exception)
			{
				Console.WriteLine("Please enter the date in described format");
			}
		}
		while(validationObj.CheckForInValidDates(dateOfBirth, ref gdYear))
		{
			Console.WriteLine("Graduation year is less than the Year of Birth");
			Console.Write("Please do enter a valid graduation year: ");
			gdYear = DateOnly.ParseExact(Console.ReadLine(), "yyyy", null);
		}
		
		//block to read correct date of joining from user
		while(true)
		{
			try
			{
				Console.Write("Date Of Joining(dd/mm/yyyy): ");
				dateOfJoining = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
				break;
			}
			catch (Exception)
			{
				Console.WriteLine("Please enter the date in described format");
			}
		}
		while (validationObj.CheckForInValidDates(dateOfBirth, ref dateOfJoining))
		{
			Console.WriteLine("Graduation year is less than the Year of Birth");
			Console.Write("Please do enter a valid graduation year: ");
			dateOfJoining = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
		}
		
		Console.Write("Department: ");
		string department = Console.ReadLine();
		Console.Write("Past Experience (in years): ");
		decimal pastExperience = Convert.ToDecimal(Console.ReadLine());

		//checking for validity of email address and dates
		UserDetails userObj = new()
		{
			FirstName = firstName,
			LastName = lastName,
			DateOfBirth = dateOfBirth,
			EmailAddress = emailAddress,
			GDYear = gdYear,
			DateOfJoining = dateOfJoining,
			Department = department,
			PastExperience = pastExperience
		};
		InsertDataClass.PushUserData(userObj);
		Console.WriteLine("-----------------------------------------");
		Console.WriteLine("User account created successfully!");
		Console.WriteLine("-----------------------------------------");
		Console.WriteLine("New user info created successfully");
		
	}
	public static void Main()
	{
		while (true)
		{
			Console.WriteLine("1. Create New User\n2. Show User Info\n3. Delete User Info\n4. Show Users List\n5. Exit");
			Console.Write("Please enter your choice of request: ");
			string userInput = Console.ReadLine();
			switch (userInput)
			{
				case "1":
					ReadUserInputs();
					break;

				case "2":
					Console.Write("Enter the user name: ");
					viewObj.ShowUserInfo(Console.ReadLine());
					break;

				case "3":
					if (delObj.IsDataEmpty())
					{
						Console.WriteLine("---------------------------------------");
						Console.WriteLine("Users list is empty!!");
						Console.WriteLine("----------------------------------------");
					}
					else
					{
						Console.Write("Enter the user first name: ");
						string firstName = Console.ReadLine();
						Console.Write("Enter the user email id: ");
						string emailAddress = Console.ReadLine();
						if (delObj.ReturnDeleteStatus(emailAddress))
						{
							Console.WriteLine("-------------------------------------------");
							Console.WriteLine("User account deleted successfully!");
							Console.WriteLine("--------------------------------------------");
						}
						else
						{
							Console.WriteLine("--------------------------------------------");
							Console.WriteLine("User details not found!");
							Console.WriteLine("--------------------------------------------");
						}
					}
					break;

				case "4":
					viewObj.ShowUsersList();
					break;

				case "5":
					Environment.Exit(0);
					break;

				default:
					Console.WriteLine("Please enter a valid choice");
					break;
			}
		}
	}
}