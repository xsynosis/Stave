using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Stave.Models;

namespace Stave.Endpoints.Authentication
{
    public class LoginEndpoint
    {
        public class LoginEndpointRequest
        {
            public string Username {get; set;}
            public string Password {get; set;}
        }

        public class LoginEndpointResponse
        {
            public string Token {get; set;}

            public string Message {get; set;}
            public bool Status {get; set;}
        }

        public static LoginEndpointResponse LoginEndpointAction(LoginEndpointRequest req, StaveContext db)
        {
            var res = new LoginEndpointResponse();

            var findUser = db.Users
            .Include(x => x.UserSessions)
            .SingleOrDefault(x => x.Username == req.Username && x.Password == req.Password && x.CanLogin);

            if (findUser == null)
            {
                res.Status = false;
                res.Message = "Login failed";
            }
            else
            {
                res.Token = Guid.NewGuid().ToString().Replace("-", "");

                findUser.UserSessions.Add(new Session(){
                    Token = res.Token,
                    IsValid = true
                });

                db.SaveChanges();

                res.Status = true;
                res.Message = "Login success for user " + findUser.Username;
            }

            return res;
        }
    }
}