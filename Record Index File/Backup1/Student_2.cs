using System;

namespace Record_index_file
{
	public class Student
	{
		public string ID;
		public string Name;
		public string Address;

		//============================================================
			
		public void ReadData_FromUser()
		{
			Console.Write("Enter ID : ");
			ID = Console.ReadLine();

			Console.Write("Enter Name : ");
			Name = Console.ReadLine();

			Console.Write("Enter Address : ");
			Address = Console.ReadLine();
		}

		//============================================================		
		public void Display_Data()
		{	
			Console.Write(ID);
			Console.Write("\t");
			Console.Write(Name);
			Console.Write("\t");
			Console.WriteLine(Address);
		}
	}

}
