using System.Text;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace Blog;
public class AccountRepository : IAccountRepository
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signinManager;
    private readonly BlogContext _context;
    private readonly ITokenService _tokenService;
    private IEmailService _emailService;
    private IConfiguration _config;

    public AccountRepository
    (UserManager<AppUser> userManager, SignInManager<AppUser> signinManager,
     BlogContext context, ITokenService tokenService, IEmailService emailService,
     IConfiguration config
     )
    {
        _userManager = userManager;
        _signinManager = signinManager;
        _emailService = emailService;
        _context = context;
        _tokenService = tokenService;
        _config = config;

    }

    public async Task<ResponseManager> Register([FromBody]  RegisterDto registerDto)
    {
        var userFromDB = await _userManager.FindByEmailAsync(registerDto.Email);
        if (userFromDB != null )
        {
            return new ResponseManager
            {
                Message = "a user with the same E-mail address found",
                IsSuccess = false
            };
        }

        if (registerDto.Password != registerDto.ConfirmPassword)
        {
            return new ResponseManager
            {
                Message = "Password and Confirm password mismatch",
                IsSuccess = false
            };
        }

        var newUser = new AppUser
        {
            Email = registerDto.Email,
            UserName = registerDto.UserName
        };

        var result = await _userManager.CreateAsync(newUser, registerDto.Password);
        var roleResult = await _userManager.AddToRoleAsync(newUser, "Member");
         
         if (!result.Succeeded)
        {
            return new ResponseManager
            {
                Message = "Problem registering user",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        // if succeeded, send them an email 
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
        var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

        var uriBuilder = new UriBuilder(_config["Origin:ConfirmEmailUrl"]);
        // sets the quering params (token and userid) on to this query
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);

        //var userEmail = newUser.Email.ToString();
        //var encodedUserEmail = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(userEmail));

        query["token"] = encodedToken;
        query["useremail"] = newUser.Email;
        uriBuilder.Query = query.ToString();

        var urlString = uriBuilder.ToString();
        var message = $"<p><strong>Welcome to our Blog</strong></p><p>Please click the below link to verify your email address:</p><p><a href='{urlString}'>Click to verify email</a></p>";

        await _emailService.SendEmailAsync(newUser.Email, "Please verify email", message);

        return new ResponseManager
        {
            Email = newUser.Email,
            Username = newUser.UserName,
            UserId = newUser.Id,
            Message = "Registeration success - please verify your email",
            IsSuccess = true
        };
       
    }


    public async Task<ResponseManager> Login([FromBody] LoginDto loginDto)
    {
        var userFromDB = await _userManager.FindByEmailAsync(loginDto.Email);

        if (userFromDB == null )
        {
            return new ResponseManager
            {
                Message = "No user found with this email",
                IsSuccess = false
            };
        }

        // For testing purpose 
        //if (userFromDB.Email == "zerkah@gmail.com") userFromDB.EmailConfirmed = true;

        if (!userFromDB.EmailConfirmed)
        {
            return new ResponseManager
            {
                Message = "Email not confirmed"
            };
        }

        var result = await _signinManager.CheckPasswordSignInAsync(userFromDB, loginDto.Password, false);
        if (!result.Succeeded)
        {
        return new ResponseManager
        {
            Message = "Invalid password",
            IsSuccess = false
        };

        }

        return new ResponseManager
        {
            Username = userFromDB.UserName,
            Email = userFromDB.Email,
            Token = await _tokenService.GenerateToken(userFromDB),
            Message = "Logged in successfully",
            IsSuccess = true
        };


    }

    public async Task<bool> Logout()
    {
        await _signinManager.SignOutAsync();
        return true;
    }
    public async Task<ResponseManager> ConfirmEmail([FromQuery] ConfirmEmailDto confirmEmailDto)
    {
        var userFromDB = await _userManager.FindByEmailAsync(confirmEmailDto.email);
        if (userFromDB is null)
        {
            return new ResponseManager
            {
                Message = "User not found",
                IsSuccess = false
            };
        }

        var decodedTokenBytes = WebEncoders.Base64UrlDecode(confirmEmailDto.token);
        var decodedToken = Encoding.UTF8.GetString(decodedTokenBytes);

        var result = await _userManager.ConfirmEmailAsync(userFromDB, decodedToken);

        if (!result.Succeeded)
        {
            return new ResponseManager
            { Message = "Could not verify email address", IsSuccess = false,
             Errors= result.Errors.Select (e => e.Description) };
        }

        return new ResponseManager
        { Message = "Email confirmed - you can now login", IsSuccess = true };

    }

    public async Task<ResponseManager> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
    {
        var userFromDB = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
        if (userFromDB is null)
        {
            return new ResponseManager { Message = "User not found", IsSuccess = false };
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(userFromDB);
        var tokenBytes = Encoding.UTF8.GetBytes(token);
        var encodedToken = WebEncoders.Base64UrlEncode(tokenBytes);

        // build uri
        var uriBuilder = new UriBuilder(_config["Origin:ResetPassword"]);
        // set queries params on to the uri
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);

        query["token"] = encodedToken;
        query["useremail"] = userFromDB.Email;

        uriBuilder.Query = query.ToString();
        var urlString = uriBuilder.ToString();
        var message = $"<p>Please click the below link to reset your password</p>:<p><a href='{urlString}'>Click to reset password</a></p";

        //send email 
        await _emailService.SendEmailAsync(userFromDB.Email, "Please reset your password", message);

        return new ResponseManager
        {
            Message = "Reset password link has been sent - Please check your email",
            IsSuccess = true
        };
    }

    public async Task<ResponseManager> ResetPassword(ResetPasswordDto resetPasswordDto)
    {
        var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
        if (user is null )
        {
            return new ResponseManager { Message = "Email has not been found", IsSuccess = false };
        }

        //decode the token which comes back to the server 
        var decodedTokenBytes = WebEncoders.Base64UrlDecode(resetPasswordDto.Token);
        var decodedToken = Encoding.UTF8.GetString(decodedTokenBytes);

        var result = await _userManager.ResetPasswordAsync(user, decodedToken, resetPasswordDto.Password);

        if (!result.Succeeded)
        {
            return new ResponseManager { Message = "Resetting password failed", IsSuccess = false };
        }

        return new ResponseManager { Message = "Password has been reset successfully", IsSuccess = true };
    }



    // Helper methods 
    // private async Task<User> UserExists (string email)
    // {
    //     return await _userManager.FindByEmailAsync(email);
    // }

    // if the code for sending email were written inside a controller, we would have been able to get the origin of the request from 
    // REQUEST HEADERs (var origin = Request.Headers ["origin"] )

   /*
   
    var origin = Request.Headers["origin"];
    var urlString = $"{origin}/account/verifyEmail?token=${token}&email=${user.email}";
    var message = $"<p>Please click the below link to verify your email address:</p><p><a href='{urlString}'></a></p";

    await _emailServie.SendEmailAsync(User.Email, "Please verify your email", message);
   
   */

}
