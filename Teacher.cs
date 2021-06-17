using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TeacherRecords
{
    
    class Teacher
    {
        private string ID;
        private string Name;
        private string Class, Section;
        private string path = "teacherRec.txt";

        public bool teacherExist(string id) 
        {
            bool found = false;
            string idLabel = "";

            string[] arrayContent = File.ReadAllLines(path);

            //storing the correct length 
            int length1 = arrayContent.Length - 2; //minus 2 - for last line

            // Loop to find --teacher by id
            for (int i = 0; i < length1 ; i++) // -1 .. the length count the last empty line in file
            { 
                //if not null --> has content
                if(arrayContent[i] != null) {
                    // using id label - to search for id
                    idLabel = arrayContent[i].Substring(0, 4); 
                }

                //if NOT ID-line --> move to next iteration
                if (idLabel != "ID: ") 
                {
                    continue;
                }

                string teacherId = arrayContent[i].Substring(4, 4);    //id always start index:4, length:4

                //if -teacher id- is found
                if (idLabel.Equals("ID: ") && teacherId.Equals(id) )
                { 
                    Console.WriteLine("Teacher is found");
                    found = true;
                }

            }//End -for- loop

            return found;
        }

        public void deleteClass(string id,string class1, string section)
        {
            bool deleted = false;
            string[] content = File.ReadAllLines(path);

            //Read file 
            string[] contentAll = File.ReadAllLines(path);

            //new content - updated with new class added
            string[] newContent = new string[contentAll.Length - 1];

            for (int i = 0; i < contentAll.Length; i++)//finding teacher
            {
                //if --> search -line- contains teacher id 
                if (contentAll[i].Contains(id))
                {
                    //-- (i+2) -> skip Name, and jump to teachers' classes 
                    //loop --> to iterate for all classes
                    for (int b = i + 2; b < contentAll.Length-1; b++) 
                    {
                        //find line that contains the -class- to delete
                        if (contentAll[b].Contains(class1) && contentAll[b].Contains(section))
                        {
                            // b -> holds last index and total length 
                            Array.Copy(contentAll, 0, newContent, 0, b);

                            //delete class string
                            contentAll[b] = "" ;

                            //copy remained text
                            Array.Copy(contentAll, (b+1), newContent, b, (newContent.Length - b));

                            //Copy to the file
                            File.WriteAllLinesAsync(path, newContent);
                            deleted = true;
                            Console.WriteLine("\n Class Deleted Successfully ..! \n");
                            break;

                        }//if class is found


                    }// for - finding last class
                }

            }//for- teachers

            if (deleted == false)
            {
                Console.WriteLine("Sorry, class and section are not found, please try again ... ");
            }
        }

        public void addNewTeacher(string id, string name, string Tclass, string section)
        {
            StreamWriter sw2 = File.AppendText(path); 

            sw2.WriteLine("ID: " + id);
            sw2.WriteLine("Name: " + name);
            sw2.WriteLine($"Class and Section: {Tclass}, {section}");
            sw2.WriteLine("----------");

            sw2.Close();

        }

        public void addClass(string id, string newClass, string newSection)
        {
            //Read file 
            string[] contentAll = File.ReadAllLines(path);

            //new content - updated with new class added
            string[] newContent = new string[contentAll.Length + 1];

            for (int i = 0; i < contentAll.Length; i++)//finding teacher
            {
                //find teacher 
                if (contentAll[i].Contains(id))
                {
                    // (i+2) ->  jump to classes 
                    for (int b = i + 2; b < contentAll.Length; b++) //iterate for classes
                    {
                        //find last class of that teacher
                        if (contentAll[b].StartsWith("----"))
                        {
                            // b -> holds last index and total length 
                            Array.Copy(contentAll, 0, newContent, 0, b);

                            //add new course string
                            newContent[b] = "Class and Section: " + newClass + ", " + newSection;

                            //copy remained text
                            Array.Copy(contentAll, b, newContent, (b + 1), (newContent.Length - (b + 1)));

                            //Copy newContent to the file
                            File.WriteAllLinesAsync(path, newContent);

                            Console.WriteLine("\n New Class added Successfully ..! \n");
                            break;

                        }//if-  last-class is found

                    }// for - finding last class
                }

            }//for- teachers

        }

        public void RetrieveAllRecords()
        {
            //Read file
            string text = File.ReadAllText(path);

            //print all records
            System.Console.WriteLine("Retrieving all Records... \n-----\n{0}", text);
            Console.WriteLine("");
        }

        public void updateClass(string id, string oldClass,string oldSection, string newClass, string newSection)
        {
            bool found= false;
            //Read file 
            string[] contentAll = File.ReadAllLines(path);

                for (int i=0;i <contentAll.Length; i++)//finding teacher
                {
                //find teacher
                if (contentAll[i].Contains(id))
                { 
                    // for --> iterate classes
                    for(int b= i+2; b < contentAll.Length; b++) 
                    {
                        //find old class to update it
                        if (contentAll[b].Contains(oldClass) && contentAll[b].Contains(oldSection))
                        {
                            found = true;
                            string updatedInfo = "Class and Section: " + newClass + ", " + newSection;
                            
                            contentAll[b] = "";
                            contentAll[b] = updatedInfo;

                            File.WriteAllLinesAsync(path, contentAll);
                            Console.WriteLine("\nClass and Section are updated successfully..\n");
                            break;
                        }// if - class found

                    }// for - classes
                }//if - teacher found

                 }//for- teachers

            //Error Message 
            if (found == false)
            {
                Console.WriteLine($"Error, Sorry the class: {oldClass} and  section: {oldSection} are not found, Please try again .. (check if the spelling is correct)");
            }

        }// update method


    }
}





