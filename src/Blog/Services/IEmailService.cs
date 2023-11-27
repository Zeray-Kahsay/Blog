namespace Blog;
public interface IEmailService
{
  Task SendEmailAsync(string userEmail, string emailSubject,  string message);
}
