using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.GroupStudy
{
    public class GroupStudyViewModel
    {
        public long Id { get; set; }
        /// <summary>
        /// نام گروه
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// نام استاد
        /// </summary>
        public string ProfessorName { get; set; }
        /// <summary>
        /// نام درس
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// ترم
        /// </summary>
        public string Term { get; set; }
        /// <summary>
        /// سال
        /// </summary>
        public string Year { get; set; }
        public string? CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
