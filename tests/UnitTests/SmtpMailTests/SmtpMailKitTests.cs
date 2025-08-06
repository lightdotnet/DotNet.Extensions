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

        var host = "smtp.ethereal.email";
        var userName = _fromMail;
        var password = "GHMdV12nF7zfFhqG7Z";

        _smtpMailKit = new SmtpMailKit(host, userName, password)
        {
            UseSsl = false,
        };
    }

    [Fact]
    public async Task Must_Send_Email_With_No_Exceptions()
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
