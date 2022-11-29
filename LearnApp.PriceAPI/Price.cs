namespace LearnApp.PriceAPI;

public class Price
{
    public DateTime Date { get; set; }

    public int Amount { get; set; }

    public string Currency { get; set; }

    public string? Summary { get; set; }
}
