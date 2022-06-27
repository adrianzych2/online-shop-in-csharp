using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models
{
    public class UserData
    {
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(@"\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{3})")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your country")]
        [StringLength(50, MinimumLength = 3)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(50, MinimumLength = 3)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [StringLength(50, MinimumLength = 3)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your zipcode")]
        [StringLength(8, MinimumLength = 3)]
        public string Zipcode { get; set; }


        

    }
}
