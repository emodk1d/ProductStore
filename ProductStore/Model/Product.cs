using System.ComponentModel.DataAnnotations.Schema;

namespace ProductStore.Model;

[Table("table_product")]
public class Product
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public required string Name { get; set; }
    [Column("price")]
    public required decimal Price { get; set; }
    [Column("manufacturer")]
    public required string Manufacturer { get; set; }
    [Column("quantity")]
    public required int Quantity { get; set; }
    [Column("article")]
    public required string Article { get; set; }
}