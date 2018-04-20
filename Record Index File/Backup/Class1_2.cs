
using System;
using System.IO;

namespace Record_index_file
{
	class Class1
	{
		static void Main(string[] args)
		{
			Student std = new Student();
			bool Continue = true;
			char ch;
			string record;

			while(Continue)
			{
				Console.WriteLine("\n-Press [1] To Add New Person.");
				Console.WriteLine("-Press [2] To Display Persons.");
				Console.WriteLine("-Press [3] To Exit.\n");
				Console.Write("Please Enter Your Choice : ");
				ch = char.Parse(Console.ReadLine());
				
				switch(ch)
				{				   
					case '1':
						while (true)
						{
							std.ReadData_FromUser();
							record = std.ID +"@" + std.Name  +"@" +std.Address;

							FileStream FS= 
								new FileStream("indexfile.txt",FileMode.Append);
							StreamWriter  SW = new StreamWriter(FS);

							FileStream d = new 
								FileStream("datafile.txt",FileMode.Append);
							StreamWriter data = new StreamWriter(d);    

							int len = (int) data.BaseStream.Length;
							
							//Writing my start in index file
							SW.WriteLine(len);
							SW.Close();

							//Writing record in data file
							data.Write(record);
							data.Close();

							Console.Write("\t\t\tMore Persons (y/n) : ");
							char ok = char.Parse(Console.ReadLine());
							if(ok != 'y')
								break;
						}
						break;

					case '2':
					{
						Console.WriteLine("\nID\tName\tAddress\n--\t----\t-------");				

						FileStream FS = new FileStream("indexfile.txt",FileMode.Open);
						StreamReader readindex = new StreamReader(FS);
						FileStream DF = new FileStream("datafile.txt",FileMode.Open);
						StreamReader readdata = new StreamReader(DF);
						
						string start,next,str;
						char[] data;
						string[] fields;
						int count;
						bool finished = false;

						start = readindex.ReadLine();
						while (!(finished))
						{
							try {
								next  = readindex.ReadLine();
								count = int.Parse(next) - int.Parse(start);
								start = next;
								
								data = new char[count];
								readdata.Read(data,0,count);
								str = new string (data);
								}
							catch
								{ 
								str = readdata.ReadToEnd();
								finished = true;
								}

							fields = str.Split('@');
							std.ID = fields[0];
							std.Name = fields[1];
							std.Address = fields[2];
								
							std.Display_Data();
							

						}//while

						readindex.Close();
						readdata.Close();
						break;
					}
					default:
						Continue = false;
						break;
				}
			}
		}
	}
}

