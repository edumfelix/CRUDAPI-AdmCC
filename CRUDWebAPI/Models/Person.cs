namespace CRUDWebAPI.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Birthday { get; set; }
        public string? EmailAdress { get; set; }
        public string? Password { get; set; }
    }
}
