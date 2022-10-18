using System.ComponentModel.DataAnnotations;

namespace CoreBussiness.BussinessEntity.Users;

public class SignupModel
{
    [Required(ErrorMessage = "phone is required")]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "passowrd is required")]
    public string Password { get; set; }
    [Required(ErrorMessage = "national code is required")]
    public string  NationalCode  { get; set; }
    [Required(ErrorMessage = "name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "lastname is required")]
    public string LastName { get; set; }
    public bool IsRuleAccepted { get; set; }
   
    public string? Code { get; set; }
}