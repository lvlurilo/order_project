namespace OrderApi.src.Domain.Entities.Base;

public class EntityBase
{
    public long Id { get; set; }

    public Guid PublicId { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public EntityBase()
    {
        PublicId = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }

    public void SetUpdatedAt()
    {
        UpdatedAt = DateTime.Now;
    }
}