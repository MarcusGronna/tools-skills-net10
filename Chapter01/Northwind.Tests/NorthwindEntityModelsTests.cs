using Microsoft.EntityFrameworkCore;
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

    // Category tests

    [Fact]
    public void CategoryCountTest()
    {
        using NorthwindContext db = new();
        int expected = 8;
        int actual = db.Categories.Count();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CategoryId1IsBeveragesTest()
    {
        using NorthwindContext db = new();
        Category? category = db.Categories.Single(c => c.CategoryId == 1);
        Assert.Equal("Beverages", category.CategoryName);
    }

    // Product tests

    [Fact]
    public void ProductCountTest()
    {
        using NorthwindContext db = new();
        int expected = 77;
        int actual = db.Products.Count();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ProductId1IsChaiTest()
    {
        using NorthwindContext db = new();
        string expected = "Chai";
        Product? product = db?.Products?.Single(p => p.ProductId == 1);
        string actual = product?.ProductName ?? string.Empty;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DiscontinuedProductCountTest()
    {
        using NorthwindContext db = new();
        int expected = 8;
        int actual = db.Products.Count(p => p.Discontinued);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ProductId1HasCategoryBeveragesTest()
    {
        using NorthwindContext db = new();
        Product? product = db.Products
            .Include(p => p.Category)
            .Single(p => p.ProductId == 1);
        Assert.NotNull(product.Category);
        Assert.Equal("Beverages", product.Category.CategoryName);
    }

    // Customer tests

    [Fact]
    public void CustomerCountTest()
    {
        using NorthwindContext db = new();
        int expected = 91;
        int actual = db.Customers.Count();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CustomerALFKIIsAlfredsFutterkisteTest()
    {
        using NorthwindContext db = new();
        Customer? customer = db.Customers.Find("ALFKI");
        Assert.NotNull(customer);
        Assert.Equal("Alfreds Futterkiste", customer.CompanyName);
    }

    [Fact]
    public void CustomerALFKIHasOrdersTest()
    {
        using NorthwindContext db = new();
        Customer? customer = db.Customers
            .Include(c => c.Orders)
            .Single(c => c.CustomerId == "ALFKI");
        Assert.NotNull(customer.Orders);
        Assert.True(customer.Orders.Count > 0);
    }

    // Employee tests

    [Fact]
    public void EmployeeCountTest()
    {
        using NorthwindContext db = new();
        int expected = 9;
        int actual = db.Employees.Count();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Employee1IsNancyDavolioTest()
    {
        using NorthwindContext db = new();
        Employee? employee = db.Employees.Find(1);
        Assert.NotNull(employee);
        Assert.Equal("Davolio", employee.LastName);
        Assert.Equal("Nancy", employee.FirstName);
    }

    // Order tests

    [Fact]
    public void OrderCountTest()
    {
        using NorthwindContext db = new();
        int expected = 830;
        int actual = db.Orders.Count();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OrderId10248HasOrderDetailsTest()
    {
        using NorthwindContext db = new();
        Order? order = db.Orders
            .Include(o => o.OrderDetails)
            .Single(o => o.OrderId == 10248);
        Assert.NotNull(order.OrderDetails);
        Assert.True(order.OrderDetails.Count > 0);
    }

    // Supplier tests

    [Fact]
    public void SupplierCountTest()
    {
        using NorthwindContext db = new();
        int expected = 29;
        int actual = db.Suppliers.Count();
        Assert.Equal(expected, actual);
    }

    // Shipper tests

    [Fact]
    public void ShipperCountTest()
    {
        using NorthwindContext db = new();
        int expected = 3;
        int actual = db.Shippers.Count();
        Assert.Equal(expected, actual);
    }
}
