﻿using System.ComponentModel.DataAnnotations;

namespace MisaAsp.Models.ViewModel
{
    public class UserRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
