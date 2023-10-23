using System.ComponentModel.DataAnnotations;
using UserManager.Domain.Constant;
using UserManager.Domain.RegexValidation;

namespace UserManager.Domain.Dto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "First Name is required")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [MobileNumberAttribute(ErrorMessage = "Invalid mobile number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Birth Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [Range(1, 2)]
        public Gender Gender { get; set; }



        [Required(ErrorMessage = "Account Type is required")]
        [Range(1,2)]
        public AccountType AccountType { get; set; }
        [Required(ErrorMessage = "Nationality is required")]
        public string NationalityId { get; set; }
    }


    public class EditUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public AccountType AccountType { get; set; }
        public string NationalityId { get; set; }
    }


    public class UserList
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
    }
}
