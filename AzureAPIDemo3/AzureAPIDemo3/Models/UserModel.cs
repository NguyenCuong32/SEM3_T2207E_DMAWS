﻿using System.ComponentModel.DataAnnotations;

namespace AzureAPIDemo3.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
