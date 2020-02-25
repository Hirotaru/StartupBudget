namespace StartupBudget.Domain.Entities
{
    public class Developer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal WeekRate { get; set; }
        public DeveloperQualification Qualification { get; set; }
    }

    public enum DeveloperQualification
    {
        Junior,
        Middle,
        Senior
    }
}
