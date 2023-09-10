namespace ValidationServices;
public interface IValidationMethods
{
	bool CheckValidEmail(string x);
	bool CheckForInValidDates(DateOnly x, ref DateOnly y);
}
class Validatation : IValidationMethods
{
	public bool CheckValidEmail(string emailAddress)
	{
		string filePath = "Data-base/email-addresses.txt";
		try
		{
			if (!File.Exists(filePath))
			{
				using (var sw = File.CreateText(filePath))
				{
					sw.Write("{0},", emailAddress);
				}
				return true;
			}
			else
			{
				string[] valuesArray;
				using (var reader = new StreamReader(filePath))
				{
					var line = reader.ReadLine();
					valuesArray = line.Split(',');
				}
				if (valuesArray.Contains(emailAddress))
				{
					return false;
				}
				else
				{
					using (StreamWriter sw = File.AppendText(filePath))
					{
						sw.Write("{0},", emailAddress);
					}
					return true;
				}
				
				
			}
		}
		catch (Exception)
		{
			using (StreamWriter sw = File.AppendText(filePath))
			{
				sw.Write(emailAddress + ",");
			}
			return true;
		}

	}
	
	public bool CheckForInValidDates(DateOnly dateOfBirth, ref DateOnly targetDate)
	{
		return dateOfBirth >= targetDate;
	}
}