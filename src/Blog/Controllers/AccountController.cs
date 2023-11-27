using Microsoft.AspNetCore.Mvc;

namespace Blog;
public class AccountController : BaseController
{
    private readonly IAccountRepository _accountRepo;
    private ILogger<AccountController> _log;

  public AccountController(IAccountRepository accountRepo, ILogger<AccountController> log)
  {
      _accountRepo = accountRepo;
      _log =  log;
    
  }

  [HttpPost ("register")]
  public async Task<IActionResult> Register(RegisterDto registerDto)
  {
    var result = await _accountRepo.Register(registerDto);

    if (result.IsSuccess)
    {
      return Ok(result);
    }

    _log.LogInformation("Registeration failed");
    return BadRequest(result);
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginDto loginDto)
  {
    var result = await _accountRepo.Login(loginDto);

    if (result.IsSuccess)
    {
      return Ok(result);
    }
    _log.LogInformation("Login failed");
    return BadRequest(result);
  }

  [HttpPost("logout")]
  public async Task<IActionResult> Logout()
  {
    var result = await _accountRepo.Logout();
    return Ok(result);
  }

  [HttpPost("confirmEmail")]
  public async Task<IActionResult> ConfirmEmail(ConfirmEmailDto confirmEmailDto)
  {
    var result = await _accountRepo.ConfirmEmail(confirmEmailDto);

    if (result.IsSuccess) return Ok(result);

    _log.LogInformation("Unsuccessful email verification");
    return BadRequest(result);
  }

  [HttpPost("forgotPassword")]
  public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
  {
    var result = await _accountRepo.ForgotPassword(forgotPasswordDto);

    if (result.IsSuccess) return Ok(result);

    _log.LogInformation("Unable to send a link for resetting password");
    return BadRequest(result);
  }

  [HttpPost("resetPassword")]
  public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
  {
    var result = await _accountRepo.ResetPassword(resetPasswordDto);

    if (result.IsSuccess) return Ok(result);

    _log.LogInformation("Unable to resetting password");
    return BadRequest(result);
  }

}
