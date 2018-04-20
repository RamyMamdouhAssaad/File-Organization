using System;

namespace Deleting_Fixed_Length_Records
{
	public class Student
	{
		public int ID_Len;
		public int Name_Len;
	
		public char[] ID;
		public char[] Name;
		//=========================================================================
		public Student()
		{
			ID_Len	 = 5;
			Name_Len = 20;
			
			ID   = new char[ID_Len];
			Name = new char[Name_Len];
		}		
		//=========================================================================
		public bool ReadData_FromUser()
		{
			string s;
			Console.Write("Enter ID : ");
			s = Console.ReadLine();
			if (s.Length > ID_Len)
			{
				Console.WriteLine("Error : ID Length Too Large !!!");
				return false;
			}
			s.CopyTo(0,ID,0,s.Length);
			for (int i=s.Length; i<ID_Len ; i++)
				ID[i] = '\0';
			
			Console.Write("Enter Name : ");
			s = Console.ReadLine();
			if (s.Length > Name_Len)
			{
				Console.WriteLine("Error : Name Length Too Large !!!");
				return false;
			}
			s.CopyTo(0,Name,0,s.Length);
			for (int i=s.Length; i<Name_Len ; i++)
				Name[i] = '\0';
			
			return true;
		}
		
		//=========================================================================
		public void Display_Data()
		{	
			Console.Write(ID);
			Console.Write("\t");
			Console.WriteLine(Name);
		}
	}
}
