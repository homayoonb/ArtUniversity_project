using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUnivercity.Application.Contract.Professor
{
    public class ProfessorViewModel
    {
        public long Id { get; set; }
        public string ProfessorName { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string? CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
