using ArtUnivercity.Application.Contract.Department;
using ArtUnivercity.Application.Contract.FieldOfStudyAndOrientation;
using ArtUnivercity.Application.Contract.GroupStudy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HostService.Areas.Administrator.Pages.ArtUniversity.FieldOfStudyAndOrientation
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public FieldOfStudyAndOrientationSearchModel SearchModel;
        public List<FieldOfStudyAndOrientationViewModel> FieldOfStudyAndOrientationViewModels;


        private readonly IFieldOfStudyAndOrientationApplication _fieldOfStudyAndOrientationApplication;
        private readonly IDepartmentApplication _departmentApplication;

        public IndexModel(IFieldOfStudyAndOrientationApplication fieldOfStudyAndOrientationApplication, IDepartmentApplication departmentApplication)
        {
            _fieldOfStudyAndOrientationApplication = fieldOfStudyAndOrientationApplication;
            _departmentApplication = departmentApplication;
        }

        public void OnGet(FieldOfStudyAndOrientationSearchModel searchModel)
        {
            FieldOfStudyAndOrientationViewModels = _fieldOfStudyAndOrientationApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateFieldOfStudyAndOrientation();
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateFieldOfStudyAndOrientation command)
        {
            var result = _fieldOfStudyAndOrientationApplication.Create(command);
            Message = result.Message;
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var fieldOfStudyAndOrientation = _fieldOfStudyAndOrientationApplication.GetCourse(id);
            return Partial("./Edit", fieldOfStudyAndOrientation);
        }

        public JsonResult OnPostEdit(EditFieldOfStudyAndOrientation command)
        {
            var result = _fieldOfStudyAndOrientationApplication.Update(command);
            Message = result.Message;
            return new JsonResult(result);
        }

        public IActionResult OnGetRemoved(long id)
        {
            var result = _fieldOfStudyAndOrientationApplication.Removed(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnGetRestored(long id)
        {
            var result = _fieldOfStudyAndOrientationApplication.Restored(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}
