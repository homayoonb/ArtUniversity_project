using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.FieldOfStudyAndOrientation
{
    public class FieldOfStudyAndOrientationViewModel
    {
        public long Id { get; set; }
        //نام رشته
        public string? Name { get; set; }
        //مقطع تحصیلی
        public string? MaghtaeReshtehTahsili { get; set; }
        /// <summary>
        /// گرایش
        /// </summary>
        public string? Gerayesh { get; set; }
        /// <summary>
        /// کد دانشکده
        /// </summary>
        public string? DepartmentName { get; set; }
        public string? CreationDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
