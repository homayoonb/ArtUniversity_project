using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ArtUnivercity.Application.Contract.Student
{
    public class CreateStudent
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Family { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FatherName { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PersenalyCode { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string NationalCode { get;  set; }
        public string Description { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MobileNumber { get;  set; }
        public string Address { get;  set; }
        public IFormFile Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        /// ساختن صفحه
        /// </summary>
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWord { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get;  set; }
    }
}
