using _0_Framework.Application;
using ArtUnivercity.Application.Contract.Course;
using ArtUnivercity.Application.Contract.GroupStudy;
using ArtUnivercity.Domain.CourseDomain;
using ArtUnivercity.Domain.GroupStudyDomain;
using ArtUnivercity.Domain.StudentDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUniversity.Application.GroupStudy
{
    public class GroupStudyApplication : IGroupStudyApplication
    {
        private readonly IGroupStudyRepository _groupStudyRepository;

        public GroupStudyApplication(IGroupStudyRepository groupStudyRepository)
        {
            _groupStudyRepository = groupStudyRepository;
        }

        public OperationResult Create(CreateGroupStudy command)
        {
            OperationResult result = new OperationResult();
            if (_groupStudyRepository.Exists(x => x.GroupName == command.GroupName))
            {
                return result.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            var groupStudy = new ArtUnivercity.Domain.GroupStudyDomain.GroupStudy(command.GroupName.Trim(), command.ProfessorId, command.CourseId, command.Term.Trim(), command.Year.Trim(), command.KeyWord.Trim(), command.MetaDescription.Trim(), command.Slug.Slugify().Trim());
            _groupStudyRepository.Create(groupStudy);

            _groupStudyRepository.SaveChanges();

            return result.Succedded();
        }

        public List<GroupStudyViewModel> GetAll()
        {
            return _groupStudyRepository.GetGroupStudies();
        }

        public EditGroupStudy GetGroupStudy(long id)
        {
            return _groupStudyRepository.GetDetails(id);
        }

        public OperationResult Removed(long id)
        {
            var operationResult = new OperationResult();

            var groupStudy = _groupStudyRepository.Get(id);
            if (groupStudy == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }
            groupStudy.Remove();

            _groupStudyRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public OperationResult Restored(long id)
        {
            var operationResult = new OperationResult();

            var groupStudy = _groupStudyRepository.Get(id);
            if (groupStudy == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            groupStudy.Restore();

            _groupStudyRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public List<GroupStudyViewModel> Search(GroupStudySearchModel searchModel)
        {
            return _groupStudyRepository.Search(searchModel);
        }

        public OperationResult Update(EditGroupStudy command)
        {
            var operationResult = new OperationResult();

            var groupStudy = _groupStudyRepository.Get(command.Id);
            if (groupStudy == null)
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_groupStudyRepository.Exists(x => x.GroupName == command.GroupName && x.Id != command.Id))
            {
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            groupStudy.Edit(command.GroupName,command.ProfessorId,command.CourseId,command.Term,command.Year,command.KeyWord,command.MetaDescription,slug);

            _groupStudyRepository.SaveChanges();

            return operationResult.Succedded();
        }
    }
}
