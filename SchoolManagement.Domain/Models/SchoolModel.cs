namespace SchoolManagement.Domain.Models
{
    public class SchoolModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
    }

    public class CreateSchoolModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoBase64 { get; set; }
    }
}
