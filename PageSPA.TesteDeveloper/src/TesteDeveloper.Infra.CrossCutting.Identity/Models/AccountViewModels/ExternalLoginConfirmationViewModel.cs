using System.ComponentModel.DataAnnotations;

namespace TesteDeveloper.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
