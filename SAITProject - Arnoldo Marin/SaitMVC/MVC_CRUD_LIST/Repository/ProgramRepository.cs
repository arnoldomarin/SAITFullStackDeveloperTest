using System.Collections.Generic;

namespace MVC_CRUD_LIST.Repository
{
    /// <summary>
    /// Helper Class containing the different helper functions.
    /// </summary>
    public class ProgramRepository : IProgramRepository
    {        
        public List<Models.SaitPrograms> SelectAllPrograms()
        {
            return ProgramList.SelectProgramList();
        }

        public Models.SaitPrograms SelectProgramById(int id)
        {
            return ProgramList.SelectProgramList().Find(x=>x.ProgramID == id);
        }

        public void InsertProgram(Models.SaitPrograms prog)
        {
            ProgramList.InsertProgramList(prog);
        }

        public void UpdateProgram(Models.SaitPrograms prog)
        {
            ProgramList.UpdateProgramList(prog);
        }

        public void DeleteProgram(int id)
        {
            ProgramList.DeleteProgramList(id);
        }
    }
}