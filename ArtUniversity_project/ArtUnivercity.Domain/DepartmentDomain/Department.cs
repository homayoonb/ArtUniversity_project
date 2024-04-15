using _0_Framework.Domain;
using ArtUnivercity.Domain.FieldOfStudyAndOrientationDomain;
using ArtUnivercity.Domain.GroupStudyDomain;

namespace ArtUnivercity.Domain.DepartmentDomain
{
    /// <summary>
    /// جدول دانشکده
    /// </summary>
    public class Department : EntityBase
    {
        /// <summary>
        /// نام دانشکده
        /// </summary>
        public string DepartMentName { get; private set; }
        ///<summary>
        /// ساختن صفحه
        /// </summary>
        public string KeyWord { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public bool IsDeleted { get; private set; }
        /// <summary>
        /// کد گروه درسی
        /// </summary>
        /// 
        public long GroupStudyId { get; private set; }
        public GroupStudy GroupStudy { get; private set; }
        public ICollection<FieldOfStudyAndOrientation> FieldOfStudyAndOrientations { get; private set; }

        public Department(string departMentName, string keyWord, string metaDescription, string slug, long groupStudyId)
        {
            DepartMentName = departMentName;
            KeyWord = keyWord;
            MetaDescription = metaDescription;
            Slug = slug;
            GroupStudyId = groupStudyId;
            IsDeleted = false;
            FieldOfStudyAndOrientations=new List<FieldOfStudyAndOrientation>();
        }

        public void Edit(string departMentName, string keyWord, string metaDescription, string slug, int groupStudyId)
        {
            DepartMentName = departMentName;
            KeyWord = keyWord;
            MetaDescription = metaDescription;
            Slug = slug;
            GroupStudyId = groupStudyId;
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
