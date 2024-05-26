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
        public long FieldOfStudyAndOrientationId { get; private set; }
        public FieldOfStudyAndOrientation FieldOfStudyAndOrientation { get; private set; }

        public Department(string departMentName, string keyWord, string metaDescription, string slug, long groupStudyId, long fieldOfStudyAndOrientationId)
        {
            DepartMentName = departMentName;
            KeyWord = keyWord;
            MetaDescription = metaDescription;
            Slug = slug;
            GroupStudyId = groupStudyId;
            FieldOfStudyAndOrientationId = fieldOfStudyAndOrientationId;
            IsDeleted = false;
        }

        public void Edit(string departMentName, string keyWord, string metaDescription, string slug, long groupStudyId, long fieldOfStudyAndOrientationId)
        {
            DepartMentName = departMentName;
            KeyWord = keyWord;
            MetaDescription = metaDescription;
            Slug = slug;
            GroupStudyId = groupStudyId;
            FieldOfStudyAndOrientationId = fieldOfStudyAndOrientationId;
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
