using _0_Framework.Domain;
using ArtUnivercity.Domain.FieldOfStudyAndOrientationDomain;
using ArtUnivercity.Domain.GroupStudyDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Domain.CourseDomain
{
    /// <summary>
    /// جدول دروس
    /// </summary>
    public class Course : EntityBase
    {
        //نام درس
        public  string CourseName { get;private set; }
        //تعداد واحد
        public int Count { get; private set; }
        //کد رشته تحصیلی
        public long FieldOfStudyAndOrientationId { get; private set; }
        public FieldOfStudyAndOrientation FieldOfStudyAndOrientation { get; private set; }
        public ICollection<GroupStudy> GroupStudies { get; private set; }
        ///<summary>
        /// ساختن صفحه
        /// </summary>
        public string KeyWord { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public bool IsDeleted { get; private set; }
        public Course(string courseName, int count, long fieldOfStudyAndOrientationId, string keyWord, string metaDescription, string slug)
        {
            CourseName = courseName ?? throw new ArgumentNullException(nameof(courseName));
            Count = count;
            FieldOfStudyAndOrientationId = fieldOfStudyAndOrientationId;
            KeyWord = keyWord ?? throw new ArgumentNullException(nameof(keyWord));
            MetaDescription = metaDescription ?? throw new ArgumentNullException(nameof(metaDescription));
            Slug = slug ?? throw new ArgumentNullException(nameof(slug));
            IsDeleted = false;
            GroupStudies = new List<GroupStudy>();
        }
        public void Edit(string courseName, int count, long fieldOfStudyAndOrientationId, string keyWord, string metaDescription, string slug)
        {
            CourseName = courseName ?? throw new ArgumentNullException(nameof(courseName));
            Count = count;
            FieldOfStudyAndOrientationId = fieldOfStudyAndOrientationId;
            KeyWord = keyWord ?? throw new ArgumentNullException(nameof(keyWord));
            MetaDescription = metaDescription ?? throw new ArgumentNullException(nameof(metaDescription));
            Slug = slug ?? throw new ArgumentNullException(nameof(slug));
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
