using System.ComponentModel.DataAnnotations;

namespace Blog;
public class RegisterDto
{
  [Required]
  [EmailAddress]
  [Display(Name = "Email")]
  public string  Email  { get; set; }

  [Required]
  [Display(Name = "UserName")]
  public string  UserName  { get; set; }

  [Required]
  [DataType(DataType.Password)]
  [Display(Name = "Password")]
  public string  Password  { get; set; }
  
  [Required]
  public string  ConfirmPassword { get; set; }

}
