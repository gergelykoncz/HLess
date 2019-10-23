using System.ComponentModel.DataAnnotations;

namespace HLess.Models.Requests
{
    /// <summary>
    /// DTO containing registration information.
    /// </summary>
    public class CreateAccountDto
    {
        /// <summary>
        /// The email of the newly signing up user.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// The password of the user.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// The name of the account.
        /// </summary>
        [Required]
        public string AccountName { get; set; }

        /// <summary>
        /// The first name of the user.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        [Required]
        public string LastName { get; set; }
    }
}
