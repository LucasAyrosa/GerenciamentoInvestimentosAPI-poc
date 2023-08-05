using GerenciamentoInvestimentos.Infrastructure.Utils;

namespace GerenciamentoInvestimentos.Infrastructure.Mappers;

public static class UserMapper
{
    public static Domain.Entities.User ToDomain(this DataModel.User dataModel)
        => new(dataModel.id, dataModel.name, dataModel.email, dataModel.password);

    public static IEnumerable<Domain.Entities.User> ToDomain(this IEnumerable<DataModel.User> dataModels)
        => dataModels.Select(dm => dm.ToDomain());

    public static DataModel.User ToDataModel(this Domain.Entities.User Entity)
        => new()
        {
            id = Entity.Id,
            name = Entity.Name,
            email = Entity.Email,
            password = Entity.Password.CryptographyPassword()
        };

    public static IEnumerable<DataModel.User> ToDataModel(this IEnumerable<Domain.Entities.User> entities)
        => entities.Select(e => e.ToDataModel());
}