namespace UserManager.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = new Guid().ToString();
            CreatedAt = DateTime.Now;
        }
        public string Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
