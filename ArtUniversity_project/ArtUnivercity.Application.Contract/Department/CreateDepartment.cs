using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.Department
{
    public class CreateDepartment
    {
        /// <summary>
        /// نام دانشکده
        /// </summary>
        /// 
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string DepartMentName { get;  set; }
        ///<summary>
        /// ساختن صفحه
        /// </summary>
        public string KeyWord { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get;  set; }
        /// <summary>
        /// کد گروه درسی
        /// </summary>
        /// 
        [Range(1,10000,ErrorMessage =ValidationMessages.IsRequired)]
        public long GroupStudyId { get;  set; }
        public ICollection<GroupStudy.GroupStudyViewModel> GroupStudy { get;  set; }
        [Range(1,10000,ErrorMessage =ValidationMessages.IsRequired)]
        public long FieldOfStudyAndOrientationId { get; set; }
        public ICollection<FieldOfStudyAndOrientation.FieldOfStudyAndOrientationViewModel> FieldOfStudyAndOrientations { get; set; }
    }
}
