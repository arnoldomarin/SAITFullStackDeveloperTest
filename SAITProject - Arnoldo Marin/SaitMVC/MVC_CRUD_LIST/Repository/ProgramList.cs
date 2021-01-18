using MVC_CRUD_LIST.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static MVC_CRUD_LIST.Models.SaitPrograms;

namespace MVC_CRUD_LIST.Repository
{
    public static class ProgramList
    {
        static List<SaitPrograms> progList = null;

        /// <summary>
        /// Function that makes a list of programs obtained from the CSV files (TextFile1).
        /// </summary>
        static ProgramList()
        {
            string fileName = "TextFile1.txt";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            progList = System.IO.File.ReadAllLines(path)
                   .Select(v => SaitPrograms.FromCsv(v))
                   .ToList();
        }

        /// <summary>
        /// Helper Function that will return a current list of SAIT programs. 
        /// </summary>
        /// <returns>progList - List of SAIT Programs</returns>
        public static List<SaitPrograms> SelectProgramList()
        {       
            return progList;
        }

        /// <summary>
        /// Function that takes a program and adds it to the list of programs for the UI and to the CSV file. 
        /// </summary>
        /// <param name="prog">Program to be added to the list of programs</param>
        public static void InsertProgramList(SaitPrograms prog)
        {
            string fileName = "TextFile1.txt";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            // Add to UI
            progList.Add(prog);

            // CSV File
            addProgram(prog.ProgramID, prog.ProgramName, prog.ProgramPriority, prog.ProgramStatus, path); 

        }

        /// <summary>
        /// Function that adds new program to the CSV File.
        /// </summary>
        /// <param name="Id">Program ID</param>
        /// <param name="name">Program Name</param>
        /// <param name="priority">Program Priority</param>
        /// <param name="status">Program Status</param>
        /// <param name="filepath">path of the CSV File</param>
        public static void addProgram(int Id, string name, int? priority, string status, string filepath)
        {
            try
            {
                
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    file.WriteLine(Id + "," + name + "," + priority + "," + status);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error adding the program: ", ex);
            }
        }

        /// <summary>
        /// Function that updates the program if there are changes. 
        /// </summary>
        /// <param name="prog">program to be updated</param>
        public static void UpdateProgramList(SaitPrograms prog)
        {
            SaitPrograms progUpdate = progList.Find(x => x.ProgramID == prog.ProgramID);
            
            progUpdate.ProgramName = prog.ProgramName;
            progUpdate.ProgramPriority = prog.ProgramPriority;
            progUpdate.ProgramStatus = prog.ProgramStatus;
        }

        /// <summary>
        /// Function that takes care of the deletion of a program from the UI 
        /// </summary>
        /// <param name="id"> Program ID to be deleted </param>
        public static void DeleteProgramList(int id)
        {
            string fileName = "TextFile1.txt";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            SaitPrograms progDelete = progList.Find(x => x.ProgramID == id);
            progList.Remove(progDelete);
            deleteProgram(progDelete.ProgramName, path, 2);
        }

        /// <summary>
        /// Function that determines where the search term is located (if it exists) and returns a bool
        /// </summary>
        /// <param name="searchTerm">Status of the program</param>
        /// <param name="record">Current program being checked in the list</param>
        /// <param name="positionOfSearchTerm"> Column in which the searched term will be located</param>
        /// <returns></returns>
        public static bool recordMatches(string searchTerm, string[] record, int positionOfSearchTerm)
        {
            if (record[positionOfSearchTerm].Equals(searchTerm))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Function that deals with deleting a program from the CSV File
        /// </summary>
        /// <param name="searchTerm"> program to be deleted</param>
        /// <param name="filepath">CSV file location</param>
        /// <param name="positionofSearchTerm">Column where the searched item would be located</param>
        public static void deleteProgram(string searchTerm, string filepath, int positionofSearchTerm)
        {
            string fileName = "temp.txt";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            positionofSearchTerm--;
            string tempFile = @path; // when deleting a record, always write all the records to a temp file
            bool deleted = false;

            try
            {
                // creating a string array of each line 
                string[] lines = System.IO.File.ReadAllLines(@filepath);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');

                    int id = Int32.Parse(fields[0]);
                    int priority = Int32.Parse(fields[2]);

                    if (!(recordMatches(searchTerm, fields, positionofSearchTerm)) || deleted)
                    {
                        addProgram(id, fields[1], priority, fields[3], @tempFile);
                    }
                    else
                    {
                        deleted = true;
                    }
                }

                System.IO.File.Delete(@filepath);
                System.IO.File.Move(tempFile, filepath);
                File.Create(path);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Something went wrong when trying to delete the program: ", ex);
            }
        }
    }
    
}