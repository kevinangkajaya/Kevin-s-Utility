namespace webapi;

public class Wealth
{
    public int ID { set; get; }
    public int UserID { set; get; }
    public string Location { set; get; } = "";
    public string Sublocation { set; get; } = "";
    public bool Active { set; get; }
    public double? Value { set; get; }
    public double ValueInRupiah { set; get; }
    public DateTime CreatedAt { set; get; }
    public DateTime? UpdatedAt { set; get; }
    public DateTime? DeletedAt { set; get; }
}