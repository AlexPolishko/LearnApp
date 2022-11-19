namespace LearnApp.Domain;
public abstract class User
{
    public string LastName {get;  init;}
    public DateTime DoB {get; init;}
    public abstract string Greetings();
}
