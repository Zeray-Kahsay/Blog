using Microsoft.AspNetCore.Identity;

namespace Blog;
public interface IAccountRepository
{
  Task<ResponseManager> Register(RegisterDto registerDto);
  Task<ResponseManager> Login(LoginDto loginDto);
  Task<ResponseManager> ConfirmEmail(ConfirmEmailDto confirmEmailDto);
  Task<bool> Logout();
  Task<ResponseManager> ForgotPassword(ForgotPasswordDto forgotPasswordDto);
  Task<ResponseManager> ResetPassword(ResetPasswordDto resetPasswordDto);
  

}
