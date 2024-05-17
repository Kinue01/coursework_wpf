namespace coursework.EntityFramework.Model;

public partial class GetClient
{
    public int? ClientId { get; set; }

    public string? ClientLastname { get; set; }

    public string? ClientFirstname { get; set; }

    public string? ClientMiddlename { get; set; }

    public string? ClientLogin { get; set; }

    public DateOnly? ClientRegDate { get; set; }

    public DateOnly? ClientBirthday { get; set; }
}
