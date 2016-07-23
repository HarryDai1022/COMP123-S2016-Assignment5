using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/**
 * Author: Zun Dai
 * Student ID: 300839401
 * Date modified: 2016-07-22
 * Program description: Assigment5, FilE I/O and Exception Handling
 * 
 */

namespace COMP123_S2016_Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            string pathName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            const char DELIM = ',';

            int selection = 0;

            while (selection != 2)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("Press 1 or 2 to continue:");
                Console.WriteLine(" 1. Display Grades    ");
                Console.WriteLine(" 2. Exit              ");
                Console.WriteLine("***************************");

                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    selection = 0;
                }
                switch (selection)
                {
                    case 1:
                        CreateGradeTxt(pathName, DELIM);
                        DisplayGrades(pathName, DELIM);
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a correct input \n");
                        break;
                }
            }
        }

        private static void CreateGradeTxt(string pathName, char DELIM)
        {
            string fileName = "Grade.txt";
            string firstName;
            string lastName;
            string Index;
            string className;
            string classGrade;

            try
            {
                FileStream outFile = new FileStream(pathName + "\\" + fileName, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);

                for (int i = 0; i < 3; i++)
                {
                    writer.WriteLine(firstName[i] + DELIM + lastName[i] + DELIM + Index[i] + DELIM + className[i] + DELIM + classGrade[i]);
                }
                writer.Close();
                outFile.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0}", error.Message);
            }
        }

        public static void DisplayGrades(string pathName, char DELIM)
        {
            string fileName;
            string[] fields;
            string fileData = "";
            string firstName;
            string lastName;
            string studentIndex;
            string className;
            string classGrade;

            Console.Write("Please enter the file name: ");
            fileName = Console.ReadLine();
            Console.WriteLine();

            try
            {
                FileStream inFile = new FileStream(pathName + "\\" + fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);

                fileData = reader.ReadLine();

                while (fileData != null)
                {
                    fields = fileData.Split(DELIM);
                    firstName = fields[0];
                    lastName = fields[1];
                    studentIndex = fields[2];
                    className = fields[3];
                    classGrade = fields[4];

                    Console.WriteLine("{0}, {1}: {2} {3}, {4}", firstName, lastName, studentIndex, className, classGrade);
                    fileData = reader.ReadLine();
                }
                Console.WriteLine();
                reader.Close();
                inFile.Close();
            }
            catch (FileNotFoundException)
            {
                Console.Clear();
                Console.WriteLine("File doesn't exist ");
            }
        }
    }
}

