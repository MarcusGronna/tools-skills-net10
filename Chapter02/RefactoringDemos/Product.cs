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
}
