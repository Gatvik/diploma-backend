﻿namespace Api.Infrastructure.Models;

public class EmailSettings
{
    public string ApiKey { get; set; }
    public string ApiSecret { get; set; }
    // public string SmtpServer { get; set; }
    // public int Port { get; set; }
    // public string Username { get; set; }
    // public string Password { get; set; }
    public string FromEmail { get; set; }
    public string FromName { get; set; }
}