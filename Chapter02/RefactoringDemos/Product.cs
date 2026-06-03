using System.Xml.Linq;

public class Product : IProduct
{
    private string? description;

    public Product()
    {
    }

    public Product(string? description)
    {
        Description = description;
    }

    public string? Description { get => description; set => description = value; }

    public void Process(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, $"'{nameof(name)}' cannot be null or whitespace.");
    }
}
