using SQLite;

namespace BikeShopApp.Models;

public class Product
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int BikeCategoryId { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
    public string ImagePath { get; set; } 
}
