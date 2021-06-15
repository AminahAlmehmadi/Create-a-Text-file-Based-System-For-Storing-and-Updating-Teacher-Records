using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecherRecordsProject
{
    class StudentsInfo
    {
        public void teacherfile()
        {
            // list for user to choose function that he want.. 
            Console.WriteLine("... Wellcome to the Rainbow School ...");
            Console.WriteLine("...............................");
            Console.WriteLine("Choose the function you need from below list: ");
            Console.WriteLine("Enter 1 for create new teacher file and add the data ..\nEnter 2 for update by delet record then add it again with new data and store in the teacher file.." +
            "\nEnter 3 for update file by insert (append) new data to the teacher file \nEnter 4 for retrive (print) data from  the teacher file ..\n" +
            "Enter 5 for exit ...");
            //take a user choose and return the fiunction he choose
            string task = Console.ReadLine();
            switch (task)
            {
                case "1":
                    Console.WriteLine("New teacher file is created ..");
                    createNewFile();
                    break;
                case "2":
                    Console.WriteLine("Now you going to update specific record in the teacher file ..");
                    deleteRecord();
                    break;
                case "3":
                    Console.WriteLine("Now you going to update by insert (append) new data to the teacher file ..");
                    updateByInset();
                    break;
                case "4":
                    Console.WriteLine(".. The content of teacher file is: ..");
                    printFile();
                    break;
                case "5":
                    quit();
                    break;
            }
        }
            //this function for add new file with new data. ask user about data and store it in file
            void createNewFile()
            {       FileStream fs = new FileStream("/Users/eleen/Desktop/teacherdata.txt", FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                try
                {
                    sw.WriteLine("New teacher file is created succussfully ... ");
                    Console.WriteLine("Teacher file created succussfuly ...");
                }
                catch(IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sw.Close();
                    fs.Close();
                }
            teacherfile();
            }
    
            void updateByInset()
            {
            FileStream fs = new FileStream("/Users/eleen/Desktop/teacherdata.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            try
                {
                    Console.WriteLine("How many number of record you want to added to tracher file: ");
                    int RecNum = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < RecNum; i++)
                    {
                        Console.WriteLine("please Enter the Id of student: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("please Enter the name of student: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("please Enter the class of student: ");
                        string classe = Console.ReadLine();
                        Console.WriteLine("please Enter the section of student: ");
                        string section = Console.ReadLine();
                    sw.WriteLine("student id: " + id + " student name: " + name + " student class: " + classe
                            + " student section: " + section);
                    
                        Console.WriteLine("the record added to teacher file is:\nstudent id: " + id + " student name: " + name + " student class: " + classe
                            + " student section: " + section);
                    Console.WriteLine("new record is added to the techer file succussfully. ");
                    Console.WriteLine();
                    }
                
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sw.Close();
                    fs.Close();
                }
                 teacherfile();
            }
        //this function will delete recor then added it again with new data..
        void deleteRecord()
        {
            string path = "/Users/eleen/Desktop/teacherdata.txt";
            Console.WriteLine("Enter the ID you want updated..");
            string idRec = Console.ReadLine();
            var oldLines = File.ReadAllLines(path);
            if (!oldLines.Contains(idRec))
            {
                Console.WriteLine("the record does not exit in teacher file..");
            }
            else
            {
                var newLines = oldLines.Where(line => !line.Contains(idRec));
                File.WriteAllLines(path, newLines);
                updateRec(idRec);
            }
        }
        void updateRec(string id)
        {
            FileStream fs = new FileStream("/Users/eleen/Desktop/teacherdata.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                Console.WriteLine("please Enter the new name of student: ");
                string name = Console.ReadLine();
                Console.WriteLine("please Enter the new class of student: ");
                string classe = Console.ReadLine();
                Console.WriteLine("please Enter the new section of student: ");
                string section = Console.ReadLine();
                sw.WriteLine("student id: " + id + " student name: " + name + " student class: " + classe
                                + " student section: " + section);

                Console.WriteLine("the record added to teacher file is:\nstudent id: " + id + " student name: " + name + " student class: " + classe
                    + " student section: " + section);
                Console.WriteLine("new record is added to the techer file succussfully. ");
                Console.WriteLine();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
            teacherfile();

    }
            //this function for retrive(print) all file content.
            void printFile()
            {
                FileStream fs = new FileStream("/Users/eleen/Desktop/teacherdata.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                try
                {
                    Console.WriteLine("this is the content of teacher file ....");
                    Console.WriteLine(sr.ReadToEnd());
                    Console.WriteLine("the end ... ");
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sr.Close();
                    fs.Close();
                }
            teacherfile();
            }
            void quit()
                 {
            System.Environment.Exit(1);
        }
        }
    }


