using ArtUnivercity.Application.Contract.Student;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HostService.Areas.Administrator.Pages.ArtUniversity.Student
{
    public class IndexModel : PageModel
    {
        private readonly IStudentApplication _studentApplication;

        public List<StudentViewModel> ListStudent { get; set; }

        public IndexModel(IStudentApplication studentApplication)
        {
            _studentApplication = studentApplication;
        }

        public void OnGet()
        {
            ListStudent=_studentApplication.GetAll();
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateStudent());
        }

        public JsonResult OnPostCreate(CreateStudent command)
        {
            var result = _studentApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var student=_studentApplication.GetStudents(id);
            return Partial("./Edit", student);
        }

        public JsonResult OnPostEdit(EditStudent command)
        {
            var result=_studentApplication.Update(command);
            return new JsonResult(result);
        }
    }
}
