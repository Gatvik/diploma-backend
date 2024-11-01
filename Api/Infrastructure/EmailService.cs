using System.Net;
using System.Net.Mail;
using Api.Application.Contracts.Infrastructure;
using Api.Infrastructure.Models;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace Api.Infrastructure;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;
    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
    {
        _logger = logger;
        _emailSettings = emailSettings.Value;
    }
    
    public async Task SendConfirmationCode(string email, string password, string code)
    {
        var client = new MailjetClient(_emailSettings.ApiKey, _emailSettings.ApiSecret);

        var request = new MailjetRequest
            {
                Resource = Send.Resource
            }
            .Property(Send.FromEmail, _emailSettings.FromEmail)
            .Property(Send.FromName, _emailSettings.FromName)
            .Property(Send.Subject, "Your confirmation code")
            .Property(Send.HtmlPart, $"<center><h1>You have been registered on the Hotel Management System service.</h1><h3>Authorize with your credentials on <HERE WILL BE LINK ON WEBSITE> and enter the code<br/>Your login: {email}<br/>Your password: {password}<br/>Your code is: {code}<br/>Don't tell credentials anyone!</h3></center>")
            .Property(Send.Recipients, new JArray {
                new JObject {
                    { "Email", email }
                }
            });

        MailjetResponse response = await client.PostAsync(request);
        
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Email sent to {email} with subject");
        }
        else
        {
            Console.WriteLine($"Failed to send email. Status: {response.StatusCode}, ErrorInfo: {response.GetErrorMessage()}");
            Console.WriteLine($"Response content: {response.Content}");
        }
    }
}