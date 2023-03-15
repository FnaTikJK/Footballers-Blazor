namespace FootBallers.Models
{
    public class FootballerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public DateOnly Birthday { get; set; }
        public string Team { get; set; }
        public string Country { get; set; }
    }
}
