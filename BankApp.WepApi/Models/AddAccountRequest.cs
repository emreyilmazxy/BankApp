using System.ComponentModel.DataAnnotations;

namespace BankApp.WepApi.Models
{
    public class AddAccountRequest
    {
        [Length(minimumLength:1,maximumLength:3)]
        [Required]
        public string Currency { get; set; }
    }
}
