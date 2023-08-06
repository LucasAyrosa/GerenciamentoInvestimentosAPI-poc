namespace GerenciamentoInvestimentos.Domain.Entities;

public class User
{
    public User(long id, string name, string email, string password)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
    }

    public long Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
}
