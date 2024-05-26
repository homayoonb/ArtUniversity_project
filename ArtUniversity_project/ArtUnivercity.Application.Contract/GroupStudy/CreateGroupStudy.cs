using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.GroupStudy
{
    public class CreateGroupStudy
    {
        /// <summary>
        /// نام گروه
        /// </summary>
        /// 
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string GroupName { get;  set; }
        /// <summary>
        /// کد استاد
        /// </summary>
        /// 
        public long ProfessorId { get;  set; }
        public ICollection<Professor.ProfessorViewModel> Professors { get;  set; }
        /// <summary>
        /// کد درس
        /// </summary>
        public long CourseId { get;  set; }
        public ICollection<Course.CourseViewModel> Courses { get;  set; }
        /// <summary>
        /// ترم
        /// </summary>
        /// 
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Term { get;  set; }
        /// <summary>
        /// سال
        /// </summary>
        /// 
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Year { get;  set; }
        ///<summary>
        /// ساختن صفحه
        /// </summary>
        /// 
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWord { get;  set; }
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string MetaDescription { get;  set; }
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string Slug { get;  set; }
    }
}
