using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.Department
{
    public class DepartmentViewModel
    {
        public long Id { get; set; }
        /// <summary>
        /// نام دانشکده
        /// </summary>
        public string DepartMentName { get; set; }

        public string GroupStudyName { get; set; }

        public string FieldOfStudyAndOrientationName { get; set; }
        public string Gerayesh { get; set; }
        public string? CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
