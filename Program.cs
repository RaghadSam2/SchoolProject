using System;
using System.IO;

namespace TeacherRecords
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to Rainbow School System ... ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(" -- Teachers' Records -- ");

            string choice = "";
            string updateChoice = "";

            

            //Display main menu -- repeat until user chooses to "exit"
            do
            {
                Teacher t1 = new Teacher();

                Console.WriteLine("----------------------------------------------"+
                                    "\nPlease enter your choice:");
                Console.WriteLine(" (1) Add new teacher");
                Console.WriteLine(" (2) Update a Record");
                Console.WriteLine(" (3) Retrieve all records");
                Console.WriteLine(" (0) exit");
                Console.WriteLine("-----------------------------------");

                choice = Console.ReadLine();

                //Error message
                if( !( choice.Equals("0") || choice.Equals("1") || choice.Equals("2") || choice.Equals("3")) ) 
                {
                    Console.WriteLine("Error: Please Enter a Valid number, ("+ choice +") is not valid !");
                    continue;
                }

                //----------------------------------------------------
                //Check user input  
                if (choice.Equals("1")) { // Add new teacher 

                    Console.WriteLine("Enter Teacher Information :");

                    Console.Write("ID: ");
                    string id = Console.ReadLine();
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Class: ");
                    string class1 = Console.ReadLine();
                    Console.Write("Section: ");
                    string section = Console.ReadLine();

                    t1.addNewTeacher(id,name,class1,section);


                }
                else if (choice.Equals("2"))  //Update existing record
                {
                    //--- First: Find teacher id ---
                    Console.WriteLine("Enter teacher ID: ");
                    string id = Console.ReadLine();

                    //-- if teacher's record is not found- contintue- to first menu 
                    if (t1.teacherExist(id) == false)
                    {
                        Console.WriteLine("Error: Teacher ID doesn't exist, please try again... \n---------------------------------");
                        continue;
                    }

                    //--  Update - menu--------------------------
                    secondMenu:
                    Console.WriteLine("---------------------------------------------" +
                                        "\nPlease enter the number of the operation: "
                                     + "\n\t(1) Add new Class and Section"
                                     + "\n\t(2) Update Class info."
                                     + "\n\t(3) Delete Class" +
                                       "\n---------------------------------------------\n");

                    updateChoice = Console.ReadLine();

                    //Error message
                    if (!(updateChoice.Equals("1") || updateChoice.Equals("2") || updateChoice.Equals("3") ))
                    {
                        Console.WriteLine("Error: Please Enter a Valid number, (" + updateChoice + ") is not valid !");
                        goto secondMenu;
                    }

                        //-----------check choices -------------------
                        // 1 for adding NEW class
                        if (updateChoice.Equals("1"))  
                        {
                            Console.Write("-------------------"+ "\nEnter Class (ex: Math) : ");
                            string class1= Console.ReadLine();

                            Console.Write("\nEnter Section (ex: M1) : ");
                            string section = Console.ReadLine();

                            t1.addClass(id,class1,section);


                        }else if (updateChoice.Equals("2")) // update specific class
                        {  
                            Console.WriteLine("Enter the old class info. that you want to update \nold Class:");
                            string class1 = Console.ReadLine();
                            
                            Console.Write("old Section: ");
                            string section = Console.ReadLine();

                            Console.WriteLine("Enter the new class:");
                            string classNew = Console.ReadLine();
                            
                        Console.WriteLine("Enter the new Section: ");
                            string sectionNew = Console.ReadLine();

                            t1.updateClass(id, class1, section, classNew, sectionNew);

                        }
                        else if (updateChoice.Equals("3")) // Delete class
                        {
                            Console.WriteLine("To Delete Class and section.. ");
                            Console.Write("Enter Class to delete: ");
                            string class1 = Console.ReadLine();

                            Console.Write("Enter Section to delete: ");
                            string section = Console.ReadLine();

                            t1.deleteClass(id,class1 ,section);
                        }


                }// End-if choice =2= Updating record 

                else if (choice.Equals("3")) // To retrieve all existing records 
                {
                    t1.RetrieveAllRecords();
                }

            } while (choice != "0" );

            //Final statement --  
            Console.WriteLine("*****\n Thank you for using Rainbow School System, See you soon .. \n");

        }
         


    }
}
