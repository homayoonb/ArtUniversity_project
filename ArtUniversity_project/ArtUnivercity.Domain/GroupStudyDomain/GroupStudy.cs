using _0_Framework.Domain;
using ArtUnivercity.Domain.CourseDomain;
using ArtUnivercity.Domain.DepartmentDomain;
using ArtUnivercity.Domain.ProfessorDomain;

namespace ArtUnivercity.Domain.GroupStudyDomain
{
    /// <summary>
    /// جدول گروه درسی
    /// </summary>
    public class GroupStudy : EntityBase
    {
        /// <summary>
        /// نام گروه
        /// </summary>
        public string GroupName { get; private set; }
        /// <summary>
        /// کد استاد
        /// </summary>
        public long ProfessorId { get; private set; }
        public Professor Professor { get; private set; }
        /// <summary>
        /// کد درس
        /// </summary>
        public long CourseId { get; private set; }
        public Course Course { get; private set; }
        /// <summary>
        /// ترم
        /// </summary>
        public string Term { get; private set; }
        /// <summary>
        /// سال
        /// </summary>
        public string Year { get; private set; }
        ///<summary>
        /// ساختن صفحه
        /// </summary>
        public string KeyWord { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public bool IsDeleted { get; private set; }
        public ICollection<Department> Departments { get; private set; }

        public GroupStudy(string groupName, long professorId, long courseId, string term, string year, string keyWord, string metaDescription, string slug)
        {
            GroupName = groupName;
            ProfessorId = professorId;
            CourseId = courseId;
            Term = term;
            Year = year;
            KeyWord = keyWord;
            MetaDescription = metaDescription;
            Slug = slug;
            IsDeleted = false;
            Departments = new List<Department>();
        }

        public void Edit(string groupName, long professorId, long courseId, string term, string year, string keyWord, string metaDescription, string slug)
        {
            GroupName = groupName;
            ProfessorId = professorId;
            CourseId = courseId;
            Term = term;
            Year = year;
            KeyWord = keyWord;
            MetaDescription = metaDescription;
            Slug = slug;
        }
        public void Remove()
        {
            IsDeleted = true;
        }
        public void Restore()
        {
            IsDeleted = false;
        }
    }
}
