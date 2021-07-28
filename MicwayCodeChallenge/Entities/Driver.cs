using System;
using System.ComponentModel.DataAnnotations;

namespace MicwayCodeChallenge.Entities
{
    public class Driver
    {
        [Required]
        public Guid Id { get; set; }

       
        [Required][StringLength(30)][MinLength(2)]
        public string FirstName { get; set; }

        [Required][StringLength(30)][MinLength(2)]
        public string LastName { get; set; }

        
        [Required]
        public DateTime Dob { get; set; }

        [Required][EmailAddress]
        public string Email { get; set; }

    }
}