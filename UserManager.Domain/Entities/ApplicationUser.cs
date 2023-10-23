using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using UserManager.Domain.Constant;

namespace UserManager.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        [ForeignKey("Nationality")]
        public string NationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }
    }
}
