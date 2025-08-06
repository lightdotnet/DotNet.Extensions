using Light.Mail;
using Light.SmtpMail;

namespace UnitTests.SmtpMailTests;

public class SmtpMailKitTests
{
    private readonly SmtpMailKit _smtpMailKit;
    private readonly string _fromMail;

    public SmtpMailKitTests()
    {
        _fromMail = "jermain.torphy@ethereal.email";

        var smtpSettings = new SmtpSettings
        {
            Host = "smtp.ethereal.email",
            Port = 587,
            UseSsl = false,
            UserName = _fromMail,
            Password = "GHMdV12nF7zfFhqG7Z"
        };

        _smtpMailKit = new SmtpMailKit(smtpSettings);
    }

    [Fact]
    public async Task Must_Send_Email_Successfully()
    {
        var recipients = new List<string>
        {
            "user@domain.local"
        };

        var mail = new MailMessage
        {
            Recipients = recipients,
            Subject = "Test Email",
            Content = "<h1>Hello World</h1><p>This is a test email.</p>",
        };

        await _smtpMailKit.SendAsync(new MailFrom(_fromMail), mail);
    }
}
