
using System;
using System.IO;

namespace Record_index_file
{
	class Class1
	{
		static void Main()
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

							FileStream ifile= new FileStream("indexfile.txt",FileMode.Append);
							StreamWriter  writeindex = new StreamWriter(ifile);

							FileStream dfile = new FileStream("datafile.txt",FileMode.Append);
							StreamWriter writedata = new StreamWriter(dfile);    

							int len = (int) dfile.Length;
							
							//Writing my start in index file
                            writeindex.WriteLine(len);
                            writeindex.Close();

							//Writing record in data file
                            writedata.Write(record);
                            writedata.Close();
                            break;
                        }
                    case 'd':
                    case 'D':
                        {
						FileStream IFS = new FileStream("indexfile.txt",FileMode.Open);
						StreamReader readindex = new StreamReader(IFS);
						FileStream DFS = new FileStream("datafile.txt",FileMode.Open);
						StreamReader readdata = new StreamReader(DFS);
						
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
