
using System;
using System.IO;

namespace Record_index_file
{
	class Class1
	{
		static void Main(string[] args)
		{
            Student std = new Student();
            string cont = "y";
            while (cont == "y" || cont == "Y")
            {
                Console.WriteLine("A Add new student");
                Console.WriteLine("D Display student information");
                Console.Write("Enter your choice:");
                string choice = Console.ReadLine();
                string record;
                switch (choice[0])
                {
                    case 'a':
                    case 'A':
                        {
							std.Get_Stud_Info();
							record = std.ID +"@" + std.Name  +"@" +std.Address;

							FileStream FS= new FileStream("indexfile.txt",FileMode.Append);
							StreamWriter  SW = new StreamWriter(FS);

							FileStream d = new FileStream("datafile.txt",FileMode.Append);
							StreamWriter data = new StreamWriter(d);    

							int len = (int) data.BaseStream.Length;
							
							//Writing my start in index file
							SW.WriteLine(len);
							SW.Close();

							//Writing record in data file
							data.Write(record);
							data.Close();
                            break;
                        }
                    case 'd':
                    case 'D':
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
								
							std.Display_Stud_Info();
							

						}//while

						readindex.Close();
						readdata.Close();
                        break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice");
                            break;
                        }
                }//switch
                Console.WriteLine("Do You want to continue?");
                cont = Console.ReadLine();
            }//while
        }
    }
}
