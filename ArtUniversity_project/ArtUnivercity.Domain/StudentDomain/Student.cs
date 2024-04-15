using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace ArtUnivercity.Domain.StudentDomain
{
    /// <summary>
    /// جدول دانشجویان
    /// </summary>
    public class Student : EntityBase
    {
        public  string Name { get; private set; }
        public string Family { get; private set; }
        public string FatherName { get; private set; }
        public  string PersenalyCode { get; private set; }
        public  string NationalCode { get; private set; }
        public string MobileNumber { get; private set; }
        public string Address { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public bool IsDeleted { get; private set; }
        ///<summary>
        /// ساختن صفحه
        /// </summary>
        public string KeyWord { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }

        public Student(string name, string family, string fatherName, string persenalyCode, string nationalCode, string mobileNumber, string address, string description, string picture, string pictureAlt, string pictureTitle, string keyWord, string metaDescription, string slug)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Family = family ?? throw new ArgumentNullException(nameof(family));
            FatherName = fatherName ?? throw new ArgumentNullException(nameof(fatherName));
            PersenalyCode = persenalyCode ?? throw new ArgumentNullException(nameof(persenalyCode));
            NationalCode = nationalCode ?? throw new ArgumentNullException(nameof(nationalCode));
            MobileNumber = mobileNumber ?? throw new ArgumentNullException(nameof(mobileNumber));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Picture = picture ?? throw new ArgumentNullException(nameof(picture));
            PictureAlt = pictureAlt ?? throw new ArgumentNullException(nameof(pictureAlt));
            PictureTitle = pictureTitle ?? throw new ArgumentNullException(nameof(pictureTitle));
            KeyWord = keyWord ?? throw new ArgumentNullException(nameof(keyWord));
            MetaDescription = metaDescription ?? throw new ArgumentNullException(nameof(metaDescription));
            Slug = slug ?? throw new ArgumentNullException(nameof(slug));
            IsDeleted = false;
        }

        public void Edit(string name, string family, string fatherName, string persenalyCode, string nationalCode, string mobileNumber, string address, string description, string picture, string pictureAlt, string pictureTitle, string keyWord, string metaDescription, string slug)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Family = family ?? throw new ArgumentNullException(nameof(family));
            FatherName = fatherName ?? throw new ArgumentNullException(nameof(fatherName));
            PersenalyCode = persenalyCode ?? throw new ArgumentNullException(nameof(persenalyCode));
            NationalCode = nationalCode ?? throw new ArgumentNullException(nameof(nationalCode));
            MobileNumber = mobileNumber ?? throw new ArgumentNullException(nameof(mobileNumber));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Picture = picture ?? throw new ArgumentNullException(nameof(picture));
            PictureAlt = pictureAlt ?? throw new ArgumentNullException(nameof(pictureAlt));
            PictureTitle = pictureTitle ?? throw new ArgumentNullException(nameof(pictureTitle));
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
