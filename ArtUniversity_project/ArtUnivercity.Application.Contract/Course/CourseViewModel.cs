using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.Course
{
    public class CourseViewModel
    {
        public long Id { get; set; }
        //نام درس
        public string CourseName { get; set; }
        //تعداد واحد
        public int Count { get; set; }
        public string FieldOfStudyAndOrientationName { get; set; }
        public string MaghtaeReshtehTahsili { get; set; }
        public string Gerayesh { get; set; }
        public string? CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
