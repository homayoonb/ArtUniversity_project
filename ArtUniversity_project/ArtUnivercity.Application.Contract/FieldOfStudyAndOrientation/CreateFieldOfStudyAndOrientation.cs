using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.FieldOfStudyAndOrientation
{
    public class CreateFieldOfStudyAndOrientation
    {
        //نام رشته
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string Name { get;  set; }
        //مقطع تحصیلی
        public MaghtaeReshtehTahsili MaghtaeReshtehTahsili { get;  set; }
        /// <summary>
        /// گرایش
        /// </summary>
        /// 
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string Gerayesh { get; set; }
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
