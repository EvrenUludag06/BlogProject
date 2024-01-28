namespace Blog.Core.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual string CreatedBy { get; set; } = "Undefined";
        public virtual string? ModifiedBy { get; set; }
        public virtual string? DeletedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
    }
}
