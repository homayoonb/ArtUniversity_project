using ArtUnivercity.Application.Contract.Professor;
using ArtUnivercity.Application.Contract.Student;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HostService.Areas.Administrator.Pages.ArtUniversity.Professor
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public ProfessorSearchModel SearchModel;
        public List<ProfessorViewModel> Professors;


        private readonly IProfessorApplication _professorApplication;

        public IndexModel(IProfessorApplication professorApplication)
        {
            _professorApplication = professorApplication;
        }

        public void OnGet(ProfessorSearchModel searchModel)
        {
            Professors = _professorApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProfessor());
        }

        public JsonResult OnPostCreate(CreateProfessor command)
        {
            var result = _professorApplication.Create(command);
            Message = result.Message;
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var professor = _professorApplication.GetProfessor(id);
            return Partial("./Edit", professor);
        }

        public JsonResult OnPostEdit(EditProfessor command)
        {
            var result = _professorApplication.Update(command);
            Message = result.Message;
            return new JsonResult(result);
        }

        public IActionResult OnGetRemoved(long id)
        {
            var result = _professorApplication.Removed(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnGetRestored(long id)
        {
            var result = _professorApplication.Restored(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}
