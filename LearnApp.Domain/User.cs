namespace LearnApp.Domain;
public abstract class User
{
    public string LastName {get;  init;}
    public DateOnly DoB {get; init;}
    public abstract string Greetings();
}
