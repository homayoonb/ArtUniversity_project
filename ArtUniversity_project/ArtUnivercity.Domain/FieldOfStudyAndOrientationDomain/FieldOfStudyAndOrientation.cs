using _0_Framework.Domain;
using ArtUnivercity.Domain.CourseDomain;
using ArtUnivercity.Domain.DepartmentDomain;

namespace ArtUnivercity.Domain.FieldOfStudyAndOrientationDomain
{
    /// <summary>
    /// رشته تحصیلی
    /// </summary>
    public class FieldOfStudyAndOrientation : EntityBase
    {
        //نام رشته
        public string Name { get; private set; }
        //مقطع تحصیلی
        public MaghtaeReshtehTahsili MaghtaeReshtehTahsili { get; private set; }
        /// <summary>
        /// گرایش
        /// </summary>
        public string Gerayesh { get; set; }
        public ICollection<Course>? Courses { get; private set; }
        public ICollection<Department>? Departments { get; set; }
        ///<summary>
        /// ساختن صفحه
        /// </summary>
        public string KeyWord { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public bool IsDeleted { get; private set; }

        public FieldOfStudyAndOrientation(string name, MaghtaeReshtehTahsili maghtaeReshtehTahsili, string gerayesh, string keyWord, string metaDescription, string slug)
        {
            Name = name;
            MaghtaeReshtehTahsili = maghtaeReshtehTahsili;
            Gerayesh = gerayesh;
            KeyWord = keyWord;
            MetaDescription = metaDescription;
            Slug = slug;
            Courses=new List<Course>();
            Departments=new List<Department>();
            IsDeleted = false;
        }

        public void Edit(string name, MaghtaeReshtehTahsili maghtaeReshtehTahsili, string gerayesh, string keyWord, string metaDescription, string slug)
        {
            Name = name;
            MaghtaeReshtehTahsili = maghtaeReshtehTahsili;
            Gerayesh = gerayesh;
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
