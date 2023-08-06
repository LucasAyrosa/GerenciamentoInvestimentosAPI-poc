namespace GerenciamentoInvestimentos.Application.Mappers;

public static class UserMapper
{
    public static Domain.Entities.User ToDomain(this Requests.CreateUserRequest request)
        => new(0, request.Name, request.Email, request.Password);

    public static Responses.CreateUserResponse ToResponse(this Domain.Entities.User user)
        => new()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
}
