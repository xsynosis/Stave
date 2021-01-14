using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Stave.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}

        public string Firstname {get; set;}
        public string Lastname {get; set;}

        public string Username {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}

        public bool CanLogin {get; set;}
        public bool IsAdmin {get; set;}

        public List<Session> UserSessions {get; set;}
    }
}