namespace BusinessServices;
public class FetchDataClass
{
	public string[] ReturnUserDetails()
	{
		string filePath = "Data-base/users-data.csv";
		var entireData = File.ReadAllText(filePath).Split('\n');
		return entireData;
	}
}