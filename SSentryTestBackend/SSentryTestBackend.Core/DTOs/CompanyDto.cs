namespace SSentryTestBackend.Core.DTOs
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public int IdentificationTypeId { get; set; }
        public string CompanyName { get; set; }
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }
        public bool AllowCellphoneMessages { get; set; }
        public bool AllowEmailMessages { get; set; }
    }
}
