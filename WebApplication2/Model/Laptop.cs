using System.Reflection.Metadata.Ecma335;

namespace LaptopStoreRefactorDb.Model
{
  public class Laptop
  {
    public Guid Id { get; set; }

    public Guid BrandId { get; set; }
    public Brand Brand { get; set; }

    private string _model;
    public string Model
    {
      get
      {
        return _model;
      }
      set
      {
        if (string.IsNullOrEmpty(value) || value.Length < 3)
        {
          throw new ArgumentOutOfRangeException(
            nameof(value),
            "Laptop model name must be at least three characters in length."
            );
        }

        _model = value;
      }
    }

    private decimal _price;
    public decimal Price
    {
      get
      {
        return _price;
      }
      set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException("Price cannot be less than zero.");
        }

        _price = value;
      }
    }

    public LaptopCondition Condition { get; set; }

    public HashSet<LaptopAndStore> LaptopsAndStores { get; set; } = 
      new HashSet<LaptopAndStore>();
  }

  public enum LaptopCondition
  {
    New,
    Refurbished,
    Rental
  }
}
