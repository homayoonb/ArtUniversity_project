using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.Professor
{
    public class CreateProfessor
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ProfessorName { get;  set; }
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string Telephone { get;  set; }
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string Address { get;  set; }
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        [EmailAddress(ErrorMessage = ValidationMessages.EmailValidation)]
        public string EmailAddress { get;  set; }
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string KeyWord { get;  set; }
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string MetaDescription { get;  set; }
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string Slug { get;  set; }
    }
}
