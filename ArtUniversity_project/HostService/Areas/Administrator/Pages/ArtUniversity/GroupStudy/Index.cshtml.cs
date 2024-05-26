using ArtUnivercity.Application.Contract.Course;
using ArtUnivercity.Application.Contract.GroupStudy;
using ArtUnivercity.Application.Contract.Professor;
using ArtUnivercity.Application.Contract.Student;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HostService.Areas.Administrator.Pages.ArtUniversity.GroupStudy
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public GroupStudySearchModel SearchModel;
        public List<GroupStudyViewModel> GroupStudies;
        public List<ProfessorViewModel> Professors;
        public List<CourseViewModel> Courses;
        public SelectList selectLists;
        private readonly IProfessorApplication _professorApplication;
        private readonly IGroupStudyApplication _groupStudyApplication;
        private readonly ICourseApplication _courseApplication;
        public IndexModel(IGroupStudyApplication groupStudyApplication, IProfessorApplication professorApplication, ICourseApplication courseApplication)
        {
            _groupStudyApplication = groupStudyApplication;
            _professorApplication = professorApplication;
            _courseApplication = courseApplication;
        }

        public void OnGet(GroupStudySearchModel searchModel)
        {

            GroupStudies = _groupStudyApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateGroupStudy();
            command.Professors = _professorApplication.GetAll();
            command.Courses=_courseApplication.GetAll();
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateGroupStudy command)
        {
            var result = _groupStudyApplication.Create(command);
            Message = result.Message;
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var command = _groupStudyApplication.GetGroupStudy(id);
            command.Professors = _professorApplication.GetAll();
            command.Courses = _courseApplication.GetAll();
            return Partial("./Edit", command);
        }

        public JsonResult OnPostEdit(EditGroupStudy command)
        {
            var result = _groupStudyApplication.Update(command);
            Message = result.Message;
            return new JsonResult(result);
        }

        public IActionResult OnGetRemoved(long id)
        {
            var result = _groupStudyApplication.Removed(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnGetRestored(long id)
        {
            var result = _groupStudyApplication.Restored(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}
