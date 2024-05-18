
    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace projectF.Models
{
    public class forgetData
    {
        [Key]
        [Display(Name = "ID")]
        public int employeeID { get; set; }

        [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Email")]
    public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string password { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }


        [Required]
        [Display(Name = "isRead")]
        public bool IsEmailConfirmed { get; set; }
    }
}
