using System.ComponentModel.DataAnnotations;

namespace HealthCareClient.Models.Contact
{
    public class Contact
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [StringLength(100), Required]
        [RegularExpression("^[a-zA-Z]{1,20}$")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(100), Required]
        [RegularExpression("^[a-zA-Z]{1,20}$")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [StringLength(100),Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "E-mail address is not valid")]
        public string Email { get; set; }

        [StringLength(20),Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone Number is not valid")]
      
          [Display(Name = "Contact Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Status")]
        public ContactStatus Status { get; set; }
    }
    public enum ContactStatus
    {
        Active,
        Inactive
    }
}