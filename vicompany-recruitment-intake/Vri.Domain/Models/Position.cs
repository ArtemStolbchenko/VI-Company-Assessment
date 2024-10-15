namespace Vri.Domain.Models;

public class Position
{
    public string Isin { get; set; }

    public decimal Price { get; set; }
         
    public int Quantity { get; set; }
}