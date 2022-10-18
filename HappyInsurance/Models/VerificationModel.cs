using System.ComponentModel.DataAnnotations;

namespace HappyInsurance.Models;

public class VerificationModel
{
   [Required(ErrorMessage = "Code is required")]
   public string Code { get; set; }
}