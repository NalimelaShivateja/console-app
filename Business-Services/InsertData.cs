using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using UserModel;

namespace BusinessServices;
public static class InsertDataClass
{
	public static void PushUserData(UserDetails userObj)
	{
		// Path to the CSV file
		string filePath = "Data-base/users-data.csv";

		if (!File.Exists(filePath))
		{
			using (StreamWriter sw = File.CreateText(filePath))
			{
				sw.WriteLine("First Name,Last Name,Date Of Birth,Email Address,Graduation Year,Date Of Joining,Department,Past Experience");
				foreach (var x in userObj.GetType().GetProperties())
				{
					sw.Write(x.GetValue(userObj, null).ToString() + ",");
				}
				sw.WriteLine();
			}
		}
		else
		{
			using (StreamWriter sw = File.AppendText(filePath))
			{
				foreach (var x in userObj.GetType().GetProperties())
				{
					sw.Write(x.GetValue(userObj, null).ToString() + ",");
				}
				sw.WriteLine();
			}
		}

	}
}