using BusinessServices;
namespace ViewUserInfo;


public interface IViewMethods
{
	void ShowUserInfo(string userName);
	void ShowUsersList();
}
public class ViewUserInfoClass:IViewMethods
{
	FetchDataClass fetchObj = new();
	public void ShowUserInfo(string userName)
	{
		string[] entireData = fetchObj.ReturnUserDetails();
		var headersArray = entireData[0].Split(',');
		if (entireData.Length == 1)
		{
			Console.WriteLine("------------------------------------");
			Console.WriteLine("Users list is empty :(");
			Console.WriteLine("-------------------------------------");
		
		}
		bool flag = true;
		for (int i = 1; i < entireData.Length; i++)
		{
			var temp = entireData[i].Split(',');
			if (temp[0] == userName)
			{
				Console.WriteLine("--------------------------------------------");
				flag = false;
				for (int j = 0; j < headersArray.Length; j++)
				{
					Console.WriteLine("{0}: {1}", headersArray[j], temp[j]);
				}
				Console.WriteLine("--------------------------------------------");
			}
		}
		if (flag)
		{
			Console.WriteLine("--------------------------------------------");
			Console.WriteLine("User not found :(");
			Console.WriteLine("--------------------------------------------");
		}
	}

	public void ShowUsersList()
	{
		string[] entireData = fetchObj.ReturnUserDetails();
		if (entireData.Length == 1)
		{
			Console.WriteLine("--------------------------------------------");
			Console.WriteLine("Users list is empty :(");
			Console.WriteLine("--------------------------------------------");
		}
		else
		{
			//write code to display list of users
			var headersList = entireData[0].Split(',');
			int index = 0;
			string userChoice = "n";
			while (true)
			{

				switch (userChoice)
				{
					case "n":
						if (index + 1 == entireData.Length - 1)
						{
							Console.WriteLine("--------------------------------------------");
							Console.WriteLine("Invalid Choice, already at the last page");
							Console.WriteLine("--------------------------------------------");
						}
						else
						{
							index += 1;
							Console.Clear();
							string[] userDetails = entireData[index].Split(',');
							Console.WriteLine("--------------------------------------------");
							Console.WriteLine("PAGE: {0}", index);
							for (int i = 0; i < headersList.Length; i++)
							{
								Console.WriteLine("{0}: {1}", headersList[i], userDetails[i]);
							}
							Console.WriteLine("--------------------------------------------");
						}
						break;

					case "p":
						if (index - 1 <= 0)
						{
							Console.WriteLine("--------------------------------------------");
							Console.WriteLine("Invalid choice, already at starting page");
							Console.WriteLine("--------------------------------------------");
						}
						else
						{
							index -= 1;
							Console.Clear();
							string[] userDetails = entireData[index].Split(',');
							Console.WriteLine("--------------------------------------------");
							Console.WriteLine("PAGE: {0}", index);
							for (int i = 0; i < headersList.Length; i++)
							{
								Console.WriteLine("{0}: {1}", headersList[i], userDetails[i]);
							}
							Console.WriteLine("--------------------------------------------");
							Console.Write("Enter p for previous or n for next user details or e for exiting this service");
							Console.WriteLine("--------------------------------------------");
						}
						break;

					case "e":
						return;

					default:
						Console.WriteLine("--------------------------------------------");
						Console.WriteLine("Invalid choice, please select the valid options");
						Console.WriteLine("--------------------------------------------");
						break;
				}
				Console.WriteLine("--------------------------------------------");
				Console.WriteLine("Enter p for previous or n for next user details or e for exiting this service");
				Console.WriteLine("--------------------------------------------");
				userChoice = Console.ReadLine();
			}
		}
	}
}


