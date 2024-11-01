namespace Api.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task SendConfirmationCode(string email, string password, string code);
}