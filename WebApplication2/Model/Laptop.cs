﻿using System.Reflection.Metadata.Ecma335;

namespace LaptopStoreRefactorDb.Model
{
  public class Laptop
  {
    public int Id { get; set; }

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

    public int BrandId { get; set; }
    public Brand Brand { get; set; }
  }

  public enum LaptopCondition
  {
    New,
    Refurbished,
    Rental
  }
}
