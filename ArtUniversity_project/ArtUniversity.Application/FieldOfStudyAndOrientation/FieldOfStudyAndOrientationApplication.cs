using _0_Framework.Application;
using ArtUnivercity.Application.Contract.Course;
using ArtUnivercity.Application.Contract.FieldOfStudyAndOrientation;
using ArtUnivercity.Domain.DepartmentDomain;
using ArtUnivercity.Domain.FieldOfStudyAndOrientationDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Application.FieldOfStudyAndOrientation
{
    public class FieldOfStudyAndOrientationApplication : IFieldOfStudyAndOrientationApplication
    {
        private readonly IFieldOfStudyAndOrientationRepository _fieldOfStudyAndOrientationRepository;

        public FieldOfStudyAndOrientationApplication(IFieldOfStudyAndOrientationRepository fieldOfStudyAndOrientationRepository)
        {
            _fieldOfStudyAndOrientationRepository = fieldOfStudyAndOrientationRepository;
        }

        public OperationResult Create(CreateFieldOfStudyAndOrientation command)
        {
            OperationResult operationResult = new OperationResult();
            if (_fieldOfStudyAndOrientationRepository.Exists(x => x.Gerayesh == command.Gerayesh))
            {
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var result = new ArtUnivercity.Domain.FieldOfStudyAndOrientationDomain.FieldOfStudyAndOrientation(command.Name, (ArtUnivercity.Domain.FieldOfStudyAndOrientationDomain.MaghtaeReshtehTahsili)command.MaghtaeReshtehTahsili,command.Gerayesh,command.KeyWord,command.MetaDescription,command.Slug.Slugify());
            _fieldOfStudyAndOrientationRepository.Create(result);
            _fieldOfStudyAndOrientationRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public List<FieldOfStudyAndOrientationViewModel> GetAll()
        {
            return _fieldOfStudyAndOrientationRepository.GetFieldOfStudyAndOrientations();
        }

        public EditFieldOfStudyAndOrientation GetCourse(long id)
        {
            return _fieldOfStudyAndOrientationRepository.GetDetails(id);
        }

        public OperationResult Removed(long id)
        {
            var operationResult = new OperationResult();

            var fieldOfStudyAndOrientation = _fieldOfStudyAndOrientationRepository.Get(id);
            if (fieldOfStudyAndOrientation == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            fieldOfStudyAndOrientation.Remove();

            _fieldOfStudyAndOrientationRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public OperationResult Restored(long id)
        {
            var operationResult = new OperationResult();

            var fieldOfStudyAndOrientation = _fieldOfStudyAndOrientationRepository.Get(id);
            if (fieldOfStudyAndOrientation == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            fieldOfStudyAndOrientation.Restore();

            _fieldOfStudyAndOrientationRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public List<FieldOfStudyAndOrientationViewModel> Search(FieldOfStudyAndOrientationSearchModel searchModel)
        {
            return _fieldOfStudyAndOrientationRepository.Search(searchModel);
        }

        public OperationResult Update(EditFieldOfStudyAndOrientation command)
        {
            var operationResult = new OperationResult();

            var fieldOfStudyAndOrientation = _fieldOfStudyAndOrientationRepository.Get(command.Id);
            if (fieldOfStudyAndOrientation == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_fieldOfStudyAndOrientationRepository.Exists(x=>x.Gerayesh==command.Gerayesh && x.Id!=command.Id))
            {
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            }

            fieldOfStudyAndOrientation.Edit(command.Name, (ArtUnivercity.Domain.FieldOfStudyAndOrientationDomain.MaghtaeReshtehTahsili)command.MaghtaeReshtehTahsili, command.Gerayesh, command.KeyWord, command.MetaDescription, command.Slug.Slugify());
            _fieldOfStudyAndOrientationRepository.SaveChanges();
            return operationResult.Succedded();
        }
    }
}
