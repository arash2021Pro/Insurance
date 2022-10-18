using System.ComponentModel.DataAnnotations;

namespace CoreApplication.UserApplication;

public class LoginModel
{
    [Required(ErrorMessage = "phone is required")]
    public string Phonenumber { get; set; }
    [Required(ErrorMessage = "passowrd is required")]
    public string Password { get; set; }
}