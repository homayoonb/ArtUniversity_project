using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.Course
{
    public class CreateCourse
    {
        //نام درس
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string CourseName { get;  set; }
        //تعداد واحد
        [Range(1,3,ErrorMessage =ValidationMessages.IsRequired)]
        public int Count { get;  set; }
        //کد رشته تحصیلی
        [Range(1, 1000000, ErrorMessage = ValidationMessages.IsRequired)]
        public long FieldOfStudyAndOrientationId { get;  set; }
        public ICollection<FieldOfStudyAndOrientation.FieldOfStudyAndOrientationViewModel> FieldOfStudyAndOrientations { get; set; }
    ///<summary>
    /// ساختن صفحه
    /// </summary>
    /// 
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWord { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get;  set; }
    }
}
