using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TennesseeDiscs.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirebaseUserId { get; set; }

        [Required(ErrorMessage = "Hmmm... You should really add a Name...")]
        [MaxLength(35)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public Cart Cart { get; set; }


    }
}
