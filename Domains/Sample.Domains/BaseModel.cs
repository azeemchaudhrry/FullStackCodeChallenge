namespace Sample.Domains;

public class BaseModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime? DeletedDate { get; set; }
}
