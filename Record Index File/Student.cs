using System;

namespace Record_index_file
{
	class Student
	{
		public string ID;
		public string Name;
		public string Address;

		//============================================================

        public void Get_Stud_Info()
		{
			Console.Write("Enter ID : ");
			ID = Console.ReadLine();

			Console.Write("Enter Name : ");
			Name = Console.ReadLine();

			Console.Write("Enter Address : ");
			Address = Console.ReadLine();
		}

		//============================================================		
        public void Display_Stud_Info()
		{	
			Console.Write(ID);
			Console.Write("\t");
			Console.Write(Name);
			Console.Write("\t");
			Console.WriteLine(Address);
		}
	}

}
