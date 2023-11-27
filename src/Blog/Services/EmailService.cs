
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Blog;
public class EmailService : IEmailService
{
    private readonly IConfiguration _config;
   public EmailService(IConfiguration config)
      {
      _config = config;
        
      }
    public async Task SendEmailAsync(string userEmail, string emailSubject, string msg)
    {
        var client = new SendGridClient(_config["SendGrid:SendGridKey"]);

    var message = new SendGridMessage
    {
      From = new EmailAddress("kahsayzeray@gmail.com", _config["SendGrid:User"]),
      Subject = emailSubject,
      PlainTextContent = msg,
      HtmlContent = msg

    };

    message.AddTo(new EmailAddress(userEmail));
    message.SetClickTracking(false, false);


    await client.SendEmailAsync(message);



    }
}
