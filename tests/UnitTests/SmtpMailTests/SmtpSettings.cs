using Light.SmtpMail;

namespace UnitTests.SmtpMailTests;

public class SmtpSettings : ISmtp, IMailkitSmtp
{
    public string Host { get; set; } = null!;

    public int Port { get; set; }

    public bool UseSsl { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
