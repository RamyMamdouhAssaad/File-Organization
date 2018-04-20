
using System;
using System.IO;

namespace StreamReader_StreamWriter
{
	
	class Class1
	{	
		static void Main()
		{
			Student Stud=new Student();
			string cont="y";
			while(cont=="y"||cont=="Y")
			{
				Console.WriteLine("A Add new student");
				Console.WriteLine("D Display student information");
				Console.Write("Enter your choice:");
				string str,choice=Console.ReadLine();
                string[] tmparr;
				switch(choice[0])
				{
					case 'a':
					case 'A':
					{
						FileStream FS=new FileStream("Data.txt",FileMode.Append);
						StreamWriter SW=new StreamWriter(FS);
						Stud.Get_Stud_Info();
                        str = Stud.Id + "*" + Stud.Name + "*" + Stud.Phone;
                        SW.WriteLine(str);
						SW.Close();
						break;
					}
					case 'd':
					case 'D':
					{
                        FileStream FS = new FileStream("Data.txt", FileMode.Open);
						StreamReader SR=new StreamReader(FS);
						while(SR.Peek()!=-1)
						{
							str=SR.ReadLine();
                            tmparr = str.Split('*');
                            Stud.Id = tmparr[0];
                            Stud.Name = tmparr[1];
							Stud.Phone=tmparr[2];
							Stud.Display_Stud_Info();
						}
						SR.Close();
						break;
					}
					default:
					{
						Console.WriteLine("Invalid Choice");
						break;
					}
				}//switch
				Console.WriteLine("Do You want to continue?");
				cont=Console.ReadLine();
			}//while
		}
	}
}
