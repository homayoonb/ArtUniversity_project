namespace ArtUnivercity.Application.Contract.Student
{
    public class StudentViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string PersenalyCode { get;  set; }
        public string NationalCode { get;  set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Picture { get;  set; }
        public string? CreationDate { get; set; }
        public bool IsStated { get; set; }
    }
}
