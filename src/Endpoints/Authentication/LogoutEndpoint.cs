using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Stave.Models;

namespace Stave.Endpoints.Authentication
{
    public class LogoutEndpoint
    {
        public class LogoutEndpointRequest
        {
            public string Token {get; set;}
        }

        public class LogoutEndpointResponse
        {
            public string Message {get; set;}
            public bool Status {get; set;}
        }

        public static LogoutEndpointResponse LogoutEndpointAction(LogoutEndpointRequest req, StaveContext db)
        {
            var res = new LogoutEndpointResponse();

            var findSession = db.Sessions
            .Include(x => x.UserDetails)
            .SingleOrDefault(x => x.Token == req.Token && x.IsValid);

            if (findSession == null)
            {
                res.Status = false;
                res.Message = "Logout faild, valid session with specified token not found";
            }
            else
            {
                findSession.IsValid = false;
                db.SaveChanges();

                res.Status = true;
                res.Message = "Logout successful for user " + findSession.UserDetails.Username;
            }

            return res;
        }
    }
}