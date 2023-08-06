using GerenciamentoInvestimentos.Infrastructure.DataModel;

namespace GerenciamentoInvestimentos.Infrastructure.Mappers;

public static class PortifolioMapper
{
    public static Portifolio ToDataModel(this Domain.Entities.Portifolio entity)
        => new()
        {
            user_id = entity.User!.Id,
            ticket = entity.Ticket,
            opening_date = entity.OpeningDate,
            closing_date = entity.ClosingDate,
            custody = entity.Custody,
            wallet = entity.Wallet,
        };

    public static Domain.Entities.Portifolio ToDomain(this Portifolio dataModel)
        => new(dataModel.id,
               null,
               dataModel.ticket,
               dataModel.opening_date,
               dataModel.closing_date,
               dataModel.custody,
               dataModel.wallet,
               new List<Domain.Entities.Operation>());

}
