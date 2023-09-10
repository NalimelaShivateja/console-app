namespace BusinessServices;
public class DeleteUserInfoClass
{

	public bool IsDataEmpty()
	{
		if (!File.Exists("Data-base/email-addresses.txt"))
		{
			return true;
		}
		return false;
	}
	public bool ReturnDeleteStatus(string emailAddress)
	{
		string[] allEmails = File.ReadAllText("Data-base/email-addresses.txt").Split(',');
		if (!allEmails.Contains(emailAddress))
		{
			return false;
		}
		string line = "";
		var fs = File.Create("Data-base/temp-data.csv");
		fs.Dispose();
		using (var reader = new StreamReader("Data-base/users-data.csv"))
		{
			using (var writer = new StreamWriter("Data-base/temp-data.csv"))
			{
				while ((line = reader.ReadLine()) != null)
				{
					var values = line.Split(',');
					if (values[3] != emailAddress)
					{
						writer.WriteLine(line);
					}
				}
			}
		}
		File.Delete("Data-base/users-data.csv");
		File.Move("Data-base/temp-data.csv", "Data-base/users-data.csv");
		File.Delete("Data-base/temp-data.csv");
		File.Delete("Data-base/email-addresses.txt");
		var efs = File.Create("Data-base/email-addresses.txt");
		efs.Close();
		using (var writer = new StreamWriter("Data-base/email-addresses.txt"))
		{
			foreach (string x in allEmails)
			{
				if (x != emailAddress && x != "")
				{
					writer.Write(x + ",");
				}
			}
		}
		return true;
	}
}