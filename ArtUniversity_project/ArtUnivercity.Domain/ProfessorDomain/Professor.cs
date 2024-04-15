using _0_Framework.Domain;
using ArtUnivercity.Domain.GroupStudyDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Domain.ProfessorDomain
{
    public class Professor : EntityBase
    {
        public string ProfessorName { get; private set; }
        public string Telephone { get; private set; }
        public string Address { get; private set; }
        public string EmailAddress { get; private set; }
        public string KeyWord { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public bool IsDeleted { get; private set; }
        public ICollection<GroupStudy> GroupStudies { get; private set; }

        public Professor(string professorName, string telephone, string address, string emailAddress, string keyWord, string metaDescription, string slug)
        {
            ProfessorName = professorName;
            Telephone = telephone;
            Address = address;
            EmailAddress = emailAddress;
            KeyWord = keyWord;
            MetaDescription = metaDescription;
            Slug = slug;
            IsDeleted = false;
            GroupStudies = new List<GroupStudy>();
        }

        public void Edit(string professorName, string telephone, string address, string emailAddress, string keyWord, string metaDescription, string slug)
        {
            ProfessorName = professorName;
            Telephone = telephone;
            Address = address;
            EmailAddress = emailAddress;
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
