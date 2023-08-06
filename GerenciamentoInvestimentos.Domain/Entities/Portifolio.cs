namespace GerenciamentoInvestimentos.Domain.Entities;

public class Portifolio
{
    public Portifolio(long id,
                      User? user,
                      string ticket,
                      DateTime openingDate,
                      DateTime? closingDate,
                      string custody,
                      string wallet,
                      IEnumerable<Operation> operations)
    {
        Id = id;
        User = user;
        Ticket = ticket;
        OpeningDate = openingDate;
        ClosingDate = closingDate;
        Custody = custody;
        Wallet = wallet;
        Operations = operations;
    }

    public long Id { get; private set; }
    public User? User { get; private set; }
    public string Ticket { get; private set; }
    public DateTime OpeningDate { get; private set; }
    public DateTime? ClosingDate { get; private set; }
    public string Custody { get; private set; }
    public string Wallet { get; private set; }
    public IEnumerable<Operation> Operations { get; private set; }

    public void SetUser(User user) => User = user;
    public void SetOperations(IEnumerable<Operation> operations) => Operations = operations;
}
