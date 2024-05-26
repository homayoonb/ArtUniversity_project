using _0_Framework.Application;
using ArtUnivercity.Application.Contract.Student;
using ArtUnivercity.Domain.StudentDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ArtUniversity.Application.Student
{
    public class StudentApplication : IStudentApplication
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IFileUploader _fileUploader;
        public StudentApplication(IStudentRepository studentRepository, IFileUploader fileUploader)
        {
            _studentRepository = studentRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateStudent command)
        {
            OperationResult result = new OperationResult();
            if (_studentRepository.Exists(x=>x.Name == command.Name && x.Family==command.Family))
            {
                return result.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            var picturePath = $"{command.Slug}";
            var pictureName = _fileUploader.Upload(command.Picture, picturePath);
            var student = new ArtUnivercity.Domain.StudentDomain.Student(command.Name.Trim(), command.Family.Trim(), command.FatherName.Trim(), command.PersenalyCode.Trim(), command.NationalCode.Trim(), command.MobileNumber.Trim(), command.Address.Trim(), command.Description.Trim(), pictureName, command.PictureAlt.Trim(), command.PictureTitle.Trim(), command.KeyWord.Trim(), command.MetaDescription.Trim(), slug.Trim());

            _studentRepository.Create(student);

            _studentRepository.SaveChanges();

            return result.Succedded();
        }

        public List<StudentViewModel> GetAll()
        {
            return _studentRepository.GetStudents();
        }

        public EditStudent GetStudents(long id)
        {
            EditStudent editStudent = _studentRepository.GetDetails(id);
            return editStudent;
        }

        public OperationResult Removed(long id)
        {
            var operationResult = new OperationResult();

            var student = _studentRepository.Get(id);
            if (student == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            student.Remove();

            _studentRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public OperationResult Restored(long id)
        {
            var operationResult = new OperationResult();

            var student = _studentRepository.Get(id);
            if (student == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            student.Restore();

            _studentRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public List<StudentViewModel> Search(StudentSearchModel searchModel)
        {
            var result = _studentRepository.Search(searchModel);
            return result;
        }

        public OperationResult Update(EditStudent command)
        {
            var operationResult = new OperationResult();

            var student = _studentRepository.Get(command.Id);
            if (student == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_studentRepository.Exists(x => x.Name == command.Name && x.Id!=command.Id))
            {
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            var picturePath = $"{command.Slug}";
            var pictureName=_fileUploader.Upload(command.Picture,picturePath);
            student.Edit(command.Name.Trim(), command.Family.Trim(), command.FatherName.Trim(), command.PersenalyCode.Trim(), command.NationalCode.Trim(), command.MobileNumber.Trim(), command.Address.Trim(), command.Description.Trim(), pictureName, command.PictureAlt.Trim(), command.PictureTitle.Trim(), command.KeyWord.Trim(), command.MetaDescription.Trim(), slug.Trim());

            _studentRepository.SaveChanges();

            return operationResult.Succedded();
        }
    }
}
