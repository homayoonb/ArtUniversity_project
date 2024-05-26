using _0_Framework.Application;
using ArtUnivercity.Application.Contract.Course;
using ArtUnivercity.Application.Contract.Professor;
using ArtUnivercity.Domain.ProfessorDomain;
using ArtUnivercity.Domain.StudentDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Application.Professor
{
    public class ProfessorApplication : IProfessorApplication
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorApplication(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public OperationResult Create(CreateProfessor command)
        {
            OperationResult result = new OperationResult();
            if (_professorRepository.Exists(x => x.ProfessorName == command.ProfessorName))
            {
                return result.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            var professor = new ArtUnivercity.Domain.ProfessorDomain.Professor(command.ProfessorName.Trim(), command.Telephone.Trim(), command.Address.Trim(), command.EmailAddress.Trim(), command.KeyWord.Trim(), command.MetaDescription.Trim(), command.Slug.Slugify().Trim());
            _professorRepository.Create(professor);

            _professorRepository.SaveChanges();

            return result.Succedded();
        }

        public List<ProfessorViewModel> GetAll()
        {
            return _professorRepository.GetProfessors();
        }

        public EditProfessor GetProfessor(long id)
        {
            return _professorRepository.GetDetails(id);
        }

        public OperationResult Removed(long id)
        {
            var operationResult = new OperationResult();

            var professor = _professorRepository.Get(id);
            if (professor == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            professor.Remove();

            _professorRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public OperationResult Restored(long id)
        {
            var operationResult = new OperationResult();

            var professor = _professorRepository.Get(id);
            if (professor == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            professor.Restore();

            _professorRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public List<ProfessorViewModel> Search(ProfessorSearchModel searchModel)
        {
            return _professorRepository.Search(searchModel);
        }

        public OperationResult Update(EditProfessor command)
        {
            var operationResult = new OperationResult();

            var professor = _professorRepository.Get(command.Id);
            if (professor == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_professorRepository.Exists(x => x.ProfessorName == command.ProfessorName && x.Id != command.Id))
            {
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            professor.Edit(command.ProfessorName.Trim(), command.Telephone.Trim(), command.Address.Trim(), command.EmailAddress.Trim(), command.KeyWord.Trim(), command.MetaDescription.Trim(), slug.Trim());

            _professorRepository.SaveChanges();

            return operationResult.Succedded();
        }
    }
}
