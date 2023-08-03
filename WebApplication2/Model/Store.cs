namespace LaptopStoreRefactorDb.Model
{
  public class Store
  {
    public Guid Id { get; set; }

    private string _streetName;
    public string StreetName
    {
      get
      {
        return _streetName;
      }
      set
      {
        if (String.IsNullOrEmpty(value) || value.Length < 3)
        {
          throw new ArgumentOutOfRangeException(
            nameof(value),
            "Store street name must be at least three characters in length."
            );
        }

        _streetName = value;
      }
    }

    private int _streetNumber;
    public int StreetNumber
    {
      get
      {
        return _streetNumber;
      }
      set
      {
        if (value < 0 || String.IsNullOrEmpty(value.ToString()))
        {
          throw new ArgumentOutOfRangeException(
            nameof(value),
            "Store street number must be greater than zero and " +
            "cannot be empty."
            );
        }
      }
    }

    private static readonly List<string> CanadianProvinces = new List<string>
    {
      "Alberta", "British Columbia", "Manitoba", "New Brunswick",
      "Newfoundland and Labrador", "Nova Scotia", "Ontario",
      "Prince Edward Island", "Quebec", "Saskatchewan",
      "Northwest Territories", "Nunavut", "Yukon"
    };

    private string _province;
    public string Province
    {
      get
      {
        return _province;
      }
      set
      {
        if (!CanadianProvinces.Contains(value))
        {
          throw new ArgumentException(
            $"Invalid province. Province must be one of the following: " +
            $"{string.Join(", ", CanadianProvinces)}"
            );
        }

        _province = value;
      }
    }

    public HashSet<LaptopAndStore> LaptopsAndStores { get; set; } =
      new HashSet<LaptopAndStore>();
  }
}
