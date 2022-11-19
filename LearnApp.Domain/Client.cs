namespace LearnApp.Domain;
public class Client : User
{
        public override string Greetings() => $"Hello, {LastName}";
}
