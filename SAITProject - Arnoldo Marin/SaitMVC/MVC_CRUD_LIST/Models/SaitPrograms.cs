using System.ComponentModel.DataAnnotations;
using System;

namespace MVC_CRUD_LIST.Models
{
    /// <summary>
    /// Program Model that contains all the data related logic.
    /// </summary>
    public class SaitPrograms
    {
        // Program attributes 
        [Display(Name="Program ID")]
        public int ProgramID { get; set; }
        [Required(ErrorMessage="ID is mandatory")]
        public string ProgramName { get; set; }
        public Nullable<int> ProgramPriority { get; set; }
        public string ProgramStatus { get; set; }

        public SaitPrograms()
        {
            ProgramID = -1;
            ProgramName = "noname";
            ProgramPriority = -1;

        }

        /// <summary>
        /// Constructor for the SaitProgram Model
        /// </summary>
        /// <param name="id"> Program ID</param>
        /// <param name="name"> Program Name</param>
        /// <param name="priorityNum"> Program Priorityr</param>
        /// <param name="statusString"> Status of the program</param>
        public SaitPrograms(int id, string name, int priorityNum, string statusString)
        {
            this.ProgramID = id;
            this.ProgramName = name;
            this.ProgramPriority = priorityNum;
            this.ProgramStatus = statusString;
        }

        /// <summary>
        /// Contains Get and Set Methods for the Model
        /// </summary>
        public class ProgramSearchModel
        {
            public int? Id { get; set; }
            public int? Priority { get; set; }
            public string Status { get; set; }
        }

        /// <summary>
        /// Splits csvline by commas and sets each program attribute to the corresponding value from the CSV file.
        /// </summary>
        /// <param name="csvLine">Line from the CSV file containing a SAIT program's attributes</param>
        /// <returns></returns>
        public static SaitPrograms FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            
            SaitPrograms allPrograms = new SaitPrograms();

            allPrograms.ProgramID = Convert.ToInt32(values[0]);
            allPrograms.ProgramName = Convert.ToString(values[1]);
            allPrograms.ProgramPriority = Convert.ToInt32(values[2]);
            allPrograms.ProgramStatus = Convert.ToString(values[3]);

            return allPrograms;
        }
    }

}