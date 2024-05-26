using _0_Framework.Application;
using ArtUnivercity.Application.Contract.Course;
using ArtUnivercity.Application.Contract.GroupStudy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.Professor
{
    public interface IProfessorApplication
    {
        OperationResult Create(CreateProfessor command);
        OperationResult Update(EditProfessor command);
        EditProfessor GetProfessor(long id);
        List<ProfessorViewModel> GetAll();
        List<ProfessorViewModel> Search(ProfessorSearchModel searchModel);
        OperationResult Removed(long id);
        OperationResult Restored(long id);
    }
}
