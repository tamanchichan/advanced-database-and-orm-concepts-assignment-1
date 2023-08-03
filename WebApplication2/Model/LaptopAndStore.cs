namespace LaptopStoreRefactorDb.Model
{
  public class LaptopAndStore
  {
    public Guid LaptopId { get; set; }
    public Laptop Laptop { get; set; }

    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    public int Quantity { get; set; }
    //  Quantity may be negative to represent a back-order
  }
}
