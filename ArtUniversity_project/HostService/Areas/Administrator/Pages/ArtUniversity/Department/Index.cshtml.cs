using ArtUnivercity.Application.Contract.Course;
using ArtUnivercity.Application.Contract.Department;
using ArtUnivercity.Application.Contract.FieldOfStudyAndOrientation;
using ArtUnivercity.Application.Contract.GroupStudy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HostService.Areas.Administrator.Pages.ArtUniversity.Department
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public DepartmentSearchModel SearchModel;
        public List<DepartmentViewModel> Departments;


        private readonly IDepartmentApplication _departmentApplication;
        private readonly IGroupStudyApplication _groupStudyApplication;
        private readonly IFieldOfStudyAndOrientationApplication _fieldOfStudyAndOrientationApplication;
        public IndexModel(IDepartmentApplication departmentApplication, IGroupStudyApplication groupStudyApplication, IFieldOfStudyAndOrientationApplication fieldOfStudyAndOrientationApplication)
        {
            _departmentApplication = departmentApplication;
            _groupStudyApplication = groupStudyApplication;
            _fieldOfStudyAndOrientationApplication = fieldOfStudyAndOrientationApplication;
        }

        public void OnGet(DepartmentSearchModel searchModel)
        {
            Departments = _departmentApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateDepartment();
            command.GroupStudy = _groupStudyApplication.GetAll();
            command.FieldOfStudyAndOrientations=_fieldOfStudyAndOrientationApplication.GetAll();
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateDepartment command)
        {
            var result = _departmentApplication.Create(command);
            Message = result.Message;
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var department = _departmentApplication.GetDepartment(id);
            department.FieldOfStudyAndOrientations = _fieldOfStudyAndOrientationApplication.GetAll();
            department.GroupStudy = _groupStudyApplication.GetAll();
            return Partial("./Edit", department);
        }

        public JsonResult OnPostEdit(EditDepartment command)
        {
            var result = _departmentApplication.Update(command);
            Message = result.Message;
            return new JsonResult(result);
        }

        public IActionResult OnGetRemoved(long id)
        {
            var result = _departmentApplication.Removed(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnGetRestored(long id)
        {
            var result = _departmentApplication.Restored(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}
