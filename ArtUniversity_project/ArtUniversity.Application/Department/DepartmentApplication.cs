using _0_Framework.Application;
using ArtUnivercity.Application.Contract.Department;
using ArtUnivercity.Domain.CourseDomain;
using ArtUnivercity.Domain.DepartmentDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Application.Department
{
    public class DepartmentApplication : IDepartmentApplication
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentApplication(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public OperationResult Create(CreateDepartment command)
        {
            OperationResult operationResult = new OperationResult();
            if (_departmentRepository.Exists(x => x.DepartMentName == command.DepartMentName))
            {
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var result = new ArtUnivercity.Domain.DepartmentDomain.Department(command.DepartMentName,command.KeyWord,command.MetaDescription,command.Slug.Slugify(),command.GroupStudyId,command.FieldOfStudyAndOrientationId);
            _departmentRepository.Create(result);
            _departmentRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public List<DepartmentViewModel> GetAll()
        {
            return _departmentRepository.GetDepartments();
        }

        public EditDepartment GetDepartment(long id)
        {
            return _departmentRepository.GetDetails(id);
        }

        public OperationResult Removed(long id)
        {
            var operationResult = new OperationResult();

            var department = _departmentRepository.Get(id);
            if (department == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            department.Remove();

            _departmentRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public OperationResult Restored(long id)
        {
            var operationResult = new OperationResult();

            var department = _departmentRepository.Get(id);
            if (department == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            department.Restore();

            _departmentRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public List<DepartmentViewModel> Search(DepartmentSearchModel searchModel)
        {
            return _departmentRepository.Search(searchModel);
        }

        public OperationResult Update(EditDepartment command)
        {
            var operationResult = new OperationResult();

            var department = _departmentRepository.Get(command.Id);
            if (department == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_departmentRepository.Exists(x => x.DepartMentName == command.DepartMentName && x.Id != command.Id))
            {
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            department.Edit(command.DepartMentName, command.KeyWord, command.MetaDescription, command.Slug.Slugify(),command.GroupStudyId,command.FieldOfStudyAndOrientationId);

            _departmentRepository.SaveChanges();

            return operationResult.Succedded();
        }
    }
}
