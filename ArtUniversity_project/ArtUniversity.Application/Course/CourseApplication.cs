using _0_Framework.Application;
using ArtUnivercity.Application.Contract.Course;
using ArtUnivercity.Domain.CourseDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Application.Course
{
    public class CourseApplication : ICourseApplication
    {
        private readonly ICourseRepository _courseRepository;

        public CourseApplication(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public OperationResult Create(CreateCourse command)
        {
            OperationResult operationResult = new OperationResult();
            if (_courseRepository.Exists(x=>x.CourseName==command.CourseName))
            {
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var result = new ArtUnivercity.Domain.CourseDomain.Course(command.CourseName, command.Count, command.FieldOfStudyAndOrientationId, command.KeyWord, command.MetaDescription, command.Slug.Slugify());
            _courseRepository.Create(result);
            _courseRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public List<CourseViewModel> GetAll()
        {
            return _courseRepository.GetStudents();
        }

        public EditCourse GetCourse(long id)
        {
            return _courseRepository.GetDetails(id);
        }

        public OperationResult Removed(long id)
        {
            var operationResult = new OperationResult();

            var course = _courseRepository.Get(id);
            if (course == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            course.Remove();

            _courseRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public OperationResult Restored(long id)
        {
            var operationResult = new OperationResult();

            var course = _courseRepository.Get(id);
            if (course == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            course.Restore();

            _courseRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public List<CourseViewModel> Search(CourseSearchModel searchModel)
        {
            return _courseRepository.Search(searchModel);
        }

        public OperationResult Update(EditCourse command)
        {
            var operationResult = new OperationResult();

            var course = _courseRepository.Get(command.Id);
            if (course == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_courseRepository.Exists(x => x.CourseName == command.CourseName && x.Id != command.Id))
            {
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            course.Edit(command.CourseName,command.Count,command.FieldOfStudyAndOrientationId,command.KeyWord,command.MetaDescription,command.Slug.Slugify());

            _courseRepository.SaveChanges();

            return operationResult.Succedded();
        }
    }
}
