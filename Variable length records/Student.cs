using System;

namespace StreamReader_StreamWriter
{
	
	public class Student
	{
		public string Id;
		public string Name;
		public string Phone;

		public void Display_Stud_Info()
		{
			Console.WriteLine("Student Information: {0},{1},{2}",Id,Name,Phone);
		}

		public void Get_Stud_Info()
		{
			
			Console.WriteLine("ID:");
			Id=Console.ReadLine();
			Console.WriteLine("Name:");
			Name=Console.ReadLine();
			Console.WriteLine("Phone:");
			Phone=Console.ReadLine();
		}
	}
}
