namespace Api.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task SendEmailConfirmationCode(string email, string password, string code);
    Task SendPasswordRecoveryCode(string email, string code);
}