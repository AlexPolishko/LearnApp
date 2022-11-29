namespace LearnApp.Domain;

public class Price
{
    public DateTime Date { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; }

    public string? Summary { get; set; }
}
