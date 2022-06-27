using System;
using System.ComponentModel.DataAnnotations;
using System.Security;
using Microsoft.VisualBasic;

namespace Codecool.CodecoolShop.Models
{
    public class CreditCard
    {

        [Required(ErrorMessage = "Please enter valid card number")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Card number should consist of 16 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Card number must be numeric")]
        [DataType(DataType.CreditCard)]
        public string? CardNumber { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(49, MinimumLength = 2, ErrorMessage = "Please enter valid first name" )]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(49, MinimumLength = 2, ErrorMessage = "Please enter valid last name")]
        public string? LastName { get; set; }

        
        [Required(ErrorMessage = "Please enter your expire month")]
        [Range(1, 12, ErrorMessage = "Please enter valid month number")]
        public int? ExpireMonth { get; set; }

        [Required(ErrorMessage = "Please enter your expire year")]
        [Range(2022, 2027, ErrorMessage = "Please enter valid month year")]
        public int? ExpireYear { get; set; }

        [Required(ErrorMessage = "Please enter your CVV")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "CVV should consist of 3 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CVV must be numeric")]
        public String? CVV { get; set; }
    }
}
