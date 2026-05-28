using Northwind.EntityModels; // To use NorthwindContext and Product.

namespace Northwind.Tests;


public class NorthwindEntityModelsTests
{
    [Fact]
    public void DatabaseContextTest()
    {
        using NorthwindContext db = new();
        Assert.True(db.Database.CanConnect());
    }

    [Fact]
    public void CategoryCountTest()
    {
        using NorthwindContext db = new();
        int expected = 8;
        int actual = db.Categories.Count();
        Assert.Equal(expected, actual);
    }
}
