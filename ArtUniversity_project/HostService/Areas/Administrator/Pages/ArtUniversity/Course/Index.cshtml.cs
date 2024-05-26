using ArtUnivercity.Application.Contract.Course;
using ArtUnivercity.Application.Contract.FieldOfStudyAndOrientation;
using ArtUnivercity.Application.Contract.Professor;
using ArtUnivercity.Application.Contract.Student;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HostService.Areas.Administrator.Pages.ArtUniversity.Course
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public CourseSearchModel SearchModel;
        public List<CourseViewModel> Courses;


        private readonly ICourseApplication _courseApplication;
        private readonly IFieldOfStudyAndOrientationApplication _fieldOfStudyAndOrientationApplication;

        public IndexModel(ICourseApplication courseApplication, IFieldOfStudyAndOrientationApplication fieldOfStudyAndOrientationApplication)
        {
            _courseApplication = courseApplication;
            _fieldOfStudyAndOrientationApplication = fieldOfStudyAndOrientationApplication;
        }

        public void OnGet(CourseSearchModel searchModel)
        {
            Courses = _courseApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateCourse();
            command.FieldOfStudyAndOrientations = _fieldOfStudyAndOrientationApplication.GetAll();
            return Partial("./Create",command);
        }

        public JsonResult OnPostCreate(CreateCourse command)
        {
            var result = _courseApplication.Create(command);
            Message = result.Message;
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var professor = _courseApplication.GetCourse(id);
            professor.FieldOfStudyAndOrientations= _fieldOfStudyAndOrientationApplication.GetAll();
            return Partial("./Edit", professor);
        }

        public JsonResult OnPostEdit(EditCourse command)
        {
            var result = _courseApplication.Update(command);
            Message = result.Message;
            return new JsonResult(result);
        }

        public IActionResult OnGetRemoved(long id)
        {
            var result = _courseApplication.Removed(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnGetRestored(long id)
        {
            var result = _courseApplication.Restored(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}
