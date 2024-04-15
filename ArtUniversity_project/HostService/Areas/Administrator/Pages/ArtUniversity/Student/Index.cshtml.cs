using ArtUnivercity.Application.Contract.Student;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HostService.Areas.Administrator.Pages.ArtUniversity.Student
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public StudentSearchModel SearchModel;
        public List<StudentViewModel> ListStudent;


        private readonly IStudentApplication _studentApplication;

        public IndexModel(IStudentApplication studentApplication)
        {
            _studentApplication = studentApplication;
        }

        public void OnGet(StudentSearchModel searchModel)
        {
            ListStudent = _studentApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateStudent());
        }

        public JsonResult OnPostCreate(CreateStudent command)
        {
            var result = _studentApplication.Create(command);
            Message = result.Message;
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var student = _studentApplication.GetStudents(id);
            return Partial("./Edit", student);
        }

        public JsonResult OnPostEdit(EditStudent command)
        {
            var result = _studentApplication.Update(command);
            Message = result.Message;
            return new JsonResult(result);
        }

        public IActionResult OnGetRemoved(long id)
        {
            var result = _studentApplication.Removed(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message=result.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnGetRestored(long id)
        {
            var result = _studentApplication.Restored(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message=result.Message;
            return RedirectToPage("./Index");

        }
    }
}
