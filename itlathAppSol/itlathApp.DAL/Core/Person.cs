namespace itlathApp.DAL.Core
{
    public abstract class  Person : AuditEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
