using GerenciamentoInvestimentos.Domain.Enums;
using GerenciamentoInvestimentos.Infrastructure.DataModel;

namespace GerenciamentoInvestimentos.Infrastructure.Mappers;

public static class OperationMapper
{
    public static Operation ToDataModel(this Domain.Entities.Operation entity)
        => new()
        {
            id = entity.Id,
            portifolio_id = entity.PortifolioId,
            type = (int)entity.Type,
            quantity = entity.Quantity,
            unit_value = entity.UnitValue,
            date = entity.Date
        };

    public static Domain.Entities.Operation ToDomain(this Operation dataModel)
        => new(dataModel.id,
               dataModel.portifolio_id,
               (EOperationType)dataModel.type,
               dataModel.quantity,
               dataModel.unit_value,
               dataModel.date);
}
