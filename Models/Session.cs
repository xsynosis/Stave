using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stave.Models
{
    public class Session
    {
        [Key]
        public int SessionId {get; set;}

        public string Token {get; set;}
        public bool IsValid {get; set;}

        public int UserId {get; set;}
        public User UserDetails {get; set;}
    }
}