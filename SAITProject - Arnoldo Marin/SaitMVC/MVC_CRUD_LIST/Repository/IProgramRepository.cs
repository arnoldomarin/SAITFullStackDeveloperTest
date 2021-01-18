using MVC_CRUD_LIST.Models;
using System.Collections.Generic;

namespace MVC_CRUD_LIST.Repository
{
    /// <summary>
    /// Constructor for ProgramRepository Class
    /// </summary>
    public interface IProgramRepository
    {
        List<SaitPrograms> SelectAllPrograms();
        SaitPrograms SelectProgramById(int id);
        void InsertProgram(SaitPrograms prog);
        void UpdateProgram(SaitPrograms prog);
        void DeleteProgram(int id);
    }
}