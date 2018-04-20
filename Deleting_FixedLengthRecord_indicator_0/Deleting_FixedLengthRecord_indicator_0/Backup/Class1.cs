using System;
using System.IO;

namespace Deleting_Fixed_Length_Records
{
	class Class1
	{
		static void Main(string[] args)
		{
			Student std = new Student();
			bool Continue = true;
			char ch;
			string record="";
			int head,newhead, offset;
			char[] c , recordarr ;
			string[] fields ;
			FileStream FS; StreamWriter SW; StreamReader SR;

			while(Continue)
			{
				Console.WriteLine("\n-Press [1] To Add Persons.");
				Console.WriteLine("-Press [2] To Display All Persons.");
				Console.WriteLine("-Press [3] To Delete Person.");
				Console.WriteLine("-Press [4] To Exit.\n");
				Console.Write("Please Enter Your Choice : ");
				ch = char.Parse(Console.ReadLine());
				
				switch(ch)
				{				   
				case '1': // Add Person
				{				
					if (!(File.Exists("customers_bank.txt ")))
					{
						FS   = new FileStream("customers_bank.txt ",FileMode.Create);
						FS.WriteByte((byte)0);
						FS.Close();						
					}
									
				while (true)
				{
					FS = new FileStream
						("customers_bank.txt ",FileMode.Open,FileAccess.ReadWrite);
					SW = new StreamWriter(FS);
					SR = new StreamReader(FS);

					std.ReadData_FromUser();
					recordarr = new char[25];
					std.ID.CopyTo(recordarr,0);
					std.Name.CopyTo(recordarr,5);

					// Read Head From File
					head = SR.BaseStream.ReadByte();
					Console.WriteLine(head);

					// if head contains 0
					if (head == 0) // No Reusable Record
					{
						// Write New Record At End Of File
						offset = (int) SW.BaseStream.Length;
						SW.BaseStream.Seek(offset,SeekOrigin.Begin);
						SW.Write(recordarr,0,25); 
					}
					else // Reusable Record Exists
					{
						// Read Deleted Record To Extract Its Reference RRN
						offset = ((head-1)*25)+1;
						SR.BaseStream.Seek(offset,SeekOrigin.Begin);

						c = new char[5];
						SR.Read(c,0,5);
						record = new string (c);
						fields = record.Split(new char[] {'*','|'});
						//-------------------------------------------
						
						// Write New Head
						SW.Flush();
						SW.BaseStream.Seek(0,SeekOrigin.Begin);
						newhead = int.Parse(fields[1]);
						SW.BaseStream.WriteByte((byte)newhead);
						
						//-------------------------------------------
						// Write New Record
						SW.Flush();
						SW.BaseStream.Seek(offset,SeekOrigin.Begin);
						SW.Write(recordarr,0,25); 
					}
					SW.Close();

					Console.Write("\t\t\tMore Persons (y/n) : ");
					char ok = char.Parse(Console.ReadLine());
					if(ok != 'y') break;
				}
					
				break;
				}
				//***************************************************************			  
					
				case '3': //Delete Person
				{
					FS = new FileStream
						("customers_bank.txt ",FileMode.Open,FileAccess.ReadWrite);
					SW = new StreamWriter(FS);
					SR = new StreamReader(FS);

					// Reading Old Head
					head = SR.BaseStream.ReadByte();
										
					//---------------------------------------------------------------				
					// Mark Row	As Deleted
					Console.WriteLine("Enter RRN of person you want to delete:");
					int RRN = int.Parse(Console.ReadLine());
					
					offset = ((RRN-1)*25)+1; // 1 for head
					SW.BaseStream.Seek(offset,SeekOrigin.Begin);
					SW.Write("*" + head.ToString() + "|");
				
					//---------------------------------------------------------------
					// Write New Head
					
					SW.Flush();
					//Clears all buffers for writer and causes any buffered data to be written to the stream.
					
					SW.BaseStream.Seek(0,SeekOrigin.Begin);
					SW.BaseStream.WriteByte((byte)RRN);
					SW.Close();

					Console.WriteLine("Person Deleted.");
					break;
				}
				//***************************************************************
			case '2': //Display All Persons
				{
					FS = new FileStream("customers_bank.txt ",FileMode.Open);
					SR = new StreamReader(FS);
				
					Console.WriteLine("ID\tName");
					Console.WriteLine("--\t----");
					c = new char[25];

					SR.BaseStream.ReadByte(); // To Read Head.

					while(SR.Peek() != -1)
					{	
						
						SR.Read(c,0,25);
						record = new string (c);
					
						std.ID   = record.Substring(0,5).ToCharArray();
						std.Name = record.Substring(5,20).ToCharArray();
						std.Display_Data();
					}
							
					SR.Close();
					break;
				}

				//***************************************************************
				default:
					Continue = false;
					break;
				}
			}
		}
	}
}
// We use only one byte for head --> RRN , thus max of 256 records may be written.

// To Mark Record As Deleted, we use:
// *oldRRN|
// This old RRN will be written in 3 bytes.
//----------------------------------------------------------------------------------


